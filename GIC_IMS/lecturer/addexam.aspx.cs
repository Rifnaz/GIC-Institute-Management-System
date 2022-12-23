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

namespace GIC_IMS.lecturer
{
    public partial class addexam : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_exam();
           
            lblError.Text = "";
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            lblError.ForeColor = Color.Red;
        }

        public void load_exam()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            String mail = Session["Email"].ToString();

            SqlCommand Com = new SqlCommand("select * from lecturer where Email='" + mail + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblcourse.Text = DR1.GetValue(6).ToString();
            }
            DR1.Close();

            // Load loads to trophy dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from exam where Course ='"+lblcourse.Text+"'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_exam.DataSource = dt;
            dtl_exam.DataBind();

            con.Close();
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String question = txtquestion.InnerText;
            String ans1 = txtans1.Text;
            String ans2 = txtans2.Text;
            String ans3 = txtans3.Text;
            String ans4 = txtans4.Text;
            String course = lblcourse.Text;
            String answer = txtanswer.Text;



            // validation
            if (course == "" || ans1 == "" || ans2 == "" || ans3 == "" || ans4 == "" || question == "" || answer == "")
            {
                lblError.Text = "All fields are required";
            }
            else
            {
                try
                {
                    //check if batch already exists
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from exam where Question='" + question + "'";

                    //error message for exixting email
                    if (cmd.ExecuteReader().Read())
                    {
                        lblError.Text = "The Question already exists";
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

                        String mail = Session["Email"].ToString();

                        SqlCommand Com = new SqlCommand("select * from lecturer where Email='" + mail + "'", con);
                        SqlDataReader DR1 = Com.ExecuteReader();
                        if (DR1.Read())
                        {
                            lblcourse.Text = DR1.GetValue(6).ToString();
                        }
                        DR1.Close();

                        //insert command
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into exam(Course, Question, Answer1, Answer2, Answer3, Answer4, Answer) values('" + course + "', '" + question + "', '" + ans1 + "', '" + ans2 + "', '"+ans3+"', '"+ans4+"', '"+answer+"')";
                        cmd1.ExecuteNonQuery();

                        //registered successfully
                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "Created Successfully";

                        load_exam();
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

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void emptyTextBox()
        {
            txtquestion.InnerText = "";
            txtans1.Text = "";
            txtans2.Text = "";
            txtans3.Text = "";
            txtans4.Text = "";
        }

    }
}