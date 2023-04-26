using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationEngine.Common.Entities
{
    public class User
    {
        public List<BookUserRating> BookUserRatings { get; set; } = new List<BookUserRating>();
        public string UserID { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
