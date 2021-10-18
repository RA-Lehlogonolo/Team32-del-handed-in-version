using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Facility
{


    public class GetMaintananceRequestCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MaintananceRequestTypeName { get; set; }
        public int MaintananceRequestTypeId { get; set; }

    }
}
