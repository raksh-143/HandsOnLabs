using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    internal class ProcessManager
    {
       static void Main()
        {
            //Client 1
            //ProcessManagerImpl.ShowProcessList();
            //Client 2
            //ProcessManagerImpl.ShowProcessList("S");
            //Client 3
            Filter filter = new Filter(FilterByMemSize); //Creating a deleagte
            ProcessManagerImpl.ShowProcessList(filter); //Passing the delegate to the backend
            ProcessManagerImpl.ShowProcessList(FilterByName); //Directly passing method name also works
            //If a user wants to use a business logic only once then an anonymous method/delegate can be used
            ProcessManagerImpl.ShowProcessList(delegate (Process process)
            {
                return process.WorkingSet64 >= 50 * 1024 * 1024;
            });
        }
        public static bool FilterByName(Process process)
        {
            
            return process.ProcessName.StartsWith("S");
        }
        public static bool FilterByMemSize(Process process)
        {
            return process.WorkingSet64 >= 50*1024*1024;
        }
    }
    public delegate bool Filter(Process process);
    class ProcessManagerImpl
    {
        //public static void ShowProcessList()
        //{
        //    Process[] processes = Process.GetProcesses();
        //    foreach (Process process in processes)
        //    {
        //        Console.WriteLine(process.ProcessName);
        //    }
        //}
        public static void ShowProcessList(Filter filter)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (filter(process)) //To call this method use delegates
                {
                    Console.WriteLine($"{process.ProcessName}");
                }
            }
        }
        //public static void ShowProcessList(long size)
        //{
        //    foreach (Process process in Process.GetProcesses())
        //    {
        //        if (process.WorkingSet64 >= size)
        //        {
        //            Console.WriteLine(process.ProcessName);
        //        }
        //    }
        //}
    }
}
