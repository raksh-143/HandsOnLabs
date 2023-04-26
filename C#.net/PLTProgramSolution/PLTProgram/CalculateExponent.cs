using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to find Xn (x to the power of n). Accept X and n. Display the result
    internal class CalculateExponent
    {
        static int X, n, exponentValue=1;
        static void CalculateExponentValue()
        {
            for(int i = 1; i <= n; i++)
            {
                exponentValue *= X;
            }
        }
        static void Main()
        {
            //Accept X and n values
            Console.Write("Enter the X value: ");
            X = int.Parse(Console.ReadLine());
            Console.Write("Enter the n value: ");
            n = int.Parse(Console.ReadLine());
            //Calculate the exponent values
            CalculateExponentValue();
            //Display the result
            Console.WriteLine($"{X}^{n} = {exponentValue}");
            Console.ReadLine();
        }
    }
}
