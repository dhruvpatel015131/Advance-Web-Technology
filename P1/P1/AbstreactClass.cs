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
    public partial class AbstractClass : Form
    {
        Sum s = null;
        public AbstractClass()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(txtNum1.Text);
                int num2 = Convert.ToInt32(txtNum2.Text);
                s = new Sum(num1, num2);
                lblAddition.Text = s.Add().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception Occured! " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNum1.Text = "";
            txtNum2.Text = "";
            lblAddition.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    abstract class Additon
    {
        public abstract int Add();
    }
    class Sum : Additon
    {
        private int num1, num2;
        public Sum() { }
        public Sum(int num1,int num2) {
            this.num1 = num1;
            this.num2 = num2;
        }
        ~Sum() { }
        public override int Add()
        {
            return num1 + num2;
        }

    }

}
