using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;
using ADOProject.Services.Interface;

namespace ADOProject.Services.Implementation
{
    public class BookingServices : IBookingService
    {
        public Booking CheckIn(string referenceNo)
        {
            throw new NotImplementedException();
        }

        public Booking CheckOut(string referenceNo)
        {
            throw new NotImplementedException();
        }

        public Booking CreateBooking(string roomName, int duration)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}