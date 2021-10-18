using Group32.Data.Context;
using Microsoft.AspNetCore.Http;
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
    public class LogsController : ControllerBase
    {

        private readonly AppDbContext _context;

        public LogsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("ResidenceLog/GetAll")]
        public ActionResult<IEnumerable<ResidenceAllocationLogDto>> GetAll()
        {
            var recordsInDb = _context.ResidenceAllocationAuditLogs
                .Include(item => item.Residence)
                .Include(item => item.Student)
                .ThenInclude(item => item.AppUser)
                .OrderBy(item => item.DateTimeStamp)
                .Select(item => new ResidenceAllocationLogDto()
                {
                    Initiator = item.Initiator,
                    StudentNumber = item.Student.AppUser.UserName,
                    Date = item.DateTimeStamp.ToString("dd/MM/yyyy"),
                    Time = item.DateTimeStamp.ToString("t"),
                    ResidenceName = item.Residence.Name,
                    OperationType = item.OperationType
                }).OrderBy(item => item.ResidenceName).ToList();

            return recordsInDb;
        }
    }
    public class ResidenceAllocationLogDto
    {
        public string Initiator { get; set; }
        public string OperationType { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ResidenceName { get; set; }
        public string StudentNumber { get; set; }
    }
}

