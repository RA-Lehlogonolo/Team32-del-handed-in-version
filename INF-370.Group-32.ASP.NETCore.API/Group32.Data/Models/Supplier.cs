using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            ProductTypes = new HashSet<ProductType>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierPhoneNumber { get; set; }

        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}
