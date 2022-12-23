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
using System.Web.UI.DataVisualization.Charting;

namespace GIC_IMS.lecturer
{
    public partial class lecturerdash : System.Web.UI.Page
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
            get_chartdata();
        }

        public void fill_Count()
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

            //pull the total students count
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from admission where Applyfor ='"+lblcourse.Text+"'", con);
            da.Fill(dt);
            lblstudent.InnerText = dt.Rows[0][0].ToString();

            //pull the total lecturers count
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select count(*) from batch where Course ='"+lblcourse.Text+"'", con);
            da2.Fill(dt2);
            lblBatches.InnerText = dt2.Rows[0][0].ToString();

            //pull the total courses count
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select count(*) from exam where Course ='"+lblcourse.Text+"'", con);
            da3.Fill(dt3);
            lblQuizzes.InnerText = dt3.Rows[0][0].ToString();

            //pull the total batches count
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("select count(*) from tutorial where Course ='"+lblcourse.Text+"'", con);
            da4.Fill(dt4);
            lblTutorials.InnerText = dt4.Rows[0][0].ToString();

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