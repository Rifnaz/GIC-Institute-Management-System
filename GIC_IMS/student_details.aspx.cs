using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using GIC_IMS.student;

namespace GIC_IMS
{
    public partial class student_details : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int id;
        static string prevPage = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            loadadmission();
        }

        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        private void loadadmission()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand Com = new SqlCommand("SELECT student.Image, student.FirstName, student.LastName, student.Email, admission.PhoneNo, admission.Dob, admission.Gender, admission.Address, admission.City, admission.Qualification, admission.Applyfor, admission.Batch, admission.fee, admission.PaymentStatus FROM student JOIN admission ON admission.StudentID = student.StudentID WHERE student.StudentID ='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                imgPopupdp.ImageUrl = DR1.GetValue(0).ToString();
                lblname.Text = DR1.GetValue(1).ToString();
                lbllast.Text = DR1.GetValue(2).ToString();
                lblmail.Text = DR1.GetValue(3).ToString();
                lblPhone.Text = DR1.GetValue(4).ToString();
                lblDob.Text = DR1.GetValue(5).ToString();
                lblGender.Text = DR1.GetValue(6).ToString();
                lblAddress.Text = DR1.GetValue(7).ToString();
                lblCity.Text = DR1.GetValue(8).ToString();
                lblqual.Text = DR1.GetValue(9).ToString();

               
            }
            else
            {
                DR1.Close();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand Com1 = new SqlCommand("SELECT * FROM student WHERE StudentID ='" + id + "'", con);
                SqlDataReader DR2 = Com1.ExecuteReader();
                if (DR2.Read())
                {
                    imgPopupdp.ImageUrl = DR2.GetValue(4).ToString();
                    lblname.Text = DR2.GetValue(1).ToString();
                    lbllast.Text = DR2.GetValue(2).ToString();
                    lblmail.Text = DR2.GetValue(3).ToString();
                }
                con.Close();

            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(dt);
            dtl_Course.DataSource = dt;
            dtl_Course.DataBind();
        }
        
    }
}