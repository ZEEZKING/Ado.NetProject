using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Repository.Interfaces
{
    public interface IUserRoleRepository
    {
       UserRole Create(UserRole userRole);
       UserRole Get(string id);
       IEnumerable<UserRole> GetAll(); 
    }
}