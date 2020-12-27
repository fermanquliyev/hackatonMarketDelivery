using Demirqol.Delivery.ItemManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Demirqol.Delivery.Data
{
    public class DeliveryDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category> categories;

        public DeliveryDataSeedContributor(IRepository<Category> categories)
        {
            this.categories = categories;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await categories.GetCountAsync() == 0)
            {
                await categories.InsertAsync(new Category
                {
                    Name = "Qida",
                    Description = "Qida və ərzaq"
                });
                await categories.InsertAsync(new Category
                {
                    Name = "İçkilər",
                    Description = "Hər növ içkilər"
                });
                await categories.InsertAsync(new Category
                {
                    Name = "Geyim",
                    Description = "Hər növ geyim və aksesuarlar"
                });
                await categories.InsertAsync(new Category
                {
                    Name = "Təbabət",
                    Description = "Dərmanlar, vitaminlər"
                });
                await categories.InsertAsync(new Category
                {
                    Name = "Ev əşyaları",
                    Description = "Ev əşyaları"
                });
                await categories.InsertAsync(new Category
                {
                    Name = "Elektronika",
                    Description = "Elektronik məhsullar"
                });
            }
        }
    }
}
