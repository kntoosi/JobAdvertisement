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
using Serilog.Core;
using CrouseServiceAdvertisement.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CrouseServiceAdvertisement.Services
{
    public class InitializeService : IInitializeService
    {

        private ILogger<InitializeService> Logger { get; }
        //private CrouseDbContext DbContext { get; set; }
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public InitializeService(ILogger<InitializeService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            Logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }
        //Static fields for every basic table
        private List<AdsGenderLSTEntity> AdsGenderList;
        private List<AdsSalaryLSTEntity> AdsSalaryList;
        private List<AdsStateLSTEntity> AdsStateList;
        private List<AdsWrkBenefitLSTEntity> AdsWrkBenefitList;
        private List<AdsWrkCategoryLSTEntity> AdsWrkCategoryList;
        private List<AdsWrkHistoryLSTEntity> AdsWrkHistoryList;
        private List<AdsWrkPlaceLSTEntity> AdsWrkPlaceList;
        private List<AdsJobPositionLSTEntity> AdsJobPositionList;
        private List<AdsSuggestedJobLSTEntity> AdsSuggestedJobList;

        public async Task<List<AdsGenderLSTEntity>> GenderList(int Active = 1)
        {
            if (AdsGenderList == null)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _dbContext = scope.ServiceProvider.GetService<CrouseDbContext>();

                        AdsGenderList = await _dbContext.AdsGenderLST.ToListAsync();

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occurred in Ads Initialize Service.", ex);
                }
            }
            switch (Active)
            {
                case 0:
                    return AdsGenderList.Where(e => e.Active == false).ToList();
                case 2:
                    return AdsGenderList;
                default:
                    return AdsGenderList.Where(e => e.Active == true).ToList();
            }

       }

        public async Task<List<AdsSalaryLSTEntity>> SalaryList(int Active = 1)
        {
            if (AdsSalaryList == null)
            { try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _dbContext = scope.ServiceProvider.GetService<CrouseDbContext>();

                        AdsSalaryList = await _dbContext.AdsSalaryLST.ToListAsync();
                    }
                }
               catch(Exception ex)
                 {
                    throw new Exception("An exception occurred in Ads Initialize Service.", ex);
                }
           }
            switch (Active)
            {
                case 0:
                    return AdsSalaryList.Where(e => e.Active == false).ToList();
                case 2:
                    return AdsSalaryList;
                default:
                    return AdsSalaryList.Where(e => e.Active == true).ToList();
            }
        }
        public async Task<List<AdsStateLSTEntity>> StateList(int Active = 1)
        {
            if (AdsStateList == null)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _dbContext = scope.ServiceProvider.GetService<CrouseDbContext>();

                        AdsStateList = await _dbContext.AdsStateLST.ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occurred in Ads Initialize Service.", ex);
                }
            }
            switch (Active)
            {
                case 0:
                    return AdsStateList.Where(e => e.Active == false).ToList();
                case 2:
                    return AdsStateList;
                default:
                    return AdsStateList.Where(e => e.Active == true).ToList();
            }
        }

        public async Task<List<AdsWrkBenefitLSTEntity>> WrkBenefitList(int Active = 1)
        {
            if (AdsWrkBenefitList == null)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _dbContext = scope.ServiceProvider.GetService<CrouseDbContext>();

                        AdsWrkBenefitList = await _dbContext.AdsWrkBenefitLST.ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occurred in Ads Initialize Service.", ex);
                }
            }
            switch (Active)
            {
                case 0:
                    return AdsWrkBenefitList.Where(e => e.Active == false).ToList();
                case 2:
                    return AdsWrkBenefitList;
                default:
                    return AdsWrkBenefitList.Where(e => e.Active == true).ToList();
            }
        }

        public async Task<List<AdsWrkCategoryLSTEntity>> WrkCategoryList(int Active = 1)
        {
            if (AdsWrkCategoryList == null)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _dbContext = scope.ServiceProvider.GetService<CrouseDbContext>();

                        AdsWrkCategoryList = await _dbContext.AdsWrkCategoryLST.ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occurred in Ads Initialize Service.", ex);
                }
            }
            switch (Active)
            {
                case 0:
                    return AdsWrkCategoryList.Where(e => e.Active == false).ToList();
                case 2:
                    return AdsWrkCategoryList;
                default:
                    return AdsWrkCategoryList.Where(e => e.Active == true).ToList();
            }
        }
        public async Task<List<AdsWrkHistoryLSTEntity>> WrkHistoryList(int Active = 1)
        {
            if (AdsWrkHistoryList == null)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _dbContext = scope.ServiceProvider.GetService<CrouseDbContext>();

                        AdsWrkHistoryList = await _dbContext.AdsWrkHistoryLST.ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occurred in Ads Initialize Service.", ex);
                }
            }
            switch (Active)
            {
                case 0:
                    return AdsWrkHistoryList.Where(e => e.Active == false).ToList();
                case 2:
                    return AdsWrkHistoryList;
                default:
                    return AdsWrkHistoryList.Where(e => e.Active == true).ToList();
            }
        }
        public async Task<List<AdsWrkPlaceLSTEntity>> WrkPlaceList(int Active = 1)
        {
            if (AdsWrkPlaceList == null)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _dbContext = scope.ServiceProvider.GetService<CrouseDbContext>();

                        AdsWrkPlaceList = await _dbContext.AdsWrkPlaceLST.ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occurred in Ads Initialize Service.", ex);
                }
            }
            switch (Active)
            {
                case 0:
                    return AdsWrkPlaceList.Where(e => e.Active == false).ToList();
                case 2:
                    return AdsWrkPlaceList;
                default:
                    return AdsWrkPlaceList.Where(e => e.Active == true).ToList();
            }
        }


        public async Task<List<AdsJobPositionLSTEntity>> JobPositionList(int Active = 1)
        {
            if (AdsJobPositionList == null)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _dbContext = scope.ServiceProvider.GetService<CrouseDbContext>();

                        AdsJobPositionList = await _dbContext.AdsJobPositionLST.ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occurred in Ads Initialize Service.", ex);
                }
            }
            switch (Active)
            {
                case 0:
                    return AdsJobPositionList.Where(e => e.Active == false).ToList();
                case 2:
                    return AdsJobPositionList;
                default:
                    return AdsJobPositionList.Where(e => e.Active == true).ToList();
            }
        }

        public async Task<List<AdsSuggestedJobLSTEntity>> SuggestedJobList(int Active = 1)
        {
            if (AdsSuggestedJobList == null)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var _dbContext = scope.ServiceProvider.GetService<CrouseDbContext>();

                        AdsSuggestedJobList = await _dbContext.AdsSuggestedJobLST.ToListAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An exception occurred in Ads Initialize Service.", ex);
                }
            }
            switch (Active)
            {
                case 0:
                    return AdsSuggestedJobList.Where(e => e.Active == false).ToList();
                case 2:
                    return AdsSuggestedJobList;
                default:
                    return AdsSuggestedJobList.Where(e => e.Active == true).ToList();
            }
        }
    }
}
