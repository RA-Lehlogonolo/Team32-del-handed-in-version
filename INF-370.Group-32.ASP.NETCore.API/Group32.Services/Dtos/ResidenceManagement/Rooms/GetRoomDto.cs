using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.ResidenceManagement.Room
{
    public class GetRoomDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Corridor { get; set; }
        public string RoomType { get; set; }
        public string BlockName { get; set; }

        public int  BlockId { get; set; }
       
        public string RoomStatus { get; set; }

    }
    
}
