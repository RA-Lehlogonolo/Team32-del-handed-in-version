using Group32.Core.VillageFreshManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.AssociativeEntity
{
    public class DayDate
    {
        public int DayId { get; set; }
        public Day Day { get; set; }

        public int DateId { get; set; }
        public Date Date { get; set; }

    }
}
    
