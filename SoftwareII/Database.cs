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
    public class Database
    {
        

        // Make the connection to the database
        public static MySqlConnection connection { get; set; }
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
        
    }
}
