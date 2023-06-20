using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Services.Interface
{
    public interface IManagerServices
    {
        string Create(Manager manager);
        Manager GetBy(string id);
        List<Manager> GetAll();
        
    }
}