using APPS_Web_APP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace APPS_Web_APP.Services
{
    public class UsersDAO
    {
        string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=APPS-Project-Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        User account = new User();
        

        public bool FindUserByNameAndPassword(User user)
        {

            bool success = false;

           // string salt = getSalt(user.UserName);
            //user.Password = hashPass(user.Password, salt);

            
            //statement to tell database what to do
            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password";

            //Keeps it open only while using the database then closes it
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 100).Value = user.Password;

                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    if(reads.HasRows)
                    {
                        success = true;
                    }
                }
                catch(Exception e)
                {
                    Console.Write(e.Message);
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
            }
        }

        public void AddUser(User user)
        {
            user.Salt = generateSalt();
            user.Password = hashPass(user.Password, user.Salt);
            user.Role = 1;
            string sqlStatement = "Insert into dbo.Users(USERNAME, PASSWORD, EMAIL, FIRSTNAME, LASTNAME, ROLE, SALT) values(@username, @password, @email, @firstname, @lastname, @role, @salt)";
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
                command.Parameters.Add("@salt", System.Data.SqlDbType.VarChar, 100).Value = user.Salt;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(SqlException e)
                {
                    Console.Write(e.Message);
                }
            }
        }

        public bool checkManager(User user)
        {

            bool success = false;


            //statement to tell database what to do
            string sqlStatement = "SELECT * FROM dbo.Users WHERE role = @role";

            //Keeps it open only while using the database then closes it
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@role", System.Data.SqlDbType.Int).Value = 1;

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
                        employees.Add(new User { Id = (int)reads[0], UserName = (string)reads[1], Password = (string)reads[2], 
                            Email = (string)reads[3], FirstName = (string)reads[4], LastName = (string)reads[5] });
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

            }

            return employees;
        }

        public String generateSalt()
        {
            int size = 350;
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        //Generates SHA256 Hash
        public string hashPass(string userPass, string salt)
        {
            byte[] password = System.Text.Encoding.UTF8.GetBytes(userPass + salt);

            System.Security.Cryptography.SHA256Managed hashed = new System.Security.Cryptography.SHA256Managed();
            byte[] hashedPass = hashed.ComputeHash(password);

            return Convert.ToBase64String(hashedPass);
        }

        //Gets salt from username to checkpasswords
        public string getSalt(string user)
        {
            string sqlStatement = "SELECT SALT FROM dbo.Users WHERE USERNAME = @username";
            string salt = "";

        

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Creates the new command
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 100).Value = user;

                //Checking to see if it worked
                try
                {
                    connection.Open();
                    SqlDataReader reads = command.ExecuteReader();

                    while (reads.Read())
                    {

                        salt = (string)reads[7];
                       
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

            }

            return salt;
        }
    }
}
