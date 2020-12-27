using System;
using System.Collections.Generic;
using System.Text;

namespace Demirqol.Delivery.OrderManagement
{
    public class OrderLineDto:CreateOrderLineInput
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
    }
}
