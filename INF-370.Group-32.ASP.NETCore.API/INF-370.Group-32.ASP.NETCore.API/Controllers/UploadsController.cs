using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace INF_370.Group_32.ASP.NETCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        [HttpPost("Students/Upload"), DisableRequestSizeLimit]
        public IActionResult UploadCompanyMembers()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Uploads", "Students");
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolderPath, fileName);


                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost("Rooms/Upload"), DisableRequestSizeLimit]
        public IActionResult UploadRoomsMembers()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Uploads", "Rooms");
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolderPath, fileName);


                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
