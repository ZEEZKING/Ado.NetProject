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
    public class ManagerRepository : IManagerRepository
    {
        public static DBContext _context;
        public ManagerRepository(DBContext context)
        {
            _context = context;
        }
        public Manager Create(Manager manager)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into manager (Id, UserId, IsDeleted, DateCreated) values('{manager.Id}', '{manager.UserId}', '{manager.IsDeleted}', '{manager.DateCreated}');",con);
                var row = command.ExecuteNonQuery();
                if(row != -1)
                {
                    return manager;
                }
                else
                {
                    return null;
                }
            }
        }

        public Manager Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from nanager where Id = @id;",con);
                command.Parameters.AddWithValue("id",id);
                var row = command.ExecuteReader();
                Manager manager = new Manager();
                while (row.Read())
                {
                    manager.Id = Convert.ToString(row[0]);
                    manager.UserId = Convert.ToString(row[1]);
                    manager.IsDeleted = bool.Parse(row[2].ToString());
                    manager.DateCreated = DateTime.Parse(row.GetString(3));
                }
                return manager;
            }
        }

        public IEnumerable<Manager> GetAll()
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from nanager ");
                var row = command.ExecuteReader();
                List<Manager> managers = new List<Manager>();
                while (row.Read())
                {
                    Manager manager = new Manager();

                    manager.Id = Convert.ToString(row[0]);
                    manager.UserId = Convert.ToString(row[1]);
                    manager.IsDeleted = bool.Parse(row[2].ToString());
                    manager.DateCreated = DateTime.Parse(row.GetString(3));

                    managers.Add(manager);
                }
                return managers;
            }
        }

        public Manager Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}