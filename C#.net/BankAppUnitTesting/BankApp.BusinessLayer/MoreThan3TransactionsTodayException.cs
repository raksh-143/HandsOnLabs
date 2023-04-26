using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BusinessLayer
{
    public class MoreThan3TransactionsTodayException:Exception
    {
        public MoreThan3TransactionsTodayException(string msg = "", Exception ex = null) : base(msg) { }
    }
}
