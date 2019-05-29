using ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalaceWebAPI.Services
{
    public interface IRoomRepository
    {
        Task<List<RoomModel>> GetAllRooms();
        Task<RoomModel> GetRoom(string name);
        Task<RoomModel> Create(RoomModel room);
        Task Update(string name, RoomModel room);
        Task Delete(string name);
    }
}
