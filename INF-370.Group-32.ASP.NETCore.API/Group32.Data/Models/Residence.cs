using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Residence
    {
        public Residence()
        {
            BlockFloors = new HashSet<BlockFloor>();
            BuildingCoordinators = new HashSet<BuildingCoordinator>();
            Events = new HashSet<Event>();
            HouseParents = new HashSet<HouseParent>();
            ResidenceDateTimeSlots = new HashSet<ResidenceDateTimeSlot>();
            StudentRoles = new HashSet<StudentRole>();
            Students = new HashSet<Student>();
        }

        public int ResidenceId { get; set; }
        public int ResidenceTypeId { get; set; }
        public int CampusId { get; set; }
        public string ResidenceName { get; set; }
        public string ResidenceAddrress { get; set; }

        public virtual Campus Campus { get; set; }
        public virtual ResidenceType ResidenceType { get; set; }
        public virtual ICollection<BlockFloor> BlockFloors { get; set; }
        public virtual ICollection<BuildingCoordinator> BuildingCoordinators { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<HouseParent> HouseParents { get; set; }
        public virtual ICollection<ResidenceDateTimeSlot> ResidenceDateTimeSlots { get; set; }
        public virtual ICollection<StudentRole> StudentRoles { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
