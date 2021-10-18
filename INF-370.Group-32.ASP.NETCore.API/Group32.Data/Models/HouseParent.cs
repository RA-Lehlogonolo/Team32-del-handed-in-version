using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class HouseParent
    {
        public int HouseParentId { get; set; }
        public int? UserId { get; set; }
        public int ResidenceId { get; set; }

        public virtual Residence Residence { get; set; }
        public virtual User User { get; set; }
    }
}
