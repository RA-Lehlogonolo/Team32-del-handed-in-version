using Group32.Core.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Core.Identity
{

   public class AppUser : IdentityUser
  {
    [Required]
    [MaxLength(50)]
    //Extend the IdentityUser Class
    public string Name { get; set; }


    [Required]
    [MaxLength(50)]
    public string Surname { get; set; }

    [Required]
    [MaxLength(50)]
    public string AutoAssignedPassword { get; set; }

    public virtual HouseParent HouseParent { get; set; }
    public virtual BuildingCoordinator BuildingCoordinator { get; set; }
    public virtual VillageFreshM VillageFreshM { get; set; }
    public virtual Student Student { get; set; }
  }
}



    

