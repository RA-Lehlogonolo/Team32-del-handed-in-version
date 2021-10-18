using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class User
    {
        public User()
        {
            DisciplinaryHearings = new HashSet<DisciplinaryHearing>();
            HouseParents = new HashSet<HouseParent>();
            Students = new HashSet<Student>();
            SystemRoles = new HashSet<SystemRole>();
            VillageFreshManagers = new HashSet<VillageFreshManager>();
        }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? AnnouncementId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Announcement Announcement { get; set; }
        public virtual SystemRole Role { get; set; }
        public virtual ICollection<DisciplinaryHearing> DisciplinaryHearings { get; set; }
        public virtual ICollection<HouseParent> HouseParents { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SystemRole> SystemRoles { get; set; }
        public virtual ICollection<VillageFreshManager> VillageFreshManagers { get; set; }
    }
}
