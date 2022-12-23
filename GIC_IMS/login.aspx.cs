using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace GIC_IMS
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string userType;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            hideErrMessage();

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            userLogin();
        }

        private void userLogin()
        {
            String email = txtEmail.Text;
            String pass = txtPass.Text;

            if (email == "" || pass == "")
            {
                if (email == "")
                {
                    lblError_mail.Visible = true;
                }

                if (pass == "")
                {
                    lblError_pass.Visible = true;

                }
            }

            else
            {
                try
                {
                    userType = Request.QueryString["id"].ToString();
                    //open and close connection
                    //Check if entered username and password are correct

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    if (userType == "admin")
                    {
                        cmd.CommandText = "select * from admin where Email='" + email + "'and Password='" + pass + "'";
                        cmd.ExecuteNonQuery();

                        //sucess message
                        if (cmd.ExecuteReader().Read())
                        {
                            Response.Redirect("admin/admindash.aspx");
                        }
                        //error message
                        else
                        {
                            lblError.Visible = true;
                        }
                        con.Close();
                    }
                    if (userType == "student")
                    {
                        cmd.CommandText = "select * from student where Email='" + email + "'and Password='" + pass + "'";
                        cmd.ExecuteNonQuery();

                        //sucess message
                        if (cmd.ExecuteReader().Read())
                        {
                            Session["Email"] = email;
                            Response.Redirect("student/studentdash.aspx");
                        }
                        //error message
                        else
                        {
                            lblError.Visible = true;
                        }
                        con.Close();
                    }

                    if (userType == "lecturer")
                    {
                        cmd.CommandText = "select * from lecturer where Email='" + email + "'and Password='" + pass + "'";
                        cmd.ExecuteNonQuery();

                        //sucess message
                        if (cmd.ExecuteReader().Read())
                        {
                            Session["Email"] = email;
                            Response.Redirect("lecturer/lecturerdash.aspx");
                        }
                        //error message
                        else
                        {
                            lblError.Visible = true;
                        }
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);

                }
            }

        }

        private void emptyTextBox()
        {
            txtPass.Text = "";
            txtEmail.Text = "";
        }

        private void hideErrMessage()
        {
            lblError_mail.Visible = false;
            lblError.Visible = false;
            lblError_pass.Visible = false;

        }

        protected void lbtnforgotlink_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgot_password.aspx?usertype="+ Request.QueryString["id"].ToString());
        }
    }
}
