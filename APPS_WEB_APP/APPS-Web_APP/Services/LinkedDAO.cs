using APPS_Web_APP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace APPS_Web_APP.Services
{
    public class LinkedDAO
    {

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jayden\Source\Repos\Schafsnj\GVSU-CIS350-APPS\APPS_WEB_APP\APPS-Web_APP\App_Data\APPS-Project-Database.mdf;Integrated Security = True"; 
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

        public List<Linked> getAssigned(User user)
        {
            List<Linked> aTasks = new List<Linked>();
            string sqlStatement = "SELECT * FROM dbo.Linked WHERE userId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", user.Id);

                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    while (reads.HasRows && reads.Read())
                    {
                        aTasks.Add(new Linked
                        {
                            Id = (int)reads[0],
                            taskId = (int)reads[1],
                            userId = (int)reads[2]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();

            }

            return aTasks;
        }

        public Linked getById(int Id)
        {
            Linked link = new Linked();
            string sqlStatement = "SELECT * FROM dbo.Linked WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id", Id);
                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    if (reads.Read())
                    {
                        link.Id = (int)reads[0];
                        link.taskId = (int)reads[1];
                        link.userId = (int)reads[2];
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();

            }

            return link;
        }

        public void remove(int Id, User user)
        {

            string sqlStatement = "DELETE FROM dbo.linked WHERE taskId = @Id AND userId = @userid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //Adding parameter
                command.Parameters.AddWithValue("@Id", Id);
                command.Parameters.AddWithValue("@userid", user.Id);


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

        public void DeleteTask(int Id)
        {

            string sqlStatement = "DELETE FROM dbo.Linked WHERE taskId = @Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //Adding parameter
                command.Parameters.AddWithValue("@Id", Id);


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
