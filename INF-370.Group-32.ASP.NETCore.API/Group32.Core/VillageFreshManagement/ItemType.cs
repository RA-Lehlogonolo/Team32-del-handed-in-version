using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.VillageFreshManagement
{
    public class ItemType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual List<Item> Items { get; set; }
        public ItemType()
        {
            Items= new List<Item>();

        }
    }
    
}
