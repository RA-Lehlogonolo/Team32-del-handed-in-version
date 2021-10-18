using Group32.Core.Facility;
using Group32.Data.Context;
using Group32.Services.Dtos.Facility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.FacilityManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintananceRequestsController : ControllerBase
    {

        private readonly AppDbContext _context;

        public MaintananceRequestsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<GetMaintananceRequestDto> GetRecord(int id)
        {
            var recordInDb = _context.MaintananceRequests
                .Where(item => item.Id == id)
                .Include(item => item.MaintananceRequestType)
                .Include(item => item.MaintananceRequestCategory)
                .Select(item => new GetMaintananceRequestDto()
                {
                    Id = item.Id,
                    Description = item.Description,
                    Date = item.Date,
                    MaintananceRequestTypeName = item.MaintananceRequestType.Name,
                    MaintananceRequestTypeId = item.MaintananceRequestType.Id,
                    MaintananceRequestCategoryName = item.MaintananceRequestCategory.Name,
                    MaintananceRequestCategoryId = item.Id
                }).First();

            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetMaintananceRequestDto>> GetAll()
        {
            var recordsInDb = _context.MaintananceRequests
               .Include(item => item.MaintananceRequestType)
               .Include(item => item.MaintananceRequestCategory)
               .Select(item => new GetMaintananceRequestDto()
               {
                   Id = item.Id,
                   Description = item.Description,
                   Date = item.Date,
                   MaintananceRequestTypeName = item.MaintananceRequestType.Name,
                   MaintananceRequestTypeId = item.MaintananceRequestType.Id,
                   MaintananceRequestCategoryName = item.MaintananceRequestCategory.Name,
                   MaintananceRequestCategoryId = item.Id

               }).OrderBy(item => item.Date).ToList();

            return recordsInDb;
        }

        [HttpPut("{username}/{id}")]
        public IActionResult Update(AddOrUpdateMaintananceRequestDto model, string username, int id)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var recordInDb = _context.MaintananceRequests.FirstOrDefault(item => item.Date.ToLower() == model.Date.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });

                }
                var newRecord = new MaintananceRequest
                {
                    Description=model.Description,
                    Date=model.Date,
                    MaintananceRequestCategoryId=model.MaintananceRequestCategoryId,
                    MaintananceRequestTypeId=model.MaintananceRequestTypeId


                };
                _context.MaintananceRequests.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<MaintananceRequest>> Delete(int id)
        {
            var recordInDb = await _context.MaintananceRequests.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //TODO: Delete Any Data that is be related to the entity


            _context.MaintananceRequests.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}




