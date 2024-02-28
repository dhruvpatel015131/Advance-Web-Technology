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
    public partial class Indexer : Form
    {
        Indexers i = null;
        public Indexer()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                i = new Indexers();
                i[0] = txtVal1.Text;
                i[1] = txtVal2.Text;
                i[2] = txtVal3.Text;



                lblIndex0.Text = i[0];
                lblIndex1.Text = i[1];
                lblIndex2.Text = i[2];

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured! " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVal1.Text = "";
            txtVal2.Text = "";
            txtVal3.Text = "";
            lblIndex0.Text = "";
            lblIndex1.Text = "";
            lblIndex2.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class Indexers
    {
        private string[] names = new string[3];
        public string this[int i]
        {
            get
            {
                return names[i];
            }
            set
            {
                names[i] = value;
            }
        }
    }
}
