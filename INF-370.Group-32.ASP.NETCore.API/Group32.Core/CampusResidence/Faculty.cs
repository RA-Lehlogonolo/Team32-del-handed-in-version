using Group32.Core.ResidenceManagement;
using Group32.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.CampusResidence
{

   public class Faculty
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual Campus Campus { get; set; }
        public int CampusId { get; set; }

        public virtual List<Student> Students { get; set; }

        public Faculty()
        {
            Students = new List<Student>();
        }
    }
}
