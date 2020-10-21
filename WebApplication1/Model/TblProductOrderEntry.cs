using System;
using System.Collections.Generic;

namespace WebAPIRetailProduct.Model
{
    public partial class TblProductOrderEntry
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public long? OrderQuantity { get; set; }
        public double? OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
