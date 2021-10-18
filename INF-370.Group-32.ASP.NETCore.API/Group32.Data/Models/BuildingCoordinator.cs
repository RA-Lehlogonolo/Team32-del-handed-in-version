using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class BuildingCoordinator
    {
        public int BuildingCoordinatorId { get; set; }
        public int ResidenceId { get; set; }

        public virtual Residence Residence { get; set; }
    }
}
