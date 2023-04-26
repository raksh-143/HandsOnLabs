using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write the pseudocodes to generate the following outputs.In all the followingcases, accept N
    internal class SeriesPattern
    {
        static int NoOfRows;
        static void SquarePattern()
        {
            int number = 1;
            int next;
            for(int i=1;i<=NoOfRows;i++)
            {
                for(int j = 1; j <= i; j++)
                {

                    next = number * number;
                    if (number % 2 == 0) {
                        next = next * -1;
                    }
                    Console.Write(next + " ");
                    number++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void MultiplicationPattern()
        {
            int number = 1;
            int next=1,counter=1;
            for (int i = 1; i <= NoOfRows; i++)
            {
                for (int j = 1; j <= i; j++)
                {

                    Console.Write(next + " ");
                    next = number * counter;
                    number = next;
                    counter++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void MirroredRightAngledTriangle()
        {
            for (int i = 1; i <= NoOfRows; i++)
            {
                for (int j = 1; j <= (NoOfRows - i); j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {

                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void TrianglePattern()
        {
            int counter = 1;
            for (int i = 1; i <= NoOfRows; i++)
            {
                for(int j = 1; j <= (NoOfRows-i); j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= counter; j++)
                {

                    Console.Write("*");
                }
                counter += 2;
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main()
        {
            //Accept number of rows from the user
            Console.Write("Enter the number of rows: ");
            NoOfRows = int.Parse(Console.ReadLine());
            //Display the pattern
            SquarePattern();
            MultiplicationPattern();
            MirroredRightAngledTriangle();
            TrianglePattern();
            Console.ReadKey();
        }
    }
}
