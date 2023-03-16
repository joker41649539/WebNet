using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AllSchool_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 模态框消息提示
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sMessage"></param>
    public void MessageBox(string sKey, string sMessage)
    {
        if (sKey == "")
        {
            sKey = "提示信息";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript 中使用"\'"显示'字符。
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>dialog = jqueryAlert({ 'title': '" + sKey + "', 'content': '" + sTemp + "', 'modal': true, 'buttons': { '确定': function () {dialog.destroy();dialog.close();} } })</script>");
    }

    /// <summary>
    /// 模态框消息提示，并跳转页面
    /// </summary>
    /// <param name="sKey">提示窗口标题</param>
    /// <param name="sMessage">消息内容</param>
    /// <param name="sURL">提示后跳转页面</param>
    public void MessageBox(string sKey, string sMessage, string sURL)
    {
        if (sKey == "")
        {
            sKey = "提示信息";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript 中使用"\'"显示'字符。
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>dialog = jqueryAlert({ 'title': '" + sKey + "', 'content': '" + sTemp + "', 'modal': true, 'buttons': { '确定': function () { location.href=\"" + sURL + "\"; } } })</script>");
    }
}
