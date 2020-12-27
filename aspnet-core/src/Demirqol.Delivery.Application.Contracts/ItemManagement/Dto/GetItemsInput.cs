using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Demirqol.Delivery.ItemManagement.Dto
{
    public class GetItemsInput:PagedResultRequestDto
    {
        public string SearchKeyword { get; set; }
        public int? CategoryId { get; set; }
        public Guid? TenantId { get; set; }
    }
}
