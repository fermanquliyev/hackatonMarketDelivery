using System;
using System.Collections.Generic;
using System.Text;

namespace Demirqol.Delivery.MarketManagement.Dto
{
    public class MarketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool IsDefault { get; set; }
        public Guid TenantId { get; set; }
    }
}
