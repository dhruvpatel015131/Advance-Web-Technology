using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1
{
    public partial class FrmEmp : Form
    {
        Employee employee = null;
        public FrmEmp()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtEmpID.Text);
                string name = txtEmpName.Text;
                employee = new Employee(id,name);
                MessageBox.Show("Object Created ");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sorry Exception Occured " + ex.Message);
            }
            finally
            {
                MessageBox.Show("Its Finally Block");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            lblEmpID.Text = employee.getId().ToString();
            lblEmpName.Text = employee.getName();
        }
    }
    class Employee
    {
        int id;
        string name;
        public Employee() { }
        public Employee(int id, string name) { 
            this.name = name;   
            this.id = id;   
        }
        ~Employee() { } 
        public int getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
    }
}
