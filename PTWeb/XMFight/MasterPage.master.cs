using System;
using System.Configuration;

public partial class Fil_MasterPage : System.Web.UI.MasterPage
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public static string DefaultConStr = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

    OpMode OP_Mode = new OpMode(DefaultConStr, 0);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //}
            string strURL = Request.Url.AbsoluteUri;

            //if (strURL.IndexOf("localhost") > -1)
            //{/// 测试程序，默认ID
            //    LoadUserInfo(6);
            //}
            //else
            //{
            //    //  LoadUserInfo();
            //    // WeChatLoad();
            //    ////  MessageBox("消息提示", "测试信息");
            //}
            LoadFoot();
        }
    }

    private void LoadFoot()
    {
        int iUserID = 0;

        try
        {
            iUserID = Convert.ToInt32(Request.Cookies["WeChat_XMFight"]["USERID"]);
        }
        catch
        {

        }

        LeftMenu.Visible = false;

        string strTemp = string.Empty;
        strTemp += "<ul class=\"footer-nav2 text-center\">";
        // strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/Question/#\"><i class=\"icon-home\"></i>首页</a></li>";
        // strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/XMFight/\"><i class=\"icon-camera-retro\"></i>学员风采</a></li>";
        strTemp += "  <li style=\"width:33%\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/XMFight/MyClass.aspx\"><i class=\"icon-calendar\"></i>我的课程</a></li>";
        strTemp += "  <li style=\"width:33%\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/XMFight/Rules.aspx\"><i class=\"icon-book\"></i>旭铭馆规</a></li>";
        strTemp += "  <li style=\"width:33%\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/XMFight/Contact.aspx\"><i class=\"icon-comments\"></i>联系我们</a></li>";
        // strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/Question/UserInfo.aspx\"><i class=\"icon-exclamation-sign\"></i>个人信息</a></li>";
        // strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/Question/#\"><i class=\" icon-exclamation-sign\"></i>帮助信息</a></li>";
        if (iUserID == 7 || iUserID == 6)
        {
            LeftMenu.Visible = true;
            ManageMenu();
            strTemp += "  <li style=\"width:33%\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/XMFight/Manage/Class.aspx\"><i class=\"icon-calendar\"></i>课程管理</a></li>";
            strTemp += "  <li style=\"width:33%\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/XMFight/Manage/Bance.aspx\"><i class=\"icon-bar-chart\"></i>盈利报表</a></li>";
        }
        strTemp += "</ul>";

        FootBut.InnerHtml = strTemp;
    }

    /// <summary>
    /// 管理菜单
    /// </summary>
    private void ManageMenu()
    {
        string strDiv = string.Empty;

        strDiv = "<a class=\"menu-toggler\" id=\"menu-toggler\" href=\"#\">";
        strDiv += " <span class=\"menu-text\"></span>";
        strDiv += "</a>";
        strDiv += " <div class=\"sidebar\" id=\"sidebar\">";
        strDiv += " <script type=\"text/javascript\">";
        strDiv += "  try { ace.settings.check('sidebar', 'fixed') } catch (e) { }";
        strDiv += " </script>";

        strDiv += " <ul class=\"nav nav-list\">";

        strDiv += "  <li class=\"active\">";
        strDiv += "    <a href='/XMFight/Manage/AddStudent.aspx' >";
        strDiv += "      <i class=\"icon-dashboard\"></i>";
        strDiv += "      <span class=\"menu-text\">添加学生 </span>";
        strDiv += "    </a>";
        strDiv += "   </li>";

        strDiv += "  <li class=\"active\">";
        strDiv += "    <a href=\"/XMFight/Manage/AddClass.aspx\">";
        strDiv += "      <i class=\"icon-dashboard\"></i>";
        strDiv += "      <span class=\"menu-text\">添加课程 </span>";
        strDiv += "    </a>";
        strDiv += "   </li>";

        strDiv += "  <li class=\"active\">";
        strDiv += "    <a href=\"/TuanGou/\">";
        strDiv += "      <i class=\"icon-dashboard\"></i>";
        strDiv += "      <span class=\"menu-text\">团购页面 </span>";
        strDiv += "    </a>";
        strDiv += "   </li>";

        strDiv += "  <li class=\"active\">";
        strDiv += "    <a href=\"/TuanGou/pay.aspx\">";
        strDiv += "      <i class=\"icon-dashboard\"></i>";
        strDiv += "      <span class=\"menu-text\">支付测试 </span>";
        strDiv += "    </a>";
        strDiv += "   </li>";

        strDiv += " </ul>";

        LeftMenu.InnerHtml = strDiv;

    }

    private bool LoadUserInfo(int iWeChatID)
    {
        bool rValue = false;

        try
        {
            iWeChatID = Convert.ToInt32(Request.Cookies["WeChat_XMFigth"]["USERID"]);
        }
        catch
        {

        }

        if (iWeChatID > 0)
        {
            string strSQL = "Select * from XMFight_Users Where ID=" + iWeChatID;
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    // 临时登录
                    /// 如果数据库有ID，则直接登录。
                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                    Response.Cookies["WeChat_XMFight"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                    Response.Cookies["WeChat_XMFight"]["COPENID"] = OP_Mode.Dtv[0]["WeChatOpenID"].ToString().Trim();
                    Response.Cookies["WeChat_XMFight"]["CNAME"] = OP_Mode.Dtv[0]["Nick"].ToString().Trim();
                    Response.Cookies["WeChat_XMFight"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                    Response.Cookies["WeChat_XMFight"]["HEADURL"] = OP_Mode.Dtv[0]["HeadImage"].ToString().Trim();

                    Response.Cookies["WeChat_XMFight"]["LOGIN"] = "true";

                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CNAME] = OP_Mode.Dtv[0]["Nick"].ToString().Trim();
                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = OP_Mode.Dtv[0]["HeadImage"].ToString().Trim();

                    ///设置COOKIE最长时间
                    //Response.Cookies["WeChat_Question"].Expires = DateTime.MaxValue;


                    /// 给用户ID赋值
                    HiddenField_UserID.Value = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                    //  Label_Nick.Text = OP_Mode.Dtv[0]["Nick"].ToString().Trim();
                    //if (OP_Mode.Dtv[0]["HeadImage"].ToString().Trim().Length > 0)
                    //{
                    //    Image_Header.ImageUrl = OP_Mode.Dtv[0]["HeadImage"].ToString().Trim();
                    //}
                    /// 更新登录时间
                    OP_Mode.SQLRUN("Update XMFight_Users set Ltime=getdate() where ID=" + iWeChatID);
                }
            }
        }

        return rValue;
    }

    /// <summary>
    /// 
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
