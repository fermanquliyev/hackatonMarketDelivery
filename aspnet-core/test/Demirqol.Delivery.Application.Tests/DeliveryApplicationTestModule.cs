using Volo.Abp.Modularity;

namespace Demirqol.Delivery
{
    [DependsOn(
        typeof(DeliveryApplicationModule),
        typeof(DeliveryDomainTestModule)
        )]
    public class DeliveryApplicationTestModule : AbpModule
    {

    }
}