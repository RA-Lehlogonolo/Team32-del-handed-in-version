using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.DisciplinaryManagement
{
    public class AddOrUpdateDisciplinaryHearingDto
    {
        [Required]
        [MaxLength(255)]
        public string Decription { get; set; }


        [Required]
        [MaxLength(255)]
        public string Venue { get; set; }

        [Required]
        [MaxLength(255)]
        public string Date { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int MisconductTypeId { get; set; }

    }
}
    
