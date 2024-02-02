using Microsoft.EntityFrameworkCore;

namespace prjVisaSuppiler.Models
{
    public partial class dbTravalPlatformContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("TravelPlatform"));
            }
        }
    }
}
