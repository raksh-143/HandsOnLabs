using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer.Entities
{
    public class Seat
    {
        public char RowId { get; set; }
        public int SeatId { get; set;}
        public Ticket Ticket { get; set;}
    }
}
