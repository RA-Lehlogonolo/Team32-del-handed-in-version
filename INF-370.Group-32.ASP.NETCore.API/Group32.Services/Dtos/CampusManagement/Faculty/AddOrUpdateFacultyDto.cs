using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.CampusManagement.Faculty
{
   public class AddOrUpdateFacultyDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CampusId { get; set; }
    }
}
