using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SoftwareII
{
    public static class Database
    {
        

        // Make the connection to the database
        public static MySqlConnection connection { get; set; }
        public static List<User> DatabaseUsers { get; set; }

        public static User loggedInUser { get; set; }


        
        public static void Connect()
        {
            try
            {

                // Get the connection string from the config
                string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;


                connection = new MySqlConnection(connectionString);
                connection.Open();

             
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Disconnect()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<User> GetUsers()
        {
            var users = new List<User>();

            try
            {
                // Ensure the database connection is open
                if (connection.State != System.Data.ConnectionState.Open)
                    Connect();

                var command = new MySqlCommand("SELECT * FROM user", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserId = Convert.ToInt32(reader["userId"]),
                            UserName = Convert.ToString(reader["userName"]),
                            Password = Convert.ToString(reader["password"]),
                            Active = Convert.ToInt32(reader["active"])
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return users;
        }



    }
}
