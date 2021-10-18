using Group32.Core.ResidenceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.EventManagement
{
    public  class GetEventDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string  StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
        public string EventType { get; set; }
        public int EventTypeId { get; set; }
        public string Residence { get; set; }
         public int ResidenceId { get; set; }
    }
}
   
