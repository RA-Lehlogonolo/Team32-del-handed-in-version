using Group32.Core.VillageFreshManagement;
using Group32.Data.Context;
using Group32.Services.Dtos.VillageFreshManagement.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.VillageFreshManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<GetItemDto> GetRecord(int id)
        {
            var recordInDb = _context.Items
                .Where(item => item.Id == id)
                .Include(item => item.ItemType)
                 .Select(item => new GetItemDto()
                 {
                     Id = item.Id,
                     Name = item.Name,
                     ItemType = item.ItemType.Name,
                     ItemTypeId = item.ItemType.Id,
                 }).First();
            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetItemDto>> GetAll()
        {
            var recordsInDb = _context.Items
               .Include(item => item.ItemType)
                .Select(item => new GetItemDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ItemType = item.ItemType.Name,
                    ItemTypeId = item.ItemType.Id,
                }).OrderBy(item => item.Name).ToList();

            return recordsInDb;
        }

        [HttpPut("{username}/{id}")]
        public IActionResult Update(AddOrUpdateItemDto model, string username, int id)
        {
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Items.FirstOrDefault(item => item.Id == id);

                if (recordInDb == null)
                {
                    return NotFound();
                }
                return Ok();
            }

            var message = "Something went wrong on your side.";
            return BadRequest(new { message });

        }

        [HttpPost("{username}")]
        public IActionResult Add(AddOrUpdateItemDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Items.FirstOrDefault(item => item.Name.ToLower() == model.Name.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });
                }

                var newRecord = new Item
                {
                    Name = model.Name,

                    ItemTypeId = model.ItemTypeId,
                  
                };
                _context.Items.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<Item>> Delete(int id)
        {
            var recordInDb = await _context.Items.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //TODO: Delete Any Data that is be related to the entity


            _context.Items.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
    




    
