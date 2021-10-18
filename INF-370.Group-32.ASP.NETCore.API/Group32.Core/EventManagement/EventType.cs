using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.EventManagement
{
    public class EventType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public virtual List<Event>  Events { get; set; }
        public EventType()
        {
            Events = new List<Event>();
        }
    }

}
