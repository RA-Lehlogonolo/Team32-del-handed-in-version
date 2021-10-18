using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class MaintananceRequest
    {
        public int MaintananceRequestId { get; set; }
        public int RoomId { get; set; }
        public int MaintanceRequestCategoryId { get; set; }
        public int MaintananceRequestTypeId { get; set; }
        public string MaintananceRequestDescription { get; set; }
        public DateTime? Date { get; set; }

        public virtual MaintananceRequestType MaintananceRequestType { get; set; }
        public virtual Room Room { get; set; }
    }
}
