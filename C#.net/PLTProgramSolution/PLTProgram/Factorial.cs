using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to find the factorial of a given number. 0! is always 1. Factorial of a negative number is not possible.
    internal class Factorial
    {
        static int number;
        static long fact = 1;
        static void CalculateFactorial()
        {
            if(number == 0 || number == 1)
            {
                fact = 1;
            }
            else
            {
                for (int i = 2; i <= number; i++)
                {
                    fact *= i;
                }
            }
        }
        static void DisplayFactorial()
        {
            Console.WriteLine($"Factorial of {number} is {fact}");
        }
        static void Main()
        {
            //Accept the number
            Console.Write("Enter the number: ");
            number = int.Parse(Console.ReadLine());
            //Calculate factorial
            CalculateFactorial();
            //Display factorial
            DisplayFactorial();
            Console.ReadKey();
        }
    }
}
