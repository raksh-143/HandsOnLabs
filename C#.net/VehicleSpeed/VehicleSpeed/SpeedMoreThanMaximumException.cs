using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSpeed
{
    internal class SpeedMoreThanMaximumException:ApplicationException
    {
        Exception innerException;
        public string errorMessage { get; set; }
        public SpeedMoreThanMaximumException(string msg="",Exception innerException=null) : base(msg,innerException){
            this.innerException = innerException;
            errorMessage = msg;
        }
    }
}
