using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.BusinessLayer.Exceptions
{
    public class EmployeeDoesNotExistException:Exception
    {
        public EmployeeDoesNotExistException(string msg="", Exception innerExpection=null) { }
    }
}
