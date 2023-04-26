using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutstandingPerson
{
    internal class Student:Person
    {
        public double Percentage;
        //public Student() { }
        public Student(string Name, double Percentage) : base(Name)
        {
            this.Percentage = Percentage;
        }
        public void Display()
        {
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Percentage: {Percentage}");
        }
        public override bool IsOutstanding()
        {
            if (Percentage > 85)
            {
                return true;
            }
            return false;
        }

    }
}
