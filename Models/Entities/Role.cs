using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADOProject.Models.Entities
{
    public class Role : BaseEntity
    {
       public string Name{get; set;}
       public string Description{get; set;}
       public List<UserRole> userRoles{get; set;} 
    }
}