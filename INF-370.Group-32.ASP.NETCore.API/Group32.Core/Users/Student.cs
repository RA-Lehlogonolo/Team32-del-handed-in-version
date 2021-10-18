using Group32.Core.AssociativeEntity;
using Group32.Core.AuditLogs;
using Group32.Core.CampusResidence;
using Group32.Core.DisciplinaryHearingManagement;
using Group32.Core.Identity;
using Group32.Core.ResidenceManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.Users
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string LevelOfStudy { get; set; }

        [Required]
        public string Gender { get; set; }

        public string AssignedToRoom { get; set; }

        public virtual Faculty Faculty { get; set; }
        public int FacultyId { get; set; }

        public virtual Residence Residence { get; set; }
        public int ResidenceId { get; set; }

        public virtual StudentRole StudentRole { get; set; }
        public int StudentRoleId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

        public IList<StudentRoom> StudentRooms { get; set; }

        public virtual List<DisciplinaryHearing>  DisciplinaryHearings{ get; set; }
        public virtual List<ResidenceAllocationAuditLog> ResidenceAllocationLog { get; set; }
        public Student()
        {
            ResidenceAllocationLog = new List<ResidenceAllocationAuditLog>();
            StudentRooms = new List<StudentRoom>();
            DisciplinaryHearings = new List<DisciplinaryHearing>();
        }
    }
}
