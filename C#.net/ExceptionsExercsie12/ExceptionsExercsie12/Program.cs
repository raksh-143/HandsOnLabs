using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsExercsie12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            try
            {
                array[12] = 5;
                int a = 10;
                int b = 0;
                int c = a / b;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Your array size is smaller than the index you are accessing");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                Console.WriteLine(ex.ToString());
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide a number by 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                Console.WriteLine(ex.ToString());
            }
            //catch
            //{
            //    //Cannot print any specific message or stack trace because there is no object reference
            //}
        }
    }
}
