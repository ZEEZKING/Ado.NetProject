using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Data.Interface;
using MySqlConnector;

namespace ADOProject.Data
{
    public class DBContext : IDBContext
    {
        public string connectionString = "server = localhost;user = root;database = HotelApp;port = 3306;password = oluwaseyi21";

        public MySqlConnection Connection()
        {
            return new MySqlConnection(connectionString);
        }


        public void CreateBookingTable()
        {
            try
            {
                using (var con = Connection())
                {
                    con.Open();
                    var command = new MySqlCommand("Create table if not exists Booking(Id varchar(4), CheckIn varChar(150), CheckOut varChar(150), Duration int(25), Status varChar(25),ReferenceNo varChar(4), RoomId varChar(50), IsDeleted varchar(50), DateCreated varchar(150), primary key(Id));", con);
                    var row = command.ExecuteNonQuery();
                    if (row != -1)
                    {
                        System.Console.WriteLine("Table Created Successfully!!!");
                    }
                    else
                    {
                        System.Console.WriteLine("Table not created");
                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        public void CreateSchema()
        {
            try
            {
                using (var con = Connection())
                {
                    con.Open();
                    var command = new MySqlCommand("CREATE SCHEMA HotelApp", con);
                    var row = command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
        public void CreateCustomerTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("create table if not exists customer(Id varchar(4),UserId varChar(5),IsDeleted varchar(50), DateCreated varchar(150), primary key(Id));", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    System.Console.WriteLine("table created sucessfully");
                }
                else
                {
                    System.Console.WriteLine("Table not created");
                }
            }
        }
        public void CreateManagerTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("create table if not exists manager(Id varChar(4),UserId varChar(5),IsDeleted varchar(50), DateCreated varchar(150), primary key(Id));", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    System.Console.WriteLine("Table created sucesfull");
                }
                else
                {
                    System.Console.WriteLine("table not created");
                }
            }
        }

        public void CreateRoleTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("create table if not exists Role(Id varChar(4),Name varChar(50),Description varChar(50),IsDeleted varchar(50), DateCreated varchar(150), primary key(Id));", con);
                var row = command.ExecuteNonQuery();
                if (row != 1)
                {
                    System.Console.WriteLine("Table created sucessfully");
                }
                else
                {
                    System.Console.WriteLine("table not created");
                }
            }
        }
        public void CreateRoomTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("create table if not exists Room(Id varchar(4), RoomName varChar(50), RoomNumber varChar(50), double Price, Booked bool, IsDeleted varchar(50), DateCreated varchar(150), primary key(Id));", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    System.Console.WriteLine("Table created sucessful");
                }
                else
                {
                    System.Console.WriteLine("table not created");
                }
            }
        }

        public void UserTable()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("create table if not exists user(Id varchar(4),Name varChar(225),Email varChar(150),Password varChar(100),PhoneNumber varChar(150),Address varChar(50),IsDeleted varchar(50), DateCreated varchar(150), primary key(Id));", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    System.Console.WriteLine("Table created sucessful");
                }
                else
                {
                    System.Console.WriteLine("table not created");
                }

            }
        }
        public void CreateWalletTable()
        {
            try
            {
                using (var con = Connection())
                {
                    con.Open();
                    var command = new MySqlCommand("create table if not exists Wallet(Id varChar(4),Amount double,UserId varChar(5),IsDeleted varchar(50), DateCreated varchar(150), primary key(Id));", con);
                    var row = command.ExecuteNonQuery();
                    if (row != -1)
                    {
                        System.Console.WriteLine("Table created sucesfull");
                    }
                    else
                    {
                        System.Console.WriteLine("table not created");
                    }
                }
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                throw;
            }

        }
        public void CreateUserRole()
        {
            using (var con = Connection())
            {
                con.Open();
                var command = new MySqlCommand("create table if not exists UserRole(Id varChar(4),UserId varChar(5),RoleId varChar(5),IsDeleted varchar(50),DateCreated varchar(150), primary key(Id));",con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    System.Console.WriteLine("Table created sucessful");
                }
                else
                {
                    System.Console.WriteLine("Table not created");
                }
            }
        }


    }
}