using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models
{
    public class RoomModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string RoomType { get; set; }

        public double RoomTariff { get; set; }

        public int RoomsAvailable { get; set; }

        public int RoomsBooked { get; set; }

        public int TotalRooms { get; set; }
    }

}
