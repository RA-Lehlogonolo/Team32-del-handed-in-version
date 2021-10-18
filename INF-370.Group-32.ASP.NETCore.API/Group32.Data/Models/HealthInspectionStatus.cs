using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class HealthInspectionStatus
    {
        public HealthInspectionStatus()
        {
            HealthInspections = new HashSet<HealthInspection>();
        }

        public int HealthInspectionStatusId { get; set; }
        public string HealthInspectionStatusName { get; set; }
        public string HealthInspectionStatusDescription { get; set; }

        public virtual ICollection<HealthInspection> HealthInspections { get; set; }
    }
}
