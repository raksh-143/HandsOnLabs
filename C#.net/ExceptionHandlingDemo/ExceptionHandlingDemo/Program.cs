using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingDemo
{
    internal class Program //PL
    {
        static void Main(string[] args)
        {
            //Accept 2 ints, find the sum and display, application should terminate only if the user wants it to
            int fno, sno, sum;
            while(true){
                try
                {
                    Console.Write("Enter first number: ");
                    fno = int.Parse(Console.ReadLine());
                    Console.Write("Enter second number: ");
                    sno = int.Parse(Console.ReadLine());
                    sum = Calculator.Sum(fno, sno);
                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
                }
                catch(FormatException)
                {
                    Console.WriteLine("Enter only numbers");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Enter small numbers");
                }
                //catch (NegativeNumberException)
                //{
                //    Console.WriteLine("Enter only positive numbers");
                //}
                //Catch all block -> Should be put at the end
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //e.InnerException.Message -> Debugging purpose
                }
                finally
                {

                }
            }
            //Console.ReadKey();
        }
    }
    /// <summary>
    /// Calculator will be used for finding mathematical calculations
    /// </summary>
    public class Calculator //BLL
    {
        /// <summary>
        /// Finds the sum
        /// </summary>
        /// <param name="a">first int</param>
        /// <param name="b">second int</param>
        /// <returns>sum of two ints</returns>
        /// <exception cref="NegativeNumberException"></exception>
        public static int Sum(int a, int b)
        {
            //Validate the input
            try
            {
                InputValidator.Validate(a, b); //Custom exception (hence no need to convert), informative (hence no need to log), rethrow (mandatory)
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message); -> Business layer should not interact with the user
                //Do not leave a catch block empty
                LogManager.LoadConfiguration("nlog.config");
                var log = LogManager.GetCurrentClassLogger();
                //log.Error(e.Message);
                log.Debug(e.Message);
                throw e;
            }
            int sum = a + b;
            //save
            try
            {
                CalculatorRepository.Save($"{a} + {b} = {sum}");
            }
            catch(Exception e)
            {
                //Convert system exception into custom exception, log(optional) and rethrow
                UnableToSaveException exp = new UnableToSaveException("Unable to save the calculator input",e);
                throw exp;
                
            }
            return sum;
        }
    }
    public class NegativeNumberException : ApplicationException
    {
        public NegativeNumberException()
        {

        }
        public NegativeNumberException(string msg) : base(msg) //Modify message using base class constructor
        {
            //Message = msg //Message cannot be modified at this level
        }
    }
    public class UnableToSaveException : ApplicationException
    {
        //public UnableToSaveException()
        //{

        //}
        //public UnableToSaveException(string msg):base(msg)
        //{

        //}
        //Default Parameters
        public UnableToSaveException(string msg=null,Exception innerException=null) : base(msg,innerException)
        {

        }
    }
    public class InputValidator
    {
        /// <summary>
        /// Validates the input
        /// </summary>
        /// <param name="a">first int</param>
        /// <param name="b">second int</param>
        /// <returns>validation of two ints as postitive, non-zero and even</returns>
        /// <exception cref="NegativeNumberException"></exception>
        public static bool Validate(int a,int b)
        {
            //Business Rule - input should be
            //positive
            if (a < 0 || b < 0)
            {
                //In business layer no interaction with the user
                NegativeNumberException exception = new NegativeNumberException("Enter only positive numbers");
                //exception.Message = "Message"; //Child class cannot add / modify the message directly
                throw exception;
            }
            //non-zero
            //even
            return true;
        }
    }
    public class CalculatorRepository //DAL
    {
        public static void Save(string input)
        {
            File.WriteAllText("/calculator.txt", input);
        }
    }
}
