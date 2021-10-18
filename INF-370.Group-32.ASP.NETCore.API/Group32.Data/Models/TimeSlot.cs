using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            DateTimeSlots = new HashSet<DateTimeSlot>();
        }

        public int TimeSlotId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual ICollection<DateTimeSlot> DateTimeSlots { get; set; }
    }
}
