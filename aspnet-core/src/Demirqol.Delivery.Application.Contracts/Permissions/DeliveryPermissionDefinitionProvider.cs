using Demirqol.Delivery.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Demirqol.Delivery.Permissions
{
    public class DeliveryPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(UserTypePermissions.GroupName,null, Volo.Abp.MultiTenancy.MultiTenancySides.Host);

            //Define your own permissions here. Example:
            myGroup.AddPermission(UserTypePermissions.Deliverer, L("Permission:Deliverer"),Volo.Abp.MultiTenancy.MultiTenancySides.Host);
            myGroup.AddPermission(UserTypePermissions.Customer, L("Permission:Customer"), Volo.Abp.MultiTenancy.MultiTenancySides.Host);

            var itemGroup = context.AddGroup(ItemPermissions.GroupName);

            //Define your own permissions here. Example:
            itemGroup.AddPermission(ItemPermissions.CreateUpdate, L("Permission:CreateUpdate"));
            itemGroup.AddPermission(ItemPermissions.Delete, L("Permission:Delete"));
            itemGroup.AddPermission(ItemPermissions.SetStockCount, L("Permission:SetStockCount"));

            var orderGroup = context.AddGroup(OrderPermissions.GroupName);

            //Define your own permissions here. Example:
            orderGroup.AddPermission(OrderPermissions.Create, L("Permission:Create"));
            orderGroup.AddPermission(OrderPermissions.UpdateOrderStatus, L("Permission:UpdateOrderStatus"));
            orderGroup.AddPermission(OrderPermissions.UpdateDeliveryStatus, L("Permission:UpdateDeliveryStatus"));

            var market = context.AddGroup(MarketPermissions.GroupName);

            //Define your own permissions here. Example:
            market.AddPermission(MarketPermissions.CreateMarket, L("Permission:CreateUpdate"));
            market.AddPermission(MarketPermissions.DeleteMarket, L("Permission:Delete"));
            market.AddPermission(MarketPermissions.GetMarkets, L("Permission:SetStockCount"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DeliveryResource>(name);
        }
    }
}
