using Group32.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Group32.Core.ResidenceManagement;
using Group32.Services.Dtos.Generic;
using Group32.Core.CampusResidence;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.ResidenceManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CampusesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<GetGenericNameAndIdDto> GetRecord(int id)
        {
            var recordInDb = _context.Campuses.Where(item => item.Id == id).Select(item => new GetGenericNameAndIdDto()
            {
                Name = item.Name,
                Id = item.Id
            }).First();

            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetGenericNameAndIdDto>> GetAll()
        {
            var recordsInDb = _context.Campuses.Select(item => new GetGenericNameAndIdDto
            {
                Name = item.Name,
                Id = item.Id
            }).OrderBy(item => item.Name).ToList();

            return recordsInDb;
        }
        [HttpPut("{username}/{id}")]
        public IActionResult Update(AddOrUpdateGenericNameOnlyDto model, string username, int id)
        {
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Campuses.FirstOrDefault(item => item.Id == id);

                if (recordInDb == null)
                {
                    return NotFound();
                }

                recordInDb.Name = model.Name;
                _context.SaveChanges();

                return Ok();
            }

            var message = "Something went wrong on your side.";
            return BadRequest(new { message });

        }
        [HttpPost("{username}")]
        public IActionResult Add(AddOrUpdateGenericNameOnlyDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Campuses.FirstOrDefault(item => item.Name.ToLower() == model.Name.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });
                }

                var newRecord = new Campus
                {
                    Name = model.Name
                };
                _context.Campuses.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<Campus>> Delete(int id)
        {
            var recordInDb = await _context.Campuses.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //Delete Campus Residences
            var campusResidences = _context.Residences.Where(item => item.CampusId == recordInDb.Id);
            _context.Residences.RemoveRange(campusResidences);
            await _context.SaveChangesAsync();

            _context.Campuses.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
    
