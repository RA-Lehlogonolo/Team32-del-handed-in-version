using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class StudentVisitation
    {
        public int StudentVisitationId { get; set; }
        public int StudentId { get; set; }
        public int VisitationApplicationStatusId { get; set; }
        public int UserId { get; set; }
        public int? UseUserId { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Reason { get; set; }
        public string VisitAddress { get; set; }
        public string StudentEmail { get; set; }
        public string HostName { get; set; }

        public virtual Student Student { get; set; }
        public virtual VisitationApplicationStatus VisitationApplicationStatus { get; set; }
    }
}
