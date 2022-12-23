using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIC_IMS
{
    public partial class contact : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String name = txtName.Text;
            String email = txtMail.Text;
            String phone = txtPhone.Text;
            String mess = txtMess.InnerText;

            // validation
            if (name == "" || email == "" || phone == "" || mess == "")
            {
                lblError.Text = "All fields are required..!";
            }
          
            else
            {
                try
                {
                   
                    int Phone = int.Parse(txtPhone.Text);

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    //insert command
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "insert into contact(Name, Email, PhoneNo, Message) values('" + name + "', '" + email + "', '" + Phone + "', '" + mess + "')";
                    cmd1.ExecuteNonQuery();

                    //registered successfully
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "Message Sent Successfully";
                    
                    con.Close();
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
    }
}