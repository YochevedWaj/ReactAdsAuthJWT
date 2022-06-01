using Microsoft.EntityFrameworkCore;

namespace ReactAdsAuthJWT.Data
{
    public class AdsDataContext : DbContext
    {
        private readonly string _connectionString;

        public AdsDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }
    }
}
