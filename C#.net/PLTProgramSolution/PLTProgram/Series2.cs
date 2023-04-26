using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    /*
    Write as many pseudocodes to generate the following series. In all the following cases, 
    accept N: 
    4, 16, 36, 64, … N 
    1, -2, 3, -4, 5, -6, … N 
    1, 4, 27, 256, 3125, … N 
    1, 4, 7, 12, 23, 42, 77, … N 
    1, 4, 9, 25, 36, 49, 81, 100, … N 
    1, 5, 13, 29, 49, 77, … N
     */
    internal class Series2
    {
        static int noOfTerms;
        static void SquaresOfEvenNaturalNumbers()
        {
            int number = 2;
            for(int i = 1; i <= noOfTerms; i++)
            {
                Console.Write((number * number) + " ");
                number += 2;
            }
            Console.WriteLine();
        }
        static void PrintNaturalNumbers()
        {
            for (int i = 1; i <= noOfTerms; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write((i*-1) + " ");
                }
                else
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
        static void PowersOfNaturalNumbers()
        {
            for (int i = 1; i <= noOfTerms; i++)
            {
                Console.Write(Math.Pow(i,i) + " ");
            }
            Console.WriteLine();
        }
        static void SumOfLast3Numbers()
        {
            int a = 1, b = 4, c = 7, sum;
            Console.Write($"{a} {b} {c} ");
            for(int i = 4; i <= noOfTerms; i++)
            {
                sum = a + b + c;
                Console.Write(sum + " ");
                a = b;
                b = c;
                c = sum;
            }
            Console.WriteLine();
        }
        static void SquaresOfNaturalNumbers()
        {
            int number = 0;
            int counter = 1;
            while (counter <= noOfTerms)
            {
                number++;
                if (number % 4 == 0)
                {
                    continue;
                }
                Console.Write((number * number) + " ");
                counter++;
            }
            Console.WriteLine();
        }
        static void MultiplesOf4ButNot12()
        {
            int number = 1,i=1;
            Console.Write(number + " ");
            while(i<=noOfTerms)
            {
                int multiple = 4 * i;
                i++;
                if (multiple % 12 == 0)
                {
                    continue;
                }
                number += multiple;
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
        static void Main()
        {
            //Accept number of terms from the user
            Console.Write("Enter the number of terms: ");
            noOfTerms = int.Parse(Console.ReadLine());
            //Display the series
            SquaresOfEvenNaturalNumbers();
            PrintNaturalNumbers();
            PowersOfNaturalNumbers();
            SumOfLast3Numbers();
            SquaresOfNaturalNumbers();
            MultiplesOf4ButNot12();
            Console.ReadLine();
        }
    }
}
