using CrouseServiceAdvertisement.Models;
using Microsoft.EntityFrameworkCore;

namespace CrouseServiceAdvertisement.Data
{
    public class CrouseDbContext : DbContext
    {
        public CrouseDbContext(DbContextOptions<CrouseDbContext> options) :
            base(options)
        {
        }

        public DbSet<AdsGenderLSTEntity> AdsGenderLST { get; set; }
        public DbSet<AdsSalaryLSTEntity> AdsSalaryLST { get; set; }
        public DbSet<AdsStateLSTEntity> AdsStateLST { get; set; }
        public DbSet<AdsWrkBenefitLSTEntity> AdsWrkBenefitLST { get; set; }
        public DbSet<AdsWrkCategoryLSTEntity> AdsWrkCategoryLST { get; set; }
        public DbSet<AdsWrkHistoryLSTEntity> AdsWrkHistoryLST { get; set; }
        public DbSet<AdsWrkPlaceLSTEntity> AdsWrkPlaceLST { get; set; }
        public DbSet<AdsJobPositionLSTEntity> AdsJobPositionLST { get; set; }
        public DbSet<AdsSuggestedJobLSTEntity> AdsSuggestedJobLST { get; set; }
        public DbSet<Ads> AdsMaster { get; set; }
        public DbSet<AdsEducation> AdsEducation { get; set; }
        public DbSet<AdsForeignLang> AdsForeignLang { get; set; }
        public DbSet<AdsSkills> AdsSkills { get; set; }
        public DbSet<AdsWrkBenefit> AdsWrkBenefit { get; set; }
    }
}
