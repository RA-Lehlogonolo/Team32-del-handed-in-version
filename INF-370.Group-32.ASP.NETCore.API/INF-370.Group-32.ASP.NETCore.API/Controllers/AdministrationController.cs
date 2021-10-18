using Group32.Core.Identity;
using Group32.Core.ResidenceManagement;
using Group32.Data.Context;
using Group32.Services.Dtos.Administration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdministrationController(
            AppDbContext appDbContext,
            RoleManager<AppRole> roleManager,
            UserManager<AppUser> userManager
            )
        {
            _appDbContext = appDbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        #region App Roles
        [HttpPost("Roles/Add/{username}")]
        public async Task<IActionResult> AddRole(AddOrUpdateRoleDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var rolesInDb = _roleManager.Roles.FirstOrDefault(item =>
                    string.Equals(item.Name.ToLower(), model.Name.ToLower()));

                if (rolesInDb != null)
                {
                    message = "Error: Role name already exist.";
                    return BadRequest(new { message });
                }

                var newRole = new AppRole()
                {
                    Name = model.Name,
                    Description = model.Description
                };

                var result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                {
                    return Ok();
                }

            }

            message = "Error: Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpPut("Roles/Update/{username}/{id}")]
        public async Task<IActionResult> UpdateRole(AddOrUpdateRoleDto model, string username, string id)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var roleInDb = _roleManager.Roles.FirstOrDefault(item =>
                    string.Equals(item.Id.ToLower(), id.ToLower()));

                if (roleInDb == null)
                {
                    message = "Error: Role not found.";
                    return BadRequest(new { message });
                }

                roleInDb.Name = model.Name;
                roleInDb.Description = model.Description;
                await _appDbContext.SaveChangesAsync();

                return Ok();

            }


            message = "Error: Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("Roles/Delete/{username}/{id}")]
        public async Task<IActionResult> DeleteRole(string username, string id)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var roleInDb = _roleManager.Roles.FirstOrDefault(item =>
                    string.Equals(item.Id.ToLower(), id.ToLower()));

                if (roleInDb == null)
                {
                    message = "Error: Role not found.";
                    return BadRequest(new { message });
                }

                var roleAppUsers = await _userManager.GetUsersInRoleAsync(roleInDb.Name);

                _appDbContext.AppUsers.RemoveRange(roleAppUsers);
                await _appDbContext.SaveChangesAsync();

                _appDbContext.AppRoles.Remove(roleInDb);
                await _appDbContext.SaveChangesAsync();

                return Ok();

            }

            message = "Error: Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpGet("Roles/GetAll")]
        public ActionResult<IEnumerable<GetUserRole>> GetAllUserRoles()
        {
            var userRolesInDb = _roleManager.Roles
                .Where(item => !string.Equals(item.Name.ToLower(), "admin".ToLower()))
                .Select(item => new GetUserRole
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description
                }).OrderBy(item => item.Name).ToList();

            return userRolesInDb;
        }
        #endregion

        #region Student Roles
        [HttpPost("StudentRole/Add/{username}")]
        public async Task<IActionResult> AddStudentRole(AddOrUpdateStudentRole model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var rolesInDb = _appDbContext.StudentRoles.FirstOrDefault(item =>
                    string.Equals(item.Name.ToLower(), model.Name.ToLower()));

                if (rolesInDb != null)
                {
                    message = "Error: Role name already exist.";
                    return BadRequest(new { message });
                }

                var newRole = new StudentRole
                {
                    Name = model.Name,
                    ResidenceId = model.ResidenceId

                };

                await _appDbContext.StudentRoles.AddAsync(newRole);
                await _appDbContext.SaveChangesAsync();

                return Ok();

            }

            message = "Error: Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpPut("StudentRole/Update/{username}/{id}")]
        public async Task<IActionResult> UpdateStudentRole(AddOrUpdateStudentRole model, string username, int id)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var roleInDb = _appDbContext.StudentRoles.FirstOrDefault(item => item.Id == id);


                if (roleInDb == null)
                {
                    message = "Error: Student Role not found.";
                    return BadRequest(new { message });
                }

                roleInDb.Name = model.Name;
                roleInDb.ResidenceId = model.ResidenceId;
                await _appDbContext.SaveChangesAsync();

                return Ok();

            }

            message = "Error: Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("StudentRole/Delete/{username}/{id}")]
        public async Task<IActionResult> DeleteStudentRole(string username, int id)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var roleInDb = _appDbContext.StudentRoles.FirstOrDefault(item => item.Id == id);

                if (roleInDb == null)
                {
                    message = "Error: Role not found.";
                    return BadRequest(new { message });
                }

                //TODO:Set All Students with Role to Normal Students
                //var studentsWithRole = _appDbContext.stu


                _appDbContext.StudentRoles.Remove(roleInDb);
                await _appDbContext.SaveChangesAsync();

                return Ok();

            }

            message = "Error: Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpGet("StudentRole/GetAll")]
        public ActionResult<IEnumerable<GetStudentRoleDto>> GetAllStudentRoles()
        {
            var userRolesInDb = _appDbContext.StudentRoles
                .Where(item => !string.Equals(item.Name.ToLower(), "NormalStudent".ToLower()))
                .Include(item => item.Residence)
                .Select(item => new GetStudentRoleDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    ResidenceName = item.Residence.Name,
                    ResidenceId = item.Residence.Id
                }).OrderBy(item => item.Name).ToList();

            return userRolesInDb;
        }

        [HttpGet("StudentRole/GetAll/WithNormalStudent")]
        public ActionResult<IEnumerable<GetStudentRoleDto>> GetAllStudentRolesForUpdates()
        {
            var userRolesInDb = _appDbContext.StudentRoles
                .Include(item => item.Residence)
                .Select(item => new GetStudentRoleDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    ResidenceName = item.Residence.Name,
                    ResidenceId = item.Residence.Id
                }).OrderBy(item => item.Name).ToList();

            return userRolesInDb;
        }

        #endregion
    }
}
