using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.ResidenceManagement.Rooms
{
    public class UploadBlockRoomsInCSVDto
    {
        [Required]
        public string FileUrl { get; set; }

    }
}
