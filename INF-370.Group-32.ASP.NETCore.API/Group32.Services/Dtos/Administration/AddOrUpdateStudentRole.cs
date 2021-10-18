using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Administration
{
  public  class AddOrUpdateStudentRole
    {
        [Required]
        public int ResidenceId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
