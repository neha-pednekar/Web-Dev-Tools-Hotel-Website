using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models;
using ProjectNehaPalaceWebAPI.Services;

namespace ProjectNehaPalaceWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Rooms")]
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // GET: api/rooms
        [HttpGet]
        public async Task<IEnumerable<RoomModel>> Get()
        {
            return await _roomRepository.GetAllRooms();
        }

        // GET: api/rooms/SingleRoom
        [HttpGet("{name}", Name = "Get")]
        public async Task<IActionResult> Get(string name)
        {
            var room = await _roomRepository.GetRoom(name);
            if (room == null)
                return new NotFoundResult();
            return new ObjectResult(room);
        }
        
        // POST: api/rooms
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RoomModel room)
        {
            await _roomRepository.Create(room);
            return new OkObjectResult(room);
        }
        
        // PUT: api/rooms/SingleRoom
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]RoomModel room)
        {
            var roomFromDb = await _roomRepository.GetRoom(name);
            if (roomFromDb == null)
                return new NotFoundResult();
            room.Id = roomFromDb.Id;
            await _roomRepository.Update(name, room);
            return new OkObjectResult(room);
        }
        
        // DELETE: api/rooms/XXXX
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var roomFromDb = await _roomRepository.GetRoom(name);
            if (roomFromDb == null)
            {
                return new NotFoundResult();
            }

            await _roomRepository.Delete(name);
            return new OkResult();
        }
    }
}
