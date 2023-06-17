using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SoftwareII
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            Database.Connect();
            Database.DatabaseUsers = Database.GetUsers();

            Database.loggedInUser = null;

            Application.Run(new MainForm());

            Database.Disconnect();
            
        }
    }
}
