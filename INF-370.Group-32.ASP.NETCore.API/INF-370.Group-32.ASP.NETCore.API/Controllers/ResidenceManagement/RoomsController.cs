using Group32.Core.ResidenceManagement;
using Group32.Data.Context;
using Group32.Services.Dtos.ResidenceManagement.Room;
using Group32.Services.Dtos.ResidenceManagement.Rooms;
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
    public class RoomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddMultiple/{username}/{blockId}")]
        public async Task<ActionResult<List<GetRoomDto>>> AddMultipleRoomsInCSV([FromBody] UploadBlockRoomsInCSVDto modal, string username, int blockId)
        {

            var isBlockInDb = _context.Blocks
                .FirstOrDefault(item => item.Id == blockId);
            var message = "";
            if (isBlockInDb == null)
            {
                message = "Error: Block not found. Try adding block first.";
                return BadRequest(new { message });
            }


            if (ModelState.IsValid)
            {
                var lines = await System.IO.File.ReadAllLinesAsync(@modal.FileUrl);
                var rooms = new List<AddIndividualRoomDto>();

                foreach (var line in lines.Skip(1))
                {
                    var rowItems = line.Split(';');
                    var addRoom = new AddIndividualRoomDto()
                    {
                        RoomNumber = rowItems[(uint)RoomRecordInCSV.RoomNumber],
                        Corridor = rowItems[(uint)RoomRecordInCSV.Corridor],
                        RoomType = rowItems[(uint)RoomRecordInCSV.RoomType],
                        BlockId = isBlockInDb.Id,
                        RoomStatus = rowItems[(uint)RoomRecordInCSV.RoomStatus]
                    };
                    rooms.Add(addRoom);
                }  

                return Ok();

            }
         
            message = "Something went wrong on your side.";
            return BadRequest(new { message });
        }

        [HttpPost("{username}")]
        public async Task<ActionResult> Add(AddIndividualRoomDto model, string username)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                var newRoom = new Room
                {
                    RoomNumber=model.RoomNumber,
                    Corridor=model.Corridor,
                    RoomType=model.RoomType,
                    RoomStatus=model.RoomStatus,
                    BlockId=model.BlockId

                };
                await _context.Rooms.AddAsync(newRoom);
                await _context.SaveChangesAsync();
                return Ok();

            }
            message = "Something went wrong on your side. Please check your connection & try again.";
            return BadRequest(new { message });
        }

        [HttpGet("{id}")]
        public ActionResult<GetRoomDto> GetRoom(int id)
        {
            var recordInDb = _context.Rooms
                .Where(item => item.Id == id)
                .Include(item => item.Block)
                .Select(item => new GetRoomDto()
                {
                    RoomNumber = item.RoomNumber,
                    Corridor = item.Corridor,
                    RoomType = item.RoomType,
                    RoomStatus = item.RoomStatus,
                    BlockName=item.Block.Name,
                    
                    BlockId = item.BlockId,

                }).First();

            if (recordInDb == null)
            {
                return NotFound();
            }

            return recordInDb;

        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<GetRoomDto>> GetAllRooms()
        {
            var recordsInDb = _context.Rooms
                .Include(item => item.Block)
                .Select(item => new GetRoomDto()
                {
                    Id = item.Id,
                    RoomNumber = item.RoomNumber,
                    Corridor = item.Corridor,
                    RoomType = item.RoomType,
                    RoomStatus = item.RoomStatus,
                    BlockId=item.BlockId,
                    BlockName=item.Block.Name

                }).OrderBy(item => item.RoomNumber).ToList();

            return recordsInDb;

        }


        public enum RoomRecordInCSV
        {
            RoomNumber,
            Corridor,
            RoomType,
            BlockName,
            RoomStatus

        }
    }
}
