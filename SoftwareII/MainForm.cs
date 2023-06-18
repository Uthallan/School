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
            //Database.loggedInUser = Database.GetUsers().FirstOrDefault(x => x.UserName == "test");


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
            if (Database.loggedInUser == null)
            {
                return;
            }
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

        private void MainFormAllRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            AppointmentsDataGridView.DataSource = Database.GetAppointments();
        }

        private void MainFormWeekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var allAppointments = Database.GetAppointments();
            var weekAppointments = allAppointments.Where(a => a.Start >= DateTime.Now && a.Start <= DateTime.Now.AddDays(7)).ToList();

            AppointmentsDataGridView.DataSource = weekAppointments;
        }

        private void MainFormMonthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var allAppointments = Database.GetAppointments();
            var monthAppointments = allAppointments.Where(a => a.Start >= DateTime.Now && a.Start <= DateTime.Now.AddDays(30)).ToList();

            AppointmentsDataGridView.DataSource = monthAppointments;
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            // 1. Number of appointment types by month
            List<Appointment> appointments = Database.GetAppointments();
            var appointmentTypesByMonth = appointments.GroupBy(a => new { a.Start.Month, a.Type })
                                                      .Select(group => new
                                                      {
                                                          Month = DateTime.Now.Month,
                                                          Type = group.Key.Type,
                                                          Count = group.Count()
                                                      });

            StringBuilder report1 = new StringBuilder();
            report1.AppendLine("Number of appointment types by month:");
            foreach (var item in appointmentTypesByMonth)
            {
                report1.AppendLine($"Month: {item.Month}, Type: {item.Type}, Count: {item.Count}");
            }

            // 2. Schedule for each user
            List<User> users = Database.GetUsers();
            StringBuilder report2 = new StringBuilder();
            report2.AppendLine("Schedule for each user:");
            foreach (User user in users)
            {
                var userAppointments = appointments.Where(a => a.UserId == user.UserId).OrderBy(a => a.Start);
                report2.AppendLine($"User: {user.UserName}");
                foreach (Appointment appt in userAppointments)
                {
                    report2.AppendLine($"    Appointment ID: {appt.AppointmentId}, Start: {appt.Start}, End: {appt.End}, Type: {appt.Type}");
                }
            }

            // 3. Number of appointments for each customer
            var customerAppointments = appointments.GroupBy(a => a.CustomerId)
                                                   .Select(group => new
                                                   {
                                                       CustomerId = group.Key,
                                                       Count = group.Count()
                                                   });

            StringBuilder report3 = new StringBuilder();
            report3.AppendLine("Number of appointments for each customer:");
            foreach (var item in customerAppointments)
            {
                report3.AppendLine($"Customer ID: {item.CustomerId}, Count: {item.Count}");
            }

            // Show the reports
            MessageBox.Show(report1.ToString());
            MessageBox.Show(report2.ToString());
            MessageBox.Show(report3.ToString());
        }



    }
}
