using System;
using System.Collections.Generic;
using System.Text;

namespace Demirqol.Delivery.Permissions
{
    public class OrderPermissions
    {
        public const string GroupName = "Order";

        public const string Create = GroupName + ".Create";
        public const string UpdateOrderStatus = GroupName + ".UpdateOrderStatus";
        public const string UpdateDeliveryStatus = GroupName + ".UpdateDeliveryStatus";
        public const string SetOrderAsDelivered = GroupName + ".SetOrderAsDelivered";
    }
}
