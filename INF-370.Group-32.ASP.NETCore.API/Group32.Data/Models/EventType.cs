using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
        public string EventTypeDescription { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
