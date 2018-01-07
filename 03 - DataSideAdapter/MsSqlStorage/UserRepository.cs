using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MsSqlStorage
{
    public class UserRepository
    {
        //TODO: Add real connection string for DB. Add your connectionstring inside the "".
        const string connectionString = "";

        public void CreateUser(User user)
        {
            string query = "INSERT Into dbo.User (Name, Password) " +
                    "VALUES (@Name, @Password) ";

            // instance connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                // add parameters and their values
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 50).Value = user.Name;
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;

                // open connection, execute command and close connection
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // For SELECTING FROM DB WITH OUT SP.

        public List<User> GetAllUsers()
        {
           
            // Provide the query string 
            string queryString =
                "SELECT * From User";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            List<User> userList = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new User()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        };
                        userList.Add(user);
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

            }

            return userList;
            
        }

        public void DeleteUser()
        {
            //TODO: Code for calling SP in DB for deleting a user
        }
    }
}
