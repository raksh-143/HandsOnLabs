using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DessignPattern.Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class RateOfInterest
    {
        public double FDA { get; set; }
        public double HousingLoan { get; set; }
        public double BusinessLoan { get; set; }
    }
    abstract class Observer
    {
        public abstract void Update();
    }
    class client : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Updating the Client about the ROI");
        }
    }
    interface INotification
    {
        void Subscribe();
        void Unsubscribe();
        void NotifyObserver();
    }
    class EmailNotification : INotification
    {
        public void Subscribe()
        {
            Console.WriteLine("Subscribed successfully!");
        }

        public void Unsubscribe()
        {
            Console.WriteLine("Unsubscribed successfully!");
        }

        public void NotifyObserver()
        {
            Console.WriteLine("Updating Customers about the change in Interest Rates");
        }
    }
}
