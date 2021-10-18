using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.ResidenceManagement.Residence
{
    public class AddOrUpdateResidenceDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        public int CampusId { get; set; }

        [Required]
        public int ResidenceTypeId { get; set; }

    }
}
