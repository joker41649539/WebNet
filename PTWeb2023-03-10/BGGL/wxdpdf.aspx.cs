using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BGGL_pdf : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }
    private void LoadData()
    {
        int iid = Convert.ToInt32(Request["ID"]);
        if (iid > 0)
        {
            StiReport report = new StiReport();
            report.Load(MapPath("/BBGL/BB/GCWXD.mrt"));
            report.Dictionary.Variables.Add("IID", iid);

            StiWebViewer1.Report = report;
        }

        HyperLink1.NavigateUrl = "/BGGL/WXDPDF.ASPX?ID=" + (iid + 1).ToString();
        HyperLink2.NavigateUrl = "/BGGL/WXDPDF.ASPX?ID=" + (iid - 1).ToString();

    }
}