using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class MealItem
    {
        public int MealId { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
