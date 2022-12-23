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

namespace GIC_IMS.lecturer
{
    public partial class tutorial : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_tutorial();
            lblError.Text = "";
            lblError.ForeColor = Color.Red;

        }

        public void load_tutorial()
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
            cmd.CommandText = "select * from tutorial where course = '"+lblcourse.Text+"'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_exam.DataSource = dt;
            dtl_exam.DataBind();

            con.Close();
        }

        private void emptyTextBox()
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String title = txtTitle.Text;
            String link = txtxLink.Text;
            String course = lblcourse.Text;

            // validation
            if (title == "" || link == "")
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
                    cmd.CommandText = "select * from tutorial where title='" + title + "'";

                    //error message for exixting email
                    if (cmd.ExecuteReader().Read())
                    {
                        lblError.Text = "The tutorial already exists";
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
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into tutorial (Title, Course, Link) values('" + title + "','"+course+"', '" + link + "')";
                        cmd1.ExecuteNonQuery();

                        //registered successfully
                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "Created Successfully";

                        load_tutorial();
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
    }
}