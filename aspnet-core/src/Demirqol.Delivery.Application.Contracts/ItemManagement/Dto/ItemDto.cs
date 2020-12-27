using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demirqol.Delivery.ItemManagement.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        public string Barcode { get; set; }
        [Required]
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
        [Required]
        public Guid TenantId { get; set; }
        public DateTime CreationTime { get; set; }
        public double StockCount { get; set; }

        public Dictionary<string, object> ExtraProperties { get; set; }
    }
}
