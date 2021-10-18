using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.VillageFreshManagement.Item
{
    public class GetItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ItemType { get; set; }
        public int ItemTypeId { get; set; }

    }

}
