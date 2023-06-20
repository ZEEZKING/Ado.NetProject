using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Services.Interface
{
    public interface IUserServices
    {
        User Login(string email, string password);
        User GetBy(string id);
        IEnumerable<User> GetAll();
    }
}