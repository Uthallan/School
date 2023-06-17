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
    public partial class CustomersForm : Form
    {
        private Customer _customer;
        public CustomersForm(Customer customer = null)
        {
            InitializeComponent();

            if (customer != null)
            {
                CustomerNameTextBox.Text = customer.CustomerName;
                CustomerAddressOneTextBox.Text = customer.Address;
                CustomerAddressTwoTextBox.Text = customer.Address2;
                CustomerCityTextBox.Text = customer.City;
                CustomerPostTextBox.Text = customer.PostalCode;
                CustomerPhoneTextBox.Text = customer.Phone;
                CustomerCountryTextBox.Text = customer.Country;

                _customer = customer;
            }

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class UserInput
        {
            public string Name { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }
            public string Phone { get; set; }
            public string Country { get; set; }

            public UserInput(string Name, string Address1, string Address2, string City, string PostCode, string Phone, string Country)
            {
                this.Name = Name;
                this.Address1 = Address1;
                this.Address2 = Address2;
                this.City = City;
                this.PostCode = PostCode;
                this.Phone = Phone;
                this.Country = Country;
            }
        }

        private bool CustomerInputValidation(UserInput userInput)
        {
            // Check if any required field is null or empty
            if (string.IsNullOrEmpty(userInput.Name)
                || string.IsNullOrEmpty(userInput.Address1)
                || string.IsNullOrEmpty(userInput.City)
                || string.IsNullOrEmpty(userInput.PostCode)
                || string.IsNullOrEmpty(userInput.Phone)
                || string.IsNullOrEmpty(userInput.Country))
            {
                MessageBox.Show("Please provide all required information.");
                return false;
            }

            // Address2 can be empty but not null
            if (userInput.Address2 == null)
            {
                MessageBox.Show("Address2 cannot be null.");
                return false;
            }

            // Validate that all fields have an appropriate length
            if (userInput.Name.Length > 45
                || userInput.Address1.Length > 50
                || userInput.Address2.Length > 50
                || userInput.City.Length > 50
                || userInput.PostCode.Length > 10
                || userInput.Phone.Length > 20
                || userInput.Country.Length > 50)
            {
                MessageBox.Show("One or more input fields exceed their maximum length.");
                return false;
            }

            // Check if the PostalCode and Phone number fields are numeric
            if (!int.TryParse(userInput.PostCode, out _))
            {
                MessageBox.Show("Postal Code must be numeric.");
                return false;
            }

            // Removing any hyphen from phone number before checking if it's numeric
            var phone = userInput.Phone.Replace("-", "");
            if (!long.TryParse(phone, out _))
            {
                MessageBox.Show("Phone number must be numeric.");
                return false;
            }

            return true;
        }





        private void Addcustomerbutton_Click(object sender, EventArgs e)
        {
            try
            {

                if (_customer != null)
                {
                    // Update _customer with the new data
                    _customer.CustomerName = CustomerNameTextBox.Text;
                    _customer.Address = CustomerAddressOneTextBox.Text;
                    _customer.Address2 = CustomerAddressTwoTextBox.Text;
                    _customer.City = CustomerCityTextBox.Text;
                    _customer.PostalCode = CustomerPostTextBox.Text;
                    _customer.Phone = CustomerPhoneTextBox.Text;
                    _customer.Country = CustomerCountryTextBox.Text;

                    // Update the customer in the database
                    Database.UpdateCustomer(_customer);
                    this.Close();
                }
                else
                {
                    UserInput userInput = new UserInput(
                    CustomerNameTextBox.Text,
                    CustomerAddressOneTextBox.Text,
                    CustomerAddressTwoTextBox.Text,
                    CustomerCityTextBox.Text,
                    CustomerPostTextBox.Text,
                    CustomerPhoneTextBox.Text,
                    CustomerCountryTextBox.Text
                );

                    // Validate user input
                    if (!CustomerInputValidation(userInput))
                    {
                        //MessageBox.Show("Could not add customer, some fields not filled in.");
                        return;
                    }

                    // Convert UserInput to Customer
                    Customer newCustomer = new Customer
                    {
                        CustomerName = userInput.Name,
                        Address = userInput.Address1,
                        Address2 = userInput.Address2,
                        City = userInput.City,
                        PostalCode = userInput.PostCode,
                        Phone = userInput.Phone,
                        Country = userInput.Country,
                        Active = 1
                    };

                    // Add newCustomer to the database
                    Database.AddCustomer(newCustomer);
                    this.Close();
                }

                
            }
            catch
            {
                MessageBox.Show("Could not add customer");
            }
        }


    }
}
