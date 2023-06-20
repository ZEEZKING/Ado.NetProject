using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADOProject.Models.Entities
{
    public class Room : BaseEntity
    {
       public string RoomName{get; set;}
       public string RoomNumber{get; set;}
       public double Price{get; set;}
       public bool Booked{get; set;}
       public List<Booking> Bookings{get; set;}

    }
}