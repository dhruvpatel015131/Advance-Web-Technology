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
    public partial class LeapYearCheck : Form
    {
        Check c = null;
        public LeapYearCheck()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                int year = Convert.ToInt32(txtYear.Text);
                c = new Check(year);
                lblCheckYear.Text = c.checkYear().ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception Occured! " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtYear.Text = "";
            lblCheckYear.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class Check
    {
        int Year;
        public Check() { }
        public Check(int Year)
        {
            this.Year = Year;
        }
        ~Check() { }

        public Boolean checkYear() {
         if((Year%4==0 && Year % 100 != 0) || (Year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
