using SimpleCalculator.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorLibrary
{
    public class Calculator
    {
        private ICalculatorRepo repo = null;
        public Calculator(ICalculatorRepo repo)
        {
            this.repo = repo;
        }
        //find sum of two ints
        //non negative numbers
        //even numbers
        //throw suitable exception if business rules violated
        public int Sum(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new NumberNegativeException("Input should be positive");
            else if (a % 2 != 0 || b % 2 != 0)
                throw new NumberOddException("Input should be even");
            //CalculatorRepo repo = new CalculatorRepo(); //Should not do this because of DIP
            repo.Save($"{a}+{b}={a+b}");
            return a + b;
        }
    }
}
