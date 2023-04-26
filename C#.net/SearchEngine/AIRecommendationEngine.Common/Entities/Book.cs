using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationEngine.Common.Entities
{
    public class Book
    {
        public List<BookUserRating> BookUserRatings { get; set; } = new List<BookUserRating>();
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string YearOfPublcation { get; set; }
        public string ImageUriSmall { get; set; }
        public string ImageUriMedium { get; set; }
        public string ImageUriLarge { get; set; }
    }
}
