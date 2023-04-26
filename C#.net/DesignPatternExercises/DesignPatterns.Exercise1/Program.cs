using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorFactory factory = CalculatorFactory.FactoryInstance;
            ICalculator myCalculator = factory.GetCalculator();
            Console.WriteLine(myCalculator.Calculate(10000,1.5,2));
        }
    }
    class CalculatorFactory
    {
        private CalculatorFactory() { }
        public static readonly CalculatorFactory FactoryInstance = new CalculatorFactory();
        public ICalculator GetCalculator()
        {
            string CalculatorTypeString = ConfigurationManager.AppSettings["MYCALC"];
            Type CalculatorType = Type.GetType(CalculatorTypeString);
            ICalculator MyCalculator = (ICalculator)Activator.CreateInstance(CalculatorType);
            return MyCalculator;
        }
    }
    interface ICalculator
    {
        double Calculate(double amount, double rateOfInterest, int duration);
    }
    class SavingsAccountCalculator: ICalculator
    {
        public double Calculate(double amount,double rateOfInterest,int duration)
        {
            Console.WriteLine("Savings Account Calculator");
            return amount * rateOfInterest * 3 / (100 * 12);
        }
    }
    class FDAccountCalculator : ICalculator
    {
        public double Calculate(double amount, double rateOfInterest, int duration)
        {
            Console.WriteLine("FD Account Calculator");
            return amount * rateOfInterest * duration / 100;
        }
    }
}
