using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationEngine.Common.Entities;

namespace RecommendationEngine.RatingsAggregator
{
    public interface IAggregator
    {
        Dictionary<string, List<int>> Aggregate(BookDetails bookDetails, Preference preference);
    }
}
