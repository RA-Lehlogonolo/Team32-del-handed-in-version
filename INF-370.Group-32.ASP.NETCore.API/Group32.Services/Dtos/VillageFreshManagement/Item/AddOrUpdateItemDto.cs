using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.VillageFreshManagement.Item
{
    public class AddOrUpdateItemDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int ItemTypeId { get; set; }
    }
    
}
