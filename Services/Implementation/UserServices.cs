using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;
using ADOProject.Repository.Interfaces;
using ADOProject.Services.Interface;

namespace ADOProject.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAll()
        {
            var users = _userRepository.GetAll();
            foreach (var user in users)
            {
                return (IEnumerable<User>)user;
            }
            return null;
        }

        public User GetBy(string id)
        {
            var get = _userRepository.Get(id);
            if(get != null)
            {
                return get;
            }
            return null;
        }

        public User Login(string email, string password)
        {
            var user = _userRepository.Getby(email);
            if (user.Email == email && user.Password == password)
            {
                return user;
            }
            return null;
            
        }
    }
}