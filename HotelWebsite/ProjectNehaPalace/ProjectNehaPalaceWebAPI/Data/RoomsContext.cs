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
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<RoomModel> Rooms => _db.GetCollection<RoomModel>("Rooms");
    }
}
