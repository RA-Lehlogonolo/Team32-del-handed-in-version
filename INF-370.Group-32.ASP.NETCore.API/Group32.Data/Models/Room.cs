using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Room
    {
        public Room()
        {
            MaintananceRequests = new HashSet<MaintananceRequest>();
        }

        public int RoomId { get; set; }
        public int? RoomInspectionId { get; set; }
        public int BlockId { get; set; }
        public string RoomNumber { get; set; }
        public string Corridor { get; set; }
        public string RoomType { get; set; }
        public string RoomStatus { get; set; }

        public virtual BlockFloor Block { get; set; }
        public virtual RoomInspection RoomInspection { get; set; }
        public virtual ICollection<MaintananceRequest> MaintananceRequests { get; set; }
    }
}
