using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionDemo.DataLayer
{
    public class TransactionBetweenAccounts
    {
        public bool TransferFunds(int fromAcc,int toAcc,int amount)
        {
            //We have to wrap all commands into single transaction
            //If amount is debited from one account but not credited to another transaction
            //should be rolled back
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            SqlCommand cmd1 = new SqlCommand($"update Accounts set Balance=Balance-{amount} where AccNo={fromAcc}", conn);
            SqlCommand cmd2 = new SqlCommand($"update Accounts set Balance=Balance+{amount} where AccNo={toAcc}", conn);
            conn.Open();

            SqlTransaction tx = conn.BeginTransaction();
            cmd1.Transaction = tx;
            cmd2.Transaction = tx;

            try
            {
                cmd1.ExecuteNonQuery();
                throw new Exception("Server Error");
                cmd2.ExecuteNonQuery();
                tx.Commit();
            }
            catch(Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}
