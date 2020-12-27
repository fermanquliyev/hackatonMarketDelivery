using Demirqol.Delivery.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demirqol.Delivery.ItemManagement
{
    public class Item : FullAuditedEntity<int>, ITenantProperty, IHasExtraProperties
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public int CategoryId { get; set; }
        public Guid TenantId { get; set; }
        public string PhotoUrl { get; set; }
        public Dictionary<string, object> ExtraProperties { get; set; }
        public double StockCount { get; set; }
        public bool OnStock { get; set; }
    }
}
