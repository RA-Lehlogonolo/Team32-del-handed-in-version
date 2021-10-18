using Group32.Core.Identity;
using Group32.Core.Users;
using Group32.Data.Context;
using Group32.Services.Dtos.Users.HouseParents;
using Group32.Services.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.UsersManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseParentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public HouseParentsController(
            AppDbContext context,
            RoleManager<AppRole> roleManager,
            UserManager<AppUser> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpGet("ResendAccountCreatedNotification/{houseParentId}")]
        public ActionResult ResendAccountCreatedNotification(int houseParentId)
        {
            var houseParent = _context.HouseParents
                .First(item => item.Id == houseParentId);
            var notificationExtenstion = new NotificationsExtension(_configuration);

            notificationExtenstion.NewHouseParentNotification(houseParent.Id);

            return Ok();
        }

        [HttpPost("{username}")]
        public async Task<ActionResult> Add(AddHouseParentDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {

                var appUsers = _context.AppUsers
                    .FirstOrDefault(item =>
                        string.Equals(item.Email, model.EmailAddress) ||
                        string.Equals(item.PhoneNumber, model.PhoneNumber));


                if (appUsers == null)
                {
                    var emailExists = await _userManager.FindByEmailAsync(model.EmailAddress);
                    if (emailExists != null)
                    {
                        message = "Account with provided email address already exist.";
                        return BadRequest(new { message });
                    }


                    var assignedPassword = UserManagementExtensions.GenerateRandomPassword();
                    var role = await _roleManager.FindByNameAsync("House Parent".ToLower());
                    if (role == null)
                    {
                        message = "House Parent Role not found";
                        return BadRequest(new { message });
                    }


                    var newUser = new AppUser()
                    {
                        UserName = model.Username,
                        Email = model.EmailAddress,
                        PhoneNumber = model.PhoneNumber,
                        Name = model.Name,
                        Surname = model.Surname,
                        AutoAssignedPassword = assignedPassword
                    };
                    var result = await _userManager.CreateAsync(newUser, assignedPassword);

                    if (result.Succeeded)
                    {

                        await _userManager.AddToRoleAsync(newUser, role.Name);

                        var newHouseParent = new HouseParent()
                        {
                            AppUserId = newUser.Id,
                            ResidenceId = model.ResidenceId
                        };
                        await _context.HouseParents.AddAsync(newHouseParent);
                        await _context.SaveChangesAsync();

                        var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                        var code = HttpUtility.UrlEncode(emailToken);

                        var user = await _userManager.FindByNameAsync(newUser.Email);
                        var notificationExtenstion = new NotificationsExtension(_configuration);
                        notificationExtenstion.NewHouseParentNotification(newHouseParent.Id);
                        return Ok();

                    }
                }

                message = "An account matching the provided details already exists.";
                return BadRequest(new { message });
            }
            message = "Something went wrong on your side. Please check your connection & try again.";
            return BadRequest(new { message });
        }

        [HttpGet("{id}")]
        public ActionResult<GetHouseParentDto> GetHouseParent(int id)
        {
            var recordInDb = _context.HouseParents
                .Where(item => item.Id == id)
                .Include(item => item.AppUser)
                .Include(item => item.Residence)
                .Select(item => new GetHouseParentDto()
                {
                    Id = item.Id,
                    AppUserId = item.AppUserId,
                    Name = item.AppUser.Name,
                    Surname = item.AppUser.Surname,
                    Username = item.AppUser.UserName,
                    PhoneNumber = item.AppUser.PhoneNumber,
                    AutoAssignedPassword = item.AppUser.AutoAssignedPassword,
                    EmailAddress = item.AppUser.Email,
                    ResidenceName = item.Residence.Name,

                }).First();

            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetHouseParentDto>> GetAllHouseParents()
        {
            var recordsInDb = _context.HouseParents
                .Include(item => item.AppUser)
                .Include(item => item.Residence)
                .Select(item => new GetHouseParentDto()
                {
                    Id = item.Id,
                    AppUserId = item.AppUserId,
                    Name = item.AppUser.Name,
                    Surname = item.AppUser.Surname,
                    Username = item.AppUser.UserName,
                    PhoneNumber = item.AppUser.PhoneNumber,
                    AutoAssignedPassword = item.AppUser.AutoAssignedPassword,
                    EmailAddress = item.AppUser.Email,
                    ResidenceName = item.Residence.Name,

                }).OrderBy(item => item.Name).ToList();

            return recordsInDb;
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<HouseParent>> Delete(int id)
        {
            var recordInDb = await _context.HouseParents.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }
            _context.HouseParents.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{username}/{id}")]
        public IActionResult Update(UpdateHouseParentDto model, string username, int id)
        {

            if (ModelState.IsValid)
            {
                var recordInDb = _context.HouseParents.FirstOrDefault(item => item.Id == id);
                if (recordInDb == null)
                {
                    return NotFound();
                }

                recordInDb.AppUser.Name = model.Name;
                recordInDb.AppUser.Surname = model.Surname;
                recordInDb.AppUser.Email = model.EmailAddress;
                recordInDb.AppUser.PhoneNumber = model.PhoneNumber;
                recordInDb.ResidenceId = model.ResidenceId;
                _context.SaveChanges();

                return Ok();
            }

            var message = "Something went wrong on your side.";
            return BadRequest(new { message });

        }
        
    }
}
