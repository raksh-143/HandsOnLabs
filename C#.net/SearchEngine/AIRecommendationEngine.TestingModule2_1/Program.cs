using RecommendationEngine.Common.Entities;
using RecommendationEngine.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.TestingModule2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CSVDataLoader csv = new CSVDataLoader();
            BookDetails bd = csv.Load();
            foreach (var item in bd.Books)
            {
                Console.WriteLine(item.ISBN);
            }
            foreach (var item in bd.Users)
            {
                Console.WriteLine(item.UserID);
            }
            foreach (var item in bd.BookUserRatings)
            {
                Console.WriteLine(item.ISBN);
            }
        }
    }
}
