using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABB_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchText();
        }
    }

    /// <summary>
    /// 依据查询条件显示信息  18956068670
    /// </summary>
    private void SearchText()
    {
        string strTxt = Request["strFilter"];
        try
        {
            if (strTxt == "安徽怀海机电设备有限公司")
            {
                ShowDivTrue();
                Btn.InnerText = "返  回";
            }
            else if (strTxt != "undefined" && strTxt.Length > 0)
            {
                ShowDivFalse();
                Btn.InnerText = "返  回";
            }
            else if (strTxt == "undefined")
            {
                Response.Write("<script language='JavaScript'>window.open('/ABB/');</script>");
            }
        }
        catch
        {

        }
    }

    private void ShowDivTrue()
    {
        string strDiv = string.Empty;
        strDiv += "<div id=\"subtitleDiv\" class=\"inputDiv\" style=\"width:100%\">";
        strDiv += "<p id=\"subtitlep\" class=\"hyxjhj\" style=\"word-break:break-all;font-size:20px\">查询成功</p>";
        strDiv += "<p id=\"subtitlep1\" class=\"hyxjhj\" style=\"word-break:break-all;font-size:20px\">安徽怀海机电设备有限公司</p>";
        strDiv += "<p id=\"subtitlep2\" class=\"hyxjhj\" style=\"word-break:break-all;font-size:20px\">是本年度ABB电机与发电机业务单元的授权经销商（授权有效期为1年）</p>";
        strDiv += "</div>";

        ShowDiv.InnerHtml = strDiv;

    }
    private void ShowDivFalse()
    {
        string strDiv = string.Empty;
        strDiv += "<div id=\"subtitleDiv\" class=\"inputDiv\" style=\"width:100%\">";
        strDiv += "<p id=\"subtitlep\" class=\"hyxjhj\" style=\"word-break:break-all;font-size:20px\">查询不成功！</p>";
        strDiv += "<p id=\"subtitlep1\" class=\"hyxjhj\" style=\"word-break:break-all;font-size:20px\">您查询的经销商在我们数据库中暂无记录。</p>";
        strDiv += "<p id=\"subtitlep2\" class=\"hyxjhj\" style=\"word-break:break-all;font-size:20px\"></p>";
        strDiv += "</div>";
        HiddenField1.Value = "true";

        ShowDiv.InnerHtml = strDiv;

    }

}