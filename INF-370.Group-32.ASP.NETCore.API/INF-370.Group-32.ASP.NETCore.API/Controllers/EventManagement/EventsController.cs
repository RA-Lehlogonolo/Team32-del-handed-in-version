using Group32.Core.EventManagement;
using Group32.Data.Context;
using Group32.Services.Dtos.EventManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.EventManagement
{
  [Route("api/[controller]")]
  [ApiController]
  public class EventsController : ControllerBase
  {
    private readonly AppDbContext _context;

    public EventsController(AppDbContext context)
    {
      _context = context;
    }
    [HttpGet("{id}")]
    public ActionResult<GetEventDto> GetRecord(int id)
    {
      var recordInDb = _context.Events
        .Where(item => item.Id == id)
        .Include(item => item.Residence)
        .Include(item => item.EventType)
        .Select(item => new GetEventDto()
        {
          Id = item.Id,
          Location = item.Location,
          Name = item.Name,
          Date = item.Date,
          StartTime = item.StartTime,
          EndTime = item.EndTime,
          Residence = item.Residence.Name,
          ResidenceId = item.Residence.Id,
          EventType = item.EventType.Name,
          EventTypeId = item.Id
        }).First();

      if (recordInDb == null)
      {
        return NotFound();
      }
      return recordInDb;
    }

    [HttpGet("GetAll")]
    public ActionResult<IEnumerable<GetEventDto>> GetAll()
    {
      var recordsInDb = _context.Events
          .Include(item => item.Residence)
          .Include(item => item.EventType)
          .Select(item => new GetEventDto()
          {
            Id = item.Id,
            Location = item.Location,
            Name = item.Name,
            Date = item.Date,
            StartTime = item.StartTime,
            EndTime = item.EndTime,
            Residence = item.Residence.Name,
            ResidenceId = item.Residence.Id,
            EventType = item.EventType.Name,
            EventTypeId = item.Id
          }).OrderBy(item => item.Name).ToList();
      return recordsInDb;
    }

    [HttpPut("{username}/{id}")]
    public IActionResult Update(AddOrUpdateEventDto model, string username, int id)
    {
      if (ModelState.IsValid)
      {
        var recordInDb = _context.Events.FirstOrDefault(item => item.Id == id);

        if (recordInDb == null)
        {
          return NotFound();
        }

        recordInDb.Name = model.Name;
        recordInDb.Location = model.Location;
        recordInDb.StartTime = model.StartTime;
        recordInDb.EndTime = model.EndTime;
        recordInDb.Date = model.Date;

        recordInDb.ResidenceId = model.ResidenceId;
        recordInDb.EventTypeId = model.EventTypeId;
        _context.SaveChanges();

        return Ok();
      }

      var message = "Something went wrong on your side.";
      return BadRequest(new { message });
    }

    [HttpPost("{username}")]
    public IActionResult Add(AddOrUpdateEventDto model, string username)
    {
      var message = "";
      if (ModelState.IsValid)
      {
        var recordInDb = _context.Events.FirstOrDefault(item => item.Name.ToLower() == model.Name.ToLower());

        if (recordInDb != null)
        {
          message = "Record already exist";
          return BadRequest(new { message });
        }

        var newRecord = new Event
        {
           Name = model.Name,
           Location = model.Location,
           StartTime = model.StartTime,
           EndTime = model.EndTime,
           Date = model.Date,
          ResidenceId = model.ResidenceId,
          EventTypeId = model.EventTypeId
      };
        _context.Events.Add(newRecord);
        _context.SaveChanges();
        return Ok();
      }

      message = "Something went wrong on your side.";
      return BadRequest(new { message });
    }

    [HttpDelete("{username}/{id}")]
    public async Task<ActionResult<Event>> Delete(int id)
    {
      var recordInDb = await _context.Events.FindAsync(id);
      if (recordInDb == null)
      {
        return NotFound();
      }
      _context.Events.Remove(recordInDb);
      await _context.SaveChangesAsync();

      return Ok();
    }



  }
}
