using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.AnnouncementManagement
{
  public class AnnouncementType
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    public virtual List<Announcement> Announcements { get; set; }
    public AnnouncementType()
    {
      Announcements = new List<Announcement>();
    }
  }
}
