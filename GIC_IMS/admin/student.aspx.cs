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

namespace GIC_IMS.admin
{
    public partial class student : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_Student();
            lblError.Text = "";
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            lblError.ForeColor = Color.Red;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String first = txtFirst.Text;
            String last = txtLast.Text;
            String mail = txtEmail.Text;
            String pass = txtPass.Text;
            String conpass = txtConpass.Text;


            // validation
            if (first == "" || last == "" || mail == "" || pass == "" || conpass == "")
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
                            lblError.Text = "Student with this Email already exists";
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
                        lblError.Text = "Upload Student's Picture";
                    }

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
            String first = txtFirst.Text;
            String last = txtLast.Text;
            String mail = txtEmail.Text;
            String pass = txtPass.Text;
            String conpass = txtConpass.Text;


            // validation
            if (first == "" || last == "" || mail == "" || pass == "" || conpass == "")
            {
                lblError.Text = "All fields are required..!";
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnRegister.Visible = false;
            }
            if (pass != conpass)
            {
                lblError.Text = "Password does not match..!";
                txtPass.Text = "";
                txtConpass.Text = "";
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnRegister.Visible = false;
            }
            else
            {
                try
                {
                    if (fileImg.HasFile)
                    {
                        int id = int.Parse(lblID.Text);

                        string str = fileImg.FileName;
                        fileImg.PostedFile.SaveAs(Server.MapPath("~/img/student/" + str));
                        string img = "~/img/student/" + str.ToString();


                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        //insert command

                        string query = "UPDATE student SET FirstName ='" + first + "', LastName ='" + last + "', Email ='" + mail + "', Image ='" + img + "', Password ='" + pass + "' where StudentID ='"+id+"'";
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = query;
                        cmd1.ExecuteNonQuery();

                        //registered successfully
                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "Updated Successfully";
                        emptyTextBox();

                        load_Student();
                        btnCancel.Visible = true;
                        btnUpdate.Visible = true;
                        btnRegister.Visible = false;

                        con.Close();
                    }
                    else
                    {
                        lblError.Text = "Upload Student's Picture";
                        btnCancel.Visible = true;
                        btnUpdate.Visible = true;
                        btnRegister.Visible = false;
                    }

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

        public void load_Student()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to student dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_Student.DataSource = dt;
            dtl_Student.DataBind();

            con.Close();
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnRegister.Visible = false;

            // edit button function
            string studentID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(studentID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from student where StudentID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblID.Text = DR1.GetValue(0).ToString();
                txtFirst.Text = DR1.GetValue(1).ToString();
                txtLast.Text = DR1.GetValue(2).ToString();
                txtEmail.Text = DR1.GetValue(3).ToString();
            }
        }

        private void emptyTextBox()
        {
            txtFirst.Text = "";
            txtLast.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtConpass.Text = "";
        }
    }
}