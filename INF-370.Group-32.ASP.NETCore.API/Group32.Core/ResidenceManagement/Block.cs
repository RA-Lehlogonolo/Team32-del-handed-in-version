using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.ResidenceManagement
{
    public class Block
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public virtual Residence Residence { get; set; }
        public int ResidenceId { get; set; }

        public virtual List<Room> Rooms { get; set; }


        public Block()
        {
            Rooms = new List<Room>();
        }
    }

}
