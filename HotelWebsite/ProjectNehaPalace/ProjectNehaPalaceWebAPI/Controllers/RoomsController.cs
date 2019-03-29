using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectNehaPalaceWebAPI.Models;
using ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models;

namespace ProjectNehaPalaceWebAPI.Controllers
{
    [Produces("application/json")]
    public class RoomsController : Controller
    {
        RoomsManager rm = new RoomsManager();
        private IHostingEnvironment _Env;
        public RoomsController(IHostingEnvironment envrnmt)
        {
            _Env = envrnmt;
        }

        // GET api/students
        [HttpGet]
        [Route("api/rooms")]
        public IEnumerable<RoomModel> GetAsync()
        {
            var webRootInfo = _Env.WebRootPath;
            var file = System.IO.Path.Combine(webRootInfo, "lastaccess.txt");
            System.IO.File.WriteAllText(file, DateTime.Now.ToString());
            return rm.GetAll;
        }

        // GET api/Rooms/RoomType
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IEnumerable<RoomModel>> Get(string roomType)
        {
            return await GetAsync(roomType);
        }

        private Task<IEnumerable<RoomModel>> GetAsync(string roomType)
        {
            return Task.FromResult(rm.GetRoomsByRoomType(roomType));
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        [ActionName("Post01")]
        public async Task<StatusCodeResult> Post01([FromBody] RoomModel roomModel)
        {
            if (roomModel == null)
            {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }
            if (await PostAsyncPartOne(roomModel))
            {
                return await PostAsyncPartTwo(roomModel);
            }
            else
            {
                rm.AddRoom(roomModel);
                //dbContext.Companies.Add(company);
                //await dbContext.SaveChangesAsync();
                return new StatusCodeResult(201); //created
            }
        }
        private Task<bool> PostAsyncPartOne(RoomModel roomModel)
        {
            return Task.FromResult(rm.GetAll.Any(_ => _.RoomType == roomModel.RoomType));
        }
        private Task<StatusCodeResult> PostAsyncPartTwo(RoomModel roomModel)
        {
            if (rm.EditRoom(roomModel))
            {
                return Task.FromResult(new StatusCodeResult(200)); //success
            }
            else
            {
                return Task.FromResult(new StatusCodeResult(404)); //not found
            }
        }

        // add new or edit
        [HttpPut]
        [Route("api/[controller]/[action]")]
        [ActionName("Put01")]
        public async Task<StatusCodeResult> Put01([FromBody] RoomModel roomModel)
        {
            if (roomModel == null)
            {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }
            if (await PostAsyncPartOne(roomModel))
            {
                return await PostAsyncPartTwo(roomModel);
            }
            else
            {
                rm.AddRoom(roomModel);
                //dbContext.Companies.Add(company);
                //await dbContext.SaveChangesAsync();
                return new StatusCodeResult(201); //created
            }
        }

        // delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("api/[controller]/{id}")]
        public async Task<StatusCodeResult> Delete(string roomType)
        {
            return await DeleteAsync(roomType);
        }
        private Task<StatusCodeResult> DeleteAsync(string roomType)
        {
            if (rm.DeleteRoom(roomType))
                return Task.FromResult(new StatusCodeResult(200));
            else
                return Task.FromResult(new StatusCodeResult(404));
        }
    }

}
