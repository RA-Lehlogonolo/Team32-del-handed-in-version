using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Users.Students
{

   public class AddIndividualStudentDto
    {
        [Required]
        public string StudentNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int ResidenceId { get; set; }

        [Required]
        public int FacultyId { get; set; }
        [Required]
        public string LevelOfStudy { get; set; }

  

        [Required]
        public string Gender { get; set; }
        [Required]
        public string AssignedToRoom { get; set; }
    }
}
