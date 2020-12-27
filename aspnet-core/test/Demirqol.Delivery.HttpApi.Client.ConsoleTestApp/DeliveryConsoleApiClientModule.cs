using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Demirqol.Delivery.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(DeliveryHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DeliveryConsoleApiClientModule : AbpModule
    {
        
    }
}
