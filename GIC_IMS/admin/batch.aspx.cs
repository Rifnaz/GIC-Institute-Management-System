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
using System.Xml.Linq;

namespace GIC_IMS.admin
{
    public partial class batch : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_Batch();
            fill_Dropdowns();
            lblError.Text = "";
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            lblError.ForeColor = Color.Red;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String batchno = txtBatchNum.Text;
            String course = dplCourse.Text;
            String start = txtStart.Text;
            String end = txtEnd.Text;
            String cood = dplcoodinator.SelectedValue;


            // validation
            if (batchno == "" || course == "" || start == "" || end == "" || cood == "")
            {
                lblError.Text = "All fields are required";
            }
            else
            {
                try
                {
                    //check if batch already exists
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from batch where BatchNo='" + batchno + "'";

                    //error message for exixting email
                    if (cmd.ExecuteReader().Read())
                    {
                        lblError.Text = "The Batch already exists";
                        emptyTextBox();
                        con.Close();
                    }

                    //insert and success message
                    else
                    {

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        //insert command
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into Batch(BatchNo, Course, StartDate, EndDate, Coodinator) values('" + batchno + "', '" + course + "', '" + start + "', '" + end + "', '"+cood+"')";
                        cmd1.ExecuteNonQuery();

                        //registered successfully
                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "Created Successfully";

                        load_Batch();
                        dplsortCourse.Items.Clear();
                        dplcoodinator.Items.Clear();
                        dplCourse.Items.Clear();
                        fill_Dropdowns();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String batchno = txtBatchNum.Text;
            String course = dplCourse.Text;
            String start = txtStart.Text;
            String end = txtEnd.Text;
            String cood = dplcoodinator.SelectedValue;


            // validation
            if (batchno == "" || course == "" || start == "" || end == "" || cood == "")
            {
                lblError.Text = "All fields are required";
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
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "UPDATE batch SET BatchNo ='" + batchno + "', Course ='" + course + "', StartDate ='" + start + "', EndDate ='" + end + "', Coodinator ='" + cood + "' WHERE BatchID ='"+id+"'";
                    cmd1.ExecuteNonQuery();

                    //registered successfully
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "Updated Successfully";

                    load_Batch();
                    dplsortCourse.Items.Clear();
                    dplcoodinator.Items.Clear();
                    dplCourse.Items.Clear();
                    fill_Dropdowns();
                    emptyTextBox();


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
            btnRegister.Visible = true;
            lblError.Text = "";
            emptyTextBox();

            dplsortCourse.Items.Clear();
            dplcoodinator.Items.Clear();
            dplCourse.Items.Clear();
            fill_Dropdowns();
        }



        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnRegister.Visible = false;

            dplsortCourse.Items.Clear();
            dplcoodinator.Items.Clear();
            dplCourse.Items.Clear();
            fill_Dropdowns();

            // edit button function
            string batchID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(batchID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from batch where BatchID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblID.Text = DR1.GetValue(0).ToString();
                txtBatchNum.Text = DR1.GetValue(1).ToString();
                dplCourse.Text = DR1.GetValue(2).ToString();
                txtStart.Text = DR1.GetValue(3).ToString();
                txtEnd.Text = DR1.GetValue(4).ToString();
                dplcoodinator.Text = DR1.GetValue(5).ToString();
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            // delete button function
            string batchID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(batchID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from batch where BatchID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            load_Batch();
            dplsortCourse.Items.Clear();
            dplcoodinator.Items.Clear();
            dplCourse.Items.Clear();
            fill_Dropdowns();

            lblError.Text = "Deleted Successfully";
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnRegister.Visible = true;
        }

        public void load_Batch()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to trophy dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from batch";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtlBatch.DataSource = dt;
            dtlBatch.DataBind();

            con.Close();
        }

        private void fill_Dropdowns()
        {
            // Fill Items to coodinator
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Name from lecturer", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplcoodinator.Items.Add(dr["Name"].ToString());
            }

            // Fill Items to coodinator
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select Name from course", con);
            da1.Fill(dt1);

            foreach (DataRow dr1 in dt1.Rows)
            {
                dplCourse.Items.Add(dr1["Name"].ToString());
                dplsortCourse.Items.Add(dr1["Name"].ToString());
            }

        }

        private void emptyTextBox()
        {
            txtBatchNum.Text = "";
            txtStart.Text = "";
            txtEnd.Text = "";
        }

        protected void dplsortCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sort = dplsortCourse.SelectedItem.ToString();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to selected batch dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from batch where Course ='" + sort + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtlBatch.DataSource = dt;
            dtlBatch.DataBind();

            dplsortCourse.Items.Clear();
            dplcoodinator.Items.Clear();
            dplCourse.Items.Clear();
            fill_Dropdowns();

            con.Close();
            
           
        }

        protected void lbtnRfresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl, true);
        }
    }
}