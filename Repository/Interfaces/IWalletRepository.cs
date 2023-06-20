using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADOProject.Models.Entities;

namespace ADOProject.Repository.Interfaces
{
    public interface IWalletRepository
    {
        Wallet Create(Wallet wallet);
        Wallet Get(string id);
        Wallet Update(string id);
        IEnumerable<Wallet> GetAll();
    }
}