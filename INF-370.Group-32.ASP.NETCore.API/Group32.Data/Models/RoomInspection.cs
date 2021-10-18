using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class RoomInspection
    {
        public RoomInspection()
        {
            Rooms = new HashSet<Room>();
        }

        public int RoomInspectionId { get; set; }
        public DateTime? Date { get; set; }
        public string CurtainBlinds { get; set; }
        public string CurtainRailHooks { get; set; }
        public string Globes { get; set; }
        public string LightSwitehes { get; set; }
        public string StudyDesk { get; set; }
        public string Chair { get; set; }
        public string WardrobeDoors { get; set; }
        public string Mattress { get; set; }
        public string WallSockets { get; set; }
        public string RoomDoor { get; set; }
        public string DoorLock { get; set; }
        public string Mirror { get; set; }
        public string WardrobeShelves { get; set; }
        public string Ceiling { get; set; }
        public string Walls { get; set; }
        public string FloorCarpet { get; set; }
        public string Other { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
