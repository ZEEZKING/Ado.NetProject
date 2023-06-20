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
    public class CustomerRepository : ICustomerRepository
    {
        public static DBContext _context;
        public CustomerRepository(DBContext context)
        {
            _context = context;
        }
        public Customer Create(Customer customer)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into customer(Id, UserId, IsDeleted, DateCreated) values('{customer.Id}', '{customer.UserId}', '{customer.IsDeleted}', '{customer.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return customer;
                }
                else
                {
                    return null;
                }
            }
        }

        public Customer Get(string id)
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from customer where Id = @id;", con);
                    command.Parameters.AddWithValue("id", id);
                    var row = command.ExecuteReader();
                    Customer customer = new Customer();
                    while (row.Read())
                    {
                        customer.Id = Convert.ToString(row[0]);
                        customer.UserId = Convert.ToString(row[1]);
                        customer.IsDeleted = bool.Parse(row[2].ToString());
                        customer.DateCreated = DateTime.Parse(row.GetString(3));
                    }
                    return customer;
                }
            }
            catch (System.Exception)
            {

                return null;
            }

        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand("select * from customer", con);
                    var row = command.ExecuteReader();
                    List<Customer> customers = new List<Customer>();
                    while (row.Read())
                    {
                        Customer customer = new Customer();

                        customer.Id = Convert.ToString(row[0]);
                        customer.UserId = Convert.ToString(row[1]);
                        customer.IsDeleted = bool.Parse(row[2].ToString());
                        customer.DateCreated = DateTime.Parse(row.GetString(3));

                        customers.Add(customer);
                    }
                    return customers;
                }
            }
            catch (System.Exception)
            {
                return null;
            }

        }
    }
}