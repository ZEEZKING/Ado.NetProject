using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Services.Interface
{
    public interface IWalletServices
    {
        Wallet Create(User user);
        Wallet Get(string id);
        Wallet Update(string id);
        IEnumerable<Wallet> GetAll();
    }
}