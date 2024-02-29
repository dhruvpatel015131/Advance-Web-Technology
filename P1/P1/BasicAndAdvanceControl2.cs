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
    public partial class BasicAndAdvanceControl2 : Form
    {
        public string fname { get; set; }
        public string mname { get; set; }
        public string sname { get; set; }
        public string dob { get; set; }
        public string address { get; set; }
        public long mobileNumber { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string hobbie { get; set; }
        public string city { get; set; }
        public Image img { get; set; }


        public BasicAndAdvanceControl2()
        {
            InitializeComponent();
        }

        private void BasicAndAdvanceControl2_Load(object sender, EventArgs e)
        {
            try
            {

                lblFirstName.Text = fname;
                lblMiddleName.Text = mname;
                lblSurname.Text = sname;
                lblDOB.Text = dob;
                lblAddress.Text = address;
                lblMobileNumber.Text = mobileNumber.ToString();
                lblUsername.Text = userName;
                lblPassword.Text = password;
                lblGender.Text = gender;
                lblHobbie.Text = hobbie;
                lblCity.Text = city;
                pictureBox1.Image = img;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured! " + ex.Message);
            }

        }
    }
}
