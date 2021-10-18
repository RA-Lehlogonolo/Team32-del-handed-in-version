using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.CampusManagement.Faculty
{
    public class GetFacultyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CampusName { get; set; }
        public int CampusId { get; set; }

    }
}
