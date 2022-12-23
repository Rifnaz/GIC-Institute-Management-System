using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIC_IMS.student
{
    public partial class courseforexam : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_courseforexam();
        }

        public void load_courseforexam()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            String mail = Session["Email"].ToString();

            // Load loads to student dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select admission.Applyfor, admission.Email, admission.Batch, course.CourseID from admission join course on admission.Applyfor = course.Name where Email ='" + mail + "' and Batch !='"+"pending"+"'";
            cmd.ExecuteNonQuery();
            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                DR1.Close();

                DataSet dt = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dtlcoursefee.DataSource = dt;
                dtlcoursefee.DataBind();
            }
            else
            {
                lblERRRRR.Text = "Admin should Assign a Batch for this to attend Exam..!";
            }
            con.Close();
        }
    }
}