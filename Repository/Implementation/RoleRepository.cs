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
    public class RoleRepository : IRoleRepository
    {
        public static DBContext _context;
        public RoleRepository(DBContext context)
        {
            _context = context;
        }
        public Role Create(Role role)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into manager (Id, Name, Description, IsDeleted, DateCreated) values('{role.Id}', '{role.Name}', '{role.Description}', '{role.IsDeleted}', '{role.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return role;
                }
                else
                {
                    return null;
                }
            }
        }

        public Role Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from role where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                Role role = new Role();
                while (row.Read())
                {
                    role.Id = Convert.ToString(row[0]);
                    role.Name = Convert.ToString(row[1]);
                    role.Description = Convert.ToString(row[2]);
                    role.IsDeleted = bool.Parse(row[3].ToString());
                    role.DateCreated = DateTime.Parse(row.GetString(4));
                }
                return role;
            }
        }

        public IEnumerable<Role> GetAll()
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand("select * from role", con);
                var row = command.ExecuteReader();
                List<Role> roles = new List<Role>();
                while (row.Read())
                {
                    Role role = new Role();

                    role.Id = Convert.ToString(row[0]);
                    role.Name = Convert.ToString(row[1]);
                    role.Description = Convert.ToString(row[2]);
                    role.IsDeleted = bool.Parse(row[3].ToString());
                    role.DateCreated = DateTime.Parse(row.GetString(4));

                    roles.Add(role);
                }
                return roles;
            }
        }
    }
}