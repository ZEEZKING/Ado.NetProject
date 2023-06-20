using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADOProject.Models.Entities
{
    public class BaseEntity
    {
        public string Id{get; set;} = Guid.NewGuid().ToString().Substring(0,4);
        public bool IsDeleted{get; set;}
        public DateTime DateCreated{get; set;}
    }
}