using Microsoft.EntityFrameworkCore;
using Demirqol.Delivery.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using Demirqol.Delivery.ItemManagement;
using Demirqol.Delivery.OrderManagement;
using Demirqol.Delivery.MarketManagement;
using Demirqol.Delivery.MultiTenancy;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System;

namespace Demirqol.Delivery.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See DeliveryMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class DeliveryDbContext : AbpDbContext<DeliveryDbContext>
    {
        public DbSet<AppUser> Users { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside DeliveryDbContextModelCreatingExtensions.ConfigureDelivery
         */
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options)
            : base(options)
        {

        }
        protected bool TenantFilterEnabled => DataFilter?.IsEnabled<ITenantProperty>() ?? false;

        protected override bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType)
        {
            if (typeof(ITenantProperty).IsAssignableFrom(typeof(TEntity)))
            {
                return true;
            }

            return base.ShouldFilterEntity<TEntity>(entityType);
        }

        protected override Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
        {
            var expression = base.CreateFilterExpression<TEntity>();

            if (typeof(ITenantProperty).IsAssignableFrom(typeof(TEntity)) && CurrentTenantId.HasValue && TenantFilterEnabled)
            {
                Expression<Func<TEntity, bool>> tenantFilter =
                    e => EF.Property<Guid>(e, "TenantId") == CurrentTenantId.Value;
                expression = expression == null
                    ? tenantFilter
                    : CombineExpressions(expression, tenantFilter);
            }

            return expression;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser

                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the DeliveryEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureDelivery method */

            builder.ConfigureDelivery();
        }
    }
}
