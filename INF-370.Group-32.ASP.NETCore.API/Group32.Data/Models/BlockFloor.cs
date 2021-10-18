using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class BlockFloor
    {
        public BlockFloor()
        {
            Rooms = new HashSet<Room>();
        }

        public int BlockId { get; set; }
        public int ResidenceId { get; set; }
        public string BlockName { get; set; }

        public virtual Residence Residence { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
