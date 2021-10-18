using Group32.Core.VillageFreshManagement;
using Group32.Data.Context;
using Group32.Services.Dtos.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.VillageFreshManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {

        private readonly AppDbContext _context;

        public DaysController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<GetGenericNameAndIdDto> GetRecord(int id)
        {
            var recordInDb = _context.Days.Where(item => item.Id == id).Select(item => new GetGenericNameAndIdDto()
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
            var recordsInDb = _context.Days.Select(item => new GetGenericNameAndIdDto
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
                var recordInDb = _context.Days.FirstOrDefault(item => item.Id == id);

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
                var recordInDb = _context.Days.FirstOrDefault(item => item.Name.ToLower() == model.Name.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });
                }

                var newRecord = new Day()
                {
                    Name = model.Name
                };
                _context.Days.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<Day>> Delete(int id)
        {
            var recordInDb = await _context.Days.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //TODO: Delete Any Data that is be related to the entity


            _context.Days.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
