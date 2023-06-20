using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;
using ADOProject.Models.Enums;

namespace ADOProject.Repository.Interfaces
{
    public interface IBookingRepository
    {
       Booking Create(Booking booking);
       Booking Get(string id);
       Booking UpdateCheckedIn(string id);
       IEnumerable<Booking> GetAll(); 
    }
}