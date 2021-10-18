using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class Announcement
    {
        public Announcement()
        {
            Users = new HashSet<User>();
        }

        public int AnnouncementId { get; set; }
        public int AnnouncementType { get; set; }
        public string AnnouncementName { get; set; }
        public string AnnouncementDescription { get; set; }
        public string Date { get; set; }

        public virtual AnnouncementType AnnouncementTypeNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
