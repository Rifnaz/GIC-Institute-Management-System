using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace GIC_IMS.admin
{
    public partial class admindash : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            fill_Count();
            load_Inquiry();
            get_chartdata();

        }

        public void fill_Count()
        {
            //pull the total students count
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from student", con);
            da.Fill(dt);
            lblstudent.InnerText = dt.Rows[0][0].ToString();

            //pull the total lecturers count
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select count(*) from lecturer", con);
            da2.Fill(dt2);
            lblLecturers.InnerText = dt2.Rows[0][0].ToString();

            //pull the total courses count
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(*) from course", con);
            da3.Fill(dt3);
            lblCourses.InnerText = dt3.Rows[0][0].ToString();

            //pull the total batches count
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("select count(*) from batch", con);
            da4.Fill(dt4);
            lblBatchs.InnerText = dt4.Rows[0][0].ToString();

            //pull the total inquries count
            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter("select count(*) from contact", con);
            da5.Fill(dt5);
            lblInquiries.InnerText = dt5.Rows[0][0].ToString();

            //pull the total admission count
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select count(*) from admission", con);
            da6.Fill(dt6);
            lblAdmission.InnerText = dt6.Rows[0][0].ToString();

            //pull the total pending count
            DataTable dt7 = new DataTable();
            SqlDataAdapter da7 = new SqlDataAdapter("select count(*) from admission where Batch = '"+ "pending" + "'", con);
            da7.Fill(dt7);
            lblPendingAdmission.InnerText = dt7.Rows[0][0].ToString();

            //pull the total income sum
            DataTable dt8 = new DataTable();
            SqlDataAdapter da8 = new SqlDataAdapter("select sum(Fee) as sum_Fee from fee", con);
            da8.Fill(dt8);
            lblIncome.InnerText = dt8.Rows[0][0].ToString();

        }
 

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            // delete button function
            string contactID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(contactID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from contact where ContactID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            fill_Count();
            load_Inquiry();
        }

        public void load_Inquiry()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to trophy dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from contact";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtlContact.DataSource = dt;
            dtlContact.DataBind();

            con.Close();
        }

        private void get_chartdata()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            Series series = Chart1.Series["Series1"];
            Series series2 = Chart2.Series["Series1"];
            con.Open();

            SqlCommand Com = new SqlCommand("SELECT Name, Fees FROM course", con);
            SqlDataReader DR = Com.ExecuteReader();
            while (DR.Read())
            {
                series.Points.AddXY(DR["Name"].ToString(), DR["Fees"]);
                series2.Points.AddXY(DR["Name"].ToString(), DR["Fees"]);
            }

            con.Close();
        }
    }
}