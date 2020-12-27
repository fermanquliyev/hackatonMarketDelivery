using System;
using System.Collections.Generic;
using System.Text;

namespace Demirqol.Delivery.Permissions
{
    public class MarketPermissions
    {
        public const string GroupName = "Market";

        //Add your own permission names. Example:
        public const string CreateMarket = GroupName + ".CreateMarket";
        public const string DeleteMarket = GroupName + ".DeleteMarket";
        public const string GetMarkets = GroupName + ".GetMarkets";
    }
}
