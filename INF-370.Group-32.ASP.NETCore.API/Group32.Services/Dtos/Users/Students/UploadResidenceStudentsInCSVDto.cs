using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Users.Students
{

   public class UploadResidenceStudentsInCSVDto
    {
        [Required]
        public string FileUrl { get; set; }
    }
}
