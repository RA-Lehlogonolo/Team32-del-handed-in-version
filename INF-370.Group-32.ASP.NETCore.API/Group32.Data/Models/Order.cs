using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            Carts = new HashSet<Cart>();
            CollectionReminders = new HashSet<CollectionReminder>();
            OrderLines = new HashSet<OrderLine>();
            Payments = new HashSet<Payment>();
        }

        public int OrderId { get; set; }
        public int CartId { get; set; }
        public int? PaymentId { get; set; }
        public int OrderStatusId { get; set; }
        public int UserId { get; set; }
        public string OrderDescription { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderNumber { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<CollectionReminder> CollectionReminders { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
