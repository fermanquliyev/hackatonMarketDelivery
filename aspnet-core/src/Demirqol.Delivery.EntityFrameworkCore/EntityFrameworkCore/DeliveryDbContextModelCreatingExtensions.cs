using Demirqol.Delivery.ItemManagement;
using Demirqol.Delivery.MarketManagement;
using Demirqol.Delivery.OrderManagement;
using Demirqol.Delivery.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Demirqol.Delivery.EntityFrameworkCore
{
    public static class DeliveryDbContextModelCreatingExtensions
    {
        public static void ConfigureDelivery(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Item>(b =>
            {
                b.ToTable(DeliveryConsts.MasterData + "Item", DeliveryConsts.DbSchema);
                b.Property(x => x.Name).HasMaxLength(100);
                b.Property(x => x.Code).HasMaxLength(50);
                b.Property(x => x.Description).HasMaxLength(500);
                b.Property(x => x.Barcode).HasMaxLength(100);
                b.HasIndex(x => x.Name);
                b.HasIndex(x => x.CategoryId);
                b.HasIndex(x => x.TenantId);
                b.HasIndex(x => x.OnStock);
                b.ConfigureByConvention();
            });

            builder.Entity<Category>(b =>
            {
                b.ToTable(DeliveryConsts.MasterData + "Category", DeliveryConsts.DbSchema);
                b.Property(x => x.Name).HasMaxLength(100);
                b.Property(x => x.Description).HasMaxLength(100);
                b.ConfigureByConvention();
            });

            builder.Entity<Market>(b =>
            {
                b.ToTable(DeliveryConsts.MasterData + "Market", DeliveryConsts.DbSchema);
                b.HasIndex(x => x.TenantId);
                b.Property(x => x.Name).HasMaxLength(100);
                b.Property(x => x.Address).HasMaxLength(250);
                b.HasIndex(x => new { x.Latitude, x.Longitude });
                b.ConfigureByConvention();
            });

            builder.Entity<Order>(b =>
            {
                b.ToTable(DeliveryConsts.Operation + "Order", DeliveryConsts.DbSchema);
                b.HasIndex(x => x.OrderStatus);
                b.HasIndex(x => x.DeliveryUserId);
                b.HasIndex(x => x.TenantId);
                b.HasIndex(x => x.CreatorId);
                b.Property(x => x.OrderStatusDescription).HasMaxLength(250);
                b.ConfigureByConvention();
            });

            builder.Entity<OrderLine>(b =>
            {
                b.ToTable(DeliveryConsts.Operation + "OrderLine", DeliveryConsts.DbSchema);
                b.HasIndex(x => x.OrderId);
                b.ConfigureByConvention();
            });

            builder.Entity<UserPosition>(b =>
            {
                b.ToTable(DeliveryConsts.Operation + "UserPosition", DeliveryConsts.DbSchema);
                b.HasIndex(x => new { x.Latitude, x.Longitude });
                b.ConfigureByConvention();
            });
        }
    }
}