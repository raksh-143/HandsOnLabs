using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to accept a double value.Separate the whole value from the
    //fractional value and store them in two variables. Display the same.
    internal class DoubleSeparation
    {
        static double number;
        static string intPart, fractionPart;
        static string numberString;
        static void SeparateValues()
        {
            /*intPart = (int)number;
            fractionPart = number - intPart;*/
            numberString = Convert.ToString(number);
            int index = numberString.IndexOf('.');
            intPart = numberString.Substring(0,index);
            fractionPart = numberString.Substring(index + 1,numberString.Length-1-index);
        }
        static void Display()
        {
            Console.WriteLine("Integer Part = " + intPart);
            Console.WriteLine("Fractional Part = " + fractionPart);
        }
        static void Main()
        {
            //Accept a double value
            Console.Write("Enter the double value: ");
            number = double.Parse(Console.ReadLine());
            //separate whole and fractional value
            SeparateValues();
            //display the whole and fractional values
            Display();
            Console.ReadKey();
        }
    }
}
