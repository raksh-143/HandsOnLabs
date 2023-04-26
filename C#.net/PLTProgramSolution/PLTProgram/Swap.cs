using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to accept two numbers. Display the two numbers. Swap the two numbers and display them again
    internal class Swap
    {
        static int firstNumber, secondNumber;
        static void SwapNumbers()
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
            Console.WriteLine("Swap Completed!");
        }
        static void DisplayNumbers()
        {
            Console.WriteLine("First Number = " + firstNumber);
            Console.WriteLine("Second Number = " + secondNumber);
        }
        static void Main()
        {
            //Accept 2 numbers from the user
            Console.Write("Enter 1st number: ");
            firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter 2nd number: ");
            secondNumber = int.Parse(Console.ReadLine());
            //display the 2 numbers
            DisplayNumbers();
            //swap the 2 numbers
            SwapNumbers();
            //display the 2 numbers again
            DisplayNumbers();
            Console.ReadKey();
        }
    }
}
