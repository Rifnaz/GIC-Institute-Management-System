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
using System.Security.Policy;
using System.Xml.Linq;

namespace GIC_IMS.admin
{
    public partial class Inquiry_details : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadadmission();
            lblError.ForeColor = Color.Red;
        }

        private void loadadmission()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            try
            {
                //select command
                id = Convert.ToInt32(Request.QueryString["id"].ToString());

                SqlCommand cmd = new SqlCommand("SELECT * FROM contact WHERE ContactID ='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = dr.GetValue(1).ToString();
                    txtMail.Text = dr.GetValue(2).ToString();
                    txtPhone.Text = dr.GetValue(3).ToString();
                    txtMess.InnerText = dr.GetValue(4).ToString();

                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnSent_Click(object sender, EventArgs e)
        {
            String body = txtBody.InnerText;
            String subject = txtSbj.Text;
            String Email = txtMail.Text;

            // validation
            if (body == "" || subject == "")
            {
                lblError.Text = "These two fields are required..!";
            }

            else
            {
                try
                {

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
                    mail.Subject = subject;
                    mail.Body = body;

                    smtpClient.Send(mail);

                    //Updated successfully
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "Reply Sent..!";

                    con.Close();
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String Email = txtMail.Text;

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

            //Updated successfully
            lblError.Text = "Declined..!";

        }
    }
}