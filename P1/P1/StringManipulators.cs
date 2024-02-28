using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1
{
    public partial class StringManipulators : Form
    {
        public StringManipulators()
        {
            InitializeComponent();
        }

        private void btnFullName_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text;
                string middleName = txtMiddleName.Text;
                string surName = txtSurName.Text;
                string fullName = firstName + " " + middleName + " " + surName;
                lblFullName.Text = fullName;
                lblUpperCase.Text = fullName.ToUpper();
                lblLowerCase.Text = fullName.ToLower();
       
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured! " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtSurName.Text = "";
            lblFullName.Text = "";
            lblUpperCase.Text = "";
            lblLowerCase.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
