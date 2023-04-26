using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberValidation.BusinessLogic.Exceptions
{
    public class InvalidMobileNumberException:ApplicationException
    {
        public InvalidMobileNumberException(string msg="",Exception innerException=null):base(msg,innerException) { }

    }
}
