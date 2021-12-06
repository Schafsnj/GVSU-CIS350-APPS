using System;
using System.Data.SqlClient;

namespace APPS_Web_APP.Services
{
    public class LinkedDAO
    {

        string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=APPS-Project-Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void addAssigned(int userId, int taskId)
        {
            string sqlStatement = "Insert into dbo.Linked(TASKID, USERID) values(@taskid, @userid)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //Adding parameter
                command.Parameters.Add("@taskid", System.Data.SqlDbType.Int).Value = taskId;
                command.Parameters.Add("@userid", System.Data.SqlDbType.Int).Value = userId;


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();
            }
        }
    }
}
