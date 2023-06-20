using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Data;
using ADOProject.Models.Entities;
using ADOProject.Models.Enums;
using ADOProject.Repository.Interfaces;
using MySqlConnector;

namespace ADOProject.Repository.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        public static DBContext _context;

        public BookingRepository(DBContext context)
        {
            _context = context;
            // _context.CreateBookingTable();
        }
        public Booking Create(Booking booking)
        {
            using (var con = _context.Connection())
            {
                con.Open();
                var command = new MySqlCommand($"insert into booking (Id, CheckIn, CheckOut, Duration, Status, RoomId, IsDeleted, DateCreated) values('{booking.Id}', '{booking.CheckIn}', '{booking.CheckOut}', '{booking.Duration}', '{booking.Status}', '{booking.IsDeleted}', '{booking.DateCreated}');", con);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return booking;
                }
                else
                {
                    return null;
                }

            }
        }

        public Booking Get(string id)
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand($"select * from booking where Id = @id;", con);
                    command.Parameters.AddWithValue("id", id);
                    var row = command.ExecuteReader();
                    Booking booking = new Booking();
                    while (row.Read())
                    {
                        booking.Id = Convert.ToString(row[0]);
                        booking.CheckIn = DateTime.Parse(row.GetString(1));
                        booking.CheckOut = DateTime.Parse(row.GetString(2));
                        booking.Duration = Convert.ToInt32(row[3]);
                        booking.Status = (BookingStatus)row[4];
                        booking.RoomId = Convert.ToString(row[5]);
                        booking.IsDeleted = bool.Parse(row[6].ToString());
                        booking.DateCreated = DateTime.Parse(row.GetString(7));

                    }
                    return booking;
                }
            }
            catch (System.Exception)
            {

                return null;
            }

        }

        public IEnumerable<Booking> GetAll()
        {
            try
            {
                using (var con = _context.Connection())
                {
                    con.Open();
                    var command = new MySqlCommand("select * from booking", con);
                    var row = command.ExecuteReader();
                    List<Booking> bookings = new List<Booking>();
                    while (row.Read())
                    {
                        Booking booking = new Booking();

                        booking.Id = Convert.ToString(row[0]);
                        booking.CheckIn = DateTime.Parse(row.GetString(1));
                        booking.CheckOut = DateTime.Parse(row.GetString(2));
                        booking.Duration = Convert.ToInt32(row[3]);
                        booking.Status = (BookingStatus)row[4];
                        booking.RoomId = Convert.ToString(row[5]);
                        booking.IsDeleted = bool.Parse(row[6].ToString());
                        booking.DateCreated = DateTime.Parse(row.GetString(7));

                        bookings.Add(booking);

                    }
                    return bookings;
                }
            }
            catch (System.Exception)
            {

                return null;
            }

        }

        public Booking UpdateCheckedIn(string id)
        {
            var bookget = Get(id);
            bookget.Status = BookingStatus.CheckedIn;
            using (var con = _context.Connection())
            {
                var command = new MySqlCommand($"update booking set status = {bookget.CheckIn}, where Id = {id}",con);
                command.Parameters.AddWithValue("id",id);
                command.Parameters.AddWithValue("booking",bookget);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return bookget;
                }
                else
                {
                    return null;
                }
            }

        }

        public Booking UpdateCheckedOut(string id)
        {
            var bookget = Get(id);
            bookget.Status = BookingStatus.CheckedOut;
            bookget.Status = BookingStatus.CheckedIn;
            using (var con = _context.Connection())
            {
                var command = new MySqlCommand($"update booking set status = {bookget.CheckOut}, where Id = {id}",con);
                command.Parameters.AddWithValue("id",id);
                command.Parameters.AddWithValue("booking",bookget);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return bookget;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}