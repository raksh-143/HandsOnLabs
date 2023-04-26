using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to accept principle, rate of interest and time. Calculate simple interest and display the same
    internal class SimpleInterest
    {
        static double simpleInterest;
        public static void CalculateSimpleInterest(double principle,double rate, double time)
        {
            simpleInterest = (principle * rate * time) / 100;
        }
        public static void DisplaySimpleInterest()
        {
            Console.WriteLine(simpleInterest);
        }
        static void Main(string[] args)
        {
            //Collect principle, rate and time from the user
            double principle, rate, time;
            Console.Write("Enter principle amount: ");
            principle = double.Parse(Console.ReadLine());
            Console.Write("Enter rate of interest: ");
            rate = double.Parse(Console.ReadLine());
            Console.Write("Enter time in years: ");
            time = double.Parse(Console.ReadLine());
            //Calculate simple interest
            CalculateSimpleInterest(principle, rate, time);
            //display it to the user
            DisplaySimpleInterest();
            Console.ReadKey();
        }
    }
}
