using MongoDB.Driver;
using ProjectNehaPalace.ProjectNehaPalaceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectNehaPalaceWebAPI.Data
{
    interface IRoomContext
    {
        IMongoCollection<RoomModel> Rooms { get; }
    }
}
