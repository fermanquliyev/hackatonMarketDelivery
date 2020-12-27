using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demirqol.Delivery.ItemManagement
{
    public class Category:FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
