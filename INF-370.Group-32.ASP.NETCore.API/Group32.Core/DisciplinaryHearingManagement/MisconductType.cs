using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.DisciplinaryHearingManagement
{
    public  class MisconductType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public virtual List<DisciplinaryHearing> DisciplinaryHearings   { get; set; }
        public MisconductType()
        {
            DisciplinaryHearings = new List<DisciplinaryHearing>();

        }
    }
}
