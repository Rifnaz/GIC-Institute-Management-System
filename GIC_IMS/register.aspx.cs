using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIC_IMS
{
    public partial class register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            hideErrMessage();
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            registerStudent();
        }

        private void registerStudent()
        {
            //Declare Varriable
            String first = txtFname.Text;
            String last = txtLname.Text;
            String mail = txtEmail.Text;
            String pass = txtPass.Text;
            String conpass = txtCon.Text;

            // validation
            if (first == "")
            {
                lblError_name.Text= "First and Last names are required";
            }
            if (last == "")
            {
                lblError_name.Text = "First and Last names are required";
            }
            if (mail == "")
            {
                lblError_mail.Text = "Enter your Email";
            }
            if (pass == "")
            {
                lblError_pass.Text = "Enter your Password";
            }
            if (conpass == "")
            {
                lblError_con.Text = "Enter Confirm Password";
            }

            if (pass != conpass)
            {
                lblError_con.Text = "Password does not match";
                txtPass.Text = "";
                txtCon.Text = "";
            }

            else
            {
                try
                {
                    if (fileImg.HasFile)
                    {
                        string str = fileImg.FileName;
                        fileImg.PostedFile.SaveAs(Server.MapPath("~/img/student/" + str));
                        string img = "~/img/student/" + str.ToString();

                        //check if student already exists
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from student where Email='" + mail + "'";

                        //error message for exixting email
                        if (cmd.ExecuteReader().Read())
                        {
                            lblError_mail.Text = "Student with this Email already exists";
                            emptyTextBox();
                            con.Close();
                        }

                        //insert and success message
                        else
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();

                            //insert command

                            string query = "insert into student(FirstName, LastName, Email, Image, Password) values('" + first + "', '" + last + "', '" + mail + "', '" + img + "', '" + pass + "')";
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = query;
                            cmd1.ExecuteNonQuery();

                            //registered successfully
                            lblError.ForeColor = Color.Blue;
                            lblError.Text = "Registered Successfully";
                            emptyTextBox();
                        }
                        con.Close();
                    }
                    else
                    {
                        lblError_pic.Text = "Upload your Picture";
                    }

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        private void emptyTextBox()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtPass.Text = "";
            txtEmail.Text = "";
            txtCon.Text = "";
        }

        private void hideErrMessage()
        {
            lblError_con.Text = "";
            lblError_pic.Text = "";
            lblError_name.Text = "";
            lblError_mail.Text = "";
            lblError.Text = "";
            lblError_pass.Text = "";
        }
    }
}