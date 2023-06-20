using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADOProject.Models.Entities
{
    public class UserRole : BaseEntity
    {
        public string UserId;
        public User User;
        public string RoleId;
        public Role Role;
    }
}