using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class MenuType
    {
        public MenuType()
        {
            MenuTypeDays = new HashSet<MenuTypeDay>();
        }

        public int MenuTypeId { get; set; }
        public string MenuTypeName { get; set; }

        public virtual ICollection<MenuTypeDay> MenuTypeDays { get; set; }
    }
}
