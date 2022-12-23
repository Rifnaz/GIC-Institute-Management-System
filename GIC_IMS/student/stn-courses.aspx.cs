using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using PayPal.Api;

namespace GIC_IMS.student
{
    public partial class stn_courses : System.Web.UI.Page
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

            loadcoursedetail();
            checkCourse();
        }

        public void loadcoursedetail()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select admission.AdmissionID, admission.Applyfor, admission.Batch, admission.fee, batch.StartDate, batch.EndDate, admission.Email, course.Lecturer, admission.PaymentStatus from admission join batch on admission.Batch = batch.BatchNo join course on admission.Applyfor = course.Name where admission.AdmissionID ='"+id+"' ";
            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                lblID.Text = DR1.GetValue(0).ToString();
                lblcourse.Text = DR1.GetValue(1).ToString();
                lblBatch.Text = DR1.GetValue(2).ToString();
                lblFee.Text = DR1.GetValue(3).ToString();
                lblStart.Text = DR1.GetValue(4).ToString();
                lblEnd.Text = DR1.GetValue(5).ToString();
                lblLecturer.Text = DR1.GetValue(7).ToString();
                lblStatus.Text = DR1.GetValue(8).ToString();
            }
        }
        protected void btnPayement_Click(object sender, EventArgs e)
        {
            Session["AdmissionID"] = lblID.Text.ToString();
            Session["Fee"] = lblFee.Text.ToString();
            Session["course"] = lblcourse.Text.ToString();

            decimal fee = decimal.Parse(lblFee.Text);
            // Authenticate with Paypal
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            // Get APIContect Object
            var apiContext = new APIContext(accessToken);

            var course = new Item();
            course.name = lblcourse.Text;
            course.currency = "USD";
            course.price = fee.ToString();
            course.sku = "1234";   // Unique ref for this booking
            course.quantity = "1";


            var transactionDtl = new Details();
            transactionDtl.tax = "0";
            transactionDtl.shipping = "0";
            transactionDtl.subtotal = fee.ToString();

            var transAmount = new Amount();
            transAmount.currency = "USD";
            transAmount.total = fee.ToString();
            transAmount.details = transactionDtl;

            var transaction = new Transaction();
            transaction.description = "Pay Your Course fee";
            transaction.invoice_number = Guid.NewGuid().ToString();   // This should the id of record storing the reservation
            transaction.amount = transAmount;

            transaction.item_list = new ItemList
            {
                items = new List<Item>() { course }
            };

            // Supply  payer object
            var payer = new Payer();
            payer.payment_method = "paypal";

            var redirectUrls = new RedirectUrls();
            redirectUrls.cancel_url = "https://localhost:44340//student/paymentdecline.aspx";
            redirectUrls.return_url = "https://localhost:44340//student/paymentsuccess.aspx";

            var payment = Payment.Create(apiContext, new Payment
            {
                intent = "sale",
                payer = payer,
                transactions = new List<Transaction> { transaction },
                redirect_urls = redirectUrls
            });

            Session["paymentId"] = payment.id;

            foreach (var link in payment.links)
            {
                if (link.rel.ToLower().Equals("approval_url"))
                {
                    // found the appropriate link, send the user there
                    Response.Redirect(link.href);
                }
            }
          
        }

        private void checkCourse()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            //select command
            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from admission where AdmissionID ='" + id + "' and PaymentStatus = '"+"paid"+"' ";
            SqlDataReader DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                btnPayement.Enabled = false;
            }
        }

    }
}
