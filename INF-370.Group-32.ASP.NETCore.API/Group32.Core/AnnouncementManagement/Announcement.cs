using Group32.Core.ResidenceManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.AnnouncementManagement
{

  public class Announcement
  {
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    public string Date { get; set; }

    public virtual AnnouncementType AnnouncementType { get; set; }
    public int AnnouncementTypeId { get; set; }

    public virtual Residence Residence { get; set; }
    public int ResidenceId { get; set; }
    public Announcement()
    {

    }
  }

}
