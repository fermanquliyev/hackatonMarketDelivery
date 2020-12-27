using Demirqol.Delivery.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demirqol.Delivery.OrderManagement
{
    public class Order : FullAuditedAggregateRoot<Guid>, ITenantProperty, IHasExtraProperties
    {
        public Order() : base()
        {

        }
        public Order(Guid id) : base(id)
        {

        }
        public int? MarketId { get; set; }
        public Guid? DeliveryUserId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderStatusDescription { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public Guid TenantId { get; set; }
    }
}
