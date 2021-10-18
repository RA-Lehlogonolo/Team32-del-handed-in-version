using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.AnnouncementManagement
{
    public class AddOrUpdateAnnouncementDto
    {
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public int AnnouncementTypeId { get; set; }

        [Required]
        public int ResidenceId { get; set; }
    }
}
