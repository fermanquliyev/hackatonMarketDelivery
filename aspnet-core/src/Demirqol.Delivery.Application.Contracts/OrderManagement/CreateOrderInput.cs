using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demirqol.Delivery.OrderManagement
{
    public class CreateOrderInput
    {
        [Required]
        public List<CreateOrderLineInput> OrderLines { get; set; }
        [Required]
        public DeliveryAdressInfoDto DeliveryAdressInfo { get; set; }
        [Required]
        public Guid TenantId { get; set; }
    }
}
