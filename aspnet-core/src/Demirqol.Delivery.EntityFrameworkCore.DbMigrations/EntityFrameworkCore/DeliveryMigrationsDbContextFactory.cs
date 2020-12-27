using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Demirqol.Delivery.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class DeliveryMigrationsDbContextFactory : IDesignTimeDbContextFactory<DeliveryMigrationsDbContext>
    {
        public DeliveryMigrationsDbContext CreateDbContext(string[] args)
        {
            DeliveryEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<DeliveryMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new DeliveryMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Demirqol.Delivery.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
