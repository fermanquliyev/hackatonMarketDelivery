using System.ComponentModel.DataAnnotations;

namespace Demirqol.Delivery.OrderManagement
{
    public class CreateOrderLineInput
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Quantity { get; set; }
    }
}
