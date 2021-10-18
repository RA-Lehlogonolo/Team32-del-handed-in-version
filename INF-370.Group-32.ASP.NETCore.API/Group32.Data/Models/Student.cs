using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            Relationship34s = new HashSet<Relationship34>();
            StudentEvents = new HashSet<StudentEvent>();
            StudentRoles = new HashSet<StudentRole>();
            StudentVisitations = new HashSet<StudentVisitation>();
        }

        public int StudentId { get; set; }
        public int UserId { get; set; }
        public int ResidenceId { get; set; }
        public int FacultyId { get; set; }
        public int StudentRoleId { get; set; }
        public string LevelOfStudy { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual Residence Residence { get; set; }
        public virtual StudentRole StudentRole { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Relationship34> Relationship34s { get; set; }
        public virtual ICollection<StudentEvent> StudentEvents { get; set; }
        public virtual ICollection<StudentRole> StudentRoles { get; set; }
        public virtual ICollection<StudentVisitation> StudentVisitations { get; set; }
    }
}
