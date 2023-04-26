using ContactManager.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DataAccess
{
    public class ContactsDBRepository : IContactsRepository
    {
        public bool Delete(int id)
        {
            IDbConnection con = GetConnection();

            string myCommand = "[dbo].[DeleteContact] @id";

            IDbCommand com = con.CreateCommand();
            com.Connection = con;
            com.CommandText = myCommand;
            com.CommandType = CommandType.StoredProcedure;

            IDbDataParameter p = com.CreateParameter();
            p.Value = id;
            p.ParameterName = "@id";
            com.Parameters.Add(p);

            using (con)
            {
                con.Open();
                int res = com.ExecuteNonQuery();
                if (res == 0)
                {
                    throw new NoSuchContactFoundException();
                }
            }
            return true;
        }

        public bool Edit(int id, Contact contactToEdit)
        {
            IDbConnection conn = GetConnection();
            string updateSql = "update Contacts set Name=@name,Email=@email,Phone=@phone,Location=@loc where ContactId=@id";
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = updateSql;
            IDbDataParameter p0 = cmd.CreateParameter();
            p0.ParameterName = "@id";
            p0.Value = id;
            cmd.Parameters.Add(p0);
            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@name";
            p1.Value = contactToEdit.Name;
            cmd.Parameters.Add(p1);
            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@email";
            p2.Value = contactToEdit.Email;
            cmd.Parameters.Add(p2);
            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@phone";
            p3.Value = contactToEdit.Phone;
            cmd.Parameters.Add(p3);
            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@loc";
            p4.Value = contactToEdit.Location;
            cmd.Parameters.Add(p4);
            using (conn)
            {
                conn.Open();
                int res = cmd.ExecuteNonQuery();
                if (res == 0)
                {
                    throw new NoSuchContactFoundException();
                }
            }
            return true;
        }

        public List<Contact> GetAll()
        {
            List<Contact> allContacts = new List<Contact>();
            IDbConnection conn = GetConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "[dbo].[Get_all_contacts]";
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            using (conn)
            using (reader) {
                bool flag = false;
                while (reader.Read())
                {
                    flag = true;
                    Contact c = new Contact();
                    c.ContactID = (int)reader[0];
                    c.Name = (string)reader[1];
                    c.Name = c.Name.Trim();
                    c.Email = reader.GetString(2);
                    c.Email = c.Email.Trim();
                    c.Phone = (string)reader["Phone"];
                    c.Location = reader["Location"].ToString().Trim();
                    allContacts.Add(c);
                }
                if (!flag)
                {
                    throw new NoSuchContactFoundException("No contacts yet");
                }
            }
            return allContacts;
        }

        public Contact GetContact(int id)
        {
            Contact reqContact = new Contact();
            IDbConnection conn = GetConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from contacts where ContactId=@id";
            IDbDataParameter p = cmd.CreateParameter();
            p.ParameterName = "@id";
            p.Value = id;
            cmd.Parameters.Add(p);
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            using (conn)
            using (reader)
            {
                bool res = reader.Read();
                if (res)
                {
                    reqContact.ContactID = (int)reader[0];
                    reqContact.Name = (string)reader[1];
                    reqContact.Name = reqContact.Name.Trim();
                    reqContact.Email = reader.GetString(2);
                    reqContact.Email = reqContact.Email.Trim();
                    reqContact.Phone = (string)reader["Phone"];
                    reqContact.Location = reader["Location"].ToString().Trim();
                }
                else
                {
                    throw new NoSuchContactFoundException("No contact with this ID");
                }
            }
            return reqContact;
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            List<Contact> allContacts = new List<Contact>();
            IDbConnection conn = GetConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from contacts where Location=@loc";
            IDbDataParameter p = cmd.CreateParameter();
            p.ParameterName = "@loc";
            p.Value = location;
            cmd.Parameters.Add(p);
            conn.Open();
            IDataReader reader = cmd.ExecuteReader();
            using (conn)
            using (reader)
            {
                bool flag = false;
                while (reader.Read())
                {
                    flag = true;
                    Contact c = new Contact();
                    c.ContactID = (int)reader[0];
                    c.Name = (string)reader[1];
                    c.Name = c.Name.Trim();
                    c.Email = reader.GetString(2);
                    c.Email = c.Email.Trim();
                    c.Phone = (string)reader["Phone"];
                    c.Location = reader["Location"].ToString().Trim();
                    allContacts.Add(c);
                }
                if (!flag)
                {
                    throw new NoSuchContactFoundException("No contacts in this location");
                }
            }
            return allContacts;
        }

        public void Save(Contact contactToSave)
        {
            //Step 1: Establish a connection to the DB
            IDbConnection conn = GetConnection();

            //Step 2: Prepare sql insert cmd and send
            //The below statement causes SQL injection
            //string insertSql = $"insert into Contacts values('{contactToSave.Name}','{contactToSave.Email}','{contactToSave.Phone}','{contactToSave.Location}')";
            string betterInsertSql = "insert into Contacts values(@name,@email,@phone,@loc)";
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = conn;
            //cmd.CommandText = betterInsertSql;
            //cmd.Parameters.AddWithValue("@name",contactToSave.Name);
            //cmd.Parameters.AddWithValue("@email",contactToSave.Email);
            //cmd.Parameters.AddWithValue("@phone",contactToSave.Phone);
            //cmd.Parameters.AddWithValue("@loc",contactToSave.Location);
            //SqlParameter p1 = new SqlParameter();
            //This code should be neutral to all the DBs
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = betterInsertSql;


            IDbDataParameter p1 = cmd.CreateParameter();
            p1.ParameterName = "@name";
            p1.Value = contactToSave.Name;
            cmd.Parameters.Add(p1);

            IDbDataParameter p2 = cmd.CreateParameter();
            p2.ParameterName = "@email";
            p2.Value = contactToSave.Email;
            cmd.Parameters.Add(p2);

            IDbDataParameter p3 = cmd.CreateParameter();
            p3.ParameterName = "@phone";
            p3.Value = contactToSave.Phone;
            cmd.Parameters.Add(p3);

            IDbDataParameter p4 = cmd.CreateParameter();
            p4.ParameterName = "@loc";
            p4.Value = contactToSave.Location;
            cmd.Parameters.Add(p4);

            using (conn)
            {
                //try
                //{
                conn.Open();
                cmd.ExecuteNonQuery();
                //}
            }

            //Step 3: Close DB connection
            //finally
            //{
                //conn.Close();
            //}
        }
        private static IDbConnection GetConnection()
        {
            //SqlConnection conn = new SqlConnection();
            string provider = ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            //Get the factory instance
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            //Get the connection from the factory instance
            IDbConnection conn = factory.CreateConnection();
            string constr = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            conn.ConnectionString = constr;
            return conn;
        }
    }
}
