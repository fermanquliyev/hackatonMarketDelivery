using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Demirqol.Delivery.Data
{
    /* This is used if database provider does't define
     * IDeliveryDbSchemaMigrator implementation.
     */
    public class NullDeliveryDbSchemaMigrator : IDeliveryDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}