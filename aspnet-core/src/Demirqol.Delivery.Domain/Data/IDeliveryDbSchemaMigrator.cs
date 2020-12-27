using System.Threading.Tasks;

namespace Demirqol.Delivery.Data
{
    public interface IDeliveryDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
