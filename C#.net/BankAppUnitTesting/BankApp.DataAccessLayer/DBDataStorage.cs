using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.DataAccessLayer
{
    public class DBDataStorage : IDataStorage
    {
        public bool Save(string msg)
        {
            return true;
        }
    }
}
