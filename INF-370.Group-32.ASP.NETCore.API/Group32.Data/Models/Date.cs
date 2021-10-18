using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Date
    {
        public Date()
        {
            DayDates = new HashSet<DayDate>();
        }

        public int DateId { get; set; }
        public DateTime? Date1 { get; set; }

        public virtual ICollection<DayDate> DayDates { get; set; }
    }
}
