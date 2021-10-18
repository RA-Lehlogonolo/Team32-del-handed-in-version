using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }
        public int PaymentStatusId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }

        public virtual Order Order { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
