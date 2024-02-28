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
    public partial class Inheritance : Form
    {
        Dog dd = new Dog();
        public Inheritance()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try {
                lblBase.Text = "";
                lblDerived.Text = "";
                lblBase.Text = dd.Eat();
                lblDerived.Text = dd.Bark();
            }
           catch(Exception ex)
            {
                MessageBox.Show("Exception Occured! " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class Animal
    {
        public string Eat()
        {
            return "Animals eat! ";
        }
    }
    class Dog : Animal
    {
        public string Bark()
        {
            return "The Dog is Barking ";
        }
    }
}
