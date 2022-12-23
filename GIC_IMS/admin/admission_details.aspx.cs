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
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;

namespace GIC_IMS.admin
{
    public partial class admission_details : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            loadadmission();
            fill_Batchdropdown();
            lblError.ForeColor = Color.Red;

        }

        private void loadadmission()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand Com = new SqlCommand("SELECT student.Image, student.FirstName, student.LastName, student.Email, admission.PhoneNo, admission.Dob, admission.Gender, admission.Address, admission.City, admission.Qualification, admission.Applyfor, admission.Batch, admission.fee FROM admission JOIN student ON student.StudentID = admission.StudentID WHERE AdmissionID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                          
                lblname.Text = DR1.GetValue(1).ToString();
                lbllast.Text = DR1.GetValue(2).ToString();
                imgPopupdp.ImageUrl = DR1.GetValue(0).ToString();
                lblmail.Text = DR1.GetValue(3).ToString();
                lblPhone.Text = DR1.GetValue(4).ToString();
                lblDob.Text = DR1.GetValue(5).ToString();
                lblGender.Text = DR1.GetValue(6).ToString();
                lblAddress.Text = DR1.GetValue(7).ToString();
                lblCity.Text = DR1.GetValue(8).ToString();
                lblqual.Text = DR1.GetValue(9).ToString();
                lblApplyfor.Text = DR1.GetValue(10).ToString();
            }

            DR1.Close();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String name = lblname.Text;
            String Email = lblmail.Text;
            string batch = dplBatch.Text;
            if (batch == "")
            {
                lblError.Text = "Select the Batch";
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

                    //update command
                    string query = "UPDATE admission SET Batch = '" + batch + "' WHERE AdmissionID ='" + id + "' ";
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
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
                    mail.Subject = "Approved Admission Mail";
                    mail.Body = "Dear, "+name+" "+"\n \n Your Admission has been approved successfully..!\n You have been added to "+batch+ " by Admin. \n \n Thank you \n inforgic@outlook.com";

                    smtpClient.Send(mail);

                    //Updated successfully
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "Added Successfully";
                    dplBatch.Items.Clear();
                    fill_Batchdropdown();

                }

                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    dplBatch.Items.Clear();
                    fill_Batchdropdown();
                }
            }
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            String name = lblname.Text;
            String Email = lblmail.Text;

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from admission where AdmissionID ='" + id + "' ";
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
            mail.Subject = "Declined Admission Mail";
            mail.Body = "Dear, " + name + " " + "\n \n We are sorry to say this..! Your Admission has been Rejected by Admin..!\n Please kindly check whethere the details you have given was correct. or contact us..\n \n Thank you \n inforgic@outlook.com";

            smtpClient.Send(mail);

            dplBatch.Items.Clear();
            fill_Batchdropdown();

            //Updated successfully
            lblError.ForeColor = Color.Blue;
            lblError.Text = "Declined..!";

            con.Close();
        }
        

        private void fill_Batchdropdown()
        {
            String course = lblApplyfor.Text;
            // Fill Items to batch select combo
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select BatchNo from batch where Course= '"+course+"'", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplBatch.Items.Add(dr["BatchNo"].ToString());
            }
        }
    }
}