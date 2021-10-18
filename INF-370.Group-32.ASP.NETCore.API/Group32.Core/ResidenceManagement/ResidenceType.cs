using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.ResidenceManagement
{
  public   class ResidenceType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        public virtual List<Residence> Residences { get; set; }

        public ResidenceType()
        {
            Residences = new List<Residence>();
        }
    }
}
