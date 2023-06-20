// See https://aka.ms/new-console-template for more information
using ADOProject.Data;
using ADOProject.Repository.Implementation;

Console.WriteLine("Hello, World!");

var db = new DBContext();
// db.Connection();
db.CreateBookingTable();



// BookingRepository buk = new BookingRepository(db);
// db.CreateBookingTable();
