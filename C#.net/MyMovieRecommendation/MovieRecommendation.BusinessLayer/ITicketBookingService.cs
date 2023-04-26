using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer
{
    public interface ITicketBookingService
    {
        double GetTotalIncomeEarnedByTheatre(string theatreName);
        List<string> GetAllMovieNamesSeenByInTheatre(string theatreName, string loginName);
        int GetTotalNumberfTicketsBookedByCity(string cityName);
        void DisplayReport(string movieName);
    }
}
