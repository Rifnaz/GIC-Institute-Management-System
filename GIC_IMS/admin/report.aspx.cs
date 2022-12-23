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
using Microsoft.Reporting.WebForms;


namespace GIC_IMS.admin
{
    public partial class report : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            fill_dropdowns();
        }

        private void fill_dropdowns()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Close();

            // Fill Items to Status combobox
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Applyfor from admission group by Applyfor", con);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                dplAdmission.Items.Add(dr["Applyfor"].ToString());
            }

            // Fill Items to Status combobox
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select Applyfor from admission group by Applyfor", con);
            da1.Fill(dt1);

            foreach (DataRow dr1 in dt1.Rows)
            {
                dplCour.Items.Add(dr1["Applyfor"].ToString());
            }
        }

        protected void btnadmsion_Click(object sender, EventArgs e)
        {
            //Empty Combobox
            dplAdmission.Items.Clear();
            dplCour.Items.Clear();
            fill_dropdowns();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from admission where Applyfor ='" + dplAdmission.SelectedValue + "'", con);
            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.ReportPath = @"D:\GIC_IMS\GIC_IMS\Reports\rptAdmission.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
            
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            //Empty Combobox
            dplAdmission.Items.Clear();
            dplCour.Items.Clear();
            fill_dropdowns();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from admission", con);
            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.ReportPath = @"D:\GIC_IMS\GIC_IMS\Reports\rptAdmission.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnfeeAll_Click(object sender, EventArgs e)
        {
            //Empty Combobox
            dplAdmission.Items.Clear();
            dplCour.Items.Clear();
            fill_dropdowns();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from admission where PaymentStatus = '"+"paid"+"'", con);
            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("DataSet2", dt);
            ReportViewer1.LocalReport.ReportPath = @"D:\GIC_IMS\GIC_IMS\Reports\rptFee.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnfee_Click(object sender, EventArgs e)
        {
            //Empty Combobox
            dplAdmission.Items.Clear();
            dplCour.Items.Clear();
            fill_dropdowns();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from admission where Applyfor ='" + dplCour.SelectedValue+"' and PaymentStatus = '" + "paid" + "'", con);
            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("DataSet2", dt);
            ReportViewer1.LocalReport.ReportPath = @"D:\GIC_IMS\GIC_IMS\Reports\rptFee.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnLec_Click(object sender, EventArgs e)
        {
            //Empty Combobox
            dplAdmission.Items.Clear();
            dplCour.Items.Clear();
            fill_dropdowns();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from lecturer", con);
            da.Fill(dt);

            ReportDataSource rds = new ReportDataSource("DataSet2", dt);
            ReportViewer1.LocalReport.ReportPath = @"D:\GIC_IMS\GIC_IMS\Reports\rptLecturer.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}