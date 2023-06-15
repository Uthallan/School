using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareII
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CheckDatabaseConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Database.connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connection is open.");
                }
                else
                {
                    MessageBox.Show("Connection is not open.");
                }
            }
            catch
            {
                MessageBox.Show("Connection is not open.");
            }
            
        }

        private void MainFormExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginForm newForm = new LoginForm();
            newForm.ShowDialog();
        }

        private void MainFormMCRButton_Click(object sender, EventArgs e)
        {
            MCRForm newForm = new MCRForm();
            newForm.ShowDialog();
        }

        private void NewAppointmentButton_Click(object sender, EventArgs e)
        {
            AppointmentForm newForm = new AppointmentForm();
            newForm.ShowDialog();
        }

        private void UpdateAppointmentButton_Click(object sender, EventArgs e)
        {
            AppointmentForm newForm = new AppointmentForm();
            newForm.ShowDialog();
        }

        private void CancelAppointmentButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
