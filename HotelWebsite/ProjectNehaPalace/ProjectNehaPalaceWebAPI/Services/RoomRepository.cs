using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models;
using ProjectNehaPalaceWebAPI.Data;

namespace ProjectNehaPalaceWebAPI.Services
{
    class RoomRepository : IRoomRepository
    {
        private readonly IRoomContext _roomContext;

        public RoomRepository(IRoomContext roomContext)
        {
            this._roomContext = roomContext;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _roomContext.Rooms.Find(book => true).ToListAsync();
        }

        public async Task<Room> GetRoom(string name)
        {
            return await _roomContext.Rooms.Find<Room>(room => room.RoomType == name).FirstOrDefaultAsync();
        }

        public async Task<Room> Create(Room room)
        {
            await _roomContext.Rooms.InsertOneAsync(room);
            return room;
        }

        public async Task Update(string name, Room roomInput)
        {
            await _roomContext.Rooms.ReplaceOneAsync(room => room.RoomType == name, roomInput);
        }
        
        public async Task Delete(string name)
        {
            await _roomContext.Rooms.DeleteOneAsync(room => room.RoomType == name);
        }

    }
}
