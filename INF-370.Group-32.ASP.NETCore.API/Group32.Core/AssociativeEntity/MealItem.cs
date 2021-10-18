using Group32.Core.VillageFreshManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.AssociativeEntity
{
    public  class MealItem
    {
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
   
}
