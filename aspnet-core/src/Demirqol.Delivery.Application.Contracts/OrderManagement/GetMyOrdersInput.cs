using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Demirqol.Delivery.OrderManagement
{
    public class GetOrdersInput: PagedResultRequestDto
    {
        public Guid? TenantId { get; set; }
    }
}
