using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationEngine.Common.Entities;
using RecommendationEngine.CoreRecommender;
using RecommendationEngine.DataLoader;
using RecommendationEngine.RatingsAggregator;

namespace RecommendationEngine.Integrator
{
    public class MyRecommendationEngine
    {
        public List<Book> Recommend(Preference preference,int limit)
        {
            Dictionary<string,double> strengths = new Dictionary<string,double>();

            //Module 2
            IDataLoader dataLoader = new CSVDataLoader();
            BookDetails allBookDetails = dataLoader.Load();

            //Module 3
            IAggregator aggregator = new RatingAggregator();
            Dictionary<string, List<int>> dictionary = aggregator.Aggregate(allBookDetails, preference);


            //Module 1
            IRecommender recommender = new PearsonCoefficient();
            int[] baseArray = new int[dictionary[preference.ISBN].Count];
            Array.Copy(dictionary[preference.ISBN].ToArray(), baseArray, dictionary[preference.ISBN].Count);
            foreach(string key in dictionary.Keys)
            {
                if (key != preference.ISBN)
                {
                    int[] otherArray = new int[dictionary[key].Count];
                    Array.Copy(dictionary[key].ToArray(), otherArray, dictionary[key].Count);
                    double correlation = recommender.GetCorrelation(baseArray.ToList(), otherArray.ToList());
                    strengths.Add(key, correlation);
                }
            }
            Dictionary<string, double> sortedDict = strengths.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            List<string> suggestedBooks = new List<string>(sortedDict.Keys);
            List<Book> myBooks = new List<Book>();
            foreach (Book book in allBookDetails.Books)
            {
                if (suggestedBooks.Contains(book.ISBN))
                {
                    myBooks.Add(book);
                }
                if (myBooks.Count == limit)
                {
                    break;
                }
            }
            return myBooks;
        }
    }
}
