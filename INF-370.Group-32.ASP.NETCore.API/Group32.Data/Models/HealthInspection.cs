using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class HealthInspection
    {
        public HealthInspection()
        {
            Relationship34s = new HashSet<Relationship34>();
        }

        public int HealthInspectionId { get; set; }
        public int HealthInspectionStatusId { get; set; }
        public int HealthInspectionTypeId { get; set; }
        public int StudentId { get; set; }
        public int YearId { get; set; }
        public DateTime? Date { get; set; }
        public bool TravelledToHighRiskCountry { get; set; }
        public bool? TravelledToDifferentProvince { get; set; }
        public bool? HadContactWithAnyoneConfirmedCovid19 { get; set; }
        public bool? HaveFever { get; set; }
        public bool? HaveCough { get; set; }
        public bool? RedEyes { get; set; }
        public bool? DifficultyBreathing { get; set; }
        public bool? SoreThrot { get; set; }
        public string Result { get; set; }

        public virtual HealthInspectionStatus HealthInspectionStatus { get; set; }
        public virtual ICollection<Relationship34> Relationship34s { get; set; }
    }
}
