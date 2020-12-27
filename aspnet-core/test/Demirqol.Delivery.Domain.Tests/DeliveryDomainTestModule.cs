using Demirqol.Delivery.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Demirqol.Delivery
{
    [DependsOn(
        typeof(DeliveryEntityFrameworkCoreTestModule)
        )]
    public class DeliveryDomainTestModule : AbpModule
    {

    }
}