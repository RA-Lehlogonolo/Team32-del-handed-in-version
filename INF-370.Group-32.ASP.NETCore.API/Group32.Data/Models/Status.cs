using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Status
    {
        public Status()
        {
            Events = new HashSet<Event>();
        }

        public int StatusId { get; set; }
        public int EventId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
