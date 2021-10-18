using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Authentication
{
   public  class LogInDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
