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
    public partial class AppointmentForm : Form
    {
        private Appointment _appointment;

        public AppointmentForm(Appointment appointment = null)
        {
            InitializeComponent();

            if (appointment != null)
            {
                CustomerIDTextBox.Text = appointment.CustomerId.ToString();


                AppointmentTypeTextbox.Text = appointment.Type;
                StartDatePicker.Value = appointment.Start;
                EndDatePicker.Value = appointment.End;
                UserIdTextBox.Text = appointment.UserId.ToString();

                List<Customer> customerList = Database.GetCustomers();

                // Find the customer with the matching ID. Used LINQ Lambda to save lines as its compact
                Customer selectedCustomer = customerList.FirstOrDefault(c => c.CustomerId == appointment.CustomerId);

                if (selectedCustomer != null)
                {
                    CustomerNameTextBox.Text = selectedCustomer.CustomerName;
                }
                else
                {
                    MessageBox.Show($"No customer was found with ID {appointment.CustomerId}.");
                }

                _appointment = appointment;
            }
            else
            {
                UserIdTextBox.Text = Database.loggedInUser.UserId.ToString();
            }


        }


        private void AppointmentFormExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainFormMCRButton_Click(object sender, EventArgs e)
        {
            MCRForm newForm = new MCRForm();
            newForm.ShowDialog();
        }

        public Customer SearchCustomersByName(string searchParameter = "")
        {
            
            Customer resultCustomer = null;
            List<Customer> customersList = Database.GetCustomers();

            // Find the customer with the matching ID. Used LINQ Lambda to save lines as its compact
            resultCustomer = customersList.FirstOrDefault(customer => customer.CustomerName.Equals(searchParameter));

            return resultCustomer;
            
            
        }
        private void SearchClientButton_Click(object sender, EventArgs e)
        {
            Customer resultCustomer = null;

            try
            {

                resultCustomer = SearchCustomersByName(ClientSearchTextBox.Text);

                CustomerNameTextBox.Text = resultCustomer.CustomerName;
                CustomerIDTextBox.Text = resultCustomer.CustomerId.ToString();
            }
            catch
            {
                MessageBox.Show("Could not find customer with that name, are you sure you typed it correctly");
            }


        }


        public class AppointmentUserInput
        {
            public string CustomerId { get; set; }
            public string UserId { get; set; }
            public string Type { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public DateTime CreateDate { get; set; }
            public string CreatedBy { get; set; }
            public DateTime LastUpdate { get; set; }
            public string LastUpdateBy { get; set; }

            public AppointmentUserInput(string CustomerId, string UserId, string Type, DateTime Start, DateTime End)
            {
                this.CustomerId = CustomerId;
                this.UserId = UserId;
                this.Type = Type;
                this.Start = Start;
                this.End = End;
                this.CreateDate = DateTime.UtcNow;
                this.CreatedBy = Database.loggedInUser.UserName;
                this.LastUpdate = DateTime.UtcNow;
                this.LastUpdateBy = Database.loggedInUser.UserName;
            }
        }

        private bool AppointmentInputValidation(AppointmentUserInput userInput)
        {
            // Check if any required field is null or empty
            if (string.IsNullOrEmpty(userInput.CustomerId)
                || string.IsNullOrEmpty(userInput.UserId)
                || string.IsNullOrEmpty(userInput.Type))
            {
                MessageBox.Show("Please provide all required information.");
                return false;
            }

            // Check if the Start and End times are reasonable
            if (userInput.Start >= userInput.End)
            {
                MessageBox.Show("Start time must be before end time.");
                return false;
            }

            // Check if the appointment is for a time in the past
            if (userInput.Start < DateTime.Now || userInput.End < DateTime.Now)
            {
                MessageBox.Show("Appointment times must be in the future.");
                return false;
            }

            return true;
        }

        public bool AppointmentValidation(Appointment newAppointment)
        {
            // Define business hours
            TimeSpan startBusinessHour = new TimeSpan(6, 0, 0);
            TimeSpan endBusinessHour = new TimeSpan(18, 0, 0);

            // Convert appointment times to local time
            DateTime localStartTime = newAppointment.Start;
            DateTime localEndTime = newAppointment.End;

            // Check if the appointment start time is earlier than the end time
            if (localStartTime >= localEndTime)
            {
                MessageBox.Show("The start time of the appointment must be earlier than the end time.");
                return false;
            }

            // Check if the appointment start and end times are within the business hours
            if ((localStartTime.TimeOfDay >= startBusinessHour && localStartTime.TimeOfDay < endBusinessHour) &&
                (localEndTime.TimeOfDay > startBusinessHour && localEndTime.TimeOfDay <= endBusinessHour))
            {
                List<Appointment> allAppointments = Database.GetAppointments();

                // Check for overlapping appointments
                foreach (var appointment in allAppointments)
                {
                    // Skip the check for the same appointment
                    if (appointment.AppointmentId == newAppointment.AppointmentId) continue;

                    if (appointment.Start < localEndTime && localStartTime < appointment.End)
                    {
                        // Show warning message
                        MessageBox.Show("The appointment overlaps with another one. Please choose a different time slot.");
                        return false;
                    }
                }

                return true;
            }

            MessageBox.Show("The appointment is not within the business hours (6 AM to 6 PM). Please choose a different time.");
            return false;
        }


        private void ScheduleButton_Click(object sender, EventArgs e)
        {
            
            
            if (_appointment != null)
            {

                // Update _appointment with the new data
                _appointment.CustomerId = int.Parse(CustomerIDTextBox.Text);
                _appointment.Type = AppointmentTypeTextbox.Text;
                _appointment.UserId = int.Parse(UserIdTextBox.Text);
                _appointment.Start = StartDatePicker.Value;
                _appointment.End = EndDatePicker.Value;
                _appointment.CreateDate = DateTime.UtcNow;
                _appointment.CreatedBy = Database.loggedInUser.UserName;
                _appointment.LastUpdate = DateTime.UtcNow;
                _appointment.LastUpdateBy = Database.loggedInUser.UserName;

                if (AppointmentValidation(_appointment))
                {
                    // Update the appointment in the database
                    Database.UpdateAppointment(_appointment);
                    this.Close();
                }
                else
                {
                    
                }



                
            }
            else
            {
                AppointmentUserInput userInput = new AppointmentUserInput(
                    CustomerIDTextBox.Text,
                    Database.loggedInUser.UserId.ToString(),
                    AppointmentTypeTextbox.Text,
                    StartDatePicker.Value,
                    EndDatePicker.Value
                    );

                // Validate user input
                if (!AppointmentInputValidation(userInput))
                {
                    // If input is invalid, return early
                    return;
                }

                // Convert UserInput to Appointment
                Appointment newAppointment = new Appointment
                {
                    CustomerId = int.Parse(userInput.CustomerId),  // Parse string to integer
                    UserId = int.Parse(userInput.UserId),          // Parse string to integer
                    Type = userInput.Type,
                    Start = userInput.Start,
                    End = userInput.End,
                    CreateDate = userInput.CreateDate,
                    CreatedBy = userInput.CreatedBy,
                    LastUpdate = userInput.LastUpdate,
                    LastUpdateBy = userInput.LastUpdateBy
                };

                if (AppointmentValidation(newAppointment))
                {
                    // Update the appointment in the database
                    Database.AddAppointment(newAppointment);
                    this.Close();
                }
                else
                {
                    
                }

                
            }
        }


    }
}
