using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("RoomType")]
        public string RoomType { get; set; }

        [BsonElement("RoomTariff")]
        public double RoomTariff { get; set; }

        [BsonElement("RoomsAvailable")]
        public int RoomsAvailable { get; set; }
    }

}
