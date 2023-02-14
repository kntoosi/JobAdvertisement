using CrouseServiceAdvertisement.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrouseServiceAdvertisement.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using CrouseServiceAdvertisement.DTO;
using CrouseServiceAdvertisement.Extensions;
using CrouseServiceAdvertisement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrouseServiceAdvertisement.Services
{
    public class AdvertisementService : IAdvertisementService
    {

        private ILogger<AdvertisementService> Logger { get; }
        private IInitializeService _initializeService { get; set; }
        private CrouseDbContext DbContext { get; set; }

        public AdvertisementService(ILogger<AdvertisementService> logger, CrouseDbContext dbContext, IInitializeService initializeService)
        {
            Logger = logger;
            DbContext = dbContext;
            _initializeService = initializeService;
        }

        #region ReportAds
        //public async Task<List<AdsOutputEntity>> GetAds(AdsSearchEntity input)
        public List<AdsOutputEntity> GetAds(AdsSearchEntity input,int role, int PrsNo)
        {

            //AdsSearchEntity adsSearchEntity = new AdsSearchEntity()
            //{
            //    Fromdate = input.Fromdate,
            //    Todate = input.Todate
            //};

            List<Ads> list = new List<Ads>();
            //Active Ads
            //if (role == 0)//Admin
            //{
            //     list = DbContext.AdsMaster.Where(AdsMaster => AdsMaster.Active == true &&
            //                                     (AdsMaster.DocDate >= input.Fromdate || input.Fromdate == -1) &&
            //                                     (AdsMaster.DocDate <= input.Todate || input.Todate == -1) &&
            //                                     (AdsMaster.WrkCategory_Id == input.WorkCategoryId || input.WorkCategoryId == -1) &&
            //                                     (AdsMaster.Id == input.id || input.id == -1) &&
            //                                     (AdsMaster.AdsStateLST_Id == 501 || AdsMaster.AdsStateLST_Id == 502 ||(AdsMaster.AdsStateLST_Id == 500 && AdsMaster.PbPersonnel_Id == PrsNo))
            //                                     ).ToList();
            //}
            //else if  (role == 1)//Applicant
            //{
            //     list = DbContext.AdsMaster.Where(AdsMaster => AdsMaster.Active == true &&
            //                                     (AdsMaster.DocDate >= input.Fromdate || input.Fromdate == -1) &&
            //                                     (AdsMaster.DocDate <= input.Todate || input.Todate == -1) &&
            //                                     (AdsMaster.WrkCategory_Id == input.WorkCategoryId || input.WorkCategoryId == -1) &&
            //                                     (AdsMaster.Id == input.id || input.id == -1) &&
            //                                     (AdsMaster.AdsStateLST_Id != 503  && AdsMaster.PbPersonnel_Id == PrsNo)
            //                                     ).ToList();
            //}
            list = DbContext.AdsMaster.Where(AdsMaster => AdsMaster.Active == true &&
                                            (AdsMaster.DocDate >= input.Fromdate || input.Fromdate == -1) &&
                                            (AdsMaster.DocDate <= input.Todate || input.Todate == -1) &&
                                            (AdsMaster.WrkCategory_Id == input.WorkCategoryId || input.WorkCategoryId == -1) &&
                                            (AdsMaster.Id == input.id || input.id == -1) 
                                            ).ToList();
            //var list = DbContext.AdsMaster.ToList();

            //Creator Ids
            List<int> creatorIdLst = list.Select(Ads => Ads.PbPersonnel_Id).ToList();

            //Confirmer Ids
            List<int> confirmerIdLst = list.Where(Ads => Ads.PbPersonnel_Id2 != null).Select(Ads => Ads.PbPersonnel_Id2.Value).ToList();

            ApiManager apimaneger = new ApiManager("https://gateway.crouseco.com/Pb/");


            //List of Creator information (PbPeronnel)
            DtPersonnelSearch dtPersonnelSearch = new DtPersonnelSearch()
            {
                PrsCodes = creatorIdLst,
                Active = 1
            };
            List<PbPersonnel> pbCreators = apimaneger.Call<DtPersonnelSearch, List<PbPersonnel>>("Pb/SearchPbPersonnels", dtPersonnelSearch).Result;

            //List of Confirmer information (PbPeronnel)
            DtPersonnelSearch dtPersonnelSearch2 = new DtPersonnelSearch();
            List<PbPersonnel> pbConfirmers = new List<PbPersonnel>();
            if (confirmerIdLst.Count > 0)
            {
                dtPersonnelSearch2.PrsCodes = confirmerIdLst;
                dtPersonnelSearch2.Active = 1;
                pbConfirmers = apimaneger.Call<DtPersonnelSearch, List<PbPersonnel>>("Pb/SearchPbPersonnels", dtPersonnelSearch2).Result;

            }
         
            ApiManager apimaneger2 = new ApiManager("https://gateway.crouseco.com/Cv/");
            //CvCOPType
            var CVCopLST = apimaneger2.CallGetAsync<List<CvCOPTypeLST>>("CvBase/GetCvCOPTypeLST", "2").Result;

            //WrkShift
            var CvWrkShiftLST = apimaneger2.CallGetAsync<List<CvWrkShiftLST>>("CvBase/GetCvWrkShiftLST","2").Result;

            //WrkCategory
            var WrkCategory = _initializeService.WrkCategoryList(2).Result;

            //WrkHistory
            var WrkHistory = _initializeService.WrkHistoryList(2).Result;

            //WrkPlace
            var WrkPlace = _initializeService.WrkPlaceList(2).Result;

            //Gender
            var Gender = _initializeService.GenderList(2).Result;

            //Salary
            var Salary = _initializeService.SalaryList(2).Result;

            //State
            var State = _initializeService.StateList(2).Result;

            //JobPosition
            var JobPosition = _initializeService.JobPositionList(2).Result;
            List<AdsOutputEntity> Query = new List<AdsOutputEntity>();
            try
            {
             Query = (from AdsMaster in list  /// گزارش اصلی 


                                               join prs in pbCreators   // مشخصات پرسنلی 
                                               on AdsMaster.PbPersonnel_Id equals prs.PersonnelCode

                                               join wcat in WrkCategory //DbContext.AdsWrkCategoryLST   // دسته بندی شغلی  
                                               on AdsMaster.WrkCategory_Id equals wcat.Id

                                               join whist in WrkHistory//DbContext.AdsWrkHistoryLST   // سابقه کاری 
                                               on AdsMaster.WrkHistory_Id equals whist.Id


                                               join cop in CVCopLST         //نوع همکاری
                                               on AdsMaster.CopTyp_Id equals cop.Id

                                               join shft in CvWrkShiftLST         //شیفت کاری
                                               on AdsMaster.WrkShift_Id equals shft.Id

                                               join plc in WrkPlace//DbContext.AdsWrkPlaceLST        //محل کار
                                               on AdsMaster.WrkPlace_Id equals plc.Id into tempw
                                               from tempwp in tempw.DefaultIfEmpty()

                                               join gnd in Gender//DbContext.AdsGenderLST          //جنسیت 
                                               on AdsMaster.Gender_Id equals gnd.Id

                                               join sal in Salary// DbContext.AdsSalaryLST          //حقوق 
                                               on AdsMaster.Salary_Id equals sal.Id

                                                join state in State//DbContext.AdsStateLST         // وضعیت آگهی 
                                                on AdsMaster.AdsStateLST_Id equals state.Id

                                                join jobPos in JobPosition//DbContext.AdsJobPositionLST         // موقعیت شغلی 
                                                on AdsMaster.AdsJobPositionLST_Id equals jobPos.Id

                                               join prs2 in pbConfirmers           // مشخصات پرسنلی تایید کننده 
                                               on AdsMaster.PbPersonnel_Id2 equals (int?)prs2.PersonnelCode into tempp
                                               from temp1 in tempp.DefaultIfEmpty()

       
                                               //where AdsMaster.ConfirmDate >= input.Fromdate && AdsMaster.ConfirmDate <= input.Todate

                                               select new AdsOutputEntity
                                               {

                                                   Id = AdsMaster.Id,
                                                   WrkCategory_Id = AdsMaster.WrkCategory_Id,
                                                   WrkCategory_Title = wcat.CategoryTitle,
                                                   PbPersonnel_Id = AdsMaster.PbPersonnel_Id,
                                                   PbPersonnel_FirstName = prs.FirstName,
                                                   PbPersonnel_LastName = prs.LastName,
                                                   JobTitle = AdsMaster.JobTitle,
                                                   WrkHistory_Id = AdsMaster.WrkHistory_Id,
                                                   WrkHistory_Title = whist.WrkHistoryTitle,
                                                   CopTyp_Id = AdsMaster.CopTyp_Id,
                                                   CopTyp_Title = cop.CoTitle,
                                                   WrkShift_Id = AdsMaster.WrkShift_Id,
                                                   WrkShift_Title = shft.ShiftTitle,
                                                   WrkPlace_Id = AdsMaster.WrkPlace_Id,
                                                   WrkPlace_Title = tempwp?.PlaceTitle,
                                                   Gender_Id = AdsMaster.Gender_Id,
                                                   Gender_Title = gnd.genderTitle,
                                                   Salary_Id = AdsMaster.Salary_Id,
                                                   Salary_Title = sal.SalaryTitle,
                                                   DutyStatus = AdsMaster.DutyStatus,
                                                   AgeFrom = AdsMaster.AgeFrom,
                                                   AgeTo = AdsMaster.AgeTo,
                                                   Description = AdsMaster.Description,
                                                   PhysicalDisability = AdsMaster.PhysicalDisability,
                                                   ExpirationDateSh = AdsMaster.ExpirationDateSh,
                                                   ExpirationTimeM = AdsMaster.ExpirationTimeM,
                                                   DocDate = AdsMaster.DocDate,
                                                   DocTime = AdsMaster.DocTime,
                                                   LogDateTime = AdsMaster.LogDateTime,
                                                   PbPersonnel_Id2 = AdsMaster.PbPersonnel_Id2,
                                                   PbPersonnel_FirstName2 = temp1?.FirstName,
                                                   PbPersonnel_LastName2 = temp1?.LastName,
                                                   ConfirmDate = AdsMaster.ConfirmDate,
                                                   ConfirmTime = AdsMaster.DocTime,
                                                   ConfirmDesc = AdsMaster.ConfirmDesc,
                                                   AdsStateLST_Id = AdsMaster.AdsStateLST_Id,
                                                   AdsStateLST_Title = state.AdsStateTitle,
                                                   AdsJobPositionLST_Id = AdsMaster.AdsJobPositionLST_Id,
                                                   AdsJobPositionLST_Title = jobPos.PositionTitle,
                                                   Active = AdsMaster.Active
                                               }).ToList();
            }
            catch (Exception ex)
            {  
                
                Query = new List<AdsOutputEntity>();
            }
            Logger.LogTrace("Ads has been taken.");
            return Query;


        }


        #endregion ReportAds

        #region ReportAdsDetail

        public AdsMasterDetailsOutputEntity GetAdsDetails(int AdsID, int role, int PrsNo)
        {

            AdsMasterDetailsOutputEntity entity = new AdsMasterDetailsOutputEntity();

            //AdsMaster
            AdsSearchEntity adsSearchEntity = new AdsSearchEntity();
            adsSearchEntity.id = AdsID;
            adsSearchEntity.Fromdate = -1;
            adsSearchEntity.Todate = -1;
            adsSearchEntity.WorkCategoryId = -1;
            adsSearchEntity.JobTitle = "";
            var check = GetAds(adsSearchEntity, role, PrsNo);
            if (check.Count == 0)
                return null; // AdsMasterID has not been found. Hence, the empty entity will be sent and 404 error is expected.
            AdsOutputEntity adsOutputEntity = check[0];//This list has just one entity    
            entity.AdsOutputEntity = adsOutputEntity;

            //AdsEducationOutput
            entity.listAdsEducationOutput = getAdsEducationOutput(AdsID);


            //ForeignLangOutput
            entity.listForeignLangOutput = getForeignLangOutput(AdsID);


            //AdsSkillsOutput
            entity.listAdsSkillsOutput = getAdsSkillsOutput(AdsID);

            //AdsWrkBenefitOutput
            entity.listAdsWrkBenefitOutput = getAdsWrkBenefitOutput(AdsID);

            return entity;


        }

        public AdsMasterDetailsOutputEntity GetAdsDetailsWithoutAuth(int AdsID)
        {

            AdsMasterDetailsOutputEntity entity = new AdsMasterDetailsOutputEntity() ;
            Ads ads = DbContext.AdsMaster.Find(AdsID);
            List<Ads> list1 = new List<Ads>();
            list1.Add(ads);
            //Creator Id
            int creatorId = ads.PbPersonnel_Id;

            //Confirmer Id
            int confirmerId = (int)ads.PbPersonnel_Id2;

            ApiManager apimaneger = new ApiManager("https://gateway.crouseco.com/Pb/");


            //List of Creator information (PbPeronnel)
            List<int> c = new List<int>();
            c.Add(creatorId);
            DtPersonnelSearch dtPersonnelSearch = new DtPersonnelSearch()
            {
                PrsCodes = c,
                Active = 1
            };
            List<PbPersonnel> pbCreators = apimaneger.Call<DtPersonnelSearch, List<PbPersonnel>>("Pb/SearchPbPersonnels", dtPersonnelSearch).Result;

            //List of Confirmer information (PbPeronnel)
            DtPersonnelSearch dtPersonnelSearch2 = new DtPersonnelSearch();
            List<PbPersonnel> pbConfirmers = new List<PbPersonnel>();
            List<int> d = new List<int>();
            d.Add(confirmerId);
            if (d.Count > 0)
            {
                dtPersonnelSearch2.PrsCodes = d;
                dtPersonnelSearch2.Active = 1;
                pbConfirmers = apimaneger.Call<DtPersonnelSearch, List<PbPersonnel>>("Pb/SearchPbPersonnels", dtPersonnelSearch2).Result;

            }

            ApiManager apimaneger2 = new ApiManager("https://gateway.crouseco.com/Cv/");
            //CvCOPType
            var CVCopLST = apimaneger2.CallGetAsync<List<CvCOPTypeLST>>("CvBase/GetCvCOPTypeLST", "2").Result;

            //WrkShift
            var CvWrkShiftLST = apimaneger2.CallGetAsync<List<CvWrkShiftLST>>("CvBase/GetCvWrkShiftLST", "2").Result;

            //WrkCategory
            var WrkCategory = _initializeService.WrkCategoryList(2).Result;

            //WrkHistory
            var WrkHistory = _initializeService.WrkHistoryList(2).Result;

            //WrkPlace
            var WrkPlace = _initializeService.WrkPlaceList(2).Result;

            //Gender
            var Gender = _initializeService.GenderList(2).Result;

            //Salary
            var Salary = _initializeService.SalaryList(2).Result;

            //State
            var State = _initializeService.StateList(2).Result;

            //JobPosition
            var JobPosition = _initializeService.JobPositionList(2).Result;
            List<AdsOutputEntity> Query = new List<AdsOutputEntity>();
            try
            {
                Query = (from AdsMaster in list1  /// گزارش اصلی 


                         join prs in pbCreators   // مشخصات پرسنلی 
                         on AdsMaster.PbPersonnel_Id equals prs.PersonnelCode

                         join wcat in WrkCategory //DbContext.AdsWrkCategoryLST   // دسته بندی شغلی  
                         on AdsMaster.WrkCategory_Id equals wcat.Id

                         join whist in WrkHistory//DbContext.AdsWrkHistoryLST   // سابقه کاری 
                         on AdsMaster.WrkHistory_Id equals whist.Id


                         join cop in CVCopLST         //نوع همکاری
                         on AdsMaster.CopTyp_Id equals cop.Id

                         join shft in CvWrkShiftLST         //شیفت کاری
                         on AdsMaster.WrkShift_Id equals shft.Id

                         join plc in WrkPlace//DbContext.AdsWrkPlaceLST        //محل کار
                         on AdsMaster.WrkPlace_Id equals plc.Id into tempw
                         from tempwp in tempw.DefaultIfEmpty()

                         join gnd in Gender//DbContext.AdsGenderLST          //جنسیت 
                         on AdsMaster.Gender_Id equals gnd.Id

                         join sal in Salary// DbContext.AdsSalaryLST          //حقوق 
                         on AdsMaster.Salary_Id equals sal.Id

                         join state in State//DbContext.AdsStateLST         // وضعیت آگهی 
                         on AdsMaster.AdsStateLST_Id equals state.Id

                         join jobPos in JobPosition//DbContext.AdsJobPositionLST         // موقعیت شغلی 
                         on AdsMaster.AdsJobPositionLST_Id equals jobPos.Id

                         join prs2 in pbConfirmers           // مشخصات پرسنلی تایید کننده 
                         on AdsMaster.PbPersonnel_Id2 equals (int?)prs2.PersonnelCode into tempp
                         from temp1 in tempp.DefaultIfEmpty()


                             //where AdsMaster.ConfirmDate >= input.Fromdate && AdsMaster.ConfirmDate <= input.Todate

                         select new AdsOutputEntity
                         {

                             Id = AdsMaster.Id,
                             WrkCategory_Id = AdsMaster.WrkCategory_Id,
                             WrkCategory_Title = wcat.CategoryTitle,
                             PbPersonnel_Id = AdsMaster.PbPersonnel_Id,
                             PbPersonnel_FirstName = prs.FirstName,
                             PbPersonnel_LastName = prs.LastName,
                             JobTitle = AdsMaster.JobTitle,
                             WrkHistory_Id = AdsMaster.WrkHistory_Id,
                             WrkHistory_Title = whist.WrkHistoryTitle,
                             CopTyp_Id = AdsMaster.CopTyp_Id,
                             CopTyp_Title = cop.CoTitle,
                             WrkShift_Id = AdsMaster.WrkShift_Id,
                             WrkShift_Title = shft.ShiftTitle,
                             WrkPlace_Id = AdsMaster.WrkPlace_Id,
                             WrkPlace_Title = tempwp?.PlaceTitle,
                             Gender_Id = AdsMaster.Gender_Id,
                             Gender_Title = gnd.genderTitle,
                             Salary_Id = AdsMaster.Salary_Id,
                             Salary_Title = sal.SalaryTitle,
                             DutyStatus = AdsMaster.DutyStatus,
                             AgeFrom = AdsMaster.AgeFrom,
                             AgeTo = AdsMaster.AgeTo,
                             Description = AdsMaster.Description,
                             PhysicalDisability = AdsMaster.PhysicalDisability,
                             ExpirationDateSh = AdsMaster.ExpirationDateSh,
                             ExpirationTimeM = AdsMaster.ExpirationTimeM,
                             DocDate = AdsMaster.DocDate,
                             DocTime = AdsMaster.DocTime,
                             LogDateTime = AdsMaster.LogDateTime,
                             PbPersonnel_Id2 = AdsMaster.PbPersonnel_Id2,
                             PbPersonnel_FirstName2 = temp1?.FirstName,
                             PbPersonnel_LastName2 = temp1?.LastName,
                             ConfirmDate = AdsMaster.ConfirmDate,
                             ConfirmTime = AdsMaster.DocTime,
                             ConfirmDesc = AdsMaster.ConfirmDesc,
                             AdsStateLST_Id = AdsMaster.AdsStateLST_Id,
                             AdsStateLST_Title = state.AdsStateTitle,
                             AdsJobPositionLST_Id = AdsMaster.AdsJobPositionLST_Id,
                             AdsJobPositionLST_Title = jobPos.PositionTitle,
                             Active = AdsMaster.Active
                         }).ToList();
            }
            catch (Exception ex)
            {

                Query = new List<AdsOutputEntity>();
            }
            if (Query.Count ==0 )
                return null; // AdsMasterID has not been found. Hence, the empty entity will be sent and 404 error is expected.
            AdsOutputEntity adsOutputEntity = Query[0];//This list has just one entity    
            entity.AdsOutputEntity = adsOutputEntity;

            //AdsEducationOutput
            entity.listAdsEducationOutput = getAdsEducationOutput(AdsID);


            //ForeignLangOutput
            entity.listForeignLangOutput = getForeignLangOutput(AdsID);


            //AdsSkillsOutput
            entity.listAdsSkillsOutput = getAdsSkillsOutput(AdsID);

            //AdsWrkBenefitOutput
            entity.listAdsWrkBenefitOutput = getAdsWrkBenefitOutput(AdsID);

            return entity;


        }

   

        private  List<AdsEducationOutputEntity> getAdsEducationOutput(int adsID)
        {
           
            ApiManager apimaneger = new ApiManager("https://gateway.crouseco.com/Cv/");

            //CvEduGradeLST
            //var CvEduGradeLST = apimaneger.CallGetAsync<List<CvEduGradeLST>>("CvBase/CvEduGradeLST").Result;
            List<CvEduGradeLST> CvEduGradeLST = new List<CvEduGradeLST>();
 
      
                CvEduGradeLST = apimaneger.CallGetAsync< List<CvEduGradeLST>>("CvBase/GetCvEduGradeLST", "2").Result;
        
            //CvStudyFieldLST
            List<CvStudyFieldLST> CvStudyFieldLST = new List<CvStudyFieldLST>();
            CvStudyFieldLST = apimaneger.CallGetAsync<List<CvStudyFieldLST>>("CvBase/GetCvStudyFieldLST", "2").Result;
      

            var list = DbContext.AdsEducation.Where(AdsEdu => AdsEdu.AdsMaster_Id == adsID ).ToList();

            List<AdsEducationOutputEntity> adsEducationOutputEntities = 
                                          (from AdsEdu in list  
                                           join ed in CvEduGradeLST   
                                           on AdsEdu.CVEduGradeLST_Id equals ed.Id

                                           join sf in CvStudyFieldLST  
                                           on AdsEdu.CvStudyFieldLST_Id equals sf.Id

                                           select new AdsEducationOutputEntity
                                           {

                                               Id = AdsEdu.Id,
                                               AdsMaster_Id = AdsEdu.AdsMaster_Id,
                                               CVEduGradeLST_Id = AdsEdu.CVEduGradeLST_Id,
                                               GradeTitle = ed.GradeTitle,
                                               CvStudyFieldLST_Id = AdsEdu.CvStudyFieldLST_Id,
                                               FieldTitle = sf.FieldTitle
                                           }).ToList();

            Logger.LogTrace("adsEducationOutputEntities has been taken.");
            return adsEducationOutputEntities;

        }
        private List<AdsForeignLangOutputEntity> getForeignLangOutput(int adsID)
        {
            ApiManager apimaneger = new ApiManager("https://gateway.crouseco.com/Cv/");

            //CvForeignLangLST
            var CvForeignLangLST = apimaneger.CallGetAsync< List<CvForeignLangLST>>("CvBase/GetCvForeignLangLST", "2").Result;

            //CvRatingLevelLST
            var CvRatingLevelLST = apimaneger.CallGetAsync< List<CvRatingLevelLST>>("CvBase/GetCvRatingLevelLST", "2").Result;

            var list = DbContext.AdsForeignLang.Where(AdsFo => AdsFo.AdsMaster_Id == adsID).ToList();

            List<AdsForeignLangOutputEntity> adsForeignLangOutputEntities =
                                          (from AdsFo in list
                                           join fl in CvForeignLangLST
                                           on AdsFo.CvForeignLangLST_Id equals fl.Id

                                           join rl in CvRatingLevelLST
                                           on AdsFo.CvRatingLevelLST_Id equals rl.Id

                                           select new AdsForeignLangOutputEntity
                                           {

                                               Id = AdsFo.Id,
                                               AdsMaster_Id = AdsFo.AdsMaster_Id,
                                               CvForeignLangLST_Id = AdsFo.CvForeignLangLST_Id,
                                               LangTitle = fl.LangTitle,
                                               CvRatingLevelLST_Id = AdsFo.CvRatingLevelLST_Id,
                                                LevelTitle = rl.LevelTitle
                                           }).ToList();

            Logger.LogTrace("adsForeignLangOutputEntities has been taken.");
            return adsForeignLangOutputEntities;
        }
        private List<AdsSkillsOutputEntity> getAdsSkillsOutput(int adsID)
        {
            ApiManager apimaneger = new ApiManager("https://gateway.crouseco.com/Cv/");

            //CvRatingLevelLST
            var CvRatingLevelLST = apimaneger.CallGetAsync< List<CvRatingLevelLST>>("CvBase/GetCvRatingLevelLST", "2").Result;

            var list = DbContext.AdsSkills.Where(AdsS => AdsS.AdsMaster_Id == adsID).ToList();

            List<AdsSkillsOutputEntity> adsSkillsOutputEntities =
                                          (from AdsS in list
                                           
                                           join rl in CvRatingLevelLST
                                           on AdsS.CvRatingLevelLST_Id equals rl.Id

                                           select new AdsSkillsOutputEntity
                                           {

                                               Id = AdsS.Id,
                                               AdsMaster_Id = AdsS.AdsMaster_Id,
                                               SkillTitle = AdsS.SkillTitle,
                                               CvRatingLevelLST_Id = AdsS.CvRatingLevelLST_Id,
                                               LevelTitle = rl.LevelTitle
                                           }).ToList();

            Logger.LogTrace("adsSkillsOutputEntities has been taken.");
            return adsSkillsOutputEntities;
        }
        private List<AdsWrkBenefitOutputEntity> getAdsWrkBenefitOutput(int adsID)
        {
            
            var wrkBenefit = _initializeService.WrkBenefitList(2).Result;

            var list = DbContext.AdsWrkBenefit.Where(AdsW => AdsW.AdsMaster_Id == adsID).ToList();

            List<AdsWrkBenefitOutputEntity> adsWrkBenefitOutputEntities =
                                          (from AdsW in list

                                           join w in wrkBenefit
                                           on AdsW.AdsWrkBenefit_Id equals w.Id

                                           select new AdsWrkBenefitOutputEntity
                                           {

                                               Id = AdsW.Id,
                                               AdsMaster_Id = AdsW.AdsMaster_Id,
                                               AdsWrkBenefit_Id = AdsW.AdsWrkBenefit_Id,
                                               BenefitTitle = w.BenefitTitle
                                        
                                           }).ToList();

            Logger.LogTrace("adsWrkBenefitOutputEntities has been taken.");
            return adsWrkBenefitOutputEntities;
        }
        #endregion ReportAdsDetail

        #region Insert
        public int AddAds(AdsMasterDetailsInputEntity adsMasterDetails, int prsNo)
        {
            // status 502 and 503 is associated to confirmer who cannot insert new row.
            // Hence, if statuses are these value, it must not be inserted.
            if( adsMasterDetails.adsInput.AdsStateLST_Id == 502 || adsMasterDetails.adsInput.AdsStateLST_Id == 503)
            {
                Logger.LogError("Status for the new record is not correct.It is not inserted.");
                return -1;
            }
            Ads newADs = new Ads();
            try
            {  
                newADs = getNewAds(adsMasterDetails.adsInput,prsNo);
                DbContext.AdsMaster.Add(newADs);
                DbContext.SaveChanges();//For Setting ID
                
                foreach (var adEd in adsMasterDetails.listAdsEducationInput)
                {
                    addAdsEducation(adEd, newADs.Id);
                }
                foreach (var fl in adsMasterDetails.listForeignLangInput)
                {
                    addAdsForeignLang(fl, newADs.Id);

                }
                foreach (var adSk in adsMasterDetails.listAdsSkillsInput)
                {
                    addAdsSkills(adSk, newADs.Id);
                }
                foreach (var adW in adsMasterDetails.listAdsWrkBenefitInput)
                {
                    addAdsWrkBenefit(adW, newADs.Id);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("An exception occurred in AddAds when calling WebApi.", ex);
                Logger.LogError("An exception occurred in AddAds when calling WebApi.", ex);
                return -1;
            }
            return newADs.Id;
        }

        private void addAdsWrkBenefit(AdsWrkBenefitInputEntity adW, int id)
        {
            AdsWrkBenefit Entity = new AdsWrkBenefit()
            {
                AdsMaster_Id = id,
                Id = 0,
                AdsWrkBenefit_Id = adW.AdsWrkBenefit_Id
            };
            DbContext.AdsWrkBenefit.Add(Entity);
            DbContext.SaveChanges();
        }

        private void addAdsSkills(AdsSkillsInputEntity adSk, int id)
        {

            AdsSkills Entity = new AdsSkills()
            {
                AdsMaster_Id = id,
                Id = 0,
                SkillTitle = adSk.SkillTitle,
                CvRatingLevelLST_Id = adSk.CvRatingLevelLST_Id
            };
            DbContext.AdsSkills.Add(Entity);
            DbContext.SaveChanges();
        }

        private void addAdsForeignLang(AdsForeignLangInputEntity fl, int id)
        {
            AdsForeignLang Entity = new AdsForeignLang()
            {
                AdsMaster_Id = id,
                Id = 0,
                CvForeignLangLST_Id = fl.CvForeignLangLST_Id,
                CvRatingLevelLST_Id = fl.CvRatingLevelLST_Id
            };
            DbContext.AdsForeignLang.Add(Entity);
            DbContext.SaveChanges();
        }

        private void addAdsEducation(AdsEducationInputEntity adEd, int id)
        {
            AdsEducation Entity = new AdsEducation()
            {
                AdsMaster_Id = id,
                Id = 0,
                CVEduGradeLST_Id = adEd.CVEduGradeLST_Id,
                CvStudyFieldLST_Id = adEd.CvStudyFieldLST_Id
            };

            DbContext.AdsEducation.Add(Entity);
            DbContext.SaveChanges();
        }

        private Ads getNewAds(AdsInputEntity adsInput, int prsNo)
        {
            DateTime now = DateTime.Now;
            Ads newADs = new Ads();
            newADs.WrkCategory_Id = adsInput.WrkCategory_Id;
            
            newADs.PbPersonnel_Id = prsNo;
            newADs.JobTitle = adsInput.JobTitle;
            newADs.WrkHistory_Id = adsInput.WrkHistory_Id;
            newADs.CopTyp_Id = adsInput.CopTyp_Id;
            newADs.WrkShift_Id = adsInput.WrkShift_Id;
            newADs.WrkPlace_Id = adsInput.WrkPlace_Id;
            newADs.Gender_Id = adsInput.Gender_Id;
            newADs.Salary_Id = adsInput.Salary_Id;
            newADs.DutyStatus = adsInput.DutyStatus;
            newADs.AgeFrom = adsInput.AgeFrom;
            newADs.AgeTo = adsInput.AgeTo;
            newADs.Description = adsInput.Description;
            newADs.PhysicalDisability = adsInput.PhysicalDisability;
            newADs.ExpirationDateSh = adsInput.ExpirationDateSh;
            
           newADs.ExpirationTimeM = adsInput.ExpirationTimeM;
            
            newADs.DocDate = getShamsiDate(now);
            newADs.DocTime = now.TimeOfDay.Hours.ToString()+":"+ now.TimeOfDay.Minutes.ToString() + ":"+ now.TimeOfDay.Seconds.ToString();
            newADs.LogDateTime = now;
            newADs.PbPersonnel_Id2 = null;
            newADs.ConfirmDate = null;
            newADs.ConfirmTime = null;
            newADs.ConfirmDesc = null;
            newADs.AdsStateLST_Id = adsInput.AdsStateLST_Id;
            newADs.Active = adsInput.Active;
            newADs.AdsJobPositionLST_Id = adsInput.AdsJobPositionLST_Id;
            return newADs;
        }

        private int getShamsiDate(DateTime now)
        {
            #region date

            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

            //string strDateShamsi = pc.GetYear(dtNow).ToString() + "/" + pc.GetMonth(dtNow).ToString().PadLeft(2, '0') + "/"
            //    + pc.GetDayOfMonth(dtNow).ToString().PadLeft(2, '0') + "   " + dtNow.Hour.ToString().PadLeft(2, '0') + ":"
            //    + dtNow.Minute.ToString().PadLeft(2, '0') + ":" + dtNow.Second.ToString().PadLeft(2, '0');
            ////1395/07/18
            //strDateShamsi1 = pc.GetYear(dtNow).ToString() + "/" + pc.GetMonth(dtNow).ToString().PadLeft(2, '0') + "/"
            //     + pc.GetDayOfMonth(dtNow).ToString().PadLeft(2, '0');
         
            int Shamsi = pc.GetYear(now) * 10000 + pc.GetMonth(now) * 100 + pc.GetDayOfMonth(now);
         
            #endregion date
            return Shamsi;
        }
        #endregion Insert
        #region Edit
        public int EditAds(AdsMasterDetailsEditEntity adsMasterDetailsEditEntity, int prsNo)
        {
            if (adsMasterDetailsEditEntity.adsMasterDetailsInputEntity.adsInput.ConfirmDesc != null && adsMasterDetailsEditEntity.adsMasterDetailsInputEntity.adsInput.ConfirmDesc != "")
            {
                //try
                //{
                //    Ads ads1 = DbContext.AdsMaster.Where(m => m.Id == adsMasterDetailsEditEntity.Id).Select(m => m).FirstOrDefault();
                //    if (ads1.PbPersonnel_Id2 != null)
                //    {
                //        Logger.LogError("This ads has confirmed and it could not be edited");
                //        return -1;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Logger.LogError("This Id has not been found.");
                //    return -1;
                //}
                Logger.LogError("is ads has confirmed and it could not be edited");
                return -1;

            }
            else
               return edit(adsMasterDetailsEditEntity);
           
        }

        private int edit(AdsMasterDetailsEditEntity adsMasterDetailsEditEntity)
        {
            try
            {
                editAdsMaster(adsMasterDetailsEditEntity);

                //AdsEducation
                var EdRemoveLst = DbContext.AdsEducation.Where(AdsEdu => AdsEdu.AdsMaster_Id == adsMasterDetailsEditEntity.Id).ToList();

                foreach (var adEd in EdRemoveLst)
                {
                    DbContext.AdsEducation.Remove(adEd);
                    DbContext.SaveChanges();
                }
                foreach (var adEd in adsMasterDetailsEditEntity.adsMasterDetailsInputEntity.listAdsEducationInput)
                {
                    addAdsEducation(adEd, adsMasterDetailsEditEntity.Id);
                }

                //ForeignLang
                var ForeignLang = DbContext.AdsForeignLang.Where(AdsF => AdsF.AdsMaster_Id == adsMasterDetailsEditEntity.Id).ToList();
                foreach (var AdsF in ForeignLang)
                {
                    DbContext.AdsForeignLang.Remove(AdsF);
                    DbContext.SaveChanges();
                }
                foreach (var fl in adsMasterDetailsEditEntity.adsMasterDetailsInputEntity.listForeignLangInput)
                {
                    addAdsForeignLang(fl, adsMasterDetailsEditEntity.Id);
                }

                //AdsSkills
                var AdsSkills = DbContext.AdsSkills.Where(AdsS => AdsS.AdsMaster_Id == adsMasterDetailsEditEntity.Id).ToList();
                foreach (var AdsS in AdsSkills)
                {
                    DbContext.AdsSkills.Remove(AdsS);
                    DbContext.SaveChanges();
                }
                foreach (var adSk in adsMasterDetailsEditEntity.adsMasterDetailsInputEntity.listAdsSkillsInput)
                {
                    addAdsSkills(adSk, adsMasterDetailsEditEntity.Id);
                }

                //AdsWrkBenefit
                var AdsWrkBenefit = DbContext.AdsWrkBenefit.Where(AdsW => AdsW.AdsMaster_Id == adsMasterDetailsEditEntity.Id).ToList();
                foreach (var AdsW in AdsWrkBenefit)
                {
                    DbContext.AdsWrkBenefit.Remove(AdsW);
                    DbContext.SaveChanges();
                }
                foreach (var adW in adsMasterDetailsEditEntity.adsMasterDetailsInputEntity.listAdsWrkBenefitInput)
                {
                   addAdsWrkBenefit(adW, adsMasterDetailsEditEntity.Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An exception occurred in EditAds when calling WebApi.", ex);
                return -1;
            }
            return adsMasterDetailsEditEntity.Id;
        }

        private void editAdsMaster(AdsMasterDetailsEditEntity adsMasterDetailsEditEntity)
        {
            try
            {
                AdsInputEntity req = adsMasterDetailsEditEntity.adsMasterDetailsInputEntity.adsInput;

                var Ads = DbContext.AdsMaster.Find(adsMasterDetailsEditEntity.Id);

                Ads.Id = adsMasterDetailsEditEntity.Id;
                Ads.WrkCategory_Id = req.WrkCategory_Id;
                Ads.JobTitle = req.JobTitle;
                Ads.WrkHistory_Id = req.WrkHistory_Id;
                Ads.CopTyp_Id = req.CopTyp_Id;
                Ads.WrkShift_Id = req.WrkShift_Id;
                Ads.WrkPlace_Id = req.WrkPlace_Id;
                Ads.Gender_Id = req.Gender_Id;
                Ads.Salary_Id = req.Salary_Id;
                Ads.DutyStatus = req.DutyStatus;
                Ads.AgeFrom = req.AgeFrom;
                Ads.AgeTo = req.AgeTo;
                Ads.Description = req.Description;
                Ads.PhysicalDisability = req.PhysicalDisability;
                Ads.ExpirationDateSh = req.ExpirationDateSh;
                Ads.ExpirationTimeM = req.ExpirationTimeM;
                Ads.AdsStateLST_Id = req.AdsStateLST_Id;
                Ads.Active = req.Active;
                Ads.AdsJobPositionLST_Id = req.AdsJobPositionLST_Id;
            }
      
            catch (Exception ex)
            {
                throw new Exception("An exception occurred in EditAds when calling WebApi.", ex);
                
            }
        }


        #endregion Edit
        #region Confirm
        public int ConfirmAds(AdsConfirmInputEntity adsConfirmInputEntity, int PrsNo)
        {
            //DateTime now = DateTime.Now;
            //try
            //{
            //    var Ads = DbContext.AdsMaster.Find(adsMasterID.Id);
            //    Ads.PbPersonnel_Id2 = prsNo;
            //    Ads.ConfirmDesc = adsMasterDetailsEditEntity.adsMasterDetailsInputEntity.adsInput.ConfirmDesc;
            //    Ads.ConfirmDate = getShamsiDate(now);
            //    Ads.ConfirmTime = now.TimeOfDay.Hours.ToString() + ":" + now.TimeOfDay.Minutes.ToString() + ":" + now.TimeOfDay.Seconds.ToString();
            //    Ads.AdsStateLST_Id = adsMasterDetailsEditEntity.adsMasterDetailsInputEntity.adsInput.AdsStateLST_Id;
            //    DbContext.SaveChanges();
            //}

            //catch (Exception ex)
            //{
            //    throw new Exception("An exception occurred in ConfirmAds when calling WebApi.", ex);
            //    return -1;
            //}
            //return adsMasterDetailsEditEntity.Id;
            DateTime now = DateTime.Now;
            try
            {
                var Ads = DbContext.AdsMaster.Find(adsConfirmInputEntity.AdsMasterId);
                Ads.PbPersonnel_Id2 = PrsNo;
                Ads.ConfirmDesc = adsConfirmInputEntity.confirmationComment;
                Ads.ConfirmDate = getShamsiDate(now);
                Ads.ConfirmTime = now.TimeOfDay.Hours.ToString() + ":" + now.TimeOfDay.Minutes.ToString() + ":" + now.TimeOfDay.Seconds.ToString();
                Ads.AdsStateLST_Id = 502;
                DbContext.SaveChanges();
            }

            catch (Exception ex)
            {
                throw new Exception("An exception occurred in ConfirmAds when calling WebApi.", ex);
                return -1;
            }
            return adsConfirmInputEntity.AdsMasterId;
        }
        #endregion Confirm

        #region ReportNotExpiredAds
        //public async Task<List<AdsOutputEntity>> GetAds(AdsSearchEntity input)
        public List<AdsMasterDetailsOutputEntity> GetNotExpiredAds(AdsSearchEntity input)
        {

            List<Ads> list = new List<Ads>();

                list = DbContext.AdsMaster.Where(AdsMaster => AdsMaster.Active == true &&
                                                (AdsMaster.DocDate >= input.Fromdate || input.Fromdate == -1) &&
                                                (AdsMaster.DocDate <= input.Todate || input.Todate == -1) &&
                                                (AdsMaster.WrkCategory_Id == input.WorkCategoryId || input.WorkCategoryId == -1) &&
                                                (AdsMaster.Id == input.id || input.id == -1) &&
                                                (AdsMaster.JobTitle.Contains(input.JobTitle)|| AdsMaster.JobTitle == "") &&
                                                (AdsMaster.AdsStateLST_Id == 502 &&
                                                AdsMaster.Id != 100000 &&  //آگهی عمومی
                                                AdsMaster.ExpirationTimeM > DateTime.Now)
                                                ).ToList();
            



            List<AdsMasterDetailsOutputEntity> adsmD = new List<AdsMasterDetailsOutputEntity>();
            foreach (Ads item in list)
            {
                adsmD.Add(GetAdsDetailsWithoutAuth(item.Id));
            }
            Logger.LogTrace("Ads has been taken.");
            return adsmD;


        }

        #endregion ReportNotExpiredAds
        #region ReportConfirmedAds
        //public async Task<List<AdsOutputEntity>> GetAds(AdsSearchEntity input)
        public List<AdsOutputEntity> GetConfirmedAds(AdsSearchEntity input)
        {

            List<Ads> list = new List<Ads>();

            list = DbContext.AdsMaster.Where(AdsMaster => AdsMaster.Active == true &&
                                            (AdsMaster.DocDate >= input.Fromdate || input.Fromdate == -1) &&
                                            (AdsMaster.DocDate <= input.Todate || input.Todate == -1) &&
                                            (AdsMaster.WrkCategory_Id == input.WorkCategoryId || input.WorkCategoryId == -1) &&
                                            (AdsMaster.JobTitle.Contains(input.JobTitle) || AdsMaster.JobTitle == "") &&
                                            (AdsMaster.Id == input.id || input.id == -1) &&
                                            (AdsMaster.AdsStateLST_Id == 502)
                                            ).ToList();



            //var list = DbContext.AdsMaster.ToList();

            //Creator Ids
            List<int> creatorIdLst = list.Select(Ads => Ads.PbPersonnel_Id).ToList();

            //Confirmer Ids
            List<int> confirmerIdLst = list.Where(Ads => Ads.PbPersonnel_Id2 != null).Select(Ads => Ads.PbPersonnel_Id2.Value).ToList();

            ApiManager apimaneger = new ApiManager("https://gateway.crouseco.com/Pb/");


            //List of Creator information (PbPeronnel)
            DtPersonnelSearch dtPersonnelSearch = new DtPersonnelSearch()
            {
                PrsCodes = creatorIdLst,
                Active = 1
            };
            List<PbPersonnel> pbCreators = apimaneger.Call<DtPersonnelSearch, List<PbPersonnel>>("Pb/SearchPbPersonnels", dtPersonnelSearch).Result;

            //List of Confirmer information (PbPeronnel)
            DtPersonnelSearch dtPersonnelSearch2 = new DtPersonnelSearch();
            List<PbPersonnel> pbConfirmers = new List<PbPersonnel>();
            if (confirmerIdLst.Count > 0)
            {
                dtPersonnelSearch2.PrsCodes = confirmerIdLst;
                dtPersonnelSearch2.Active = 1;
                pbConfirmers = apimaneger.Call<DtPersonnelSearch, List<PbPersonnel>>("Pb/SearchPbPersonnels", dtPersonnelSearch2).Result;

            }

            ApiManager apimaneger2 = new ApiManager("https://gateway.crouseco.com/Cv/");
            //CvCOPType
            var CVCopLST = apimaneger2.CallGetAsync<List<CvCOPTypeLST>>("CvBase/GetCvCOPTypeLST", "2").Result;

            //WrkShift
            var CvWrkShiftLST = apimaneger2.CallGetAsync<List<CvWrkShiftLST>>("CvBase/GetCvWrkShiftLST", "2").Result;

            //WrkCategory
            var WrkCategory = _initializeService.WrkCategoryList(2).Result;

            //WrkHistory
            var WrkHistory = _initializeService.WrkHistoryList(2).Result;

            //WrkPlace
            var WrkPlace = _initializeService.WrkPlaceList(2).Result;

            //Gender
            var Gender = _initializeService.GenderList(2).Result;

            //Salary
            var Salary = _initializeService.SalaryList(2).Result;

            //State
            var State = _initializeService.StateList(2).Result;

            //JobPosition
            var JobPosition = _initializeService.JobPositionList(2).Result;
            List<AdsOutputEntity> Query = new List<AdsOutputEntity>();
            try
            {
                Query = (from AdsMaster in list  /// گزارش اصلی 


                         join prs in pbCreators   // مشخصات پرسنلی 
                         on AdsMaster.PbPersonnel_Id equals prs.PersonnelCode

                         join wcat in WrkCategory //DbContext.AdsWrkCategoryLST   // دسته بندی شغلی  
                         on AdsMaster.WrkCategory_Id equals wcat.Id

                         join whist in WrkHistory//DbContext.AdsWrkHistoryLST   // سابقه کاری 
                         on AdsMaster.WrkHistory_Id equals whist.Id


                         join cop in CVCopLST         //نوع همکاری
                         on AdsMaster.CopTyp_Id equals cop.Id

                         join shft in CvWrkShiftLST         //شیفت کاری
                         on AdsMaster.WrkShift_Id equals shft.Id

                         join plc in WrkPlace//DbContext.AdsWrkPlaceLST        //محل کار
                         on AdsMaster.WrkPlace_Id equals plc.Id into tempw
                         from tempwp in tempw.DefaultIfEmpty()

                         join gnd in Gender//DbContext.AdsGenderLST          //جنسیت 
                         on AdsMaster.Gender_Id equals gnd.Id

                         join sal in Salary// DbContext.AdsSalaryLST          //حقوق 
                         on AdsMaster.Salary_Id equals sal.Id

                         join state in State//DbContext.AdsStateLST         // وضعیت آگهی 
                         on AdsMaster.AdsStateLST_Id equals state.Id

                         join jobPos in JobPosition//DbContext.AdsJobPositionLST         // موقعیت شغلی 
                         on AdsMaster.AdsJobPositionLST_Id equals jobPos.Id

                         join prs2 in pbConfirmers           // مشخصات پرسنلی تایید کننده 
                         on AdsMaster.PbPersonnel_Id2 equals (int?)prs2.PersonnelCode into tempp
                         from temp1 in tempp.DefaultIfEmpty()


                             //where AdsMaster.ConfirmDate >= input.Fromdate && AdsMaster.ConfirmDate <= input.Todate

                         select new AdsOutputEntity
                         {

                             Id = AdsMaster.Id,
                             WrkCategory_Id = AdsMaster.WrkCategory_Id,
                             WrkCategory_Title = wcat.CategoryTitle,
                             PbPersonnel_Id = AdsMaster.PbPersonnel_Id,
                             PbPersonnel_FirstName = prs.FirstName,
                             PbPersonnel_LastName = prs.LastName,
                             JobTitle = AdsMaster.JobTitle,
                             WrkHistory_Id = AdsMaster.WrkHistory_Id,
                             WrkHistory_Title = whist.WrkHistoryTitle,
                             CopTyp_Id = AdsMaster.CopTyp_Id,
                             CopTyp_Title = cop.CoTitle,
                             WrkShift_Id = AdsMaster.WrkShift_Id,
                             WrkShift_Title = shft.ShiftTitle,
                             WrkPlace_Id = AdsMaster.WrkPlace_Id,
                             WrkPlace_Title = tempwp?.PlaceTitle,
                             Gender_Id = AdsMaster.Gender_Id,
                             Gender_Title = gnd.genderTitle,
                             Salary_Id = AdsMaster.Salary_Id,
                             Salary_Title = sal.SalaryTitle,
                             DutyStatus = AdsMaster.DutyStatus,
                             AgeFrom = AdsMaster.AgeFrom,
                             AgeTo = AdsMaster.AgeTo,
                             Description = AdsMaster.Description,
                             PhysicalDisability = AdsMaster.PhysicalDisability,
                             ExpirationDateSh = AdsMaster.ExpirationDateSh,
                             ExpirationTimeM = AdsMaster.ExpirationTimeM,
                             DocDate = AdsMaster.DocDate,
                             DocTime = AdsMaster.DocTime,
                             LogDateTime = AdsMaster.LogDateTime,
                             PbPersonnel_Id2 = AdsMaster.PbPersonnel_Id2,
                             PbPersonnel_FirstName2 = temp1?.FirstName,
                             PbPersonnel_LastName2 = temp1?.LastName,
                             ConfirmDate = AdsMaster.ConfirmDate,
                             ConfirmTime = AdsMaster.DocTime,
                             ConfirmDesc = AdsMaster.ConfirmDesc,
                             AdsStateLST_Id = AdsMaster.AdsStateLST_Id,
                             AdsStateLST_Title = state.AdsStateTitle,
                             AdsJobPositionLST_Id = AdsMaster.AdsJobPositionLST_Id,
                             AdsJobPositionLST_Title = jobPos.PositionTitle,
                             Active = AdsMaster.Active
                         }).ToList();
            }
            catch (Exception ex)
            {

                Query = new List<AdsOutputEntity>();
            }
            Logger.LogTrace("Ads has been taken.");
            return Query;


        }

        #endregion ReportNotExpiredAds
    }
}