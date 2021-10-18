using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class OrderLine
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
