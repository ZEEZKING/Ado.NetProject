using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Repository.Interfaces
{
    public interface IManagerRepository
    {
       Manager Create(Manager manager);
       Manager Get(string id); 
       Manager Update(User user);
       IEnumerable<Manager> GetAll();
    }
}