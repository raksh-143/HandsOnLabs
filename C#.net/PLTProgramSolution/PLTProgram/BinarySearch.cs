using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PLTProgram
{
    //Write a pseudocode to store N elements in an array of integer. Display the
    //elements.Sort the elements.Accept a number to be searched.Display whether
    //the number is found or not in the array using BINARY SEARCH.
    internal class BinarySearch
    {
        static int[] array;
        static int arraySize;
        static int keyToBeFound;
        static bool isKeyPresent = false;
        static void PerformBinarySearch()
        {
            int low = 0;
            int high = arraySize - 1;
            int mid;
            Array.Sort(array);
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (array[mid] == keyToBeFound)
                {
                    isKeyPresent = true;
                    return;
                }
                else if (array[mid] < keyToBeFound)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
        }
        static void DisplayResult()
        {
            if (isKeyPresent)
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
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"Enter the {i + 1}th element: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            //Accept the number to be found
            Console.Write("Enter the number to be found: ");
            keyToBeFound = int.Parse(Console.ReadLine());
            //search for the number
            PerformBinarySearch();
            //display the result
            DisplayResult();
            Console.ReadKey();
        }
    }
}
