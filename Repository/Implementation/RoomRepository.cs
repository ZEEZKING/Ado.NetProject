using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Data;
using ADOProject.Models.Entities;
using ADOProject.Repository.Interfaces;
using MySqlConnector;

namespace ADOProject.Repository.Implementation
{
    public class RoomRepository : IRoomRepository
    {
        public static DBContext _context;
        public RoomRepository(DBContext context)
        {
            _context = context;
        }
        public Room Create(Room room)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into room(Id, Name, RoomNumber,Price, Booked, IsDeleted, DateCreated) values('{room.Id}', '{room.RoomName}', '{room.RoomNumber}','{room.Price}', '{room.Booked}' ,'{room.IsDeleted}', '{room.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return room;
                }
                else
                {
                    return null;
                }
            }
        }

        public Room Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from room where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                Room room = new Room();
                while (row.Read())
                {
                    room.Id = Convert.ToString(row[0]);
                    room.RoomName = Convert.ToString(row[1]);
                    room.RoomNumber = Convert.ToString(row[2]);
                    room.Price = double.Parse(row[3].ToString());
                    room.Booked = bool.Parse(row[4].ToString());
                    room.IsDeleted = bool.Parse(row[5].ToString());
                    room.DateCreated = DateTime.Parse(row.GetString(6));
                }
                return room;
            }
        }

        public IEnumerable<Room> GetAll()
        {
           
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from room where Id = @id;", con);
                var row = command.ExecuteReader();
                List<Room> rooms = new List<Room>();
                while (row.Read())
                {
                    Room room = new Room();

                    room.Id = Convert.ToString(row[0]);
                    room.RoomName = Convert.ToString(row[1]);
                    room.RoomNumber = Convert.ToString(row[2]);
                    room.Price = double.Parse(row[3].ToString());
                    room.Booked = bool.Parse(row[4].ToString());
                    room.IsDeleted = bool.Parse(row[5].ToString());
                    room.DateCreated = DateTime.Parse(row.GetString(6));

                    rooms.Add(room);
                }
                return rooms;
            } 
        }

        public Room GetRoom(string roomName)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var commandText = new MySqlCommand($"select * from room where RoomName = @roomName;",con);
                var row =commandText.ExecuteScalar();
                Room room = new Room();
                room.RoomName = Convert.ToString(0);
                return room;
            }
        }

        public Room Update(string id)
        {
            var getBook = Get(id);
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"update room set Booked = {getBook.Booked}, where Id = {id}",con);
                command.Parameters.AddWithValue("id",id);
                command.Parameters.AddWithValue("room",getBook);
                var row = command.ExecuteNonQuery();
                 if (row != -1)
                {
                    return getBook;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}