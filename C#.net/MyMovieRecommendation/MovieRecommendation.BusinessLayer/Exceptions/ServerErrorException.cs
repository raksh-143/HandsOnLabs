﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer.Exceptions
{
    public class ServerErrorException:Exception
    {
        public ServerErrorException(string msg=null,Exception inner=null):base(msg,inner) { }
    }
}
