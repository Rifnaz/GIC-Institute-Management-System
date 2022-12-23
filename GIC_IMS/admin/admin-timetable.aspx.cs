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

namespace GIC_IMS.admin
{
    public partial class timetable : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            load_timetable();
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
            cmd.CommandText = "select * from timetable where Course ='" + sort + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtlTimetable.DataSource = dt;
            dtlTimetable.DataBind();

            dplsortCourse.Items.Clear();
            fill_Dropdowns();

            con.Close();
        }

        protected void lbtnRfresh_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl, true);
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
            cmd.CommandText = "select * from timetable";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtlTimetable.DataSource = dt;
            dtlTimetable.DataBind();

            con.Close();
        }

        private void fill_Dropdowns()
        {
            // Fill Items to coodinator
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select Name from course", con);
            da1.Fill(dt1);

            foreach (DataRow dr1 in dt1.Rows)
            {
                dplsortCourse.Items.Add(dr1["Name"].ToString());
            }

        }
    }
}