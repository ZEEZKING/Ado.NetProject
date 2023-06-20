using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Repository.Interfaces
{
    public interface ICustomerRepository
    {
       Customer Create(Customer customer);
       Customer Get(string id);
        IEnumerable<Customer> GetAll();
    }
}