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

namespace GIC_IMS.student
{
    public partial class stn_tutorial : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_tutorial();
        }

        public void load_tutorial()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            String mail = Session["Email"].ToString();

            SqlCommand Com = new SqlCommand("select * from admission where Email='" + mail + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblcourse.Text = DR1.GetValue(9).ToString();
            }
            DR1.Close();

            // Load loads to trophy dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tutorial where course = '" + lblcourse.Text + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_exam.DataSource = dt;
            dtl_exam.DataBind();

            con.Close();
        }
    }
}