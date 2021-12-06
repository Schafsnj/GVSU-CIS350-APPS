using APPS_Web_APP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web.Helpers;

namespace APPS_Web_APP.Services
{
    public class UsersDAO
    {
        string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=APPS-Project-Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        User account = new User();


        

        public bool FindUserByNameAndPassword(User user)
        {



                user.UserName = user.UserName.ToLower();
                bool success = false;
                //Creating list to store user passwords
                List<String> passwords = null;


                //statement to tell database what to do
                string sqlStatement = "SELECT PASSWORD FROM dbo.Users WHERE USERNAME = @username";

                //Keeps it open only while using the database then closes it
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //Creates the new command
                    SqlCommand command = new SqlCommand(sqlStatement, connection);
                    command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;


                    //Checking to see if it worked
                    try
                    {
                        connection.Open();
                        SqlDataReader reads = command.ExecuteReader();

                        while(reads.HasRows && reads.Read())
                        {
                            if(passwords == null) //Initializing list of password
                            {
                                passwords = new List<String>();
                            }

                            String password = reads.GetString(reads.GetOrdinal("PASSWORD"));
                            passwords.Add(password);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.Write(e.Message);
                    }
                }
                if(passwords != null)
                {
                    for(int i = 0; i < passwords.Count; i++) 
                    {
  
                        success = Crypto.VerifyHashedPassword(passwords[i], user.Password);
         
                    }
                }
                  
                return success;
        }

        public void Delete(int Id)
        {
         
            string sqlStatement = "DELETE FROM dbo.Users WHERE Id = @Id";
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

        public void AddUser(User user)
        {
     
            user.Password = hashPass(user.Password);
            user.UserName = user.UserName.ToLower();
            user.Role = 2;
            user.LoggedIn = 1;
            string sqlStatement = "Insert into dbo.Users(USERNAME, PASSWORD, EMAIL, FIRSTNAME, LASTNAME, ROLE, LOGGEDIN) values(@username, @password, @email, @firstname, @lastname, @role, @loggedin)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                //Adding parameter
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 100).Value = user.Password;
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 100).Value = user.Email;
                command.Parameters.Add("@firstname", System.Data.SqlDbType.VarChar, 40).Value = user.FirstName;
                command.Parameters.Add("@lastname", System.Data.SqlDbType.VarChar, 40).Value = user.LastName;
                command.Parameters.Add("@role", System.Data.SqlDbType.Int).Value = user.Role;
                command.Parameters.Add("@loggedin", System.Data.SqlDbType.Int).Value = user.LoggedIn;


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(SqlException e)
                {
                    Console.Write(e.Message);
                }
                connection.Close(); 
            }
        }

        public bool checkManager(User user)
        {

            bool success = false;


            //statement to tell database what to do
            string sqlStatement = "SELECT * FROM dbo.Users WHERE ROLE = @role AND USERNAME = @username";

            //Keeps it open only while using the database then closes it
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
               // command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@role", 2);
                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    if (!(reads.HasRows))
                    {
                        success = true;
                        return success;
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();
            }
           
            return success;
        }
        public bool checkLoggedIn(User user)
        {

            bool success = false;


            //statement to tell database what to do
            string sqlStatement = "SELECT * FROM dbo.Users WHERE LOGGEDIN = 1 AND USERNAME = @username";

            //Keeps it open only while using the database then closes it
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@username", user.UserName);

                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    if (reads.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();
            }

            return success;
        }

        public List<User> GetAllEmployees()
        {
            List<User> employees = new List<User>();
            string sqlStatement = "SELECT * FROM dbo.Users WHERE ROLE = 2";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
       
                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    while(reads.Read())
                    {
                        employees.Add(new User { 
                            Id = (int)reads[0], 
                            UserName = (string)reads[1], 
                            Password = (string)reads[2], 
                            Email = (string)reads[3], 
                            FirstName = (string)reads[4], 
                            LastName = (string)reads[5],
                            Role = (int)reads[6]
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();

            }

            return employees;
        }

        public User findUser(string username)
        {
            User user = new User();
            string sqlStatement = "SELECT * FROM dbo.Users WHERE USERNAME = @username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@username", username);
                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    if(reads.Read())
                    { 
                        user.Id = (int)reads[0];
                        user.UserName = (string)reads[1];
                        user.Password = (string)reads[2];
                        user.Email = (string)reads[3];
                        user.FirstName = (string)reads[4];
                        user.LastName = (string)reads[5];
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();

            }

            return user;
        }

        public User findUserById(int Id)
        {
            User user = new User();
            string sqlStatement = "SELECT * FROM dbo.Users WHERE Id = @id";

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
                        user.Id = (int)reads[0];
                        user.UserName = (string)reads[1];
                        user.Password = (string)reads[2];
                        user.Email = (string)reads[3];
                        user.FirstName = (string)reads[4];
                        user.LastName = (string)reads[5];
                        user.Role = (int)reads[6];
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                connection.Close();

            }

            return user;
        }

        public void changePassword(User usermodel, string newPassword)
        {
            newPassword = hashPass(newPassword);
            string sqlStatement = "UPDATE dbo.Users SET PASSWORD = @password, LOGGEDIN = @loggedin WHERE Id = @Id";
               

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@password", newPassword);
                command.Parameters.AddWithValue("@loggedin", 0);
                command.Parameters.AddWithValue("@Id", usermodel.Id);
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

        public void SaveEdit(User usermodel)
        {
          
            string sqlStatement = "UPDATE dbo.Users SET USERNAME = @username, FIRSTNAME = @firstname, EMAIL = @email, LASTNAME = @lastname, ROLE = @role WHERE Id = @Id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@username", usermodel.UserName);
                command.Parameters.AddWithValue("@firstname", usermodel.FirstName);
                command.Parameters.AddWithValue("@lastname", usermodel.LastName);
                command.Parameters.AddWithValue("@email", usermodel.Email);
                command.Parameters.AddWithValue("@role", usermodel.Role);
                command.Parameters.AddWithValue("@Id", usermodel.Id);
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


        //Generates SHA256 Hash
        public string hashPass(string userPass)
        {

            string password = userPass;
            string hashedPass = Crypto.HashPassword(password);
            return hashedPass;
        }

    }
}
