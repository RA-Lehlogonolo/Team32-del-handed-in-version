using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Students = new HashSet<Student>();
        }

        public int FacultyId { get; set; }
        public int CampusId { get; set; }
        public string FacultyName { get; set; }

        public virtual Campus Campus { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
