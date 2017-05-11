using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UNiVERSiTYwebapp.Gateways
{
    public class DBGateway
    {
        private string connectionString;
        private SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataReader reader;

        protected DBGateway()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBContext"].ConnectionString;
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        private void OpenConnection()
        {
            connection.Open();
        }

        private void CloseConnection()
        {
            connection.Close();
        }

        protected void ExecuteQuery()
        {
            OpenConnection();
            reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        protected int ExecuteNonQuery()
        {
            OpenConnection();
            int result = command.ExecuteNonQuery();
            CloseConnection();
            return result;
        }

        protected long ExecuteNonQuery(bool insert)
        {
            OpenConnection();
            long result = 0;
            if (insert)
                result = Convert.ToInt64(command.ExecuteScalar());
            else
                ExecuteNonQuery();
            CloseConnection();
            return result;
        }
    }
}