using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer.Entities
{
    public class Show
    {
        public int ShowId { get; set; }
        public DateTime ShowTime { get; set; }
        public double Cost { get; set; }
    }
}
