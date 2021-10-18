using Group32.Core.AssociativeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.VillageFreshManagement
{
    public class Day
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public IList<MenuTypeDay> MenuTypeDays { get; set; }

    }

}
