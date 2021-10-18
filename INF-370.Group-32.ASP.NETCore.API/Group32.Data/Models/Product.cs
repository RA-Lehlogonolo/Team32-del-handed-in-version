using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
            PriceChangeLocks = new HashSet<PriceChangeLock>();
        }

        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<PriceChangeLock> PriceChangeLocks { get; set; }
    }
}
