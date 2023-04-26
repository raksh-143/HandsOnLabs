using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLTProgram
{
    //Write a pseudocode to display the 1st , 2nd , and 4th multiple of 7 which gives the
    //remainder 1 when divided by 2,3,4,5 and 6
    internal class CheckDivisibility
    {
        static void Main()
        {
            int i = 1;
            int counter = 1;
            int multiple,number = 7;
            while (true)
            {
                multiple = number * i;
                if((multiple % 2 == 1) && (multiple % 3 == 1) && (multiple % 4 == 1) && (multiple % 5 == 1) && (multiple % 6 == 1))
                {
                    if(counter == 3)
                    {
                        counter++;
                        i++;
                        continue;
                    }
                    else if(counter == 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(counter + ". " + multiple);
                        counter++;
                    }
                }
                i++;
            }
            Console.ReadKey();
        }
    }
}
