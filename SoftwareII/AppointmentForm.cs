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
                UserIdTestBox.Text = appointment.UserId.ToString();

                List<Customer> customerList = Database.GetCustomers();

                // Find the customer with the matching ID
                Customer selectedCustomer = customerList.FirstOrDefault(c => c.CustomerId == appointment.CustomerId);

                if (selectedCustomer != null)
                {
                    // Update the textbox with the customer's name
                    CustomerNameTextBox.Text = selectedCustomer.CustomerName;
                }
                else
                {
                    // Show a message if no customer was found with the selected ID
                    MessageBox.Show($"No customer was found with ID {appointment.CustomerId}.");
                }

                _appointment = appointment;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (userInput.Start < DateTime.UtcNow || userInput.End < DateTime.UtcNow)
            {
                MessageBox.Show("Appointment times must be in the future.");
                return false;
            }

            return true;
        }

        private void ScheduleButton_Click(object sender, EventArgs e)
        {
            if (_appointment != null)
            {
                // Update _appointment with the new data
                _appointment.CustomerId = int.Parse(CustomerIDTextBox.Text);
                _appointment.Type = AppointmentTypeTextbox.Text;
                _appointment.UserId = int.Parse(UserIdTestBox.Text);
                _appointment.Start = StartDatePicker.Value;
                _appointment.End = EndDatePicker.Value;
                _appointment.CreateDate = DateTime.UtcNow;
                _appointment.CreatedBy = Database.loggedInUser.UserName;
                _appointment.LastUpdate = DateTime.UtcNow;
                _appointment.LastUpdateBy = Database.loggedInUser.UserName;
               

                // Update the appointment in the database
                Database.UpdateAppointment(_appointment);
                this.Close();
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

                // Add newAppointment to the database
                Database.AddAppointment(newAppointment);
                this.Close();
            }
        }


    }
}
