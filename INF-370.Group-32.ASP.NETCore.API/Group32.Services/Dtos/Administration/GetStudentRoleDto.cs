using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Administration
{
  public  class GetStudentRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResidenceId { get; set; }
        public string ResidenceName { get; set; }
    }
}
