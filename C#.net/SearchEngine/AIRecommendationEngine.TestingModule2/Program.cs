using AIRecommendationEngine.

namespace AIRecommendationEngine.TestingModule2
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVDataLoader csv = new CSVDataLoader();
            BookDetails bd = csv.Load();
            foreach(var item in bd.Books)
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