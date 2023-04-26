using GenerateSeries.BusinessLayer;
using System;
using System.Collections.Generic;

namespace GenerateSeries.PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Getting user input
            Console.WriteLine("Enter the number of terms required: ");
            int range = int.Parse(Console.ReadLine());

            //Getting object of generate series
            IGenerateSeries mySeries = new GeneratePrimeSeries();

            //Getting the series
            List<int> series = mySeries.Generate(range);
            if(series.Count > 0)
            {
                Console.WriteLine("The series requested is as follows: ");
            }
            foreach(int i in series)
            {
                Console.WriteLine(i);
            }

            //Printing the count ascending, descending and neither ascending nor descending numbers
            Console.WriteLine($"The number of ascending numbers is: {mySeries.GetCountOfAscendingNumbers(series)}");
            Console.WriteLine($"The number of descending numbers is: {mySeries.GetCountOfDescendingNumbers(series)}");
            Console.WriteLine($"The number of neither ascending nor descending numbers is: " +
                $"{mySeries.GetCountOfNeitherAscendingNorDescendingNumbers(series)}");

            //Printing the numbers with two adjacent consecutive digits
            Console.WriteLine("The numbers in which two adjacent consecutive digits are present are: ");
            List<int> adjacentNumbers = mySeries.TwoDigitsAdjacent(series);
            foreach(int number in adjacentNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
