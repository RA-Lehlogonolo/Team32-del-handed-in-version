using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Event
    {
        public Event()
        {
            StudentEvents = new HashSet<StudentEvent>();
        }

        public int EventId { get; set; }
        public int StatusId { get; set; }
        public int EventTypeId { get; set; }
        public int ResidenceId { get; set; }
        public int? UserId { get; set; }
        public int? StudentId { get; set; }
        public string EventName { get; set; }
        public byte[] EventPoster { get; set; }
        public string EventLocation { get; set; }
        public DateTime? TimeSlot { get; set; }
        public DateTime? Date { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual Residence Residence { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<StudentEvent> StudentEvents { get; set; }
    }
}
