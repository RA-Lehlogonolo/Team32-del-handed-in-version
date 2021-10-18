using Group32.Core.VillageFreshManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.AssociativeEntity
{
    public class MenuTypeDay
    {
        public int MenuTypeId { get; set; }
        public MenuType MenuType { get; set; }
        public int DayId { get; set; }
        public Day Day { get; set; }
        public IList<MenuTypeDayMealType> MenuTypeDayMealTypes { get; set; }



    }
}
