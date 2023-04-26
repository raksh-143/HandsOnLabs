using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRecommendation.BusinessLayer.Entities;

namespace MovieRecommendation.BusinessLayer
{
    public class ShowInfo
    {
        public List<Show> GetShows()
        {
            IDbConnection conn = GetConnection();

            string command = "GetShows";

            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;

            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@date";
            p1.Value = DateTime.Now;
            cmd.Parameters.Add(p1);
            
            conn.Open();
            IDataReader myReader = cmd.ExecuteReader();

            List<Show> availableShows = new List<Show>();

            using (conn)
            using (myReader)
            {
                while(myReader.Read())
                {
                    Show show = new Show();
                    show.ShowId = (int)myReader["ShowID"];
                    show.ShowTime = (DateTime)myReader["ShowTime"];
                    show.Cost = Convert.ToDouble(myReader["Cost"]);
                    availableShows.Add(show);
                }
            }
            return availableShows;
        }
        public IDbConnection GetConnection()
        {
            string providerName = ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            IDbConnection connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            return connection;
        }
    }
}
