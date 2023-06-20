using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Services.Interface
{
    public interface IRoleServices
    {
       Role Create(string name, string description);
       Role Getby(string id);
       List<Role> GetAll(); 
    }
}