using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Demirqol.Delivery.Data;
using Volo.Abp.DependencyInjection;

namespace Demirqol.Delivery.EntityFrameworkCore
{
    public class EntityFrameworkCoreDeliveryDbSchemaMigrator
        : IDeliveryDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreDeliveryDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the DeliveryMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<DeliveryMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}