using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PLTProgram
{
    /*
    Write the pseudocodes to generate the following series. In all the following cases, 
    accept N: 
    1, -2, 6, -15, 31, -56, … N 
    1, 1, 2, 3, 5, 8, 13, … N 
    1, -2, 4, -6, 7,-10, 10,-14… N 
    1, 5, 8, 14, 27, 49, … N
     */
    internal class Series1
    {
        static int NoOfTerms;
        static void MultiplyBySquares()
        {
            int counter = 1;
            int number = 1;
            int output = 1;
            for(int i=1;i<=NoOfTerms;i++)
            {
                if (i % 2 == 0)
                {
                    output = output * -1;
                }
                Console.Write(output + " ");
                output = counter + number * number;
                counter = output;
                number++;
            }
            Console.WriteLine();
        }
        static void FibonacciSeries()
        {
            int p = 0;
            int q = 1;
            int r = 1;
            for(int i=0;i<NoOfTerms;i++)
            {
                Console.Write(r + " ");
                r = p + q;
                p = q;
                q = r;
            }
            Console.WriteLine();
        }
        static void Alternate3And4()
        {
            int number_3 = 1;
            int number_4 = 2;
            for(int i = 1; i <= NoOfTerms; i++)
            {
                if (i % 2 == 0)
                {
                    int tmp = number_4 * -1;
                    Console.Write(tmp + " ");
                    number_4 += 4;
                }
                else
                {
                    Console.Write(number_3 + " ");
                    number_3 += 3;
                }
            }
            Console.WriteLine();
        }
        static void SumOfLastThreeTerms()
        {
            int a = 1;
            int b = 5;
            int c = 8;
            Console.Write($"{a} {b} {c} ");
            for (int i = 4; i <= NoOfTerms; i++)
            {
                int next = a + b + c;
                Console.Write(next + " ");
                a = b;
                b = c;
                c = next;
            }
        }
        static void Main()
        {
            //Accept the number of terms to be printed by the user
            Console.Write("Enter the number of terms required: ");
            NoOfTerms = int.Parse(Console.ReadLine());
            //Print the terms
            MultiplyBySquares();
            FibonacciSeries();
            Alternate3And4();
            SumOfLastThreeTerms();
            Console.ReadKey();
        }
    }
}
