using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class SystemRole
    {
        public SystemRole()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
