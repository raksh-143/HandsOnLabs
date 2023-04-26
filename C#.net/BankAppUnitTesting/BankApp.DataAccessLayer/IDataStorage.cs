using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.DataAccessLayer
{
    public interface IDataStorage
    {
        bool Save(string msg);
    }
}
