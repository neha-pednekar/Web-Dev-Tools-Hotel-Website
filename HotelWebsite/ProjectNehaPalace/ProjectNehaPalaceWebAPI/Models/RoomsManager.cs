using Newtonsoft.Json;
using ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalaceWebAPI.Models
{
    public class RoomsManager
    {
        List<RoomModel> _rooms;
        public RoomsManager()
        {
            try
            {
                if (File.Exists("rooms.txt"))
                {
                    _rooms = ReadRoomList().ToList();
                }
                else
                {
                    _rooms = new List<RoomModel>()
                    { 
                        new RoomModel
                        (RoomType.SingleRoom.ToString(),(double)RoomTariff.SingleRoom, true, 
                        (int)RoomsAvailable.SingleRoom),
                        new RoomModel
                        (RoomType.DoubleRoom.ToString(),(double)RoomTariff.DoubleRoom, true, 
                        (int)RoomsAvailable.DoubleRoom),
                        new RoomModel
                        (RoomType.DeluxeOneBedroomSuite.ToString(),(double)RoomTariff.DeluxeOneBedroomSuite, true, 
                        (int)RoomsAvailable.DeluxeOneBedroomSuite),
                        new RoomModel
                        (RoomType.DeluxeTwoBedroomSuite.ToString(),(double)RoomTariff.DeluxeTwoBedroomSuite, true, 
                        (int)RoomsAvailable.DeluxeTwoBedroomSuite),
                        new RoomModel
                        (RoomType.RoyalSuit.ToString(),(double)RoomTariff.RoyalSuit, true, 
                        (int)RoomsAvailable.RoyalSuit),
                        new RoomModel
                        (RoomType.KingSuit.ToString(),(double)RoomTariff.KingSuit, true, 
                        (int)RoomsAvailable.KingSuit)
                       };
                    WriteRoomsList(_rooms);
                }
            }
            catch (IOException ioe)
            {

            }
        }

        IEnumerable<RoomModel> ReadRoomList()
        {
            return JsonConvert.DeserializeObject<List<RoomModel>>(File.ReadAllText("rooms.txt"));
        }

        void WriteRoomsList(IEnumerable<RoomModel> rooms)
        {
            var output = JsonConvert.SerializeObject(rooms);
            File.WriteAllText("rooms.txt", output);
        }

        public IEnumerable<RoomModel> GetAll { get { return _rooms; } }

        public IEnumerable<RoomModel> GetRoomsByRoomType(string _roomType)
        {
            //return _students.Where(o => o.GPA.Equals(gpa)).ToList();
            return _rooms.Where(_ => _.RoomType == _roomType).ToList();
        }

        public IEnumerable<RoomModel> GetRoomsByRoomTariff(double _roomTariff)
        {
            //return _students.Where(o => o.GPA.Equals(gpa)).ToList();
            return _rooms.Where(_ => _.RoomTariff == _roomTariff).ToList();
        }

        public void AddRoom(RoomModel roomModel)
        {
            _rooms.Add(roomModel);
            var output = JsonConvert.SerializeObject(_rooms);
            File.WriteAllText("rooms.txt", output);
        }

        public bool DeleteRoom(string roomType)
        {
            if (!_rooms.Any(_ => _.RoomType == roomType)) return false;
            _rooms.RemoveAll(_ => _.RoomType == roomType);
            return true;
        }

        public bool EditRoom(RoomModel roomModel)
        {
            var _room = _rooms.FirstOrDefault(_ => _.RoomType == roomModel.RoomType);
            if (_room == null) return false;
            _room.RoomType = roomModel.RoomType;
            _room.Availability = roomModel.Availability;
            _room.RoomsAvailable = roomModel.RoomsAvailable;
            _room.RoomTariff = roomModel.RoomTariff;

            return true;
        }
    }
}
