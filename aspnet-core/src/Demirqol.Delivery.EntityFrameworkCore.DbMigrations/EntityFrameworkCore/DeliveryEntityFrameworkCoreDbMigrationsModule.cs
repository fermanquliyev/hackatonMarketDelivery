using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Demirqol.Delivery.EntityFrameworkCore
{
    [DependsOn(
        typeof(DeliveryEntityFrameworkCoreModule)
        )]
    public class DeliveryEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DeliveryMigrationsDbContext>();
        }
    }
}
