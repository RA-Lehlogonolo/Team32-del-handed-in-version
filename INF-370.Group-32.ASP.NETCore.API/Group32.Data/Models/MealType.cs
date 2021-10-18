using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class MealType
    {
        public MealType()
        {
            MenuTypeDayMealTypes = new HashSet<MenuTypeDayMealType>();
        }

        public int MealTypeId { get; set; }
        public string MealTypeName { get; set; }

        public virtual ICollection<MenuTypeDayMealType> MenuTypeDayMealTypes { get; set; }
    }
}
