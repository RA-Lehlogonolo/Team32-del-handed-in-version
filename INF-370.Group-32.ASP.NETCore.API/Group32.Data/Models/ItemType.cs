using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class ItemType
    {
        public ItemType()
        {
            Items = new HashSet<Item>();
        }

        public int ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
