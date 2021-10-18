using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.Facility
{

   public class MaintananceRequestCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual MaintananceRequestType MaintananceRequestType { get; set; }
        public int MaintananceRequestTypeId { get; set; }
        public virtual List<MaintananceRequest> MaintananceRequests { get; set; }

        public MaintananceRequestCategory()
        {
            MaintananceRequests = new List<MaintananceRequest>();
        }
    }
}
