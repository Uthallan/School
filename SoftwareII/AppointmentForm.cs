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
        public AppointmentForm()
        {
            InitializeComponent();
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
    }
}
