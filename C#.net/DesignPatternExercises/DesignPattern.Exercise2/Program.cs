using System;
using System.Collections.Generic;

namespace DesignPattern.Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class CostCalculation
    {
        public virtual double Calculate(List<int> qty,List<double> price)
        {
            double total = 0;
            for(int i=0;i<qty.Count;i++)
            {
                total += qty[i] * price[i];
            }
            Decorator dd = new SurpriseDiscount();
            double discount = dd.GetDiscount(total);
            Decorator sd = new Sale();
            double saleOff = sd.GetDiscount(total);
            total -= (discount + saleOff);
            return total;
        }
    }
    class Decorator : CostCalculation
    {
        public CostCalculation MyCostCalculation { get; set; }
        public virtual double GetDiscount(double amount)
        {
            return amount * 0.1;
        }
    }
    class SurpriseDiscount : Decorator
    {
        public override double GetDiscount(double amount)
        {
            return amount * 0.15;
        }
    }
    class Sale : Decorator
    {
        public override double GetDiscount(double amount)
        {
            return 100;
        }

    }
}
