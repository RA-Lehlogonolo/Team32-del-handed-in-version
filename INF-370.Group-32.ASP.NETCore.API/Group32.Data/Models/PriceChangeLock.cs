using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class PriceChangeLock
    {
        public int PriceChangeLock1 { get; set; }
        public int ProductId { get; set; }
        public string Price { get; set; }

        public virtual Product Product { get; set; }
    }
}
