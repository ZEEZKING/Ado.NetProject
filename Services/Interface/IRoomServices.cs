using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Services.Interface
{
    public interface IRoomServices
    {
        Room Create(string roomName,string roomNumber,double Price);
        Room GetRoom(string id);
        Room CheckIfRoomAvailable(string roomNumber);
        IEnumerable<Room> GetAll();
    }
}