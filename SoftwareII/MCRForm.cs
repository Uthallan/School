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
        }

        private void MCRFormExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
