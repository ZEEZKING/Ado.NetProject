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
    public class WalletRepository : IWalletRepository
    {
        public static DBContext _context;
        public WalletRepository(DBContext context)
        {
            _context = context;
        }
        public Wallet Create(Wallet wallet)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into Wallet(Id, Amount, UserId,  IsDeleted, DateCreated) values('{wallet.Id}', '{wallet.Amount}', '{wallet.UserId}',  '{wallet.IsDeleted}', '{wallet.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return wallet;
                }
                else
                {
                    return null;
                }
            }
        }

        public Wallet Get(string id)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from where Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                var row = command.ExecuteReader();
                Wallet wall = new Wallet();
                while (row.Read())
                {
                    wall.Id = Convert.ToString(row[0]);
                    wall.UserId = Convert.ToString(row[1]);
                    wall.Amount = double.Parse(row[2].ToString());
                    wall.IsDeleted = bool.Parse(row[3].ToString());
                    wall.DateCreated = DateTime.Parse(row.GetString(4));
                }
                return wall;
            }
        }

        public IEnumerable<Wallet> GetAll()
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"select * from where Id = @id;", con);
                var row = command.ExecuteReader();
                List<Wallet> wallets = new List<Wallet>();
                while (row.Read())
                {
                    Wallet wall = new Wallet();

                    wall.Id = Convert.ToString(row[0]);
                    wall.UserId = Convert.ToString(row[1]);
                    wall.Amount = double.Parse(row[2].ToString());
                    wall.IsDeleted = bool.Parse(row[3].ToString());
                    wall.DateCreated = DateTime.Parse(row.GetString(4));

                    wallets.Add(wall);
                }
                return wallets;
            }
        }

        public Wallet Update(string id)
        {
            var wallGet = Get(id);
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"update wallet set  Id = @id;", con);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("Wallet",wallGet);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return wallGet;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}