using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Item
    {
        public Item()
        {
            MealItems = new HashSet<MealItem>();
        }

        public int ItemId { get; set; }
        public int ItemTypeId { get; set; }
        public string ItemName { get; set; }

        public virtual ItemType ItemType { get; set; }
        public virtual ICollection<MealItem> MealItems { get; set; }
    }
}
