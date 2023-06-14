using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SoftwareII
{
    public class Database
    {
        // Get the connection string from the config
        string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

        // Make the connection to the database
        MySqlConnection connection = null;
        public void Connect()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

             
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
        
    }
}
