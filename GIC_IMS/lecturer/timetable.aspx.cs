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

namespace GIC_IMS.lecturer
{
    public partial class timetable : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_timetable();
            fill_Dropdowns();
            lblError.Text = "";
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            lblError.ForeColor = Color.Red;
        }

        public void load_timetable()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to student dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select timetable.TimetableID, course.Lecturer, timetable.Course, timetable.Batch, timetable.Subject, timetable.Sun, timetable.Mon, timetable.Tue, timetable.Wed, timetable.Thu, timetable.Fri, timetable.Sat from timetable join course on timetable.Course = course.Name";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtlTimetable.DataSource = dt;
            dtlTimetable.DataBind();

            con.Close();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String course = dplCourse.SelectedValue;
            String batch = dplBatch.SelectedValue;
            String subject = txtsub.Text;
            String sun = txtSun.Text;
            String mon = txtMon.Text;
            String tue = txtTue.Text;
            String wed = txtWed.Text;
            String thu = txtThu.Text;
            String fri = txtFri.Text;
            String sat = txtSat.Text;

            // validation
            if (course == "" || batch == "" || subject == "")
            {
                lblError.Text = "First 3 fields are required..!";
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
                    cmd.CommandText = "select * from timetable where Subject='" + subject + "'";

                    //error message for exixting email
                    if (cmd.ExecuteReader().Read())
                    {
                        lblError.Text = "Timetable with this Subject already exists";
                        emptyTextBox();
                        con.Close();
                    }


                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    //insert command

                    string query = "insert into timetable(Course, Subject, Batch, Sun, Mon, Tue, Wed, Thu, Fri, Sat) values('" + course + "', '" + subject + "', '" + batch + "', '" + sun + "', '" + mon + "', '" + tue + "', '" + wed + "', '" + thu + "', '" + fri + "', '" + sat + "')";
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = query;
                    cmd1.ExecuteNonQuery();

                    //registered successfully
                    load_timetable();
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "Created Successfully";
                    emptyTextBox();

                    dplBatch.Items.Clear();
                    dplCourse.Items.Clear();
                    fill_Dropdowns();

                    con.Close();


                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String course = dplCourse.SelectedValue;
            String batch = dplBatch.SelectedValue;
            String subject = txtsub.Text;
            String sun = txtSun.Text;
            String mon = txtMon.Text;
            String tue = txtTue.Text;
            String wed = txtWed.Text;
            String thu = txtThu.Text;
            String fri = txtFri.Text;
            String sat = txtSat.Text;

            // validation
            if (course == "" || batch == "" || subject == "")
            {
                lblError.Text = "First 3 fields are required..!";
            }

            else
            {
                try
                {
                    int id = int.Parse(lblID.Text);

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    //insert command

                    string query = "update timetable set Course ='" + course + "', Subject ='" + subject + "', Batch ='" + batch + "', '" + sun + "', '" + mon + "', '" + tue + "', '" + wed + "', '" + thu + "', '" + fri + "', '" + sat + "' where TimetableID ='"+id+"'";
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = query;
                    cmd1.ExecuteNonQuery();

                    //registered successfully
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "Update Successfully";
                    emptyTextBox();

                    load_timetable();
                    dplBatch.Items.Clear();
                    dplCourse.Items.Clear();
                    fill_Dropdowns();

                    con.Close();


                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnCreate.Visible = true;
            lblError.Text = "";
            emptyTextBox();

            dplBatch.Items.Clear();
            dplCourse.Items.Clear();
            fill_Dropdowns();
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnCreate.Visible = false;

            dplBatch.Items.Clear();
            dplCourse.Items.Clear();
            fill_Dropdowns();

            // edit button function
            string timetableID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(timetableID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from timetable where TimetableID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblID.Text = DR1.GetValue(0).ToString();
                dplCourse.Text = DR1.GetValue(1).ToString();
                dplBatch.Text = DR1.GetValue(3).ToString();
                txtsub.Text = DR1.GetValue(2).ToString();
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {

            // delete button function
            string timetableID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(timetableID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from timetable where TimetableID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            load_timetable();
            dplBatch.Items.Clear();
            dplCourse.Items.Clear();
            fill_Dropdowns();

            lblError.Text = "Deleted Successfully";
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnCreate.Visible = true;
        }

        private void emptyTextBox()
        {

        }

        private void fill_Dropdowns()
        {
            // Fill Items to coodinator
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Name from course", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplCourse.Items.Add(dr["Name"].ToString());
            }

            // Fill Items to coodinator
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select batchNo from batch", con);
            da1.Fill(dt1);

            foreach (DataRow dr1 in dt1.Rows)
            {
                dplBatch.Items.Add(dr1["BatchNo"].ToString());
            }
        }
    }
}