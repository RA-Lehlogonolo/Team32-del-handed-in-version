using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.ResidenceManagement.Block
{ 
    public class GetBlockDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResidenceName { get; set; }
        public int ResidenceId { get; set; }
    }
}
