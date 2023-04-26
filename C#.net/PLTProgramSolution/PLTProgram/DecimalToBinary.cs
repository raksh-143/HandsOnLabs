using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to accept a decimal number. Display it in the binary form.
    internal class DecimalToBinary
    {
        static int decimalNumber;
        static string binaryNumber = "";
        static void ConvertToBinary()
        {
            while (decimalNumber != 0)
            {
                int rem = decimalNumber%2;
                decimalNumber /= 2;
                binaryNumber = rem + binaryNumber;
            }
        }
        static void Main()
        {
            //Accept decimal number from user
            Console.Write("Enter the decimal number: ");
            decimalNumber = int.Parse(Console.ReadLine());
            //Calculate the binary number
            ConvertToBinary();
            //Display the binary Number
            Console.WriteLine("The binary number is " + binaryNumber);
            Console.ReadKey();
        }
    }
}
