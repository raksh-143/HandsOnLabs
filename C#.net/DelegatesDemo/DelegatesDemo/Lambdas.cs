using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    internal class Lambdas
    {
        static void Main()
        {
            //Instead of using an anonymous function we can also use lambdas
            ProcessManagerImpl.ShowProcessList((Process process)=>{return process.WorkingSet64 >= 50 * 1024 * 1024;});
            //Types of lambdas 
            //1. Lambda statements
            //Some lambda statements can be converted into lambda expressions
            //Remove any language dependent keyword or expression; Make sure it does not have multiple lines of code
            //ProcessManagerImpl.ShowProcessList((Process process) => { return process.WorkingSet64 >= 50 * 1024 * 1024; });
            //If single parameter brackets and data type is not needed
            //2. Lambda expressions
            //x->type inference feature in c#
            //ProcessManagerImpl.ShowProcessList(x => x.WorkingSet64 >= 50 * 1024 * 1024);
        }
        public static bool FilterByName(Process process)
        {

            return process.ProcessName.StartsWith("S");
        }
        public static bool FilterByMemSize(Process process)
        {
            return process.WorkingSet64 >= 50 * 1024 * 1024;
        }
    }
}
