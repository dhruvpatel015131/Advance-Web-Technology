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
    public partial class SalaryCalculation : Form
    {
        Emp emp = null;
        public SalaryCalculation()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);
                string name = txtName.Text;
                string designation = txtDesignation.Text;
                string department = txtDepartment.Text;
                int salary = Convert.ToInt32(txtBasicSalary.Text);

                emp = new Emp(id, name,designation, department,salary);
                lblTotalSalary.Text = emp.calSalary().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occured! " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtDesignation.Text = "";
            txtDepartment.Text = "";
            txtBasicSalary.Text = "";
            lblTotalSalary.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class Emp
    {
        int id,salary;
        string name, designation, department;

        public Emp(int id, string name,string designation,string department,int salary)
        {
            this.id = id;
            this.name = name;
            this.designation = designation;
            this.department = department;
            this.salary = salary;
        }
        ~Emp() { }
        public int getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public string getDesignation()
        {
            return designation;
        }
        public string  getDepartment()
        {
            return department;
        }
        public int getSalary()
        {
            return salary;
        }
        public double calSalary()
        {
            return (salary + (salary * 0.8) + (salary * 0.1)) - (2000 + 250);
        }
    }        
}
