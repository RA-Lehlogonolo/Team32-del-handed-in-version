using System;
using System.Collections.Generic;

#nullable disable

namespace Group32.Data.Models
{
    public partial class AnnouncementType
    {
        public AnnouncementType()
        {
            Announcements = new HashSet<Announcement>();
        }

        public int AnnouncementType1 { get; set; }
        public string AnnouncementTypeName { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
