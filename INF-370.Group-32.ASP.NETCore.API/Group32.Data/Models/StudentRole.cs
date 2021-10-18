using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class StudentRole
    {
        public StudentRole()
        {
            Students = new HashSet<Student>();
        }

        public int StudentRoleId { get; set; }
        public int ResidenceId { get; set; }
        public int StudentId { get; set; }
        public string RoleName { get; set; }

        public virtual Residence Residence { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
