using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class DayDate
    {
        public int DayId { get; set; }
        public int DateId { get; set; }

        public virtual Date Date { get; set; }
        public virtual Day Day { get; set; }
    }
}
