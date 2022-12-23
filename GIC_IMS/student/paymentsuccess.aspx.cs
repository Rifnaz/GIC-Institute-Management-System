using GIC_IMS.admin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace GIC_IMS.student
{
    public partial class paymentsuccess : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            addpayement();
            addstatus();
        }

        public void addpayement()
        {
            String AD = Session["AdmissionID"].ToString();
            String fee = Session["Fee"].ToString();
            String cour = Session["course"].ToString();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //insert command
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "insert into fee(AdmissionID, Fee, Course, status) values('" + AD + "', '"+fee+"', '" + cour + "', '" + "paid" + "')";
            cmd1.ExecuteNonQuery();

            con.Close();

        }

        public void addstatus()
        {
            String AD = Session["AdmissionID"].ToString();
            String fee = Session["Fee"].ToString();
            String cour = Session["course"].ToString();

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //insert command
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update admission set PaymentStatus ='"+"paid"+"' where AdmissionID ='"+AD+"' ";
            cmd1.ExecuteNonQuery();

            con.Close();

        }
    }
}