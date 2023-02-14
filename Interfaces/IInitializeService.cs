using CrouseServiceAdvertisement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrouseServiceAdvertisement.Interfaces
{
    public interface IInitializeService
    {
        public  Task<List<AdsGenderLSTEntity>> GenderList(int Active = 1);
        public  Task<List<AdsSalaryLSTEntity>> SalaryList(int Active = 1);
        public  Task<List<AdsStateLSTEntity>> StateList(int Active = 1);
        public  Task<List<AdsWrkBenefitLSTEntity>> WrkBenefitList(int Active = 1);
        public  Task<List<AdsWrkCategoryLSTEntity>> WrkCategoryList(int Active = 1);
        public  Task<List<AdsWrkHistoryLSTEntity>> WrkHistoryList(int Active = 1);
        public  Task<List<AdsWrkPlaceLSTEntity>> WrkPlaceList(int Active = 1);
        public  Task<List<AdsJobPositionLSTEntity>> JobPositionList(int Active = 1);
        public  Task<List<AdsSuggestedJobLSTEntity>> SuggestedJobList(int Active = 1);
    }
}
