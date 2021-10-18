using Group32.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Group32.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Group32.Services.Extensions
{ 
  public  class NotificationsExtension
    {
        private readonly IConfiguration _configuration;

        public NotificationsExtension(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void NewHouseParentNotification(int houseParentId)
        {
            var context = new AppDbContext(_configuration);
            var to = context.HouseParents.Where(item => item.Id == houseParentId)
                .Include(item => item.AppUser)
                .Include(item => item.Residence)
                .Single();


            var subjectLine = "[TuksVillage Board] House Parent Account";

            var htmlMessageToApplicant = $"<p>Hi " + to.AppUser.Name + ",<br><br><br>You have been added as a house parent for " + to.Residence.Name + ".<br><br>" +
                                         $"Use these credentials to sign in" +
                                         $"<br/><br/>" +
                                         "Username: " + to.AppUser.UserName + "<br/><br/>" + "Auto-generated Password: " + to.AppUser.AutoAssignedPassword +
                                         " <br/><br/> " +
                                         $"You will have to change the auto generated password" +
                                         "Thanks,<br/>" +
                                         "TuksVillage Board Online Systm";

            var planTextMessage = "Here are your login details, Username: "
                                  + to.AppUser.UserName +
                                  ", Password: " + to.AppUser.AutoAssignedPassword;

            Email.SendGenericEmail("ngcebomasilela445@gmail.com", "TUksVillage Board", to.AppUser.Email, to.AppUser.Name, subjectLine, htmlMessageToApplicant, planTextMessage);
        }
        public void NewStudentNotification(int studentId)
        {
            var context = new AppDbContext(_configuration);
            var to = context.Students.Where(item => item.Id == studentId)
                .Include(item => item.AppUser)
                .Include(item => item.Residence)
                .Include(item => item.Faculty)
                .Include(item => item.StudentRole)
                .Single();


            var subjectLine = "[TuksVillage Board] Student Account";

            var htmlMessageToApplicant = $"<p>Hi " + to.AppUser.Name + ",<br><br><br>You have been added as a student to our online system and assigned to the residence: " + to.Residence.Name + ".<br><br>" +
                                         $"Use these credentials to sign in" +
                                         $"<br/><br/>" +
                                         "Username: " + to.AppUser.UserName + "<br/><br/>" + "Auto-generated Password: " + to.AppUser.AutoAssignedPassword +
                                         " <br/><br/> " +
                                         $"You will have to change the auto generated password" +
                                         "Thanks,<br/>" +
                                         "TuksVillage Board Online System";

            var planTextMessage = "Here are your login details, Username: "
                                  + to.AppUser.UserName +
                                  ", Password: " + to.AppUser.AutoAssignedPassword;

            Email.SendGenericEmail("ngcebomasilela445@gmail.com", "TUksVillage Board", to.AppUser.Email, to.AppUser.Name, subjectLine, htmlMessageToApplicant, planTextMessage);
        }
        public void NewBuildingCordinatorNotification(int buildingCoordinatorId)
        {
            var context = new AppDbContext(_configuration);
            var to = context.buildingCoordinators.Where(item => item.Id == buildingCoordinatorId)
                .Include(item => item.AppUser)
                .Include(item => item.Residence)
                .Single();


            var subjectLine = "[TuksVillage Board] Building Coordinator Account";

            var htmlMessageToApplicant = $"<p>Hi " + to.AppUser.Name + ",<br><br><br>You have been added as a house parent for " + to.Residence.Name + ".<br><br>" +
                                         $"Use these credentials to sign in" +
                                         $"<br/><br/>" +
                                         "Username: " + to.AppUser.UserName + "<br/><br/>" + "Auto-generated Password: " + to.AppUser.AutoAssignedPassword +
                                         " <br/><br/> " +
                                         $"You will have to change the auto generated password" +
                                         "Thanks,<br/>" +
                                         "TuksVillage Board Online System";

            var planTextMessage = "Here are your login details, Username: "
                                  + to.AppUser.UserName +
                                  ", Password: " + to.AppUser.AutoAssignedPassword;

           Email.SendGenericEmail("ngcebomasilela445@gmail.com", "TUksVillage Board", to.AppUser.Email, to.AppUser.Name, subjectLine, htmlMessageToApplicant, planTextMessage);
        }
        public void NewVillageFreshManagerNotification(int villageFreshManagerId)
        {
            var context = new AppDbContext(_configuration);
            var to = context.villageFreshMs.Where(item => item.Id == villageFreshManagerId)
                .Include(item => item.AppUser)
                .Single();


            var subjectLine = "[TuksVillage Board] Village Fresh Manager Account";

            var htmlMessageToApplicant = $"<p>Hi " + to.AppUser.Name + ",<br><br><br>You have been added as a villageFresh Manager  " +   ".<br><br>" +
                                         $"Use these credentials to sign in" +
                                         $"<br/><br/>" +
                                         "Username: " + to.AppUser.UserName + "<br/><br/>" + "Auto-generated Password: " + to.AppUser.AutoAssignedPassword +
                                         " <br/><br/> " +
                                         $"You will have to change the auto generated password" +
                                         "Thanks,<br/>" +
                                         "TuksVillage Board Online System";

            var planTextMessage = "Here are your login details, Username: "
                                  + to.AppUser.UserName +
                                  ", Password: " + to.AppUser.AutoAssignedPassword;

           Email.SendGenericEmail("ngcebomasilela445@gmail.com", "TUksVillage Board", to.AppUser.Email, to.AppUser.Name, subjectLine, htmlMessageToApplicant, planTextMessage);
        }
    }
}
