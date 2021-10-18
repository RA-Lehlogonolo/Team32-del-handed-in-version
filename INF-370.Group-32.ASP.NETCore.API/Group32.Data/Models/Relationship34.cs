using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Relationship34
    {
        public int StudentId { get; set; }
        public int HealthInspectionId { get; set; }

        public virtual HealthInspection HealthInspection { get; set; }
        public virtual Student Student { get; set; }
    }
}
