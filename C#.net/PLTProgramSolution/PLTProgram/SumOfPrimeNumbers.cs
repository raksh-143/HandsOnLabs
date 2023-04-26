using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to find the sum of all the prime numbers in the range n to m. 
    //Display each prime number and also the final sum
    internal class SumOfPrimeNumbers
    {
        static int start, end;
        static bool IsPrime(int number)
        {
            for(int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void CalculateSumOfPrimeNumbers()
        {
            int sumOfPrimeNumbers = 0;
            for(int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                    sumOfPrimeNumbers += i;
                }
            }
            Console.WriteLine("Sum = "+sumOfPrimeNumbers);
        }
        static void Main()
        {
            //Accept range from user
            Console.Write("Enter Start number: ");
            start = int.Parse(Console.ReadLine());
            Console.Write("Enter End number: ");
            end = int.Parse(Console.ReadLine());
            //Calculate sum of prime numbers
            CalculateSumOfPrimeNumbers();
            Console.ReadKey();
        }
    }
}
