using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace ADOProject.Data.Interface
{
    public interface IDBContext
    {
       MySqlConnection Connection();
       void CreateSchema();
       void CreateBookingTable();
       void CreateCustomerTable();
       void CreateManagerTable();
       void CreateRoleTable();
       void CreateRoomTable();
       void UserTable();
       void CreateWalletTable();
       void CreateUserRole();
       
    }
}