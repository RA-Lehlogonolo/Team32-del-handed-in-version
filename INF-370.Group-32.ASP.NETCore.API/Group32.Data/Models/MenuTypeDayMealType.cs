using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class MenuTypeDayMealType
    {
        public MenuTypeDayMealType()
        {
            MenuRotations = new HashSet<MenuRotation>();
        }

        public int MenuTypeId { get; set; }
        public int DayId { get; set; }
        public int MealTypeId { get; set; }
        public int MenuRotationId { get; set; }
        public int MealId { get; set; }
        public string MenuTitle { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual MealType MealType { get; set; }
        public virtual MenuRotation MenuRotation { get; set; }
        public virtual MenuTypeDay MenuTypeDay { get; set; }
        public virtual ICollection<MenuRotation> MenuRotations { get; set; }
    }
}
