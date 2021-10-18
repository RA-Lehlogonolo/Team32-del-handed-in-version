using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.AnnouncementManagement
{
  public class GetAnnouncementDto
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }

    public string AnnouncementType { get; set; }
    public int AnnouncementTypeId { get; set; }
    public string Residence { get; set; }
    public int ResidenceId { get; set; }
  }
}
    
