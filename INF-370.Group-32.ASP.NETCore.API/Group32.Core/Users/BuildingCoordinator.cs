using Group32.Core.Identity;
using Group32.Core.ResidenceManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.Users
{
  public  class BuildingCoordinator
    {
        public int Id { get; set; }


        public virtual Residence Residence { get; set; }
        public int ResidenceId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
