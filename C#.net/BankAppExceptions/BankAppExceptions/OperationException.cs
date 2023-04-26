using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppExceptions
{
    internal class OperationException:ApplicationException
    {
        public OperationException(string msg="",Exception ex=null):base(msg) { }
    }
}
