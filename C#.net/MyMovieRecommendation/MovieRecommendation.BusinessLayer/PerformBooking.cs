using MovieRecommendation.BusinessLayer.Entities;
using MovieRecommendation.BusinessLayer.Exceptions;
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
    public class PerformBooking
    {
        public int Book(Booking booking)
        {
            IDbConnection conn = GetConnection();

            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            string command = "Book";
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;

            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@bookingdate";
            p2.Value = DateTime.Now;
            cmd.Parameters.Add(p2);

            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@showid";
            p3.Value = booking.Show.ShowId;
            cmd.Parameters.Add(p3);

            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@userid";
            p4.Value = booking.User.UserID;
            cmd.Parameters.Add(p4);
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            using (conn)
            using(reader)
            {
                if (reader.Read())
                {
                    return int.Parse(Convert.ToString(reader[0]));
                }
                else
                {
                    throw new ServerErrorException("Error occured while booking!Try again later");
                }
            }
        }

        public bool Cancel(Booking booking)
        {
            IDbConnection conn = GetConnection();

            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            string command = "Cancel";
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;

            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@bookingid";
            p2.Value = booking.BookingId;
            cmd.Parameters.Add(p2);

            using (conn)
            {
                conn.Open();
                int res = cmd.ExecuteNonQuery();
                if (res == 0)
                {
                    throw new ServerErrorException("Error occured while cancelling booking!Try again later");
                }
            }

            return true;
        }
        public IDbConnection GetConnection()
        {
            string provider = ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            DbProviderFactory dbf = DbProviderFactories.GetFactory(provider);
            IDbConnection conn = dbf.CreateConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            return conn;
        }
    }
}
