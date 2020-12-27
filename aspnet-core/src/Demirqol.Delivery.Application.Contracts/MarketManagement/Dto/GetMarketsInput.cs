using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Demirqol.Delivery.MarketManagement.Dto
{
    public class GetMarketsInput:PagedResultRequestDto
    {
        public Guid? TenantId { get; set; }
    }
}
