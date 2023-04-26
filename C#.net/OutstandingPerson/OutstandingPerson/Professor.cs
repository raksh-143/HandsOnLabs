using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutstandingPerson
{
    internal class Professor : Person
    {
        public int BooksPublished;
        //public Professor() { }
        public Professor(string Name,int BooksPublished):base(Name)
        {
            this.BooksPublished = BooksPublished;
        }
        public void Print()
        {
            Console.WriteLine($"Professor Name: {Name}");
            Console.WriteLine($"Number of Books Published: {BooksPublished}");
        }
        public override bool IsOutstanding()
        {
            if(BooksPublished > 4)
            {
                return true;
            }
            return false;
        }
    }
}
