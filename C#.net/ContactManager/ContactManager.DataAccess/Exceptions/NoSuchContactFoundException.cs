using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess.Exceptions
{
    public class NoSuchContactFoundException:ApplicationException
    {
        public NoSuchContactFoundException(string message="") : base(message) { }
    }
}
