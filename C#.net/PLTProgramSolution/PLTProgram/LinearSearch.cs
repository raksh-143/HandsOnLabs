using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PLTProgram
{
    //Write a pseudocode to store N elements in an array of integer. Display the elements.Accept a number to be searched.
    //Display whether the number is foundor not in the array (LINEAR SEARCH)
    internal class LinearSearch
    {
        static int[] array;
        static int arraySize;
        static int keyToBeFound;
        static bool isKeyPresent = false;
        static void PerformLinearSearch()
        {
            for(int i = 0; i < arraySize; i++)
            {
                if (array[i] == keyToBeFound)
                {
                    isKeyPresent= true;
                }
            }
        }
        static void DisplayResult()
        {
            if(isKeyPresent)
            {
                Console.WriteLine("Key is present in the array");
            }
            else
            {
                Console.WriteLine("Key is not present in the array");
            }
        }
        static void Main()
        {
            //Accept the array from the user
            Console.Write("Enter the number of elements: ");
            arraySize = int.Parse(Console.ReadLine());
            array = new int[arraySize];
            for(int i=0;i<arraySize; i++)
            {
                Console.Write($"Enter the {i+1}th element: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            //Accept the number to be found
            Console.Write("Enter the number to be found: ");
            keyToBeFound = int.Parse(Console.ReadLine());
            //search for the number
            PerformLinearSearch();
            //display the result
            DisplayResult();
            Console.ReadKey();
        }
    }
}
