using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Configuration;

namespace GIC_IMS
{
    public partial class forgot_password : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        string userType;
        string randomNo;

        static string prevPage = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
                Random rnd = new Random();
                randomNo = (rnd.Next(100000, 999999)).ToString();

                Label1.Text = randomNo;
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            lblEmailError.Text = "";
            lblCodelError.Text = "";
            lblCodelError.ForeColor = Color.Red;
            lblEmailError.ForeColor = Color.Red;
        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Label2.Text = Label1.Text;
            String Email = txtMail.Text;

            if (Email == "")
            {
                lblEmailError.Text = "Please Enter your Email";
            }
            else
            {

                //mail send
                string username = "danonymous4436@gmail.com";
                string password = "crppbsoqznyntqza";
                ICredentialsByHost credentials = new NetworkCredential(username, password);

                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = credentials
                };

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(username);
                mail.To.Add(Email);
                mail.Subject = "Password Reset Verification";
                mail.Body = "Your Verification Code here..\n" +Label1.Text+ "\n\nGlobal International College \nhanifarifnazz@gmail.com.";
                smtpClient.Send(mail);

                lblEmailError.ForeColor = Color.Blue;
                lblEmailError.Text = "Verification Code Sent Successfully";

                LabelEmail.Text = txtMail.Text;
            }
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {

            String code = txtCode.Text;

            if(code == "")
            {
                lblCodelError.Text = "Please Enter the Verification Code";
            }

            if (code == Label2.Text)
            {
                Response.Redirect("reset-password.aspx?usertype="+ Request.QueryString["usertype"].ToString()+"&email="+LabelEmail.Text+"&code="+Label2.Text);
            }
            else
            {
                lblCodelError.Text = "Please Enter the Correct Verification Code we've sent..!";
            }
        }
    }
}