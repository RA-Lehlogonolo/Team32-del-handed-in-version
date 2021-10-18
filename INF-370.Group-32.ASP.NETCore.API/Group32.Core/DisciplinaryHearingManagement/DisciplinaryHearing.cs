using Group32.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.DisciplinaryHearingManagement
{
    public class DisciplinaryHearing
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Desscription { get; set; }

        [Required]
        [MaxLength(255)]
        public string Venue { get; set; }

        [Required]
        [MaxLength(255)]
        public string Date { get; set; }

        public virtual MisconductType MisconductType { get; set; }
        public int MisconductTypeId { get; set; }
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }

    }
}
    
