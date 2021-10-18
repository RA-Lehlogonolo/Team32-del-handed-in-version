using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class DisciplinaryHearing
    {
        public int DisciplinaryHearingId { get; set; }
        public int UserId { get; set; }
        public int StudentId { get; set; }
        public int YearId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }

        public virtual User User { get; set; }
    }
}
