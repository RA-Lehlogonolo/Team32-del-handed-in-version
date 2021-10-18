using Group32.Core.AuditLogs;
using Group32.Core.Identity;
using Group32.Core.ResidenceManagement;
using Group32.Core.Users;
using Group32.Data.Context;
using Group32.Services.Dtos.Users.Students;
using Group32.Services.Extensions;
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
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public StudentsController(
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

        [HttpGet("ResendAccountCreatedNotification/{studentId}")]
        public ActionResult ResendAccountCreatedNotification(int studentId)
        {
            var houseParent = _context.Students
                .First(item => item.Id == studentId);
            var notificationExtenstion = new NotificationsExtension(_configuration);

            notificationExtenstion.NewStudentNotification(houseParent.Id);

            return Ok();
        }

        [HttpPost("AddMultiple/{username}/{residenceId}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<List<GetStudentDto>>> AddMultipleStudentsInCSV([FromBody] UploadResidenceStudentsInCSVDto modal, string username, int residenceId)
        {
            var isResidenceInDb = _context.Residences
                .FirstOrDefault(item => item.Id == residenceId);
            var message = "";
            if (isResidenceInDb == null)
            {
                message = "Error: Residence not found. Try adding residence first.";
                return BadRequest(new { message });
            }

            if (ModelState.IsValid)
            {

                var lines = await System.IO.File.ReadAllLinesAsync(@modal.FileUrl);
                var students = new List<AddIndividualStudentDto>();
                foreach (var line in lines.Skip(2))
                {

                    var rowItems = line.Split(';');
                    //Don't input csv empty rows
                    if (rowItems[(uint)StudentRecordInCSV.StudentNumber].Length > 1)
                    {
                        var facultyInDb = _context.Faculties
                            .FirstOrDefault(item => string.Equals(item.Name.ToLower(), rowItems[(uint)StudentRecordInCSV.Faculty].ToLower()));


                        if (facultyInDb == null)
                        {
                            message = $"Row {line}: Faculty at  not found. Add operation cancelled for all records. Correct error and upload again.";
                            return BadRequest(new { message });
                        }

                        var tempStudent = new AddIndividualStudentDto()
                        {
                            StudentNumber = rowItems[(uint)StudentRecordInCSV.StudentNumber],
                            Name = rowItems[(uint)StudentRecordInCSV.Name],
                            Surname = rowItems[(uint)StudentRecordInCSV.Surname],
                            PhoneNumber = "0" + rowItems[(uint)StudentRecordInCSV.PhoneNumber],
                            EmailAddress = rowItems[(uint)StudentRecordInCSV.StudentNumber] + "@tuks.co.za",
                            LevelOfStudy = rowItems[(uint)StudentRecordInCSV.LevelOfStudy],
                            Gender = rowItems[(uint)StudentRecordInCSV.Gender],
                            ResidenceId = isResidenceInDb.Id,
                            FacultyId = facultyInDb.Id
                        };

                        var isAppUserInDb = _context.AppUsers
                            .FirstOrDefault(item =>
                                string.Equals(item.Email, tempStudent.EmailAddress) ||
                                string.Equals(item.PhoneNumber, tempStudent.PhoneNumber));

                        if (isAppUserInDb != null)
                        {
                            var emailExists = await _userManager.FindByEmailAsync(tempStudent.EmailAddress);
                            if (emailExists != null)
                            {
                                message = $"Row {line}: Student with matching student number already exist in Database." +
                                          $" Add operation cancelled for all records. Correct error and upload again.";
                                return BadRequest(new { message });
                            }

                            message = $"Row {line}: A student matching the provided details already exists." +
                                      $" Add operation cancelled for all records. Correct error and upload again.";
                            return BadRequest(new { message });
                        }

                        students.Add(tempStudent);

                    }

                }

                foreach (var studentDto in students)
                {
                    var assignedPassword = UserManagementExtensions.GenerateRandomPassword();
                    var appRole = await _roleManager.FindByNameAsync("Student".ToLower());
                    if (appRole == null)
                    {
                        message = "Student Role not found. Add Student Role first. Add operation cancelled for all records. Correct error and upload again.";
                        return BadRequest(new { message });
                    }

                    var studentRoleInResidence = await _context.StudentRoles
                        .Where(item => item.ResidenceId == studentDto.ResidenceId)
                        .FirstOrDefaultAsync(item => string.Equals(item.Name.ToLower(), "NormalStudent".ToLower()));

                    if (studentRoleInResidence == null)
                    {
                        var normalStudentRole = new StudentRole()
                        {
                            Name = "NormalStudent".ToLower(),
                            ResidenceId = studentDto.ResidenceId,
                        };
                        await _context.StudentRoles.AddAsync(normalStudentRole);
                        await _context.SaveChangesAsync();
                        studentRoleInResidence = normalStudentRole;
                    }

                    var newUser = new AppUser()
                    {
                        UserName = studentDto.StudentNumber,
                        Email = studentDto.EmailAddress,
                        PhoneNumber = studentDto.PhoneNumber,
                        Name = studentDto.Name,
                        Surname = studentDto.Surname,

                        AutoAssignedPassword = assignedPassword
                    };
                    var result = await _userManager.CreateAsync(newUser, assignedPassword);

                    if (result.Succeeded)
                    {
                        var currentDateTimeStamp = DateTime.Now;
                        await _userManager.AddToRoleAsync(newUser, appRole.Name);

                        var newStudent = new Student
                        {
                            AppUserId = newUser.Id,
                            FacultyId = studentDto.FacultyId,
                            ResidenceId = studentDto.ResidenceId,
                            StudentRoleId = studentRoleInResidence.Id,
                            LevelOfStudy = studentDto.LevelOfStudy,
                            Gender = studentDto.Gender,
                            AssignedToRoom = studentDto.AssignedToRoom
                        };
                        await _context.Students.AddAsync(newStudent);
                        await _context.SaveChangesAsync();

                        var newResidenceAudit = new ResidenceAllocationAuditLog
                        {
                            DateTimeStamp = currentDateTimeStamp,
                            Initiator = username,
                            OperationType = "Add",
                            ResidenceId = studentDto.ResidenceId,
                            StudentId = newStudent.Id
                        };
                        await _context.ResidenceAllocationAuditLogs.AddAsync(newResidenceAudit);
                        await _context.SaveChangesAsync();

                        var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                        var code = HttpUtility.UrlEncode(emailToken);

                        var notificationExtenstion = new NotificationsExtension(_configuration);
                        notificationExtenstion.NewStudentNotification(newStudent.Id);
                    }

                }
                return Ok();

            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpPost("{username}")]
        public async Task<ActionResult> Add(AddIndividualStudentDto model, string username)
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
                    var appRole = await _roleManager.FindByNameAsync("Student".ToLower());
                    if (appRole == null)
                    {
                        message = "Student Role not found.";
                        return BadRequest(new { message });
                    }

                    var studentRoleInResidence = await _context.StudentRoles
                        .Where(item => item.ResidenceId == model.ResidenceId)
                        .FirstOrDefaultAsync(item => string.Equals(item.Name.ToLower(), "NormalStudent".ToLower()));

                    if (studentRoleInResidence == null)
                    {
                        var normalStudentRole = new StudentRole()
                        {
                            Name = "NormalStudent".ToLower(),
                            ResidenceId = model.ResidenceId,
                        };
                        await _context.StudentRoles.AddAsync(normalStudentRole);
                        await _context.SaveChangesAsync();
                        studentRoleInResidence = normalStudentRole;
                    }

                    var newUser = new AppUser()
                    {
                        UserName = model.StudentNumber,
                        Email = model.EmailAddress,
                        PhoneNumber = model.PhoneNumber,
                        Name = model.Name,
                        Surname = model.Surname,
                        AutoAssignedPassword = assignedPassword
                    };
                    var result = await _userManager.CreateAsync(newUser, assignedPassword);

                    if (result.Succeeded)
                    {
                        var currentDateTimeStamp = DateTime.Now;
                        await _userManager.AddToRoleAsync(newUser, appRole.Name);

                        var newStudent = new Student
                        {
                            AppUserId = newUser.Id,
                            FacultyId = model.FacultyId,
                            ResidenceId = model.ResidenceId,
                            StudentRoleId = studentRoleInResidence.Id,
                            LevelOfStudy = model.LevelOfStudy,
                            Gender = model.Gender,
                            AssignedToRoom = model.AssignedToRoom
                        };
                        await _context.Students.AddAsync(newStudent);
                        await _context.SaveChangesAsync();

                        var newResidenceAudit = new ResidenceAllocationAuditLog
                        {
                            DateTimeStamp = currentDateTimeStamp,
                            Initiator = username,
                            OperationType = "Add",
                            ResidenceId = model.ResidenceId,
                            StudentId = newStudent.Id
                        };
                        await _context.ResidenceAllocationAuditLogs.AddAsync(newResidenceAudit);
                        await _context.SaveChangesAsync();

                        var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                        var code = HttpUtility.UrlEncode(emailToken);

                        var notificationExtenstion = new NotificationsExtension(_configuration);
                        notificationExtenstion.NewStudentNotification(newStudent.Id);
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
        public ActionResult<GetStudentDto> GetStudent(int id)
        {
            var recordInDb = _context.Students
                .Where(item => item.Id == id)
                .Include(item => item.AppUser)
                .Include(item => item.Residence)
                .Include(item => item.Faculty)
                .Include(item => item.StudentRole)
                .Select(item => new GetStudentDto()
                {
                    Id = item.Id,
                    AppUserId = item.AppUserId,
                    Name = item.AppUser.Name,
                    Surname = item.AppUser.Surname,
                    StudentNumber = item.AppUser.UserName,
                    PhoneNumber = item.AppUser.PhoneNumber,
                    AutoAssignedPassword = item.AppUser.AutoAssignedPassword,
                    EmailAddress = item.AppUser.Email,
                    ResidenceName = item.Residence.Name,
                    StudentRole = item.StudentRole.Name,
                    FacultyName = item.Faculty.Name,
                    AssignedToRoom = item.AssignedToRoom.ToString(),
                    Gender = item.Gender,
                    LevelOfStudy = item.LevelOfStudy
                }).First();

            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetStudentDto>> GetAllStudents()
        {
            var recordsInDb = _context.Students
                .Include(item => item.AppUser)
                .Include(item => item.Residence)
                .Include(item => item.Faculty)
                .Include(item => item.StudentRole)
                .Select(item => new GetStudentDto()
                {
                    Id = item.Id,
                    AppUserId = item.AppUserId,
                    Name = item.AppUser.Name,
                    Surname = item.AppUser.Surname,
                    StudentNumber = item.AppUser.UserName,
                    PhoneNumber = item.AppUser.PhoneNumber,
                    AutoAssignedPassword = item.AppUser.AutoAssignedPassword,
                    EmailAddress = item.AppUser.Email,
                    ResidenceName = item.Residence.Name,
                    StudentRole = item.StudentRole.Name,
                    FacultyName = item.Faculty.Name,
                    Gender = item.Gender,
                    AssignedToRoom=item.AssignedToRoom,
                    LevelOfStudy = item.LevelOfStudy

                }).OrderBy(item => item.Name).ToList();

            return recordsInDb;
        }

        [HttpGet("GetAll/RoomCorridor/{gender}")]
        public ActionResult<IEnumerable<GetStudentDto>> GetAllStudentsToAssigen(string gender)
        {
            var recordsInDb = _context.Students
                //.Where(item=>item.Gender.ToLower() == gender.ToLower()) // We only want to return a list a students mathcing the corridor gender
                //.Where(item=>item.AssignedToRoom == false)
                .Include(item => item.AppUser)
                .Include(item => item.Residence)
                .Include(item => item.Faculty)
                .Include(item => item.StudentRole)
                .Select(item => new GetStudentDto()
                {
                    Id = item.Id,
                    AppUserId = item.AppUserId,
                    Name = item.AppUser.Name,
                    Surname = item.AppUser.Surname,
                    StudentNumber = item.AppUser.UserName,
                    PhoneNumber = item.AppUser.PhoneNumber,
                    AutoAssignedPassword = item.AppUser.AutoAssignedPassword,
                    EmailAddress = item.AppUser.Email,
                    ResidenceName = item.Residence.Name,
                    StudentRole = item.StudentRole.Name,
                    FacultyName = item.Faculty.Name,
                    LevelOfStudy = item.LevelOfStudy

                }).OrderBy(item => item.Name).ToList();

            return recordsInDb;
        }
        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var recordInDb = await _context.Students.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }
            var auditLogs = _context.ResidenceAllocationAuditLogs
                .Where(item => item.ResidenceId == id);
         
            _context.ResidenceAllocationAuditLogs.RemoveRange(auditLogs);
            await _context.SaveChangesAsync();

            var residenceStudents = _context.Students
                .Where(item => item.ResidenceId == id)
                .Where(item => item.Id == id);
            _context.Students.RemoveRange(residenceStudents);

            _context.Students.Remove(recordInDb);
            await _context.SaveChangesAsync();


            return Ok();

        }
        //TODO WHen deleting student

        //1. Delete Auditlog
        //2. Delete Student
        //3. Delete AppUser
    }
    public enum StudentRecordInCSV
    {
        StudentNumber,
        Name,
        Surname,
        PhoneNumber,
        Faculty,
        LevelOfStudy,
        Gender,
    }
}

