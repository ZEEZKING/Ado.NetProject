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
    public class UserRoleRepository : IUserRoleRepository
    {
        public static DBContext _context;
        public UserRoleRepository(DBContext context)
        {
            _context = context;
        }
        public UserRole Create(UserRole userRole)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into userrole(Id, UserId, RoleId, IsDeleted, DateCreated) values('{userRole.Id}', '{userRole.UserId}', '{userRole.RoleId}',  '{userRole.IsDeleted}', '{userRole.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return userRole;
                }
                else
                {
                    return null;
                }
            }
        }

        public UserRole Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                UserRole userRole = new UserRole();
                while (row.Read())
                {
                    userRole.Id = Convert.ToString(row[0]);
                    userRole.UserId = Convert.ToString(row[1]);
                    userRole.RoleId = Convert.ToString(row[2]);
                    userRole.IsDeleted = bool.Parse(row[3].ToString());
                    userRole.DateCreated = DateTime.Parse(row.GetString(4));
                }
                return userRole;
            }
        }

        public IEnumerable<UserRole> GetAll()
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from where Id = @id;", con);
                var row = command.ExecuteReader();
                List<UserRole> userRoles = new List<UserRole>();
                while (row.Read())
                {
                    UserRole userRole = new UserRole();

                    userRole.Id = Convert.ToString(row[0]);
                    userRole.UserId = Convert.ToString(row[1]);
                    userRole.RoleId = Convert.ToString(row[2]);
                    userRole.IsDeleted = bool.Parse(row[3].ToString());
                    userRole.DateCreated = DateTime.Parse(row.GetString(4));

                    userRoles.Add(userRole);
                }
                return userRoles;
            }
        }
    }
}