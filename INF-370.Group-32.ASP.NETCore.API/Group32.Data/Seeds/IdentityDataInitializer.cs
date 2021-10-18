using Group32.Core.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group32.Data.Seeds
{
   public  class IdentityDataInitializer
    {
        public static void SeedDatabase(
            UserManager<AppUser> userManager,
            RoleManager<AppRole>roleManager )
        {
            SeedRoles(roleManager).Wait();
            SeedUsers(userManager).Wait();

        }
        public static async Task  SeedRoles(RoleManager<AppRole> roleManager)
        {
            var isAdminRoleIbDb = await roleManager.RoleExistsAsync("Admin".ToLower());
            if (!isAdminRoleIbDb)
            {
                var role = new AppRole()
                {
                    Name = "Admin".ToLower(),
                 
                };
                await roleManager.CreateAsync(role);
            }
        }
        public static async Task SeedUsers( UserManager<AppUser> userManager)
        {
            var isAdminInDb = await userManager.FindByNameAsync("HouseParent".ToLower());
            if (isAdminInDb == null)
            {
                var adminUser = new AppUser()
                {
                    UserName = "houseparent".ToLower(),
                    Email = "houseparent@up.ac.za",
                    Name = "Mbali",
                    Surname = "Dhlomo",
                    AutoAssignedPassword = "Admin12345$"
                };

                var result = await userManager.CreateAsync(adminUser, "Admin12345$");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin".ToLower ());
                }
            }
        }
    }
}
