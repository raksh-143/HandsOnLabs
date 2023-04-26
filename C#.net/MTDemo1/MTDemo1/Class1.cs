using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTDemo1
{
    internal class Class1
    {
        static void Main()
        {
            Thread t1 = new Thread(M1);
            Thread t2 = new Thread(() => { M2(100); }); //Used for methods that take in parameters other than objects
            //Thread t3 = new Thread(M3);
            //Thread t4 = new Thread(M4);

            //If we use a constructor for creating a task we should call start method -> Use if you don't want to start right after creating the objects
            Task tt1 = new Task(M1);
            tt1.Start();

            //Use if you want to start right after creating the objects
            Task ttt1 = Task.Factory.StartNew(M1);

            Task tt2 = new Task(() => { M2(100); });
            Task<int> tt3 = new Task<int>(M3);
            int r = tt3.Result;
            //The current thread is blocked until the result is obtained

            //if a method returns value use the generic version of task
        }
        static void M1() { }
        static void M2(int i) { }    
        static int M3() { return 1; }
        static int M4(int x) { return 0; }

    }
}
