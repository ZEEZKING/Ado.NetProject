using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADOProject.Models.Entities
{
    public class Customer : BaseEntity
    {
        public string UserId{get; set;}
        public User  User{get; set;}
    }
}