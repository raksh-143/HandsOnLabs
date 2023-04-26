using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to find the largest and second largest of 3 numbers
    internal class LargestAndSecondLargest
    {
        static int fno, sno, tno;
        static int largest, secondLargest=0;
        static void FindLargest()
        {
            if(fno>sno && fno > tno)
            {
                largest = fno;
            }
            else if(sno>fno && sno>tno)
            {
                largest = sno;
            }
            else
            {
                largest = tno;
            }
        }
        static void FindSecondLargest()
        {
            int large=0;
            int[] arrayOfNumbers = { fno, sno, tno };
            foreach (int i in arrayOfNumbers)
            {
                if (i > large)
                {
                    secondLargest = large;
                    large = i;
                }
                if(i>secondLargest && i<large)
                {
                    secondLargest = i;
                }
            }
        }
        static void Display()
        {
            Console.WriteLine("Largest = " + largest);
            Console.WriteLine("Second Largest = " + secondLargest);
        }
        static void Main()
        {
            //Accept 3 numbers from the user
            Console.Write("Enter first number: ");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            sno = int.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            tno = int.Parse(Console.ReadLine());
            //find the largest
            FindLargest();
            //find the second largest
            FindSecondLargest();
            //display
            Display();
            Console.ReadKey();
        }
    }
}
