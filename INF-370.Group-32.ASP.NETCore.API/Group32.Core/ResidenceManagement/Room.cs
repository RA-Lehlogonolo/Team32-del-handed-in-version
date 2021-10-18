using Group32.Core.AssociativeEntity;
using Group32.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.ResidenceManagement
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string RoomNumber { get; set; }
        public string Corridor { get; set; }
        public string RoomType { get; set; }
        public string RoomStatus { get; set; }

        public virtual Block Block { get; set; }
        public int BlockId { get; set; }
        public IList<StudentRoom> StudentRooms { get; set; }
        public Room()
        {
            StudentRooms = new List<StudentRoom>();
        }
    }
}
    
