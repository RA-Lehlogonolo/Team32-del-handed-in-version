using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class MenuRotation
    {
        public MenuRotation()
        {
            MenuTypeDayMealTypes = new HashSet<MenuTypeDayMealType>();
        }

        public int MenuRotationId { get; set; }
        public int MenuTypeId { get; set; }
        public int DayId { get; set; }
        public int MealTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual MenuTypeDayMealType MenuTypeDayMealType { get; set; }
        public virtual ICollection<MenuTypeDayMealType> MenuTypeDayMealTypes { get; set; }
    }
}
