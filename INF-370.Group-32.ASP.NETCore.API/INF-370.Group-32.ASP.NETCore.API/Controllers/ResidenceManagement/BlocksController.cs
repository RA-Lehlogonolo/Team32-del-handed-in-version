using Group32.Core.ResidenceManagement;
using Group32.Data.Context;
using Group32.Services.Dtos.Generic;
using Group32.Services.Dtos.ResidenceManagement.Block;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.ResidenceManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocksController : ControllerBase
    {

        private readonly AppDbContext _context;

        public BlocksController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<GetBlockDto> GetRecord(int id)
        {
            var recordInDb = _context.Blocks
                .Where(item => item.Id == id)
                .Include(item => item.Residence)
                .Select(item => new GetBlockDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ResidenceName = item.Residence.Name,
                    ResidenceId = item.Id
                }).First();

            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }


        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetBlockDto>> GetAll()
        {
            var recordsInDb = _context.Blocks
                .Include(item => item.Residence)
                .Select(item => new GetBlockDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ResidenceName= item.Residence.Name,
                    ResidenceId = item.Id
                }).OrderBy(item => item.Name).ToList();

            return recordsInDb;
        }

        [HttpPut("{username}/{id}")]
        public IActionResult Update(AddOrUpdateBlockDto model, string username, int id)
        {
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Blocks.FirstOrDefault(item => item.Id == id);

                if (recordInDb == null)
                {
                    return NotFound();
                }

                recordInDb.Name = model.Name;
                recordInDb.ResidenceId = model.ResidenceId;
                _context.SaveChanges();

                return Ok();
            }
            var message = "Something went wrong on your side.";
            return BadRequest(new { message });

        }

        [HttpPost("{username}")]
        public IActionResult Add(AddOrUpdateBlockDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Blocks.FirstOrDefault(item => item.Name.ToLower() == model.Name.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });
                }

                var newRecord = new Block
                {
                    Name = model.Name,
                    ResidenceId = model.ResidenceId,
                };
                _context.Blocks.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<Block>> Delete(int id)
        {
            var recordInDb = await _context.Blocks.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //TODO: Delete Any Data that is be related to the entity


            _context.Blocks.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
