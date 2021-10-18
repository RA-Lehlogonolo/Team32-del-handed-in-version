using Group32.Core.ResidenceManagement;
using Group32.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.ResidenceManagement
{
  public  class StudentRole
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual Residence Residence { get; set; }
        public int ResidenceId { get; set; }

        public virtual List<Student> Students { get; set; }

        public StudentRole()
        {
            Students = new List<Student>();
        }
    }
}
