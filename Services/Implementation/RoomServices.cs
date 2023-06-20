using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;
using ADOProject.Repository.Interfaces;
using ADOProject.Services.Interface;

namespace ADOProject.Services.Implementation
{
    public class RoomServices : IRoomServices
    {
        private readonly IRoomRepository _roomRepository;
        public RoomServices(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public Room CheckIfRoomAvailable(string roomNumber)
        {
            throw new NotImplementedException();
        }

        public Room Create(string roomName, string roomNumber,double price)
        {
            var roomExist = Check(roomName);
            if (roomExist)
            {
                return null;
            }
            Room room = new Room()
            {
                RoomName = roomName,
                RoomNumber = roomNumber,
                Price = price
            };
            var rooms = _roomRepository.Create(room);
            return room;
        }

        public IEnumerable<Room> GetAll()
        {
            throw new NotImplementedException();
        }

        public Room GetRoom(string id)
        {
            var room = _roomRepository.Get(id);
            if (room != null)
            {
                return room;
            }
            return null;
        }

        private bool Check(string roomName)
        {
            var room = _roomRepository.GetRoom(roomName);
            if (room.RoomName == roomName)
            {
                return true;
            }
            return false;
        }
    }
}