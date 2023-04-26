using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to find the sum of all odd numbers from 1 to N.Accept N.Display the sum
    internal class SumOfOddNumbers
    {
        static int range;
        static int sum = 0;
        static void FindSumOfOddNumbers()
        {
            for(int i=1;i<=range; i+=2) {
                sum += i;
            }
        }
        static void Display()
        {
            Console.WriteLine("Sum of " + range + " odd natural numbers is " + sum);
        }
        static void Main()
        {
            //Accept N
            Console.Write("Enter the N value: ");
            range = int.Parse(Console.ReadLine());
            //find sum of all odd numbers
            FindSumOfOddNumbers();
            //display sum
            Display();
            Console.ReadKey();
        }
    }
}
