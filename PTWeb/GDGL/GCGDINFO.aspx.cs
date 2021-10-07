using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class BBGL_BBShow : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string LoginID;
            LoginID = Request.Cookies["WeChat_Yanwo"]["USERID"].ToString();
        }
        catch
        {
            MessageBox("", "您还未登陆，无权查看该页！<br/>请先登陆！", "/Login.aspx");
            return;
        }


        LoadBBInfo();
    }

    /// <summary>
    /// 加载报表信息
    /// </summary>
    private void LoadBBInfo()
    {
        StiReport report = new StiReport();

        this.Title = "工程工单明细表";

        /// 获得报表名称
        report.Load(MapPath("/BBGL/BB/GCGDINFO.MRT"));

        /// 默认加载用户ID信息
        report.Dictionary.Variables.Add("GCDH", Request["GCDH"].ToString());
        StiWebViewer1.Report = report;
    }

}