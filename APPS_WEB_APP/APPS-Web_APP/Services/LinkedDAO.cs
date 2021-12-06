using System;
using System.Data.SqlClient;

namespace APPS_Web_APP.Services
{
    public class LinkedDAO
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jayden\Source\Repos\Schafsnj\GVSU-CIS350-APPS\APPS_WEB_APP\APPS-Web_APP\App_Data\APPS-Project-Database.mdf;Integrated Security = True"; public void addAssigned(int userId, int taskId)
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
