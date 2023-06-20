using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Repository.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User Get(string id);
        User Getby(string email);
        IEnumerable<User> GetAll();
    }
}