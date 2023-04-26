using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer
{
    public class TicketBookingService : ITicketBookingService
    {
        public void DisplayReport(string movieName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllMovieNamesSeenByInTheatre(string theatreName, string loginName)
        {
            throw new NotImplementedException();
        }

        public double GetTotalIncomeEarnedByTheatre(string theatreName)
        {
            throw new NotImplementedException();
        }

        public int GetTotalNumberfTicketsBookedByCity(string cityName)
        {
            IDbConnection conn = GetConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string command = "select count(*) from Tickets where BookingID in (select BookingID from Booking where UserID in (select UserID from User where AddressID in (select AddressID from Address where City=@city)))";
            cmd.CommandText = command;
            IDbDataParameter p = cmd.CreateParameter();
            p.ParameterName = "@city";
            p.Value = cityName;
            cmd.Parameters.Add(p);
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            using(conn)
            using (reader)
            {
                if (reader.Read())
                {
                    return int.Parse(reader.GetString(0));
                }
                else
                {
                    throw new Exception("No tickets booked from this city");
                }
            }
        }
        private IDbConnection GetConnection()
        {
            string provider = ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            DbProviderFactory dbf = DbProviderFactories.GetFactory(provider);
            IDbConnection conn = dbf.CreateConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            return conn;
        }
    }
}
