using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Xml;
using Newtonsoft.Json;

/// <summary>
/// PageBaseShop 的摘要说明
/// </summary>
public class PageBaseShop : System.Web.UI.Page
{
    public static string DefaultConStr = "Data Source=hds316158156.my3w.com;Initial Catalog=hds316158156_db;User Id=hds316158156;Password=joK12141649539";

    public static OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    public PageBaseShop()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 依据权限ID和用户ID判断是否有此功能权限。有返回TURE，反之返回FALSE;
    /// </summary>
    /// <param name="WebID">页面ID</param>
    /// <param name="PhoneNo">用户ID</param>
    /// <returns></returns>
    public bool QXBool(int WebID, string PhoneNo)
    {
        bool rValue = false;
        string strSQL = "Select * from Shop_Module where PhoneNo='" + PhoneNo + "' and ModuleID=" + WebID.ToString() + "";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                rValue = true;
            }
        }
        return rValue;
    }

    /// <summary>
    /// 当前用户
    /// </summary>
    public string DefaultUser
    {
        get
        {
            string rValue = "0";

            try
            {
                rValue = Request.Cookies["Shop"]["PhoneNo"];
            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>dialog = jqueryAlert({ 'title': '提 示', 'content': '您还未登陆。<br/>请先登陆！', 'modal': true, 'buttons': { '确定': function () { location.href=\"/Shop/Login.aspx\"; } } })</script>");
            }

            return rValue;
        }
    }
    public bool IsInt(string value)
    {
        return Regex.IsMatch(value, @"^[+-]?\d*$");
    }

    /// <summary>
    /// 弹出消息框
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sMessage">提示消息</param>
    public void MessageBox(string sMessage)
    {
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript 中使用"\'"显示'字符。

        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>dialog = jqueryAlert({'content': '" + sTemp + "'})</script>");

    }
    /// <summary>
    /// 弹出消息框
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sMessage">提示消息</param>
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

    /// <summary>
    /// 模态框消息提示，并跳转页面
    /// </summary>
    /// <param name="UpdatePanel">无刷新PANEL名</param>
    /// <param name="sKey">提示窗口标题</param>
    /// <param name="sMessage">消息内容</param>
    /// <param name="sURL">提示后跳转页面</param>
    public void MessageBox(Control UpdatePanel, string sKey, string sMessage, string sURL)
    {
        if (sKey == "")
        {
            sKey = "提示信息";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript 中使用"\'"显示'字符。

        ScriptManager.RegisterClientScriptBlock(UpdatePanel, this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='" + sTemp + "';document.getElementById('MSGTitle').innerHTML='" + sKey + "'", true);
        ScriptManager.RegisterStartupScript(UpdatePanel, this.GetType(), "sKey", "$('#MSG').modal('show');$(function () {$('#MSG').on('hide.bs.modal', function () {setTimeout(parent.location.href = '" + sURL + "', 0);})});", true);

    }
}
