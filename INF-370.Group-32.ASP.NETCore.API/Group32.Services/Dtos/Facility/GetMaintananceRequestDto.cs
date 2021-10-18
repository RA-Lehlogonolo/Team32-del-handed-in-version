using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Facility
{
    public class GetMaintananceRequestDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public string MaintananceRequestTypeName { get; set; }
        
        public int MaintananceRequestTypeId{ get; set; }

        public string MaintananceRequestCategoryName { get; set; }
        public int MaintananceRequestCategoryId { get; set; }
    }
}
