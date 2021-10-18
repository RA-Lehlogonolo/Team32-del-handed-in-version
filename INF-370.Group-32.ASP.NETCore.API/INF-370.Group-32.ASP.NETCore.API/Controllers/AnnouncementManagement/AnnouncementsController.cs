using Group32.Data.Context;
using Microsoft.AspNetCore.Http;
using Group32.Core.AnnouncementManagement;
using Group32.Services.Dtos.AnnouncementManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.AnnouncementManagement
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnnouncementsController : ControllerBase
  {
    private readonly AppDbContext _context;

    public AnnouncementsController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet("{id}")]
    public ActionResult<GetAnnouncementDto> GetRecord(int id)
    {
      var recordInDb = _context.Announcements
          .Where(item => item.Id == id)
          .Include(item => item.AnnouncementType)
          .Include(item => item.Residence)
          .Select(item => new GetAnnouncementDto()
          {
            Id = item.Id,
            Description = item.Description,
            Date = item.Date,
            AnnouncementType = item.AnnouncementType.Name,
            AnnouncementTypeId = item.AnnouncementType.Id,
            Residence = item.Residence.Name,
            ResidenceId = item.ResidenceId

          }).FirstOrDefault();
      if (recordInDb == null)
      {
        return NotFound();
      }

      return recordInDb;
    }

    [HttpGet("GetAll")]
    public ActionResult<IEnumerable<GetAnnouncementDto>> GetAll()
    {
      var recordsInDb = _context.Announcements
          .Include(item => item.AnnouncementType)
          .Include(item => item.Residence)
          .Select(item => new GetAnnouncementDto()
          {
            Id = item.Id,
            Description = item.Description,
            Date = item.Date,
            AnnouncementType = item.AnnouncementType.Name,
            AnnouncementTypeId = item.AnnouncementType.Id,
            Residence = item.Residence.Name,
            ResidenceId = item.ResidenceId
          }).OrderBy(item => item.Date).ToList();
      return recordsInDb;
    }

    [HttpPut("{username}/{id}")]
    public IActionResult Update(AddOrUpdateAnnouncementDto model, string username, int id)
    {
      if (ModelState.IsValid)
      {
        var recordInDb = _context.Announcements.FirstOrDefault(item => item.Id == id);

        if (recordInDb == null)
        {
          return NotFound();
        }
        recordInDb.Description = model.Description;
        recordInDb.Date = model.Date;
        recordInDb.AnnouncementTypeId = model.AnnouncementTypeId;
        recordInDb.ResidenceId = model.ResidenceId;
        _context.SaveChanges();
        return Ok();
      }
      var message = "Something went wrong on your side.";
      return BadRequest(new { message });
    }
    [HttpPost("{username}")]
    public IActionResult Add(AddOrUpdateAnnouncementDto model, string username)
    {
      var message = "";
      if (ModelState.IsValid)
      {
        var recordInDb = _context.Announcements.FirstOrDefault(item => item.Description.ToLower() == model.Description.ToLower());

        if (recordInDb != null)
        {
          message = "Record already exist";
          return BadRequest(new { message });
        }

        var newRecord = new Announcement()

        {
          Description = model.Description,
          Date = model.Date,
          AnnouncementTypeId = model.AnnouncementTypeId,
          ResidenceId = model.ResidenceId
        };
        _context.Announcements.Add(newRecord);
        _context.SaveChanges();
        return Ok();
      }
      message = "Something went wrong on your side.";
      return BadRequest(new { message });
    }
    [HttpDelete("{username}/{id}")]
    public async Task<ActionResult<Announcement>> Delete(int id)
    {
      var recordInDb = await _context.Announcements.FindAsync(id);
      if (recordInDb == null)
      {
        return NotFound();
      }
      _context.Announcements.Remove(recordInDb);
      await _context.SaveChangesAsync();

      return Ok();
    }
  }
}
