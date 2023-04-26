using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRecommendation.BusinessLayer.Entities;
using MovieRecommendation.BusinessLayer.Exceptions;
namespace MovieRecommendation.BusinessLayer
{
    public class UserAccountManager
    {
        public int AddUser(User user)
        {
            IDbConnection conn = GetConnection();

            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            string command = "AddUser";
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;

            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@loginname";
            p2.Value = user.LoginName;
            cmd.Parameters.Add(p2);

            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@firstname";
            p3.Value = user.FirstName;
            cmd.Parameters.Add(p3);

            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@lastname";
            p4.Value = user.LastName;
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
                    throw new ServerErrorException("Error occured while adding user! Try again later");
                }
            }
        }
        public bool UpdateUser(User user)
        {
            IDbConnection conn = GetConnection();

            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            string command = "UpdateUser";
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;

            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@userid";
            p1.Value = user.UserID;
            cmd.Parameters.Add(p1);

            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@loginname";
            p2.Value = user.LoginName;
            cmd.Parameters.Add(p2);

            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@firstname";
            p3.Value = user.FirstName;
            cmd.Parameters.Add(p3);

            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@lastname";
            p4.Value = user.LastName;
            cmd.Parameters.Add(p4);
            using (conn)
            {
                conn.Open();
                int res = cmd.ExecuteNonQuery();
                if (res == 0)
                {
                    throw new UserNotFoundException("No such user found");
                }
            }
            return true;
        }
        public bool DeleteUser(User user)
        {
            IDbConnection conn = GetConnection();

            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            string command = "DeleteUser";
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;

            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@userid";
            p1.Value = user.UserID;
            cmd.Parameters.Add(p1);

            using (conn)
            {
                conn.Open();
                int res = cmd.ExecuteNonQuery();
                if (res == 0)
                {
                    throw new UserNotFoundException("No such user found");
                }
            }
            return true;
        }
       private static IDbConnection GetConnection()
        {
            string provider = ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            IDbConnection conn = factory.CreateConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            return conn;

        }
    }
}
