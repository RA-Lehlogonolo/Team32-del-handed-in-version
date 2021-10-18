using Group32.Core.VillageFreshManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.AssociativeEntity
{
    public    class MenuTypeDayMealType
    {
        public int MenuTypeId { get; set; }
        public MenuType MenuType { get; set; }
        public int DayId { get; set; }
        public Day Day { get; set; }
        public int MealTypeId { get; set; }
        public MealType MealType { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }


    }

}
