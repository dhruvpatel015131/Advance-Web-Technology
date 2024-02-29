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
    public partial class DateAndTimeCalculation : Form
    {
        
        public DateAndTimeCalculation()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           try
            {
                DateTime dt = DateTime.Now;
                txtFullDateAndTime.Text = dt.ToString("f");
                txtLongDate.Text = dt.ToString("D");
                txtShortDate.Text = dt.ToString("d");
                txtGeneralDT.Text = dt.ToString("G");
                txtLongTime.Text = dt.ToString("T");
                txtShortTime.Text = dt.ToString("t");
                int daysInYear = DateTime.IsLeapYear(dt.Year) ? 365 : 66;
                txtDaysLeft.Text = (daysInYear - dt.DayOfYear).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured! " + ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
