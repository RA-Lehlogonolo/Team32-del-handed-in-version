using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.ResidenceManagement.Block
{
    public class AddOrUpdateBlockDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public int ResidenceId { get; set; }

    }
    
}
