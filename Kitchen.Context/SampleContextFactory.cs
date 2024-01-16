using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kitchen.Context
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<KitchenContext>
    {
        public KitchenContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<KitchenContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new KitchenContext(options);
        }
    }
}
