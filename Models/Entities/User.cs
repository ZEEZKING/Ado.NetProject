using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADOProject.Models.Entities
{
    public class User : BaseEntity
    {
        public string Name{get; set;}
        public string Email{get; set;}
        public string Password{get; set;}
        public string PhoneNumber{get; set;}
        public string Address{get; set;}
        public List<UserRole> userRoles{get; set;} 
        public Manager Manager{get; set;}
        public Customer Customer{get; set;}

    }
}