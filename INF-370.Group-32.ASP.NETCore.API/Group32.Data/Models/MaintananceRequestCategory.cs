using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class MaintananceRequestCategory
    {
        public int MaintanceRequestCategoryId { get; set; }
        public int MaintananceRequestTypeId { get; set; }
        public string MaintananceRequestCategoryName { get; set; }
    }
}
