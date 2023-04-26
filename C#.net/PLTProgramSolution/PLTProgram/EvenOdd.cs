using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to accept a number and display whether it is an even or odd number
    internal class EvenOdd
    {
        static int number;
        static bool isEven;
        static void CheckEvenOdd()
        {
            isEven = (number % 2 == 0) ? true : false;
        }
        static void Display()
        {
            if(isEven == true)
            {
                Console.WriteLine(number + " is even");
            }
            else
            {
                Console.WriteLine(number + " is odd");
            }
        }
        static void Main()
        {
            //Accept number from user
            Console.Write("Enter the number: ");
            number = int.Parse(Console.ReadLine());
            //check even or odd
            CheckEvenOdd();
            //display message
            Display();
            Console.ReadKey();
        }
    }
}
