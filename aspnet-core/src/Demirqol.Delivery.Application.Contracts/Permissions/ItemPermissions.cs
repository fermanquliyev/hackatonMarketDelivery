using System;
using System.Collections.Generic;
using System.Text;

namespace Demirqol.Delivery.Permissions
{
    public class ItemPermissions
    {
        public const string GroupName = "Item";

        public const string CreateUpdate = GroupName + ".CreateUpdate";
        public const string Delete = GroupName + ".Delete";
        public const string SetStockCount = GroupName + ".SetStockCount";
    }
}
