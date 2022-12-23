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

namespace GIC_IMS.student
{
    public partial class stn_exam : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string course;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

            load_exam();
        }

        public void load_exam()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            String mail = Session["Email"].ToString();
            course = Request.QueryString["course"];

            // Load loads to student dtl
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select admission.AdmissionID, admission.Email, admission.Applyfor, admission.PaymentStatus, exam.ExamID, exam.Course, exam.Question, exam.Answer1, exam.Answer2, exam.Answer3, exam.Answer4, exam.Answer from exam join admission on admission.Applyfor = exam.Course where exam.Course ='" + course + "'";
            cmd.ExecuteNonQuery();

            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dtl_exam.DataSource = dt;
            dtl_exam.DataBind();

            con.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            foreach(DataListItem dli in dtl_exam.Items)
            {
                RadioButton rb1 = (RadioButton)dli.FindControl("RadioButton1");
                Label lblAns = (Label)dli.FindControl("lblAnswer");

                if(rb1.Checked == true)
                {
                    if (rb1.Text.Equals(lblAns.Text))
                    {
                        Label lblSelect = (Label)dli.FindControl("lblSeleted");
                        lblSelect.Text = "Correct Answer";
                        lblSelect.ForeColor = Color.Green;
                    }
                    else
                    {
                        Label lblwrong = (Label)dli.FindControl("lblSeleted");
                        lblwrong.Text = "Wrong Answer";
                        lblwrong.ForeColor = Color.Red;
                    }
                }
            }
            foreach (DataListItem dli in dtl_exam.Items)
            {
                RadioButton rb2 = (RadioButton)dli.FindControl("RadioButton2");
                Label lblAns = (Label)dli.FindControl("lblAnswer");

                if (rb2.Checked == true)
                {
                    if (rb2.Text.Equals(lblAns.Text))
                    {
                        Label lblSelect = (Label)dli.FindControl("lblSeleted");
                        lblSelect.Text = "Correct Answer";
                        lblSelect.ForeColor = Color.Green;
                    }
                    else
                    {
                        Label lblwrong = (Label)dli.FindControl("lblSeleted");
                        lblwrong.Text = "Wrong Answer";
                        lblwrong.ForeColor = Color.Red;
                    }
                }
            }
            foreach (DataListItem dli in dtl_exam.Items)
            {
                RadioButton rb3 = (RadioButton)dli.FindControl("RadioButton3");
                Label lblAns = (Label)dli.FindControl("lblAnswer");

                if (rb3.Checked == true)
                {
                    if (rb3.Text.Equals(lblAns.Text))
                    {
                        Label lblSelect = (Label)dli.FindControl("lblSeleted");
                        lblSelect.Text = "Correct Answer";
                        lblSelect.ForeColor = Color.Green;
                    }
                    else
                    {
                        Label lblwrong = (Label)dli.FindControl("lblSeleted");
                        lblwrong.Text = "Wrong Answer";
                        lblwrong.ForeColor = Color.Red;
                    }
                }
            }
            foreach (DataListItem dli in dtl_exam.Items)
            {
                RadioButton rb4 = (RadioButton)dli.FindControl("RadioButton4");
                Label lblAns = (Label)dli.FindControl("lblAnswer");

                if (rb4.Checked == true)
                {
                    if (rb4.Text.Equals(lblAns.Text))
                    {
                        Label lblSelect = (Label)dli.FindControl("lblSeleted");
                        lblSelect.Text = "Correct Answer";
                        lblSelect.ForeColor = Color.Green;
                    }
                    else
                    {
                        Label lblwrong = (Label)dli.FindControl("lblSeleted");
                        lblwrong.Text = "Wrong Answer";
                        lblwrong.ForeColor = Color.Red;
                    }
                }
            }

            lblResult.Text = "30";
        }
    }
    
}