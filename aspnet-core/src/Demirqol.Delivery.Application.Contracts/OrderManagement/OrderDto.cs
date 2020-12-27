using System;
using System.Collections.Generic;
using System.Text;

namespace Demirqol.Delivery.OrderManagement
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderStatusDescription { get; set; }
        public Guid TenantId { get; set; }
        public DateTime CreationTime { get; set; }
        public Dictionary<string,object> ExtraProperties { get; set; }
        public double Distance { get; set; }
        public int? MarketId { get; set; }
    }
}
