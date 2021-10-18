using Group32.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Group32.Core.ResidenceManagement;
using Group32.Services.Dtos.ResidenceManagement.Residence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Group32.Core.CampusResidence;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.ResidenceManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidencesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResidencesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<GetResidenceDto> GetRecord(int id)
        {
            var recordInDb = _context.Residences
                .Where(item => item.Id == id)
                .Include(item => item.ResidenceType)
                .Include(item => item.Campus)
                .Select(item => new GetResidenceDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    ResidenceType = item.ResidenceType.Name,
                    ResidenceTypeId = item.ResidenceType.Id,
                    CampusName = item.Name,
                    CampusId = item.Id
                }).First();

            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetResidenceDto>> GetAll()
        {
            var recordsInDb = _context.Residences
                .Include(item => item.ResidenceType)
                .Include(item => item.Campus)
                .Select(item => new GetResidenceDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    ResidenceType = item.ResidenceType.Name,
                    ResidenceTypeId = item.ResidenceType.Id,
                    CampusName = item.Name,
                    CampusId = item.Id
                }).OrderBy(item => item.Name).ToList();

            return recordsInDb;
        }


        [HttpPut("{username}/{id}")]
        public IActionResult Update(AddOrUpdateResidenceDto model, string username, int id)
        {
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Residences.FirstOrDefault(item => item.Id == id);

                if (recordInDb == null)
                {
                    return NotFound();
                }

                recordInDb.Name = model.Name;
                recordInDb.Address = model.Address;
                recordInDb.CampusId = model.CampusId;
                recordInDb.ResidenceTypeId = model.ResidenceTypeId;
                _context.SaveChanges();

                return Ok();
            }

            var message = "Something went wrong on your side.";
            return BadRequest(new { message });

        }

        [HttpPost("{username}")]
        public IActionResult Add(AddOrUpdateResidenceDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var recordInDb = _context.Residences.FirstOrDefault(item => item.Name.ToLower() == model.Name.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });
                }

                var newRecord = new Residence
                {
                    Name = model.Name,
                    Address = model.Address,
                    CampusId = model.CampusId,
                    ResidenceTypeId = model.ResidenceTypeId
                };
                _context.Residences.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<Residence>> Delete(int id)
        {
            var recordInDb = await _context.Residences.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //TODO: Delete Any Data that is be related to Residence
            var residenceHouseParents = _context.HouseParents.Where(item => item.ResidenceId == id);
            _context.HouseParents.RemoveRange(residenceHouseParents);
            await _context.SaveChangesAsync();



            _context.Residences.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

