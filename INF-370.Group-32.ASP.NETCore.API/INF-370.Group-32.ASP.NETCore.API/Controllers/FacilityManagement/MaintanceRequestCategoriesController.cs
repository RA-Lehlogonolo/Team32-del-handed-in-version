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
    public class MaintanceRequestCategoriesController : ControllerBase
    {

        private readonly AppDbContext _context;

        public MaintanceRequestCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<GetMaintananceRequestCategoryDto> GetRecord(int id)
        {
            var recordInDb = _context.MaintananceRequestCategories
                .Where(item => item.Id == id)
                .Include(item => item.MaintananceRequestType)
                .Select(item => new GetMaintananceRequestCategoryDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    MaintananceRequestTypeName = item.MaintananceRequestType.Name,
                    MaintananceRequestTypeId = item.Id
                }).First();

            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetMaintananceRequestCategoryDto>> GetAll()
        {
            var recordsInDb = _context.MaintananceRequestCategories
                .Include(item => item.MaintananceRequestType)
                .Select(item => new GetMaintananceRequestCategoryDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    MaintananceRequestTypeName = item.MaintananceRequestType.Name,
                    MaintananceRequestTypeId = item.Id
                }).OrderBy(item => item.Name).ToList();

            return recordsInDb;
        }
        [HttpPut("{username}/{id}")]
        public IActionResult Update(AddOrUpdateMaintananceRequestCategoryDto model, string username, int id)
        {
            if (ModelState.IsValid)
            {
                var recordInDb = _context.MaintananceRequestCategories.FirstOrDefault(item => item.Id == id);

                if (recordInDb == null)
                {
                    return NotFound();
                }

                recordInDb.Name = model.Name;
                recordInDb.MaintananceRequestTypeId = model.MaintananceRequestTypeId;
                _context.SaveChanges();

                return Ok();
            }
            var message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }
        [HttpPost("{username}")]
        public IActionResult Add(AddOrUpdateMaintananceRequestCategoryDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var recordInDb = _context.MaintananceRequestCategories.FirstOrDefault(item => item.Name.ToLower() == model.Name.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });
                }

                var newRecord = new MaintananceRequestCategory
                {
                    Name = model.Name,
                    MaintananceRequestTypeId = model.MaintananceRequestTypeId,
                };
                _context.MaintananceRequestCategories.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<MaintananceRequestCategory>> Delete(int id)
        {
            var recordInDb = await _context.MaintananceRequestCategories.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //TODO: Delete Any Data that is be related to the entity


            _context.MaintananceRequestCategories.Remove(recordInDb);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
