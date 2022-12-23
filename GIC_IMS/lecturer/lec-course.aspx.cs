using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIC_IMS.lecturer
{
    public partial class lec_course : System.Web.UI.Page
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
        }

        protected void dplsortBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sort = dplsortBatch.SelectedItem.ToString();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to selected batch dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select student.StudentID, student.FirstName, student.Image, admission.Applyfor, admission.Batch from admission join student on student.StudentID = admission.StudentID where Batch ='" + sort + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_Student.DataSource = dt;
            dtl_Student.DataBind();

            dplsortBatch.Items.Clear();
            fill_Dropdowns();

            con.Close();
        }

        private void fill_Dropdowns()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            String mail = Session["Email"].ToString();

            SqlCommand Com = new SqlCommand("select * from lecturer where Email='" + mail + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblcourse.Text = DR1.GetValue(6).ToString();
            }
            DR1.Close();

            // Fill Items to coodinator
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select BatchNo from batch where Course ='"+lblcourse.Text+"'", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplsortBatch.Items.Add(dr["BatchNo"].ToString());
            }

        }

        protected void lbtnRfresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl, true);
        }

        public void load_Batch()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            String mail = Session["Email"].ToString();

            SqlCommand Com = new SqlCommand("select * from lecturer where Email='" + mail + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblcourse.Text = DR1.GetValue(6).ToString();
            }
            DR1.Close();

            // Load loads to admission dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select student.StudentID, student.FirstName, student.Image, admission.Applyfor, admission.Batch from admission join student on student.StudentID = admission.StudentID where Applyfor ='" + lblcourse.Text+"'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_Student.DataSource = dt;
            dtl_Student.DataBind();

            con.Close();
        }
    }
}