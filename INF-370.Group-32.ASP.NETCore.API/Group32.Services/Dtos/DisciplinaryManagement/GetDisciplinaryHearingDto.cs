using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.DisciplinaryManagement
{
    public  class GetDisciplinaryHearingDto
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string Venue { get; set; }
        public string Date { get; set; }

        public string MisconductType { get; set; }
        public int MisconductTypeId { get; set; }

    }
   
}
