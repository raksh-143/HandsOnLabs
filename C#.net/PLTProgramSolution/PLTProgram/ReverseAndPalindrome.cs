using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to display the reverse of a string and check if it is a palindrome
    internal class ReverseAndPalindrome
    {
        static string inputString = "";
        static string reverseString = "";
        static bool isPalindrome = false;
        static void ReverseString()
        {
            StringBuilder strbld = new StringBuilder(inputString);
            for (int i = 0; i < inputString.Length / 2; i++)
            {
                char temp = strbld[i];
                strbld[i] = strbld[strbld.Length - 1 - i];
                strbld[strbld.Length - 1 - i] = temp;
            }
            reverseString = strbld.ToString();
        }
        static void CheckPalindrome()
        {
            if (inputString.Equals(reverseString))
            {
                isPalindrome = true;
            }
        }
        static void DisplayResult()
        {
            Console.WriteLine("The input string is " + inputString);
            Console.WriteLine("The reverse of input string is " + reverseString);
            if (isPalindrome)
            {
                Console.WriteLine("The input string is a palindrome");
            }
            else
            {
                Console.WriteLine("The input string is not a palindrome");
            }
        }
        static void Main()
        {
            //Accept string from users
            Console.Write("Enter the string: ");
            inputString = Console.ReadLine();
            //Reverse String
            ReverseString();
            //Check if string is a palindrome
            CheckPalindrome();
            //Display the reversed string
            DisplayResult();
            Console.ReadKey();
        }
    }
}
