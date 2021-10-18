using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartLines = new HashSet<CartLine>();
            Orders = new HashSet<Order>();
        }

        public int CartId { get; set; }
        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        public int? Total { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<CartLine> CartLines { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
