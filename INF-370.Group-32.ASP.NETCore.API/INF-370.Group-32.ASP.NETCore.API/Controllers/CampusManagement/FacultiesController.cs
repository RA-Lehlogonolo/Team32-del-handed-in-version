using Group32.Core.CampusResidence;
using Group32.Core.ResidenceManagement;
using Group32.Data.Context;
using Group32.Services.Dtos.CampusManagement.Faculty;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.CampusManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FacultiesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<GetFacultyDto> GetRecord(int id)
        {
            var recordInDb = _context.Faculties
                .Where(item => item.Id == id)
                .Include(item => item.Campus)
                .Select(item => new GetFacultyDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CampusName = item.Campus.Name,
                    CampusId = item.Id
                }).First();

            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetFacultyDto>> GetAll()
        {
            var recordsInDb = _context.Faculties
                .Include(item => item.Campus)
                .Select(item => new GetFacultyDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CampusName = item.Campus.Name,
                    CampusId = item.Id
                }).OrderBy(item => item.Name).ToList();

            return recordsInDb;
        }
        [HttpPut("{username}/{id}")]
        public IActionResult Update(AddOrUpdateFacultyDto model, string username, int id)
        {
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Faculties.FirstOrDefault(item => item.Id == id);

                if (recordInDb == null)
                {
                    return NotFound();
                }

                recordInDb.Name = model.Name;
                recordInDb.CampusId = model.CampusId;
                _context.SaveChanges();

                return Ok();
            }
            var message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }
        [HttpPost("{username}")]
        public IActionResult Add(AddOrUpdateFacultyDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Faculties.FirstOrDefault(item => item.Name.ToLower() == model.Name.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });
                }

                var newRecord = new Faculty
                {
                    Name = model.Name,
                    CampusId = model.CampusId,
                };
                _context.Faculties.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<Campus>> Delete(int id)
        {
            var recordInDb = await _context.Faculties.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //TODO: Delete Any Data that is be related to the entity


            _context.Faculties.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}


