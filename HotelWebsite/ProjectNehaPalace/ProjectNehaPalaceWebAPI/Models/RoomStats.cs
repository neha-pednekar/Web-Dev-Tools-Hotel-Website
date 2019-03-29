using ProjectNehaPalaceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalaceWebAPI.Models
{
    public class RoomStats
    {
        private RoomsManager _manager = new RoomsManager();

        public async Task<int> GetRoomCount()
        {
            return await Task.FromResult(_manager.GetAll.Count());
        }

        public async Task<int> GetStudentCountByGpa(string roomType)
        {
            return await Task.FromResult(_manager.GetRoomsByRoomType(roomType).Count());
        }
    }

    public class RoomStatsSingleton
    {
        private static RoomStatsSingleton instance;
        public static RoomsManager _manager;

        public async Task<int> GetRoomCount()
        {
            return await Task.FromResult(_manager.GetAll.Count());
        }

        public async Task<int> GetRoomCountByRoomType(string roomType)
        {
            return await Task.FromResult(_manager.GetRoomsByRoomType(roomType).Count());
        }

        private RoomStatsSingleton() { }

        public static RoomStatsSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomStatsSingleton();
                    _manager = new RoomsManager();
                }
                return instance;
            }
        }
    }
}
