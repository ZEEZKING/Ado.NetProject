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
    public class UserRepository : IUserRepository
    {
        public static DBContext _context;
        public UserRepository(DBContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into user(Id, Name, Email, Password, PhoneNumber, Address, IsDeleted, DateCreated) values('{user.Id}', '{user.Name}', '{user.Email}', '{user.Password}', '{user.PhoneNumber}', '{user.Address}', '{user.IsDeleted}', '{user.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        public User Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from user where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                User user = new User();
                while (row.Read())
                {
                    user.Id = Convert.ToString(row[0]);
                    user.Name = Convert.ToString(row[1]);
                    user.Email = Convert.ToString(row[2]);
                    user.Password = Convert.ToString(row[3]);
                    user.PhoneNumber = Convert.ToString(row[4]);
                    user.Address = Convert.ToString(row[5]);
                    user.IsDeleted = bool.Parse(row[6].ToString());
                    user.DateCreated = DateTime.Parse(row.GetString(7));

                }
                return user;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from user where Id = @id;", con);
                var row = command.ExecuteReader();
                List<User> users = new List<User>();
                while (row.Read())
                {
                    User user = new User();

                    user.Id = Convert.ToString(row[0]);
                    user.Name = Convert.ToString(row[1]);
                    user.Email = Convert.ToString(row[2]);
                    user.Password = Convert.ToString(row[3]);
                    user.PhoneNumber = Convert.ToString(row[4]);
                    user.Address = Convert.ToString(row[5]);
                    user.IsDeleted = bool.Parse(row[6].ToString());
                    user.DateCreated = DateTime.Parse(row.GetString(7));

                    users.Add(user);

                }
                return users;
            }
        }

        public User Getby(string email)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var commandText = new MySqlCommand($"select * from user where Email = @email;",con);
                var row = commandText.ExecuteScalar();
                User user = new User();
                user.Email = Convert.ToString(0);
                return user;
            }
        }
    }
}