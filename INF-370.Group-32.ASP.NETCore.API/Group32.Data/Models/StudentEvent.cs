using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class StudentEvent
    {
        public int EventId { get; set; }
        public int StudentId { get; set; }
        public string Rsvp { get; set; }

        public virtual Event Event { get; set; }
        public virtual Student Student { get; set; }
    }
}
