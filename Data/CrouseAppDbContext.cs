using Microsoft.EntityFrameworkCore;

namespace CrouseServiceAdvertisement.Data
{
    public class CrouseAppDbContext : DbContext
    {
        public CrouseAppDbContext(DbContextOptions<CrouseAppDbContext> options) :
            base(options)
        {
        }

        //public DbSet<Models.Log> Logs { get; set; }
    }
}
