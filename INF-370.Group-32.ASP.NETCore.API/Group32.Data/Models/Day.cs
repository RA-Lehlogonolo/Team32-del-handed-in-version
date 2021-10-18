using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Day
    {
        public Day()
        {
            DayDates = new HashSet<DayDate>();
            MenuTypeDays = new HashSet<MenuTypeDay>();
        }

        public int DayId { get; set; }
        public decimal? Day1 { get; set; }

        public virtual ICollection<DayDate> DayDates { get; set; }
        public virtual ICollection<MenuTypeDay> MenuTypeDays { get; set; }
    }
}
