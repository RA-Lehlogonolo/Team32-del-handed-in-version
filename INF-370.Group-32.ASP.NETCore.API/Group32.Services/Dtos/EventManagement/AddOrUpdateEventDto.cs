using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Services.Dtos.EventManagement
{
  public class AddOrUpdateEventDto
  {
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Required]
    [MaxLength(255)]
    public string Location { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Date { get; set; }

    [Required]
    public int ResidenceId { get; set; }

    [Required]
    public int EventTypeId { get; set; }
  }

  
    
}
