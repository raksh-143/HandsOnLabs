using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //TPL
using System.Threading; //Classic MT
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace MTDemo1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine(Environment.ProcessorCount);
            return 0;
            Stopwatch sw = Stopwatch.StartNew();

            //Sequential
            Console.WriteLine($"Main: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Running seq...");
            M1();
            M2();
            Console.WriteLine(sw.ElapsedMilliseconds);

            //Using Classic Thread
            Console.WriteLine("Using Classic Thread");
            sw = Stopwatch.StartNew();
            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);
            t1.Start();
            Thread t2 = new Thread(M2); //Doesn't wait for t1 to finish -> Main thread will not wait for the child thread to finish
            t2.Start();
            t1.Join(); //Unless Specified
            t2.Join();
            Console.WriteLine(sw.ElapsedMilliseconds);

            //Using TPL-Task
            Console.WriteLine("Using TPL-Task");
            sw = Stopwatch.StartNew();
            Task task1 = new Task(M1);
            task1.Start();
            Task task2 = new Task(M2);
            task2.Start();
            task1.Wait();
            task2.Wait();
            Console.WriteLine(sw.ElapsedMilliseconds);

            // Using TPL-Parallel
            Console.WriteLine("Using TPL-Parallel");
            sw = Stopwatch.StartNew();
            Parallel.Invoke(M11, M22); //Blocks the current thread and resumes only after both M1 and M2 are completed
            Console.WriteLine(sw.ElapsedMilliseconds);
            M3();
        }
        static void M1()
        {
            Console.WriteLine($"M1: {Thread.CurrentThread.ManagedThreadId}");
            for(int i = 1; i <= 10; i++)
            {
                Thread.Sleep(500);
            }
        }
        static void M2()
        {
            Console.WriteLine($"M2: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(500);
            }
        }
        static void M11()
        {
            Console.WriteLine($"M11: {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 1; i <= 10; i++)
            //{
            //    Thread.Sleep(500);
            //}

            //Parallel For
            Parallel.For(1, 11,i=>Thread.Sleep(500));

        }
        static void M22()
        {
            Console.WriteLine($"M22: {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 1; i <= 10; i++)
            //{
            //    Thread.Sleep(500);
            //}
            Parallel.For(1, 11, i => Thread.Sleep(500));
        }
        static void M3()
        {
            Console.WriteLine($"M3: {Thread.CurrentThread.ManagedThreadId}");
            Parallel.For(1, 101, delegate(int i)
            {
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
