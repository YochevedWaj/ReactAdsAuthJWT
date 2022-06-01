using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ReactAdsAuthJWT.Data
{
    public class AdsContextFactory : IDesignTimeDbContextFactory<AdsDataContext>
    {
        public AdsDataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}ReactAdsAuthJWT.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new AdsDataContext(config.GetConnectionString("ConStr"));
        }
    }
}
