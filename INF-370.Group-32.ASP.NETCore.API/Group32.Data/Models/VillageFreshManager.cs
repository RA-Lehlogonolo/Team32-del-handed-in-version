using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class VillageFreshManager
    {
        public int VillageFreshManagerId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
