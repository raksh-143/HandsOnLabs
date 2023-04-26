using SimpleCalculator.Business;
using System;

namespace PracticePrograms
{
    internal class Program //UI
    {
        //First Approach
        /*public static void Main(string[] args) //Every method should do only one task
        {
            //Accept two integers and calculate their sum

            //Accept two integers
            int fno;
            int sno;
            int sum = 0;
            Console.Write("Enter first number: ");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            sno = int.Parse(Console.ReadLine());
            //find the sum
            sum = fno + sno;
            //display the result
            Console.WriteLine($"Sum of {fno} and {sno} is {sum}");
        }*/

        //Second Approach
        /*public static void Main(string[] args) //UI Logic
        {
            //Accept two integers and calculate their sum

            //Accept two integers
            int fno;
            int sno;
            int sum = 0;
            Console.Write("Enter first number: ");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            sno = int.Parse(Console.ReadLine());
            //find the sum
            sum = FindSum(fno,sno);
            //display the result
            Console.WriteLine($"Sum of {fno} and {sno} is {sum}");
        }
        static int FindSum(int fno,int sno) //SRP - BL
        {
            return fno + sno;
        }
        */
        //Third Approach
        public static void Main(string[] args) //UI Logic
        {
            //Accept two integers and calculate their sum

            //Accept two integers
            int fno;
            int sno;
            int sum = 0;
            Console.Write("Enter first number: ");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            sno = int.Parse(Console.ReadLine());
            //find the sum
            sum =Calculator.FindSum(fno, sno);
            //display the result
            Console.WriteLine($"Sum of {fno} and {sno} is {sum}");
        }
    }

    /*class Calculator //BL
    {
        public static int FindSum(int fno,int sno)
        {
            return fno + sno;
        }
    }*/
}
