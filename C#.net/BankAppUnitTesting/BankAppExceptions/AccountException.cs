using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppExceptions
{
    public class AccountException:ApplicationException
    {
        public AccountException(string msg="",Exception innerException=null):base(msg)
        {
        }
    }
}
