using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to accept a binary number. Display it in the decimal form.
    internal class BinaryToDecimal
    {
        static int decimalNumber=0;
        static string binaryNumber;
        static void ConvertToDecimal()
        {
            int power = 0;
            for(int i=binaryNumber.Length-1;i>=0;i--)
            {
                if (binaryNumber[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2,power);
                }
                power++;
            }
        }
        static void Main()
        {
            //Accept binary number from user
            Console.Write("Enter the binary number: ");
            binaryNumber = Console.ReadLine();
            //Calculate the decimal number
            ConvertToDecimal();
            //Display the decimal Number
            Console.WriteLine("The decimal number is " + decimalNumber);
            Console.ReadKey();
        }
    }
}
