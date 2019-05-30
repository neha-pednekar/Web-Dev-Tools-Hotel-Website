using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models;
using ProjectNehaPalaceWebAPI.Data;

namespace ProjectNehaPalaceWebAPI.Models
{
    public class RoomContext : IRoomContext
    {
        private readonly IMongoDatabase _db;
        public RoomContext(IOptions<Settings> options)
        {
            //var client = new MongoClient(options.Value.ConnectionString);
            //_db = client.GetDatabase(options.Value.Database);
            var client = new MongoClient("");
            _db = client.GetDatabase("room_info");
        }
        public IMongoCollection<RoomModel> Rooms => _db.GetCollection<RoomModel>("rooms");
    }
}
