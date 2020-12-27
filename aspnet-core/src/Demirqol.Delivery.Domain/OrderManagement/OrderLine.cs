using System;
using Volo.Abp.Domain.Entities;

namespace Demirqol.Delivery.OrderManagement
{
    public class OrderLine:Entity<int>
    {
        public int ItemId { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public Guid OrderId { get; set; }
    }
}
