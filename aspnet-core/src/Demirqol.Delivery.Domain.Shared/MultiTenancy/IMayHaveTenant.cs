using System;
using System.Collections.Generic;
using System.Text;

namespace Demirqol.Delivery.MultiTenancy
{
    public interface ITenantProperty
    {
        public Guid TenantId { get; set; }
    }
}
