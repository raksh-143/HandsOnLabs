using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BillingSystem bs = new BillingSystem();
            bs.GenerateBill();
            //TaxCalculatorFactory tcf1 = TaxCalculatorFactory.Instance;
            //Console.WriteLine($"tcf1: {tcf1.GetHashCode()}");
            //TaxCalculatorFactory tcf2 = TaxCalculatorFactory.Instance;
            //Console.WriteLine($"tcf2: {tcf2.GetHashCode()}");
        }
    }
    class BillingSystem
    {
        //private ITaxCalculator myTaxCalculator = null;
        //public BillingSystem(ITaxCalculator taxCalculator)
        //{
        //    myTaxCalculator = taxCalculator;
        //}
        public void GenerateBill()
        {
            //Scan the product and calculate total amount
            double amount = 6500.90;
            //Work with discount, offers, tax calculations
            double discount = 125.00;
            //Using Reflection
            TaxCalculatorFactory tcf = TaxCalculatorFactory.Instance;
            ITaxCalculator taxCalculator = tcf.CreateTaxCalculator();
            double tax = taxCalculator.CalculateTax(amount);
            //Print bill
            double totalAmount = amount - discount + tax;
            //Payment

        }
    }
    public class TaxCalculatorFactory
    {
        private TaxCalculatorFactory() { }
        //private static TaxCalculatorFactory Instance = null;
        //public static TaxCalculatorFactory GetInstance()
        //{
        //    if(Instance == null)
        //    {
        //        Instance =  new TaxCalculatorFactory();
        //    }
        //    return Instance;
        //}
        public static readonly TaxCalculatorFactory Instance = new TaxCalculatorFactory();
        public ITaxCalculator CreateTaxCalculator()
        {
            //Read the config file
            string taxCalcClass = ConfigurationManager.AppSettings["TAXCALC"];
            //Create the instance
            Type theCalculator = Type.GetType(taxCalcClass);
            ITaxCalculator itc = (ITaxCalculator)Activator.CreateInstance(theCalculator);
            //return
            return itc;
        }
    }
    public interface ITaxCalculator //Strategy
    {
        double CalculateTax(double amount);
    }
    class KATaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            double ct = 125.67;
            double kst = 56.89;
            double es = 50.00;
            double sbt = 23;
            double kkt = 20;
            double tax = ct + kst + es + sbt+ kkt;
            Console.WriteLine("KA tax calculator");
            return tax;
        }
    }
    class TNTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            double ct = 125.67;
            double tnst = 56.89;
            double ecs = 50.00;
            double at = 23;
            double lt = 20;
            double tax = ct + tnst + ecs + at + lt;
            Console.WriteLine("TN tax calculator");
            return tax;
        }
    }
    class MyUSTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            USTaxCalculator ustc = new USTaxCalculator();
            float amountFloat = (float)amount;
            double tax = ustc.ComputeTax(amountFloat);
            Console.WriteLine("US tax calculator");
            return tax;
        }
    }
    //Pre written code was purchased -> we only have the dll file
    class USTaxCalculator
    {
        public float ComputeTax(float amount)
        {
            return 124f;
        }
    }
}
