using RecommendationEngine.Common.Entities;
using RecommendationEngine.DataLoader;
using RecommendationEngine.RatingsAggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.TestingModule3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CSVDataLoader csv = new CSVDataLoader();
            BookDetails bd = csv.Load();
            Preference myPreference = new Preference { Age = 20, State = "colorado" };
            RatingAggregator ra = new RatingAggregator();
            Dictionary<string,List<int>> result = ra.Aggregate(bd, myPreference);
            foreach(string key in result.Keys)
            {
                foreach(int val in result[key])
                {
                    Console.WriteLine(val);
                }
            }
        }
    }
}
