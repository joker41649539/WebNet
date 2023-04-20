using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            if (strURL.IndexOf("localhost") > -1)
            {/// 测试程序，默认ID
                LoadUserInfo(6);
            }
            else
            {
                //  LoadUserInfo();
                WeChatLoad();
                ////  MessageBox("消息提示", "测试信息");
            }
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
        strTemp += "  <li  style=\"width:33%\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/TuanGou/Offer.aspx?ID=1\"><i class=\"icon-home\"></i>首页</a></li>";
        strTemp += "  <li  style=\"width:33%\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/TuanGou/\"><i class=\"icon-credit-card\"></i>我的订单</a></li>";
        strTemp += "  <li  style=\"width:33%\"><a class=\"btn btn-app btn-white btn-xs\" href=\"/TuanGou/Contact.aspx\"><i class=\"icon-info\"></i>关于我们</a></li>";
        //strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/TuanGou/pay.aspx\"><i class=\"icon-book\"></i>测试付款</a></li>";
        // strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/TuanGou/\"><i class=\"icon-comments\"></i>联系我们</a></li>";
        // strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/Question/UserInfo.aspx\"><i class=\"icon-exclamation-sign\"></i>个人信息</a></li>";
        // strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/Question/#\"><i class=\" icon-exclamation-sign\"></i>帮助信息</a></li>";

        if (iUserID == 7 || iUserID == 6)
        {
            ManageMenu();
            LeftMenu.Visible = true;
            strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/XMFight/Manage/Class.aspx\"><i class=\"icon-calendar\"></i>课程管理</a></li>";
            strTemp += "  <li><a class=\"btn btn-app btn-white btn-xs\" href=\"/XMFight/Manage/Bance.aspx\"><i class=\"icon-bar-chart\"></i>盈利报表</a></li>";
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
        strDiv += "    <a href='/TuanGou/OfferAdd.aspx' >";
        strDiv += "      <i class=\"icon-dashboard\"></i>";
        strDiv += "      <span class=\"menu-text\">添加团购信息</span>";
        strDiv += "    </a>";
        strDiv += "   </li>";
        strDiv += "  <li class=\"active\">";
        strDiv += "    <a href='/TuanGou/Offers.aspx' >";
        strDiv += "      <i class=\"icon-dashboard\"></i>";
        strDiv += "      <span class=\"menu-text\">所有团购信息</span>";
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
    /// 微信登录
    /// </summary>
    private void WeChatLoad()
    {
        string accessToken = string.Empty;
        string DeBugMsg = string.Empty;
        // 旭铭搏击 账号
        string AppId = "wxf60778eb4d1003de";//与微信公众账号后台的AppId设置保持一致，区分大小写。
        string AppSecret = "4224c03a03edeba44cb4aab9b27678be";

        var code = string.Empty;
        var opentid = string.Empty;
        try
        {
            code = Request.QueryString["code"];
            DeBugMsg += "code:" + code;
        }
        catch
        {

        }
        // https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf60778eb4d1003de&redirect_uri=http://ptweb.x76.com.cn/TuanGou/Offer.aspx?ID=1&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect
        if (string.IsNullOrEmpty(code))
        {

        }
        else
        {
            string strWeixin_OpenID = string.Empty;

            string STRUSERID = string.Empty;

            if (strWeixin_OpenID == string.Empty || STRUSERID == string.Empty)
            {
                DeBugMsg += "<br> 没有所需的OPENID！";

                // this.Label1.Text = "没有所需的OPENID";
                var client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", AppId, AppSecret, code);
                var data = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();
                var obj = serializer.Deserialize<Dictionary<string, string>>(data);

                if (!obj.TryGetValue("access_token", out accessToken))
                {
                    DeBugMsg += "<br> Token获取错误！";
                }
                else
                {
                    opentid = obj["openid"];
                    Response.Cookies["WeChat_XMFight"]["COPENID"] = opentid.ToString();

                    //MessageBox("", "opentid：" + opentid);
                }

                //    // string tempToken = GetaccessWebToken(code);

                //    //url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", accessToken, opentid);
                //    //data = client.DownloadString(url);
                //    //var userInfo = serializer.Deserialize<Dictionary<string, object>>(data);
                //    //DeBugMsg += "userInfo：" + data.ToString();
                //    ////int vsex = 2;

                //    ////var vcity = "中国";

                //    ////if (userInfo["sex"].ToString() == "1")
                //    ////{
                //    ////    vsex = 0;
                //    ////}

                //    ////vcity = userInfo["country"].ToString() + userInfo["province"].ToString() + userInfo["city"].ToString();
                //    ////DeBugMsg += "城市：" + vcity;
                //    ////if (opentid.Length == 0)
                //    ////{
                //    ////    opentid = "test111";
                //    ////}
                //    //string UserName = "testName";
                //    //string HeadUserUrl = "";

                //    //UserName = userInfo["nickname"].ToString();
                //    //DeBugMsg += "昵称：" + UserName;
                //    //HeadUserUrl = userInfo["headimgurl"].ToString();

                //    //DeBugMsg += "头像：" + HeadUserUrl;


                //    string strSQL;
                //    strSQL = " Select * from XMFight_Users where WeChatOpenID='" + opentid.ToString() + "'";

                //    if (OP_Mode.SQLRUN(strSQL))
                //    {
                //        if (OP_Mode.Dtv.Count > 0)
                //        {
                //            if (Convert.ToInt32(OP_Mode.Dtv[0]["flag"]) != 0)
                //            {
                //                MessageBox("", "您被禁止登陆！<br>请联系管理员。", "/Login.aspx");
                //                return;
                //            }
                //            /// 如果数据库有ID，则直接登录。
                //            Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                //            Response.Cookies["WeChat_XMFight"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                //            Response.Cookies["WeChat_XMFight"]["COPENID"] = opentid.ToString();
                //            Response.Cookies["WeChat_XMFight"]["CNAME"] = opentid.ToString();
                //            Response.Cookies["WeChat_XMFight"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                //          //  Response.Cookies["WeChat_XMFight"]["HEADURL"] = HeadUserUrl;

                //            Response.Cookies["WeChat_XMFight"]["LOGIN"] = "true";

                //         //   Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CNAME] = UserName;
                //          //  Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = HeadUserUrl;

                //            ///设置COOKIE最长时间
                //        //    Response.Cookies["WeChat_Question"].Expires = DateTime.MaxValue;

                //            /// 更新登录时间
                //            OP_Mode.SQLRUN("Update XMFight_Users set Ltime=getdate() where WeChatOpenID='" + opentid.ToString() + "'");

                //            return;
                //        }
                //        else
                //        {
                //            try
                //            {

                //                strSQL = " INSERT INTO XMFight_Users (Nick,HEADImage,WeChatOpenID) VALUES ('" + opentid + "','" + opentid + "','" + opentid + "')";

                //                strSQL += " Select * from XMFight_Users where WeChatOpenID='" + opentid + "'";

                //                DeBugMsg += "+" + strSQL + "+";

                //                if (OP_Mode.SQLRUN(strSQL))
                //                {
                //                    if (OP_Mode.Dtv.Count > 0)
                //                    {
                //                        Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                //                        Response.Cookies["WeChat_XMFight"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                //                        Response.Cookies["WeChat_XMFight"]["COPENID"] = OP_Mode.Dtv[0]["WeChatOpenID"].ToString().Trim();
                //                        Response.Cookies["WeChat_XMFight"]["CNAME"] = HttpUtility.UrlEncode(OP_Mode.Dtv[0]["Nick"].ToString()); //HttpUtility.UrlDecode(Request.Cookies["SK_WZGY"]["CNAME"].ToString().Trim(), Encoding.GetEncoding("UTF-8"))
                //                        Response.Cookies["WeChat_XMFight"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                //                        Response.Cookies["WeChat_XMFight"]["HEADURL"] = OP_Mode.Dtv[0]["HEADImage"].ToString().Trim();

                //                        Response.Cookies["WeChat_XMFight"][Constant.COOKIENAMEUSER_CNAME] = OP_Mode.Dtv[0]["WeChatName"].ToString().Trim();
                //                        Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = OP_Mode.Dtv[0]["HEADImage"].ToString().Trim();

                //                        Response.Cookies["WeChat_XMFight"]["LOGIN"] = "true";
                //                        Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_LGOIN] = "true";
                //                        ///设置COOKIE最长时间  不设置时间，窗口关闭则丢失
                //                       // Response.Cookies["WeChat_Question"].Expires = DateTime.MaxValue;

                //                        string MSG = string.Empty;// string.Format("<img class=\"img-rounded\" src=\"{1}\" width=\"60PX\" />欢迎 {0} 注册成功。<br/>祝您生活愉快。", OP_Mode.Dtv[0]["CNAME"].ToString(), OP_Mode.Dtv[0]["HEADURL"].ToString());

                //                        //MSG = "<img class=\"img-rounded\" src=\"" + OP_Mode.Dtv[0]["HEADImage"].ToString() + "\" width=\"60PX\" />欢迎 " + OP_Mode.Dtv[0]["Nick"].ToString() + " 注册成功。<br/>祝您生活愉快。";

                //                        //MessageBox("", MSG);

                //                        return;
                //                    }
                //                }
                //            }
                //            catch (Exception ex)
                //            {
                //                DeBugMsg += "<br>" + ex.ToString();
                //               // MessageBox("", "4：" + DeBugMsg);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        DeBugMsg += OP_Mode.strErrMsg;
                //       // MessageBox("", "5：" + DeBugMsg);
                //    }

                //}
                //if (DeBugMsg.Length > 0)
                //{
                //   // MessageBox("", DeBugMsg);
            }
        }

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
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '" + sKey + "', 'content': '" + sTemp + "', 'modal': true, 'buttons': { '确定': function () {dialog.destroy();dialog.close();} } })</script>");
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
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '" + sKey + "', 'content': '" + sTemp + "', 'modal': true, 'buttons': { '确定': function () { location.href=\"" + sURL + "\"; } } })</script>");
    }

}
