using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_MasterPage : System.Web.UI.MasterPage
{
    public static string DefaultConStr = "Data Source=hds316158156.my3w.com;Initial Catalog=hds316158156_db;User Id=hds316158156;Password=joK12141649539";

    public static OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DefaultMSG();// MessageBox("1、您的收货地址信息未完善。<br>2、您的收款银行未完善。<br>3、您的金豆余额不足，请充值。<br>4、PhoneNo:" + DefaultUser);
        }
    }

    private void loadData(string Db_user)
    {
        string strSQL = "  Select *,(Select Count(ID) From Shop_Address where UserNo=Shop_UserInfo.PhoneNo) AddressCount from Shop_UserInfo where PhoneNo='" + Db_user + "' AND FLAG=0 ";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string sIMGWeChat = string.Empty;
                string sIMGPay = string.Empty;
                string sBankName = string.Empty;
                string sBankStart = string.Empty;
                string sBankID = string.Empty;
                double GoldCount = 0;
                bool BankMSG = false;
                bool AddressMSG = false;
                int AddressCount = 0;

                sIMGWeChat = OP_Mode.Dtv[0]["WeChatImg"].ToString();
                sIMGPay = OP_Mode.Dtv[0]["PayImg"].ToString();
                sBankName = OP_Mode.Dtv[0]["BankName"].ToString();
                sBankStart = OP_Mode.Dtv[0]["BankStart"].ToString();
                sBankID = OP_Mode.Dtv[0]["BankID"].ToString();
                AddressCount = Convert.ToInt32(OP_Mode.Dtv[0]["AddressCount"]);
                GoldCount = Convert.ToDouble(OP_Mode.Dtv[0]["GoldCount"]);

                if (sIMGWeChat.Length > 0 || sIMGPay.Length > 0 || (sBankID.Length + sBankName.Length + sBankID.Length) > 0)
                {
                    BankMSG = true;
                }
                if (AddressCount > 0)
                {
                    AddressMSG = true;
                }

                /// 执行登录操作
                /// 
                /// 把登录信息写入到COOKIE里
                ResponseCokie(Db_user, BankMSG, AddressMSG, GoldCount);
            }
        }
    }

    private void DefaultMSG()
    {
        try
        {
            int i = 0;
            string strMSG = string.Empty;

            if (Request.Cookies["Shop"]["PhoneNo"] != null)
            {
                loadData(Request.Cookies["Shop"]["PhoneNo"].ToString());
            }

            if (!Convert.ToBoolean(Request.Cookies["Shop"]["BankMsg"]))
            {
                i++;
                strMSG += i + "、您的收款银行未完善。<br>";
            }
            if (!Convert.ToBoolean(Request.Cookies["Shop"]["AddressMsg"]))
            {
                i++;
                strMSG += i + "、您的收货地址信息未完善。<br>";
            }
            if (Convert.ToDouble(Request.Cookies["Shop"]["GoldCount"]) < 10)
            {
                i++;
                strMSG += i + "、您的金豆余额不足，请充值。<br>";
            }
            if (strMSG.Length > 4)
            {
                MessageBox(strMSG.Substring(0, strMSG.Length - 4));
            }
        }
        catch
        {

        }
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

    /// <summary>
    /// 写入Cookie 判断是否填写过信息
    /// </summary>
    public void ResponseCokie(string PhonNo, bool BankMsg, bool AddressMsg, double GoldCount)
    {
        Response.Cookies["Shop"]["PhoneNo"] = PhonNo;
        Response.Cookies["Shop"]["BankMsg"] = BankMsg.ToString();
        Response.Cookies["Shop"]["AddressMsg"] = AddressMsg.ToString();
        Response.Cookies["Shop"]["GoldCount"] = GoldCount.ToString();
    }

}
