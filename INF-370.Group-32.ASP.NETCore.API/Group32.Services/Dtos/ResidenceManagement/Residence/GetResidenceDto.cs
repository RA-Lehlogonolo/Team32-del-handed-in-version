using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.ResidenceManagement.Residence
{
  public  class GetResidenceDto
    {

        public int Id { get; set; }


        public string Name { get; set; }

        public string Address { get; set; }

        public string CampusName { get; set; }
        public int CampusId { get; set; }

        public string ResidenceType { get; set; }
        public int ResidenceTypeId { get; set; }
    }
}
