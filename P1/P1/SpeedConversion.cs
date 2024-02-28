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
    public partial class SpeedConversion : Form
    {
        Conversion c = null;
        public SpeedConversion()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKnots.Text = "";
            lblKph.Text = "";
            lblMph.Text = "";

                
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                double knotsConversion = Convert.ToDouble(txtKnots.Text);
                c = new Conversion(knotsConversion);
                lblKph.Text = c.getKph().ToString();
                lblMph.Text = c.getMph().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception Occured! " + ex.Message);
            }
        }
    }
    class Conversion
    {
        double knots;
        public Conversion() { }
        public Conversion(double knots)
        {
            this.knots = knots;
        }
        ~Conversion() { }

        public double getMph()
        {
            return knots * 1.15078;
        }

        public double getKph()
        {
            return knots * 1.852;
        }
    }
}
