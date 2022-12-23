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
using System.Reflection.Emit;

namespace GIC_IMS.admin
{
    public partial class admission : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            loadstudent();
            
        }

        private void loadstudent()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT student.FirstName, student.Image, admission.AdmissionID FROM admission JOIN student ON student.StudentID = admission.StudentID WHERE Batch='"+"pending"+"'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_admission.DataSource = dt;
            dtl_admission.DataBind();

        }

    }
}