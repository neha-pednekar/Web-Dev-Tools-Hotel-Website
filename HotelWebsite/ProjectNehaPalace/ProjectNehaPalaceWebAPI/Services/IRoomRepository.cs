using ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalaceWebAPI.Services
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoom(string name);
        Task<Room> Create(Room room);
        Task Update(string name, Room room);
        Task Delete(string name);
    }
}
