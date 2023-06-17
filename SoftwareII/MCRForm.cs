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
    public partial class MCRForm : Form
    {
        public MCRForm()
        {
            
            InitializeComponent();
            List<Customer> customers = Database.GetCustomers();
            CustomersDataGridView.DataSource = customers;
        }

        private void MCRFormExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewRecordButton_Click(object sender, EventArgs e)
        {
            CustomersForm newform = new CustomersForm();
            newform.ShowDialog();
            List<Customer> customers = Database.GetCustomers();
            CustomersDataGridView.DataSource = customers;
        }

        private void UpdateRecordButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (CustomersDataGridView.CurrentRow != null)
            {
                // Get the selected customer
                Customer selectedCustomer = (Customer)CustomersDataGridView.CurrentRow.DataBoundItem;

                // Pass the selected customer to the CustomersForm
                CustomersForm newform = new CustomersForm(selectedCustomer);
                newform.ShowDialog();

                // Refresh the DataGridView
                List<Customer> customers = Database.GetCustomers();
                CustomersDataGridView.DataSource = customers;
            }
            else
            {
                MessageBox.Show("Please select a row in the data grid view");
            }
        }


        private void DeleteRecordButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the DataGridView
            if (CustomersDataGridView.CurrentRow != null)
            {
                // Get the selected customer
                Customer selectedCustomer = (Customer)CustomersDataGridView.CurrentRow.DataBoundItem;

                // Delete the selected customer
                Database.DeleteCustomer(selectedCustomer);
                List<Customer> customers = Database.GetCustomers();
                CustomersDataGridView.DataSource = customers;
            }
            else
            {
                MessageBox.Show("Please select a row in the data grid view");
            }
        }

    }
}
