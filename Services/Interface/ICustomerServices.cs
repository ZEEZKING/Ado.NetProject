using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Services.Interface
{
    public interface ICustomerServices
    {
        string Create(User user);
        Customer Getby(string id);
        List<Customer> GetAll();
    }
}