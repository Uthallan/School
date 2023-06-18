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

            AppointmentsDataGridView.DataSource = Database.GetAppointments();

            // auto logging in as test for testing
            Database.loggedInUser = Database.GetUsers().FirstOrDefault(x => x.UserName == "test");


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
            AppointmentsDataGridView.DataSource = Database.GetAppointments();
        }

        private void UpdateAppointmentButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (AppointmentsDataGridView.SelectedCells.Count > 0 && AppointmentsDataGridView.SelectedCells[0].RowIndex > 0)
            {
                int rowIndex = AppointmentsDataGridView.SelectedCells[0].RowIndex;
                // Get the first selected row
                DataGridViewRow selectedRow = AppointmentsDataGridView.Rows[rowIndex];

                // Get the appointmentId from the selected row
                var appointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);

                // Get the list of all appointments
                var appointments = Database.GetAppointments();

                // Find the appointment with the matching ID
                Appointment selectedAppointment = appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);

                if (selectedAppointment != null)
                {
                    // Open the AppointmentForm with the selected appointment
                    AppointmentForm newForm = new AppointmentForm(selectedAppointment);
                    newForm.ShowDialog();

                    // Refresh the DataGridView
                    AppointmentsDataGridView.DataSource = Database.GetAppointments();
                }
                else
                {
                    // Show a message if no appointment was found with the selected ID
                    MessageBox.Show($"No appointment was found with ID {appointmentId}.");
                }
            }
            else
            {
                // Show a message if no row was selected
                MessageBox.Show("Please select an appointment to update.");
            }
        }




        private void CancelAppointmentButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (AppointmentsDataGridView.SelectedCells.Count > 0 && AppointmentsDataGridView.SelectedCells[0].RowIndex >= 0)
            {
                int rowIndex = AppointmentsDataGridView.SelectedCells[0].RowIndex;
                // Get the first selected row
                DataGridViewRow selectedRow = AppointmentsDataGridView.Rows[rowIndex];

                // Get the appointmentId from the selected row
                var appointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);

                // Get the list of all appointments
                var appointments = Database.GetAppointments();

                // Find the appointment with the matching ID
                Appointment selectedAppointment = appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);

                if (selectedAppointment != null)
                {
                    // Confirm cancellation before deleting
                    var confirmResult = MessageBox.Show($"Are you sure you want to cancel the appointment with ID {appointmentId}?", "Confirm Cancellation", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Delete the appointment
                        Database.DeleteAppointment(selectedAppointment);

                        // Refresh the DataGridView
                        AppointmentsDataGridView.DataSource = Database.GetAppointments();
                    }
                }
                else
                {
                    // Show a message if no appointment was found with the selected ID
                    MessageBox.Show($"No appointment was found with ID {appointmentId}.");
                }
            }
            else
            {
                // Show a message if no row was selected
                MessageBox.Show("Please select an appointment to cancel.");
            }
        }




        private void AppointmentsDataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (Database.loggedInUser != null)
            {
                LoggedInUserLabel.Text = $"Logged in as {Database.loggedInUser.UserName}";
            }
            else
            {
                LoggedInUserLabel.Text = "";
            }
        }
    }
}
