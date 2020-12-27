using Demirqol.Delivery.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Demirqol.Delivery.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(DeliveryEntityFrameworkCoreDbMigrationsModule),
        typeof(DeliveryApplicationContractsModule)
        )]
    public class DeliveryDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
