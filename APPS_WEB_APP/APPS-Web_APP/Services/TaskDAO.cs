using APPS_Web_APP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace APPS_Web_APP.Services
{
    public class TaskDAO
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jayden\Source\Repos\Schafsnj\GVSU-CIS350-APPS\APPS_WEB_APP\APPS-Web_APP\App_Data\APPS-Project-Database.mdf;Integrated Security = True";
        public List<Task> GetAllTasks()
        {
            List<Task> tasks = new List<Task>();
            string sqlStatement = "SELECT * FROM dbo.Tasks";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    while (reads.Read())
                    {
                        tasks.Add(new Task
                        {
                            Id = (int)reads[0],
                            TaskName = (string)reads[1],
                            TaskDesc = (string)reads[2],
                            Company = (string)reads[3],
                            Contact = (string)reads[4],
                            Email = (string)reads[5],
                            Status = (string)reads[6]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();

            }

            return tasks;
        }

        public void AddTask(Task task)
        {
            task.Status = "Open";
            string sqlStatement = "Insert into dbo.Tasks(TASKNAME, TASKDESC, COMPANY, CONTACT, EMAIL, STATUS) values(@taskname, @taskdesc, @company, @contact, @email, @status)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //Adding parameter
                command.Parameters.Add("@taskname", System.Data.SqlDbType.VarChar, 40).Value = task.TaskName;
                command.Parameters.Add("@taskdesc", System.Data.SqlDbType.VarChar, 100).Value = task.TaskName;
                command.Parameters.Add("@company", System.Data.SqlDbType.VarChar, 100).Value = task.Company;
                command.Parameters.Add("@contact", System.Data.SqlDbType.VarChar, 40).Value = task.Contact;
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 40).Value = task.Email;
                command.Parameters.Add("@status", System.Data.SqlDbType.VarChar, 40).Value = task.Status;

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

            string sqlStatement = "DELETE FROM dbo.Tasks WHERE Id = @Id";
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

        public void SaveEditTask(Task task)
        {

            string sqlStatement = "UPDATE dbo.Tasks SET TASKNAME = @taskname, TASKDESC = @taskdesc, COMPANY = @company, " +
                "CONTACT = @contact, EMAIL = @email WHERE Id = @Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@taskname", task.TaskName);
                command.Parameters.AddWithValue("@taskdesc", task.TaskDesc);
                command.Parameters.AddWithValue("@company", task.Company);
                command.Parameters.AddWithValue("@contact", task.Contact);
                command.Parameters.AddWithValue("@email", task.Contact);
                command.Parameters.AddWithValue("@Id", task.Id);
                //Checking to see if it worked
                try
                {
                    connection.Open();
                    command.ExecuteScalar();

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();

            }
        }

        public Task findById(int Id)
        {
            Task task = new Task();
            string sqlStatement = "SELECT * FROM dbo.Tasks WHERE Id = @id";

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
                        task.Id = (int)reads[0];
                        task.TaskName = (string)reads[1];
                        task.TaskDesc = (string)reads[2];
                        task.Company = (string)reads[3];
                        task.Contact = (string)reads[4];
                        task.Email = (string)reads[5];
                        task.Status = (string)reads[6];
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();

            }

            return task;
        }

        public List<Task> GetAllTasksAssigned(List<Linked> assigned)
        {
            List<Task> tasks = new List<Task>();
            Task task = new Task();

            //statement to tell database what to do
            string sqlStatement = "SELECT * FROM dbo.Tasks";

            //Keeps it open only while using the database then closes it
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);


                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    while (reads.HasRows && reads.Read())
                    {
                        
                        task.Id = (int)reads[0];
                        task.TaskName = (string)reads[1];
                        task.TaskDesc = (string)reads[2];
                        task.Company = (string)reads[3];
                        task.Contact = (string)reads[4];
                        task.Email = (string)reads[5];
                        task.Status = (string)reads[6];
                        tasks.Add(task);
                        task = new Task();
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }
            if (tasks != null)
            {
                for (int i = 0; i < tasks.Count; i++)
                {

                    if(inTask(tasks[i].Id, assigned) == false)
                    {
                        tasks.RemoveAt(i);
                    }

                }
            }

            return tasks;
        }

        private bool inTask(int id, List<Linked> assigned)
        {
            for(int i = 0; i < assigned.Count; i++)
            {
                if(id == assigned[i].taskId)
                {
                    return true;
                }
            }
            return false;
        }

        public void updateStatus(int Id)
        {

            string sqlStatement = "UPDATE dbo.Tasks SET STATUS = @status WHERE Id = @Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@status", "Completed");
                command.Parameters.AddWithValue("@Id", Id);
                //Checking to see if it worked
                try
                {
                    connection.Open();
                    command.ExecuteScalar();

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();

            }
        }
    }


}
