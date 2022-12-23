using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GIC_IMS.admin
{
    public partial class announcement : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_announcement();
            lblError.Text = "";
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            lblError.ForeColor = Color.Red;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String title = txtTitle.Text;
            String sub = txtSub.Text;
            String start = txtStart.Text;
            String end = txtEnd.Text;
            String venue = txtVenue.Text;
            String time = txtTime.Text;
            String content = txtContent.InnerText;


            // validation
            if (title == "" || sub == "" || start == "" || end == "" || venue == "" || time == "" || content == "")
            {
                lblError.Text = "All fields are required..!";
            }
           
            else
            {
                try
                {
                    if (filepic.HasFile)
                    {
                        string str = filepic.FileName;
                        filepic.PostedFile.SaveAs(Server.MapPath("~/img/announcement/" + str));
                        string pic = "~/img/announcement/" + str.ToString();

                        //check if student already exists
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from announcement where Title='" + title + "'";

                        //error message for exixting email
                        if (cmd.ExecuteReader().Read())
                        {
                            lblError.Text = "Announcement with this Title already exists";
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

                            string query = "insert into announcement(Title, SubTitle, StartDate, EndDate, Venue, Time, Content, Picture) values('" + title + "', '" + sub + "', '" + start + "', '" + end + "', '" + venue + "', '"+time+"', '"+content+"', '"+pic+"')";
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
                        lblError.Text = "Upload relevent Picture";
                    }

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        public void load_announcement()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // Load loads to student dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from announcement";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtlAnnounce.DataSource = dt;
            dtlAnnounce.DataBind();

            con.Close();
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnCreate.Visible = false;
            // edit button function
            string announcementID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(announcementID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand Com = new SqlCommand("select * from announcement where AnnouncementID='" + id + "'", con);
            SqlDataReader DR1 = Com.ExecuteReader();
            if (DR1.Read())
            {
                lblID.Text = DR1.GetValue(0).ToString();
                txtTitle.Text = DR1.GetValue(1).ToString();
                txtSub.Text = DR1.GetValue(2).ToString();
                txtStart.Text = DR1.GetValue(3).ToString();
                txtEnd.Text = DR1.GetValue(4).ToString();
                txtVenue.Text = DR1.GetValue(5).ToString();
                txtTime.Text = DR1.GetValue(6).ToString();
                txtContent.InnerText = DR1.GetValue(7).ToString();
            }

        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            // delete button function
            string announcementID = ((LinkButton)sender).CommandArgument.ToString();
            int id = int.Parse(announcementID);

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            // delete command
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from course where CourseID ='" + id + "' ";
            cmd.ExecuteNonQuery();

            lblError.Text = "Deleted Successfully";
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnCreate.Visible = true;
        }

        private void emptyTextBox()
        {
            txtTitle.Text = "";
            txtSub.Text = "";
            txtStart.Text = "";
            txtEnd.Text = "";
            txtVenue.Text = "";
            txtTime.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Declare Varriable
            String title = txtTitle.Text;
            String sub = txtSub.Text;
            String start = txtStart.Text;
            String end = txtEnd.Text;
            String venue = txtVenue.Text;
            String time = txtTime.Text;
            String content = txtContent.InnerText;


            // validation
            if (title == "" || sub == "" || start == "" || end == "" || venue == "" || time == "" || content == "")
            {
                lblError.Text = "All fields are required..!";
            }

            else
            {
                try
                {
                    if (filepic.HasFile)
                    {
                        int id = int.Parse(lblID.Text);

                        string str = filepic.FileName;
                        filepic.PostedFile.SaveAs(Server.MapPath("~/img/announcement/" + str));
                        string pic = "~/img/announcement/" + str.ToString();
                       
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Open();

                        //insert command

                        string query = "UPDATE announcement SET Title ='" + title + "', SubTitle = '" + sub + "', StartDate = '" + start + "', EndDate = '" + end + "', Venue = '" + venue + "', Time = '" + time + "', Content = '" + content + "', Picture = '" + pic + "' where Announcement ='"+id+"'";
                        SqlCommand cmd1 = con.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = query;
                        cmd1.ExecuteNonQuery();

                        //registered successfully
                        lblError.ForeColor = Color.Blue;
                        lblError.Text = "Updated Successfully";

                        load_announcement();
                        btnCancel.Visible = true;
                        btnUpdate.Visible = true;
                        btnCreate.Visible = false;
                        emptyTextBox();
                        
                        con.Close();
                    }
                    else
                    {
                        lblError.Text = "Upload relevent Picture";
                    }

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnCreate.Visible = true;
            emptyTextBox();
        }
    }
}