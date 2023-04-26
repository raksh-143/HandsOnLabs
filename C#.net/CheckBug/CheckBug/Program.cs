using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = File.OpenText("abc.txt");
            try
            {
                int input1, input2, output;
                input1 = int.Parse(sr.ReadLine());
                input2 = int.Parse(sr.ReadLine());
                output = input1 / input2;
                //sr.Close(); //-> won't be closed if exception occurs
            }
            catch (FormatException)
            {
                //throw Exception;
                Console.WriteLine("File contains invalid values");
            }
            catch(OverflowException)
            {
                Console.WriteLine("Memory full");
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Cannot divide a number by zero");
            }
            catch (Exception ex) //-> Catching any other possible exceptions
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }
        }
        static void AnotherMethod()
        {

        }
    }
}
