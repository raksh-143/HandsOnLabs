using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write the pseudocodes to generate the following outputs.In all the following cases, accept N
    internal class NumberPattern
    {
        static int numberOfRows;
        static void Pattern1()
        {
            for(int i = 1; i <= numberOfRows; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Pattern2()
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Pattern3()
        {
            int counter = 1;
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(counter + " ");
                    counter++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Pattern4()
        {
            int p = 0;
            int q = 1;
            int r;
            Console.WriteLine("1");
            for(int i = 2; i <= numberOfRows; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    r = p + q;
                    Console.Write(r + " ");
                    p = q;
                    q = r;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main()
        {
            //Accept number of rows from user
            Console.Write("Enter the number of rows: ");
            numberOfRows = int.Parse(Console.ReadLine());
            //Display pattern
            Pattern1();
            Pattern2();
            Pattern3();
            Pattern4();
            Console.ReadKey();
        }
    }
}
