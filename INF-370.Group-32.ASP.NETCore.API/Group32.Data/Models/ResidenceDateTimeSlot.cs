using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class ResidenceDateTimeSlot
    {
        public int DateId { get; set; }
        public int TimeSlotId { get; set; }
        public int ResidenceId { get; set; }

        public virtual DateTimeSlot DateTimeSlot { get; set; }
        public virtual Residence Residence { get; set; }
    }
}
