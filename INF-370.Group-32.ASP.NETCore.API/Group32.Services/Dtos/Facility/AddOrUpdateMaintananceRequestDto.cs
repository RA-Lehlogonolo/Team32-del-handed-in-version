using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Facility
{
    public class AddOrUpdateMaintananceRequestDto
    {

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }


        [Required]
        [MaxLength(255)]
        public string Date { get; set; }

        [Required]
        public int MaintananceRequestTypeId { get; set; }

        [Required]
        public int MaintananceRequestCategoryId { get; set; }

    }

   
}
