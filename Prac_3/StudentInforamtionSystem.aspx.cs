using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac_3
{
    public partial class StudentInforamtionSystem : System.Web.UI.Page
    {
        // Connection string is initialized to null
        static string conStr = ConfigurationManager.ConnectionStrings["studConnString"].ToString();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DataTable dt = null;

        //clear data from textbox
        public void clearData()
        {
            txtRollNo.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtDisplay.Text = "";
        }
        // Method to display student information in the GridView
        public void showDisplay()
        {
            try
            {
                // Create a new SqlCommand to retrieve student information
                cmd = new SqlCommand("SELECT * FROM stud", conn);

                // Check if the connection is closed, if so open it
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Create a new DataTable to store the student information
                dt = new DataTable();

                // Load the student information into the DataTable
                dr = cmd.ExecuteReader();
                dt.Load(dr);

                // Set the GridView data source to the DataTable
                GVStudDetails.DataSource = dt;

                // Bind the data to the GridView
                GVStudDetails.DataBind();
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                lblMessage.Text = "Exception Occured! " + ex.Message;
            }
            finally
            {
                // Close the connection
                conn.Close();
            }
        }

        // Page load event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new SqlConnection using the connection string
            conn = new SqlConnection(conStr);

            // Call the showDisplay method to display student information
            showDisplay();
        }

        // Button click event handler to add a new student
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtRollNo.Text != ""&& txtName.Text !=""&& txtAddress.Text !="")
                {
                   // insert the new student information @rn is placeholder
                    cmd = new SqlCommand("INSERT INTO stud(rollno,name,address)VALUES(@rn,@nm,@add)",conn);
                    if(conn.State==ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Parameters.AddWithValue("@rn", txtRollNo.Text);
                    cmd.Parameters.AddWithValue("@nm", txtName.Text);
                    cmd.Parameters.AddWithValue("@add", txtAddress.Text);
                    int r = cmd.ExecuteNonQuery();
                    if(r !=0)
                    {
                        lblMessage.Text = r + " Data Inserted Sucessfully";

                    }
                    else
                    {
                        lblMessage.Text = "Record not Inserted";
                    }
                }
            }
            catch(Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                clearData();
                showDisplay();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRollNo.Text != "" && Convert.ToUInt16(txtRollNo.Text)>0)
                {
                    cmd = new SqlCommand("DELETE stud WHERE rollno=@rn ", conn);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    cmd.Parameters.AddWithValue("@rn", txtRollNo.Text);

                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        lblMessage.Text = r + " Data DELEED Sucessfully";

                    }
                    else
                    {
                        lblMessage.Text = "Record not DELETED ";
                    }
                } 
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                showDisplay();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRollNo.Text != "" && txtName.Text != "" && txtAddress.Text != "")
                {
                    cmd = new SqlCommand("UPDATE stud SET name=@nm,address=@add WHERE rollno=@rn", conn);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    cmd.Parameters.AddWithValue("@rn", txtRollNo.Text);
                    cmd.Parameters.AddWithValue("@nm", txtName.Text);
                    cmd.Parameters.AddWithValue("@add", txtAddress.Text);
                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        lblMessage.Text = r + " Data Updated Sucessfully";

                    }
                    else
                    {
                        lblMessage.Text = "Record not Inserted";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                clearData();
                showDisplay();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRollNo.Text != "")
                {
                    // insert the new student information @rn is placeholder
                    cmd = new SqlCommand("SELECT * FROM stud WHERE rollno=@rn", conn);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Parameters.AddWithValue("@rn", txtRollNo.Text);
                    dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        txtDisplay.Text = "Record Found";
                        txtRollNo.Text = dr[0].ToString();
                        txtName.Text = dr[1].ToString();
                        txtAddress.Text = dr[2].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                clearData();
            }
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt);
                //dv.Sort = txtDisplay.Text; // "rollno ASC"
                dv.RowFilter = txtDisplay.Text;// "address = 'Ratnagiri'"
                GVStudDetails.DataSource = dv;
                GVStudDetails.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                clearData();
            }
        }

        protected void btnStoredProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRollNo.Text != "" && txtName.Text != "" && txtAddress.Text != "")
                {
                    cmd = new SqlCommand();
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertData";
                    cmd.Parameters.Add(new SqlParameter("@Rollno", SqlDbType.SmallInt)).Value = Convert.ToInt16(txtRollNo.Text);
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)).Value = txtName.Text;
                    cmd.Parameters.Add(new SqlParameter("@Add", SqlDbType.VarChar)).Value = txtAddress.Text;

                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        lblMessage.Text = r + " Data Inserted Sucessfully";

                    }
                    else
                    {
                        lblMessage.Text = "Record not Inserted";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                clearData();
                showDisplay();
            }
        }

        protected void btnSearchStoredProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRollNo.Text != ""&& Convert.ToInt32(txtRollNo.Text)>0)
                {
                   
                    cmd = new SqlCommand();
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "selectData";
                    cmd.Parameters.Add(new SqlParameter("@Rollno", SqlDbType.SmallInt)).Value = Convert.ToInt16(txtRollNo.Text);
                    dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        txtDisplay.Text = "Record Found";
                        while (dr.Read())
                        {
                            txtRollNo.Text = dr[0].ToString();
                            txtName.Text = dr[1].ToString();
                            txtAddress.Text = dr[2].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                showDisplay();
            }
        }

        protected void btnDeleteStoredProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRollNo.Text != "" && Convert.ToUInt16(txtRollNo.Text) > 0)
                {
                    cmd = new SqlCommand();
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "deleteData";

                    cmd.Parameters.Add(new SqlParameter("@Rollno", SqlDbType.SmallInt)).Value = Convert.ToInt16(txtRollNo.Text);

                    int r = cmd.ExecuteNonQuery();
                    if (r != 0)
                    {
                        lblMessage.Text = r + " Data DELEED Sucessfully";

                    }
                    else
                    {
                        lblMessage.Text = "Record not DELETED ";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error Occured! " + ex.Message;
            }
            finally
            {
                conn.Close();
                showDisplay();
            }
        }
    }
}