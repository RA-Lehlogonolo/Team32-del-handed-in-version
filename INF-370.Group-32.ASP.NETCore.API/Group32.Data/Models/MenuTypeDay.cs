using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class MenuTypeDay
    {
        public MenuTypeDay()
        {
            MenuTypeDayMealTypes = new HashSet<MenuTypeDayMealType>();
        }

        public int MenuTypeId { get; set; }
        public int DayId { get; set; }

        public virtual Day Day { get; set; }
        public virtual MenuType MenuType { get; set; }
        public virtual ICollection<MenuTypeDayMealType> MenuTypeDayMealTypes { get; set; }
    }
}
