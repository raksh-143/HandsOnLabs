using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingWordsInASentence
{
    internal class SortStringBasedOnLength
    {
        static void Main()
        {
            Console.Write("Enter the number of strings: ");
            int size = int.Parse(Console.ReadLine());
            string[] inputStrings = new string[size];
            Console.WriteLine("Enter the strings: ");
            for(int i=0;i<inputStrings.Length;i++)
            {
                inputStrings[i] = Console.ReadLine();
            }
            Array.Sort(inputStrings,new SortByLength());
            Console.WriteLine("The sorted order of strings is:  ");
            for (int i = 0; i < inputStrings.Length; i++)
            {
                Console.WriteLine(inputStrings[i]);
            }
            Console.ReadKey();
        }
    }
    class SortByLength : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length > y.Length)
            {
                return 1;
            }
            else if (x.Length < y.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
