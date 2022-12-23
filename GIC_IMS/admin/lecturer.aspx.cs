using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace GIC_IMS.admin
{
    public partial class Lecturer : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_lecturer();
            lblError.Text = "";
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            lblError.ForeColor = Color.Red;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String name = txtFname.Text;
            String Email = txtEmail.Text;
            String phone = txtPhone.Text;
            String pass = txtPass.Text;
            String conpass = txtConpass.Text;
            String qual = dplQual.SelectedValue;
            String field = txtField.Text;

            // validation
            if (name == "" || Email == "" || phone == "" || pass == "" || conpass == "" || qual == "" || field == "")
            {
                lblError.Text = "All fields are required..!";
            }
            if (pass != conpass)
            {
                lblError.Text = "Password does not match..!";
                txtPass.Text = "";
                txtConpass.Text = "";
            }
            else
            {
                try
                {
                    //check if lecturer already exists
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from lecturer where Email='" + Email + "'";

                    //error message for exixting email
                    if (cmd.ExecuteReader().Read())
                    {
                        lblError.Text = "The Lecturer with this Email already exist..!";
                        emptyTextBox();
                        con.Close();
                    }

                    //insert and success message
                    else
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
                        cmd1.CommandText = "insert into lecturer(Name, Email, Qualification, Field, PhoneNo, Password) values('" + name + "', '" + Email + "', '" + qual + "', '" + field + "', ' "+Phone+" ',' " +pass+ " ')";
                        cmd1.ExecuteNonQuery();

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
                        mail.Subject = "GIC Account Creation Mail";
                        mail.Body = "Mr/Ms, " + name + " " + "\n\nYour GIC Account has been Created successfully..!\nYou can login to the system using provided Email and Password below.\n\nEmail- " + Email + "\nPassword-"+pass+" \n\nThank you \n\nRifnaz Hanifa \nHead of IT faculty \nGlobal International College \nhanifarifnazz@gmail.com.";

                        smtpClient.Send(mail);

                        //registered successfully
                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "Registered Successfully";

                        load_lecturer();
                        emptyTextBox();
                    }
                    con.Close();


                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String name = txtFname.Text;
            String mail = txtEmail.Text;
            String phone = txtPhone.Text;
            String pass = txtPass.Text;
            String conpass = txtConpass.Text;
            String qual = dplQual.SelectedValue;
            String field = txtField.Text;

            // validation
            if (name == "" || mail == "" || phone == "" || pass == "" || conpass == "" || qual == "" || field == "")
            {
                lblError.Text = "All fields are required..!";
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnRegister.Visible = false;
            }
            if (pass != conpass)
            {
                lblError.Text = "Password does not match..!";
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnRegister.Visible = false;
            }
            else
            {
                try
                {
                    int id = int.Parse(lblID.Text);
                    int Phone = int.Parse(txtPhone.Text);

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();

                    //insert command
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "UPDATE lecturer SET Name ='" + name + "', Email = '" + mail + "', Qualification = '" + qual + "', Field = '" + field + "', PhoneNo = ' " + Phone + " ', Password = ' " + pass + " ' WHERE LecturerID ='"+id+"'";
                    cmd1.ExecuteNonQuery();

                    //Updated successfully
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "Updated Successfully";

                    load_lecturer();
                    emptyTextBox();
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                    btnRegister.Visible = false;
                    con.Close();
                   

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                    btnRegister.Visible = false;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnRegister.Visible = true;
            lblError.Text = "";
            emptyTextBox();
        }

        protected void lbtnView_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnRegister.Visible = false;

            // edit button function
            string lecturerID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(lecturerID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from lecturer where LecturerID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblID.Text = DR1.GetValue(0).ToString();
                txtFname.Text = DR1.GetValue(1).ToString();
                txtEmail.Text = DR1.GetValue(2).ToString();
                dplQual.Text = DR1.GetValue(3).ToString();
                txtField.Text = DR1.GetValue(4).ToString();
                txtPhone.Text = DR1.GetValue(5).ToString();
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            // edit button function
            String lecturerID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(lecturerID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from lecturer where LecturerID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            load_lecturer();
            lblError.Text = "Deleted Successfully";
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnRegister.Visible = true;
         
        }

        private void emptyTextBox()
        {
            txtFname.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtPass.Text = "";
            txtConpass.Text = "";
            txtField.Text = "";
            dplQual.Text = "";
        }

        public void load_lecturer()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to trophy dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from lecturer";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtlLecture.DataSource = dt;
            dtlLecture.DataBind();

            con.Close();
        }
    }
}