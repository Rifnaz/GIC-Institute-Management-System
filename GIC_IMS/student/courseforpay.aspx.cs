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
    public partial class courseforpay : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_courseforpay();           
        }

        public void load_courseforpay()
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
            cmd.CommandText = "select * from admission where Email ='"+mail+ "' and Batch !='" + "pending" + "'";
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
                lblERRRRR.Text = "Admin should Assign a Batch for this to Make the payment..!";
            }

            con.Close();
        }
    }
}