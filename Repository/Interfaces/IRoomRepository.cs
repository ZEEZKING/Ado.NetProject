using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Repository.Interfaces
{
    public interface IRoomRepository
    {
        Room Create(Room room);
        Room Get(string id);
        Room GetRoom(string roomName);
        Room Update(string id);
        IEnumerable<Room> GetAll();
    }
}