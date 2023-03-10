using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BBGL_PrintReport : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StiReport report = new StiReport();

        string STRDJBH = string.Empty;

        int DJLX = 0;

        try
        {
            STRDJBH = Request["DJBH"];
        }
        catch
        {

        }

        try
        {
            DJLX = Convert.ToInt32(Request["DJLX"]);
        }
        catch
        {

        }

        if (STRDJBH.Length > 0)
        {
            if (DJLX == 0)
            { /// 单据类型是 0 的为结算单打印
                report.Load(MapPath("/BBGL/BB/Print_JSD.mrt"));

                Label_Name.Text = STRDJBH;
                report.Dictionary.Variables.Add("DJBH", STRDJBH);
                report.Dictionary.Variables.Add("USERID", DefaultUser);
            }
            else if (DJLX == 1)
            { /// 单据类型是 1 的为库存调整单打印
                report.Load(MapPath("/BBGL/BB/Print_KCTZD.mrt"));

                Label_Name.Text = STRDJBH;
                report.Dictionary.Variables.Add("DJBH", STRDJBH);
                report.Dictionary.Variables.Add("USERID", DefaultUser);
            }

            StiWebViewer1.Report = report;

        }
        else
        {
            MessageBox("", "错误的参数类型~<br/>请重试~");
            return;
        }
        // LoadBBInfo();
    }

}