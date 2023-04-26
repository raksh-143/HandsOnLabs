using RecommendationEngine.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecommendationEngine.RatingsAggregator
{
    public class RatingAggregator : IAggregator
    {
        enum TeenAge
        {
            start=1,end=16
        }
        enum YoungAge
        {
            start=17,end=30
        }
        enum MidAge
        {
            start=31,end=50
        }
        enum OldAge
        {
            start=51,end=60
        }
        enum SeniorCitizen
        {
            start=61,end=100
        }
        public Dictionary<string, List<int>> Aggregate(BookDetails bookDetails, Preference preference)
        {
            Dictionary<string, List<int>> RatingsForBooks = new Dictionary<string, List<int>>();
            foreach (var user in bookDetails.Users)
            {
                if (IsOfAgeGroup(user.Age, preference.Age))
                {
                    if (user.State == preference.State)
                    {
                        foreach(BookUserRating bur in user.BookUserRatings)
                        {
                            if (RatingsForBooks.ContainsKey(bur.ISBN))
                            {
                                RatingsForBooks[bur.ISBN].Add(bur.Rating);
                            }
                            else
                            {
                                List<int> curBookRatings = new List<int>
                                {
                                    bur.Rating
                                };
                                RatingsForBooks.Add(bur.ISBN, curBookRatings);
                            }
                        }
                    }
                    
                } 
            }
            return RatingsForBooks;
        }

        private static bool IsOfAgeGroup(int age1, int age2)
        {
            if(Enumerable.Range((int)TeenAge.start,(int)TeenAge.end).Contains(age1) && Enumerable.Range((int)TeenAge.start, (int)TeenAge.end).Contains(age2))
            {
                return true;
            }
            else if(Enumerable.Range((int)YoungAge.start, (int)YoungAge.end).Contains(age1) && Enumerable.Range((int)YoungAge.start, (int)YoungAge.end).Contains(age2))
            {
                return true;
            }
            else if(Enumerable.Range((int)MidAge.start, (int)MidAge.end).Contains(age1) && Enumerable.Range((int)MidAge.start, (int)MidAge.end).Contains(age2))
            {
                return true;
            }
            else if(Enumerable.Range((int)OldAge.start, (int)OldAge.end).Contains(age1) && Enumerable.Range((int)OldAge.start, (int)OldAge.end).Contains(age2))
            {
                return true;
            }
            else if(Enumerable.Range((int)SeniorCitizen.start, (int)SeniorCitizen.end).Contains(age1) && Enumerable.Range((int)SeniorCitizen.start, (int)SeniorCitizen.end).Contains(age2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
