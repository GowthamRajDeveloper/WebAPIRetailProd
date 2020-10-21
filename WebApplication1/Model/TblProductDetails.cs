using System;
using System.Collections.Generic;

namespace WebAPIRetailProduct.Model
{
    public partial class TblProductDetails
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public long? Cost { get; set; }
        public byte[] Weight { get; set; }
        public long? ProductQuantityAvilable { get; set; }
        public byte[] IsActive { get; set; }
    }
}
