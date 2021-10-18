using Group32.Core.ResidenceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.EventManagement
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public string StartTime { get; set; }
         public string EndTime { get; set; }
       public string Date { get; set; }
        public virtual Residence Residence { get; set; }
        public int ResidenceId { get; set; }
        public virtual EventType EventType { get; set; }
        public int EventTypeId { get; set; }

    }
    
}
