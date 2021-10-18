using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Meal
    {
        public Meal()
        {
            MealItems = new HashSet<MealItem>();
            MenuTypeDayMealTypes = new HashSet<MenuTypeDayMealType>();
        }

        public int MealId { get; set; }

        public virtual ICollection<MealItem> MealItems { get; set; }
        public virtual ICollection<MenuTypeDayMealType> MenuTypeDayMealTypes { get; set; }
    }
}
