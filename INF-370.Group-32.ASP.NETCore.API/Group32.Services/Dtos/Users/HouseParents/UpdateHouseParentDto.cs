using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.Users.HouseParents
{
    public class UpdateHouseParentDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int ResidenceId { get; set; }
    }
}
