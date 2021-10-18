using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class VisitationApplicationStatus
    {
        public VisitationApplicationStatus()
        {
            StudentVisitations = new HashSet<StudentVisitation>();
        }

        public int VisitationApplicationStatusId { get; set; }
        public string VisitationApplicationStatusName { get; set; }
        public string VisitationApplicationStatusDescription { get; set; }

        public virtual ICollection<StudentVisitation> StudentVisitations { get; set; }
    }
}
