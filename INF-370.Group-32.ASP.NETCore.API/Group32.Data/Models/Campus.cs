using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Campus
    {
        public Campus()
        {
            Faculties = new HashSet<Faculty>();
            Residences = new HashSet<Residence>();
        }

        public int CampusId { get; set; }
        public string CampusName { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<Residence> Residences { get; set; }
    }
}
