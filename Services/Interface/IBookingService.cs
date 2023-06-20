using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Services.Interface
{
    public interface IBookingService
    {
        Booking CreateBooking(string roomName, int duration);
        Booking CheckIn(string referenceNo);
        Booking CheckOut(string referenceNo);
        List<Booking> GetAll();
        
    }
}