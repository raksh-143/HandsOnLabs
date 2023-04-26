using RecommendationEngine.Common.Entities;
using RecommendationEngine.DataLoader;
using RecommendationEngine.RatingsAggregator;
using RecommendationEngine.Integrator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the Book Store!");
                Console.WriteLine("Enter your state: ");
                string myState = Console.ReadLine();
                Console.WriteLine("Enter your age: ");
                int myAge = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the ISBN of the book you just read: ");
                string myISBN = Console.ReadLine();
                Console.WriteLine("How many books would you like to read?");
                int limit = int.Parse(Console.ReadLine());
                Stopwatch stopwatch = Stopwatch.StartNew();
                Preference myPreference = new Preference { State = myState, Age = myAge, ISBN = myISBN };
                MyRecommendationEngine recommendation = new MyRecommendationEngine();
                List<Book> myBooks = recommendation.Recommend(myPreference, limit);
                if(myBooks.Count > 0)
                {
                    Console.WriteLine("More such books that you can read are:");
                    for (int i = 0; i < myBooks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {myBooks[i].BookTitle}");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry! Did not find books similar to your taste! Try again later!");
                }
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error occured! Try again later!");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
