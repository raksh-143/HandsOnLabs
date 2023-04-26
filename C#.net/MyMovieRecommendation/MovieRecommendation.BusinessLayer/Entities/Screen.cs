using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer.Entities
{
    public class Screen
    {
        public int ScreenId { get; set; }
        public string ScreenName { get; set; }
        public Theatre Theatre { get; set; }
        public List<Show> Shows { get; set; } = new List<Show>();
        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}
