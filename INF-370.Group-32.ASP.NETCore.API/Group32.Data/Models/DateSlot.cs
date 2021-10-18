using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class DateSlot
    {
        public DateSlot()
        {
            DateTimeSlots = new HashSet<DateTimeSlot>();
        }

        public int DateId { get; set; }
        public DateTime? Date { get; set; }

        public virtual ICollection<DateTimeSlot> DateTimeSlots { get; set; }
    }
}
