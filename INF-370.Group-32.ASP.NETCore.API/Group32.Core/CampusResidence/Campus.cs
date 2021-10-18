using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group32.Core.ResidenceManagement;

namespace Group32.Core.CampusResidence
{
   public class Campus
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual List<Residence> Residences { get; set; }

        public Campus()
        {
            Residences = new List<Residence>();
        }

    }
}
