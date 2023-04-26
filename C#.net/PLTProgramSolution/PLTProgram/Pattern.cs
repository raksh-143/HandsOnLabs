using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write the pseudocodes to generate the following outputs.In all the following cases, accept N
    internal class Pattern
    {
        static int numberOfRows;
        static void StarPattern()
        {
            for(int i=0; i<numberOfRows; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void NumberPattern()
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(i+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void ConsecutiveNumberPattern()
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void RightAngledTriangle()
        {
            for (int i = 1; i <= numberOfRows; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main()
        {
            //Accept N value
            Console.Write("Enter the number of rows: ");
            numberOfRows = int.Parse(Console.ReadLine());
            //Display the pattern
            StarPattern();
            NumberPattern();
            ConsecutiveNumberPattern();
            RightAngledTriangle();
            Console.ReadKey();
        }
    }
}
