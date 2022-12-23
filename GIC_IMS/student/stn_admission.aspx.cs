using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GIC_IMS.student
{
    public partial class stn_admission : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_Admissionapplyfor();
            lblError.Text = "";
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            lblError.ForeColor = Color.Red;
            fill_coursedropdown();
            load_Student();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String phone = txtPhone.Text;
            String dob = txtDOB.Text;
            String city = txtCity.Text;
            String address = txtAddress.InnerText;
            String gender = dplGender.SelectedValue;
            String qual = dplQualification.SelectedValue;
            String apply = dplApply.SelectedValue;
            int id = int.Parse(lblID.Text);
            String mail = lblEmail.Text;
            String fee = lbldpcours.Text;


            // validation
            if (phone == "" || dob == "" || city == "" || address == "" || gender == "" || qual == "" || apply == "")
            {
                lblError.Text = "All fields are required";
            }
            if (txtPhone.Text.Length > 7 && txtPhone.Text.Length <3)
            {
                lblError.Text = "The Phone number should be 7 nubers Maximum and 3 numbers minium";
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
                    cmd.CommandText = "select * from admission where StudentID='" + id + "' and Applyfor ='"+apply+"'";

                    //error message for exixting email
                    if (cmd.ExecuteReader().Read())
                    {
                        lblError.Text = "You have already applied for this course";
                        emptyTextBox();
                        con.Close();
                    }

                    //insert and success message
                    else
                    {
                        int PhoneNo = int.Parse(txtPhone.Text);

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        //insert command
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into admission(StudentID, Email, PhoneNo, Dob, Gender, Address, City, Qualification, Applyfor, Batch, fee, PaymentStatus) values('" + id + "', '" + mail + "', '" + PhoneNo + "', '" + dob + "', '"+gender+"', '"+address+"', '"+city+"', '"+qual+"', '"+apply+"', '"+"pending"+"','"+fee+"', '"+"pending"+"')";
                        cmd1.ExecuteNonQuery();

                        //registered successfully
                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "Created Successfully";

                        load_Admissionapplyfor();
                        dplApply.Items.Clear();
                        fill_coursedropdown();
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

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnSubmit.Visible = true;

            dplApply.Items.Clear();
            fill_coursedropdown();
            lblError.Text = "";
            emptyTextBox();
        }

        public void load_Admissionapplyfor()
        {
            String mail = Session["Email"].ToString();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to trophy dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from admission where Email ='"+mail+"'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_applyfor.DataSource = dt;
            dtl_applyfor.DataBind();

            con.Close();
        }

        private void emptyTextBox()
        {
            txtPhone.Text = "";
            txtDOB.Text = "";
            txtCity.Text = "";
            txtAddress.InnerText = "";
        }

        private void fill_coursedropdown()
        {
            // Fill Items to Loadid select combo
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Name from course", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplApply.Items.Add(dr["Name"].ToString());
            }
        }

        protected void dplApply_SelectedIndexChanged(object sender, EventArgs e)
        {
            String fee = dplApply.SelectedValue;

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from course where Name='" + fee + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lbldpcours.Text = DR1.GetValue(3).ToString();
            }
        }

        public void load_Student()
        {
            String mail = Session["Email"].ToString();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from student where Email='" + mail + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblID.Text = DR1.GetValue(0).ToString();
                lblEmail.Text = DR1.GetValue(3).ToString();
                lblname.Text = DR1.GetValue(1).ToString();
                imgdp.ImageUrl = DR1.GetValue(4).ToString();
            }
        }
    }
}