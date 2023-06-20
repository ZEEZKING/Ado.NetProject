using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADOProject.Models.Entities
{
    public class Wallet : BaseEntity
    {
      public double Amount{get; set;}
      public string UserId{get; set;}
      public User User{get; set;} 
    }
}