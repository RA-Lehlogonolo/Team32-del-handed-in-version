using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class MaintananceRequestType
    {
        public MaintananceRequestType()
        {
            MaintananceRequests = new HashSet<MaintananceRequest>();
        }

        public int MaintananceRequestTypeId { get; set; }
        public string MaintananceRequestTypeName { get; set; }

        public virtual ICollection<MaintananceRequest> MaintananceRequests { get; set; }
    }
}
