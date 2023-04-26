using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to display a number in words
    internal class NumberInWords
    {
        static int number;
        static string resultStatement = "";
        static void DisplayNumberInWords()
        {
            string[] numbersInWords = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            int tmp = number;
            while(tmp != 0)
            {
                int rem = tmp % 10;
                tmp /= 10;
                resultStatement = numbersInWords[rem] + " " + resultStatement;
            }
            Console.WriteLine(resultStatement);
        }
        static void Main()
        {
            //Accept the number
            Console.Write("Enter the number: ");
            number = int.Parse(Console.ReadLine());
            //Display number in words
            DisplayNumberInWords();
            Console.ReadKey();
        }
    }
}
