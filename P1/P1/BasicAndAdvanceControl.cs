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
    public partial class BasicAndAdvanceControl : Form
    {
        public BasicAndAdvanceControl()
        {
            InitializeComponent();
        }

       

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                BasicAndAdvanceControl2 b1 = new BasicAndAdvanceControl2();
                b1.fname = txtFirstName.Text;
                b1.mname = txtMiddleName.Text;
                b1.sname = txtSurname.Text;
                b1.dob = dtDob.SelectionStart.ToString();
                b1.address = txtAddress.Text;
                b1.mobileNumber = Convert.ToInt64(txtMobileNumber.Text);
                b1.userName = txtUsername.Text;
                b1.password = txtPassword.Text;
                b1.gender = (rbnMale.Checked) ? "Male" : "Female";
                b1.hobbie = txtHobbie.Text;
                b1.city = txtCity.Text;
                b1.img = pictureBox1.Image;
                b1.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured! " + ex.Message);
            }
           



        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
                if(dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }
                


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured! " + ex.Message);
            }
        }
    }
}
