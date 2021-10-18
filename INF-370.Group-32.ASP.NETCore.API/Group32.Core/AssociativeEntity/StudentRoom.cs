using Group32.Core.Facility;
using Group32.Core.ResidenceManagement;
using Group32.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.AssociativeEntity
{
    public class StudentRoom
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
        public string MoveInDate { get; set; }
        public string MoveOutDate { get; set; }
        public virtual List<MaintananceRequest> MaintananceRequests { get; set; }
        public StudentRoom()
        {
            MaintananceRequests = new List<MaintananceRequest>();
        }
    }
}
