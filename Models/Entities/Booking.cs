using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Enums;

namespace ADOProject.Models.Entities
{
    public class Booking : BaseEntity
    {
        public DateTime CheckIn{get; set;}
        public DateTime CheckOut {get; set;}
        public int Duration {get; set;}
        public BookingStatus Status {get; set;} = BookingStatus.pending;
        public string ReferenceNo{get; set;} 
        public string RoomId{get; set;}
        public Room Room{get; set;}               
    }
}