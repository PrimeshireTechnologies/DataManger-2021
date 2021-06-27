using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

namespace SickeCell.Reports
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report.rdlc");                
                SickeCellEntities1 entities = new SickeCellEntities1();
                ReportDataSource datasource = new ReportDataSource("Information", (from information in entities.Information select information));
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportViewer1.Width = 1300;
                ReportViewer1.Height = 700;
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.NamingContainer.Visible = true;
                ReportViewer1.ShowPageNavigationControls = true;

                ReportViewer1.LocalReport.Refresh();
            }            
        }
    }
}