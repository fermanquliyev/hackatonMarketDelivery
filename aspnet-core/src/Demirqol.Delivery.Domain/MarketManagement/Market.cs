using Demirqol.Delivery.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demirqol.Delivery.MarketManagement
{
    public class Market : FullAuditedEntity<int>, ITenantProperty
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool IsDefault { get; set; }
        public Guid TenantId { get; set; }
    }
}
