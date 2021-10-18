using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Payments = new HashSet<Payment>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeDescription { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
