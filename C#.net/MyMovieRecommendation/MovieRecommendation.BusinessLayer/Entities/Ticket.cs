using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public Booking Booking { get; set; }
    }
}
