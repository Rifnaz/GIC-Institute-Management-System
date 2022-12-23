using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIC_IMS.admin
{
    public partial class courses : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_Course();
            fill_Lecturedropdown();
            lblError.Text = "";
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            lblError.ForeColor = Color.Red;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            createCourse();
        }

        private void createCourse()
        {
            //Declare Varriable
            String name = txtName.Text;
            String semi = txtSemi.Text;
            String fee = txtFee.Text;
            String lecturer = dplLecturer.SelectedValue;

            // validation
            if (name == "" || semi == "" || fee == "" || lecturer == "")
            {
                lblError.Text = "All fields are required";
            }
            else
            {
                try
                {
                    //check if student already exists
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from course where Name='" + name + "'";

                    //error message for exixting email
                    if (cmd.ExecuteReader().Read())
                    {
                        lblError.Text = "The Course already exists";
                        emptyTextBox();
                        con.Close();
                    }

                    //insert and success message
                    else
                    {
                        int Semi = int.Parse(txtSemi.Text);
                        int Fee = int.Parse(txtFee.Text);

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        //insert command
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into course(Name, Semester, Fees, Lecturer) values('" + name + "', '" + Semi + "', '" + Fee + "', '" + lecturer + "')";
                        cmd1.ExecuteNonQuery();

                        SqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "UPDATE lecturer SET Course ='" + name + "' WHERE Name ='" + lecturer + "'";
                        cmd2.ExecuteNonQuery();

                        //registered successfully
                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "Created Successfully";

                        load_Course();
                        dplLecturer.Items.Clear();
                        fill_Lecturedropdown();
                        emptyTextBox();
                    }
                    con.Close();


                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        private void emptyTextBox()
        {
            txtName.Text = "";
            txtSemi.Text = "";
            txtFee.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String name = txtName.Text;
            String semi = txtSemi.Text;
            String fee = txtFee.Text;
            String lecturer = dplLecturer.SelectedValue;

            // validation
            if (name == "" || semi == "" || fee == "" || lecturer == "")
            {
                lblError.Text = "All fields are required";
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnRegister.Visible = false;
            }
            else
            {
                try
                {
                    int id = int.Parse(lblID.Text);
                    int Semi = int.Parse(txtSemi.Text);
                    int Fee = int.Parse(txtFee.Text);

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    //insert command
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "UPDATE course SET Name ='" + name + "', Semester ='" + Semi + "', Fees = '" + Fee + "', Lecturer = '" + lecturer + "' WHERE CourseID ='"+id+"'";
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "UPDATE lecturer SET Course ='" + name + "' WHERE Name ='" + lecturer + "'";
                    cmd2.ExecuteNonQuery();

                    //registered successfully
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "Updated Successfully";

                    load_Course();
                    dplLecturer.Items.Clear();
                    fill_Lecturedropdown();
                    emptyTextBox();
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                    btnRegister.Visible = false;

                    con.Close();


                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                    btnRegister.Visible = false;

                }
            }
        }

        private void fill_Lecturedropdown()
        {
            // Fill Items to Loadid select combo
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Name from lecturer", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplLecturer.Items.Add(dr["Name"].ToString());
            }
        }

        public void load_Course()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to trophy dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from course";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtlCourse.DataSource = dt;
            dtlCourse.DataBind();

            con.Close();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnRegister.Visible = true;
            lblError.Text = "";
            emptyTextBox();

            dplLecturer.Items.Clear();
            fill_Lecturedropdown();
        }

        protected void lbtnEdit_Click1(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnRegister.Visible = false;
            dplLecturer.Items.Clear();
            fill_Lecturedropdown();

            // edit button function
            string courseID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(courseID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from course where CourseID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblID.Text = DR1.GetValue(0).ToString();
                txtName.Text = DR1.GetValue(1).ToString();
                txtSemi.Text = DR1.GetValue(2).ToString();
                txtFee.Text = DR1.GetValue(3).ToString();
                dplLecturer.Text = DR1.GetValue(4).ToString();
            }
        }

        protected void lbtnDelete_Click1(object sender, EventArgs e)
        {
            // delete button function
            string courseID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(courseID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from course where CourseID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            load_Course();
            dplLecturer.Items.Clear();
            fill_Lecturedropdown();
            lblError.Text = "Deleted Successfully";
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnRegister.Visible = true;
        }
    }
}