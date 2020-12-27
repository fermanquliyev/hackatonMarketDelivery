using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demirqol.Delivery.ItemManagement.Dto
{
   public class SetItemStockInput
    {
        public int ItemId { get; set; }
        [Range(0,double.MaxValue)]
        public double StockCount { get; set; }
    }
}
