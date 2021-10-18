using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class CartLine
    {
        public string CartLineId { get; set; }
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? LineTotal { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
