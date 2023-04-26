using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorLibrary
{
    public class NumberOddException:ApplicationException
    {
        public NumberOddException(string msg=null,Exception innerException=null):base(msg,innerException) { }
    }
}
