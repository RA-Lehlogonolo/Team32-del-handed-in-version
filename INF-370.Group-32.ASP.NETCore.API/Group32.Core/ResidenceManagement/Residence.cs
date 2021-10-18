using Group32.Core.AnnouncementManagement;
using Group32.Core.AuditLogs;
using Group32.Core.CampusResidence;
using Group32.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.ResidenceManagement
{
   public class Residence
   {

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        [Required]
        [MaxLength(255)]
        public string Address { get; set; }


        public virtual Campus Campus { get; set; }
        public int CampusId { get; set; }

    

        public virtual ResidenceType ResidenceType { get; set; }
        public int ResidenceTypeId { get; set; }

        public virtual List<HouseParent> HouseParents { get; set; }
        public virtual List<StudentRole> StudentRoles { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<ResidenceAllocationAuditLog> AllocationLog { get; set; }

        public virtual List< Block> Blocks { get; set; }
        public virtual List<Announcement> Announcements { get; set; }
        public Residence()
        {
            HouseParents = new List<HouseParent>();
            StudentRoles = new List<StudentRole>();
            Students = new List<Student>();
            AllocationLog = new List<ResidenceAllocationAuditLog>();
            Blocks = new List<Block>();
            Announcements = new List<Announcement>();

        }
   }
}
