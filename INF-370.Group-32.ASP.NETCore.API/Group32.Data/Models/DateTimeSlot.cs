using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class DateTimeSlot
    {
        public DateTimeSlot()
        {
            ResidenceDateTimeSlots = new HashSet<ResidenceDateTimeSlot>();
        }

        public int DateId { get; set; }
        public int TimeSlotId { get; set; }

        public virtual DateSlot Date { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
        public virtual ICollection<ResidenceDateTimeSlot> ResidenceDateTimeSlots { get; set; }
    }
}
