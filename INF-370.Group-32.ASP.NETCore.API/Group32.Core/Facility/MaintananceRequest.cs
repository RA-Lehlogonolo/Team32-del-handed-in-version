using Group32.Core.AssociativeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.Facility
{
    public class MaintananceRequest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public string Date { get; set; }
       
        public virtual MaintananceRequestType MaintananceRequestType { get; set; }
        public int MaintananceRequestTypeId { get; set; }
        public virtual MaintananceRequestCategory MaintananceRequestCategory { get; set; }
        public int MaintananceRequestCategoryId { get; set; }


        //referencing fk student rooms
        public virtual StudentRoom StudentRoom { get; set; }
        public int StudentId { get; set; }
        public int RoomId { get; set; }

        public MaintananceRequest()
        {

        }

    }
}
