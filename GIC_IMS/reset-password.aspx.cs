using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace GIC_IMS
{
    public partial class reset_password : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string userType;
        string Email;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            lblError.Text = "";
            lblError.ForeColor = Color.Red;
        }

        protected void btnRest_Click(object sender, EventArgs e)
        {
            String pass = txtpass.Text;
            String confirm = txtCon.Text;

            if (confirm == "" || pass == "")
            {
                lblError.Text = "Please Enter your new Passwords";
            }

            else
            {
                try
                {
                    userType = Request.QueryString["usertype"].ToString();
                    Email = Request.QueryString["email"].ToString();

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    if (userType == "admin")
                    {
                        cmd.CommandText = "select * from admin where Email='" + Email + "'";
                        cmd.ExecuteNonQuery();

                        //sucess message
                        if (cmd.ExecuteReader().Read())
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();

                            //insert command
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "UPDATE admin SET Password ='" + pass + "' WHERE Email ='" + Email + "'";
                            cmd1.ExecuteNonQuery();

                            //Updated successfully
                            lblError.ForeColor = Color.Blue;
                            lblError.Text = "Password Reseted Successfully..!";
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
                        cmd.CommandText = "select * from student where Email='" + Email + "'";
                        cmd.ExecuteNonQuery();

                        //sucess message
                        if (cmd.ExecuteReader().Read())
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();

                            //insert command
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "UPDATE student SET Password ='" + pass + "' WHERE Email ='" + Email + "'";
                            cmd1.ExecuteNonQuery();

                            //Updated successfully
                            lblError.ForeColor = Color.Blue;
                            lblError.Text = "Password Reseted Successfully..!";
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
                        cmd.CommandText = "select * from lecturer where Email='" + Email + "'";
                        cmd.ExecuteNonQuery();

                        //sucess message
                        if (cmd.ExecuteReader().Read())
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            con.Open();

                            //insert command
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "UPDATE lecturer SET Password ='" + pass + "' WHERE Email ='" + Email + "'";
                            cmd1.ExecuteNonQuery();

                            //Updated successfully
                            lblError.ForeColor = Color.Blue;
                            lblError.Text = "Password Reseted Successfully..!";
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
    }
}