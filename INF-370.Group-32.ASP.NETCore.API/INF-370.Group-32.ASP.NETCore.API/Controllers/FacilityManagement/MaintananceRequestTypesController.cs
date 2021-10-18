using Group32.Core.Facility;
using Group32.Data.Context;
using Group32.Services.Dtos.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers.FacilityManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintananceRequestTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaintananceRequestTypesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<GetGenericNameAndIdDto> GetRecord(int id)
        {
            var recordInDb = _context.MaintananceRequestTypes.Where(item => item.Id == id).Select(item => new GetGenericNameAndIdDto()
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
            var recordsInDb = _context.MaintananceRequestTypes.Select(item => new GetGenericNameAndIdDto
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
                var recordInDb = _context.MaintananceRequestTypes.FirstOrDefault(item => item.Id == id);

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
                var recordInDb = _context.MaintananceRequestTypes.FirstOrDefault(item => item.Name.ToLower() == model.Name.ToLower());

                if (recordInDb != null)
                {
                    message = "Record already exist";
                    return BadRequest(new { message });
                }

                var newRecord = new MaintananceRequestType()
                {
                    Name = model.Name
                };
                _context.MaintananceRequestTypes.Add(newRecord);
                _context.SaveChanges();
                return Ok();
            }

            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpDelete("{username}/{id}")]
        public async Task<ActionResult<MaintananceRequestType>> Delete(int id)
        {
            var recordInDb = await _context.MaintananceRequestTypes.FindAsync(id);
            if (recordInDb == null)
            {
                return NotFound();
            }

            //Delete All Maintanance Request Types 


            _context.MaintananceRequestTypes.Remove(recordInDb);
            await _context.SaveChangesAsync();

            return Ok();
        }




    }
}
