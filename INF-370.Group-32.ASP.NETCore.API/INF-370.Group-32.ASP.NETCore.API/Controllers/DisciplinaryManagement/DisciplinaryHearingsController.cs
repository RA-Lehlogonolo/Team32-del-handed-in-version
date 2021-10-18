using Group32.Core.DisciplinaryHearingManagement;
using Group32.Data.Context;
using Group32.Services.Dtos.DisciplinaryManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.DisciplinaryManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaryHearingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisciplinaryHearingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<GetDisciplinaryHearingDto> GetRecord(int id)
        {
            var recordInDb = _context.DisciplinaryHearings
                .Where(item => item.Id == id)
                .Include(item => item.MisconductType)
                .Include(item => item.Student)
                .Select(item => new GetDisciplinaryHearingDto()
                {
                    Id = item.Id,
                    Description = item.Desscription,
                    Venue = item.Venue,
                    Date = item.Date,
                    MisconductType = item.MisconductType.Name,
                    MisconductTypeId = item.MisconductType.Id



                }).First();
            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetDisciplinaryHearingDto>> GetAll()
        {
            var recordsInDb = _context.DisciplinaryHearings
                .Include(item => item.MisconductType)
                .Include(item => item.Student)
                .Select(item => new GetDisciplinaryHearingDto()
                {
                    Id = item.Id,
                    Description = item.Desscription,
                    Venue = item.Venue,
                    Date = item.Date,
                    MisconductType = item.MisconductType.Name,
                    MisconductTypeId = item.MisconductType.Id
                }).OrderBy(item => item.Date).ToList();

            return recordsInDb;
        }

        [HttpPut("{username}/{id}")]
        public IActionResult Update(AddOrUpdateDisciplinaryHearingDto model, string username, int id)
        {
            if (ModelState.IsValid)
            {
                var recordInDb = _context.DisciplinaryHearings.FirstOrDefault(item => item.Id == id);

                if (recordInDb == null)
                {
                    return NotFound();
                }

                recordInDb.Desscription = model.Decription;
                recordInDb.Venue = model.Venue;
                recordInDb.Date = model.Date;
                recordInDb.MisconductTypeId = model.MisconductTypeId;
                recordInDb.StudentId = model.StudentId;
                _context.SaveChanges();
                return Ok();
            }

            var message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpPost("{username}")]
        public IActionResult Add(AddOrUpdateDisciplinaryHearingDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var recordInDb = _context.DisciplinaryHearings.FirstOrDefault(item => item.Date.ToLower() == model.Date.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });
                }

                var newRecord = new DisciplinaryHearing
                {
                    Desscription = model.Decription,
                    Venue = model.Venue,
                    Date = model.Date,
                    MisconductTypeId = model.MisconductTypeId,
                    StudentId=model.StudentId,
                };
                _context.DisciplinaryHearings.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<DisciplinaryHearing>> Delete(int id)
        {
            var recordInDb = await _context.DisciplinaryHearings.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //TODO: Delete Any Data that is be related to the entity


            _context.DisciplinaryHearings.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}



