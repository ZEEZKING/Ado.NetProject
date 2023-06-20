using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Repository.Interfaces
{
    public interface IRoleRepository
    {
       Role Create(Role role); 
       Role Get(string id);
       IEnumerable<Role> GetAll();
    }
}