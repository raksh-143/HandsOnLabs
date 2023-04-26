using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode
{
    class AbstractionInterface
    {
        static void Main(string[] args)
        {
            //SimpleCalculator sc = new SimpleCalculator();
            MyMathApp app = new MyMathApp();
            app.Calculator = new SuperCalculator();
            Console.WriteLine(app.Sum(10, 20, 38, 40));
            Console.ReadKey();
        }
    }
    interface ICalculator
    {
        int Sum(int[] numbers);
    }
    class SimpleCalculator:ICalculator
    {
        public int Sum(int[] numbers)
        {
            int total = 0;
            foreach(int i in numbers)
            {
                total += i;
            }
            return total;
        }
    }
    class SuperCalculator : ICalculator
    {
        public int Sum(params int[] numbers)
        {
            return numbers.Sum();
        }
    }
    //The problem with Generalization is that we cannot control the changes made to the parent class (SimpleCalculator)
    //Also if we get a better solution in the future then there will be a lot of modifications required
    class MyMathApp : ICalculator
    {
        //Creating an ICalculator object => Even if implementation changes we can use any object of ICalculator
        public ICalculator Calculator { get; set; }
        public int Sum(params int[] numbers)
        {
            return Calculator.Sum(numbers);
        }


        //Using SimpleCalculator => Uses; If implementation changes problems will arise
        //public int Sum(params int[] numbers)
        //{
        //    SimpleCalculator sc = new SimpleCalculator();
        //    return sc.Sum(numbers);
        //}


        //The abstraction of this method is different from that of the other method (Sum) => Borrow implementation
        //public int FindSum(int[] numbers)
        //{
        //    SimpleCalculator sc = new SimpleCalculator();
        //    return sc.Sum(numbers);
        //}

        //If we don't have the abstraction already then borrow both abstraction and implementation => Generalization
    }
}
