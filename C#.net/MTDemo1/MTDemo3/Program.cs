using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Monitor/Lock -> One thread per process
            //Mutex -> One thread throughout all processes
            //Semaphore -> Fixed number of threads across multiple processes
            M1();
        }
        static void M1()
        {
            int pcount = Environment.ProcessorCount;
            ParallelOptions opts = new ParallelOptions();
            opts.MaxDegreeOfParallelism= pcount/2; //Number of cores to be used

            HashSet<int> list = new HashSet<int>();
            Object obj = new object();

            Parallel.For(1, 100, opts, i => {
                lock (obj)
                {
                    list.Add(Thread.CurrentThread.ManagedThreadId);
                }
            });
            Console.WriteLine(list.Count);
        }
    }
}
