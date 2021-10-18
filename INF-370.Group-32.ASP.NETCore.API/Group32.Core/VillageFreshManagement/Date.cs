using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.VillageFreshManagement
{
    public   class Date
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]

        public DateTime date { get; set; }
    }
  
}
