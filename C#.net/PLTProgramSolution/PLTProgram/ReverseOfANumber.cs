using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to find the reverse of a number.Store the reverse value in a different variable.Display the reverse
    internal class ReverseOfANumber
    {
        static int number,reverse;
        static void ReverseNumber()
        {
            int tmp = number;
            while(tmp != 0)
            {
                int rem = tmp % 10;
                tmp /= 10;
                reverse = reverse * 10 + rem;
            }
        }
        static void DisplayReverse()
        {
            Console.WriteLine($"The reverse of {number} is {reverse}");
        }
        static void Main()
        {
            //Accept the number
            Console.Write("Enter the number: ");
            number = int.Parse(Console.ReadLine());
            //Reverse the number
            ReverseNumber();
            //Display the reverse
            DisplayReverse();
            Console.ReadKey();
        }
    }
}
