using Group32.Core.AssociativeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.VillageFreshManagement
{
    public class Meal
    {
        public int Id { get; set; }
        public IList<MealItem> MealItems { get; set; }
        public IList<MenuTypeDayMealType> MenuTypeDayMealTypes { get; set; }

    }
}
    
