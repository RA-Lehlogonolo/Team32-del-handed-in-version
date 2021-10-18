using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Users.Students
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string StudentNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AutoAssignedPassword { get; set; }
        public string ResidenceName { get; set; }
        public string FacultyName { get; set; }
        public string StudentRole { get; set; }
        public string Gender { get; set; }
        public string AssignedToRoom { get; set; }
        public string LevelOfStudy { get; set; }
    }
}
