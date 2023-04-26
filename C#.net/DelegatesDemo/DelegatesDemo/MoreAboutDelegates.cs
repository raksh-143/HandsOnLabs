using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    internal class MoreAboutDelegates
    {
        static void Main()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            //find sum of all even numbers
            Func<int, bool> filter = new Func<int, bool>(x=>x%2==0);
            int evenSum = list.Where(x => x % 2 == 0).Sum();
            //int evenSum = list.Where(MethodName).Sum();
            //int evenSum = list.Where(filter).Sum();
            Console.WriteLine(evenSum);
        }
    }
}
