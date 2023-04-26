using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        //Data in XML
        static void LINQToXML2()
        {
            XDocument document = XDocument.Load("XMLFile2.xml");

            //XML to another XML
            XElement doc = new XElement("books",
            from b in document.Descendants("book")
            where b.Element("genre").Value == "Fantasy"
            select new XElement("book", new XElement("id", b.Attribute("id").Value), new XElement("title", b.Element("title").Value),
            new XElement("author", b.Element("author").Value)));

            doc.Save("FantasyBooks.xml");

            //XML to Objects
            var fantasyBooks = from b in document.Descendants("book") where b.Element("genre").Value == "Fantasy" select new { BookId = b.Attribute("id").Value, Title = b.Element("title").Value, Author = b.Element("author").Value };
            foreach (var book in fantasyBooks)
            {
                Console.WriteLine($"{book.BookId}: {book.Title} By {book.Author}");
            }
        }
        static void LINQToXML()
        {
            XDocument document = XDocument.Load("XMLFile1.xml");
            var shortWords = from w in document.Descendants("word") where w.Value.Length <= 3 select w.Value;
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }
        }
        //Data in in-memory objects
        static void LINQToObjects3()
        {
            List<string> list = new List<string>() { "one", "two", "three", "four", "five", "six" };
            var shortWords = from w in list where w.Length <= 3 select w;
            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }
        }
        static void LINQToObjects2()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var evenNumbers = from n in numbers where IsEven(n) orderby n descending select n;
            numbers.Add(10);
            //10 is included because LINQ queries execute when it is required in an operation not in 14 but 17
            //Constructs an expression tree in line 14 only when resource is consumed the expression is executed
            //Never return the expression always cast it into a list and return
            //Deferred execution and immeditate execution
            //Return type of LINQ query is IEnumerable
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }
        static void LINQToObjects()
        {
            //LINQ TO OBJECTS
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Extract all even numbers into a separate list
            //Traditional
            List<int> evenNumbers = new List<int>();
            Console.WriteLine("Using traditional method");
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }
            //LINQ
            Console.WriteLine("Using LINQ method expressions");
            evenNumbers = (from n in numbers where n % 2 == 0 orderby n descending select n).ToList();
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("Using LINQ method extensions");
            evenNumbers = numbers.Where(x => x % 2 == 0).OrderByDescending(x => x).ToList();
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
    class BookTitleAuthor
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
