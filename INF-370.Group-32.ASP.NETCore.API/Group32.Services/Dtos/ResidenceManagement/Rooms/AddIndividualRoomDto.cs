using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.ResidenceManagement.Room
{
    public class AddIndividualRoomDto
    {
        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public string Corridor { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        public int BlockId { get; set; }

        [Required]
        public string RoomStatus { get; set; }

    }
}
    
