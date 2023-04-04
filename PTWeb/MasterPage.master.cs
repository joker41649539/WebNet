using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Web.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{
    ///https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx03159369fc0c71c2&redirect_uri=http%3A%2F%2Fptweb.x76.com.cn%2F&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect\
    ///https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx03159369fc0c71c2&redirect_uri=http%3A%2F%2Fptweb.x76.com.cn%2FWeChat%2FKQ.aspx&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect\


    //https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx03159369fc0c71c2&redirect_uri=http%3A%2F%2Fwww.putian.ink%2Fdefault.aspx&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect
    //https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx03159369fc0c71c2&redirect_uri=https%3A%2F%2Fwww.putian.ink%2Fdefault.aspx&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect

    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public static string DefaultConStr = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

    OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //try
            //{
            //    string LoginID;
            //    LoginID = Request.Cookies["WeChat_Yanwo"]["USERID"].ToString();
            //}
            //catch
            //{
            //    MessageBox("", "您还未登陆，无权查看该页！<br/>请先登陆！", "/Login.aspx");
            //    return;
            //}
            string strURL = Request.Url.AbsoluteUri;
            if (strURL.IndexOf("putian") > -1 || strURL.IndexOf("localhost") > -1 || strURL.IndexOf("10.3.8.123") > -1)
            {
                try
                {
                    if (Request["WeChat"] == "0")
                    {/// 0 表示企业微信
                        WeChatWorkLoad();
                    }
                    else
                    {/// 1 表示正常微信
                        WeChatLoad();
                    }
                    this.Label_Name.Text = HttpUtility.UrlDecode(Request.Cookies["WeChat_Yanwo"]["CNAME"], Encoding.GetEncoding("UTF-8"));

                    string strTemp = Request.Cookies["WeChat_Yanwo"]["HEADURL"];

                    if (strTemp.Length > 0)
                    {
                        this.Image_User.ImageUrl = strTemp;
                    }
                    else
                    {
                        this.Image_User.ImageUrl = "/images/luLogo.png";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox("", "您还未登陆！!!<br/>请先登陆！" + ex.ToString(), "/Login.aspx");
                    return;
                }

                //string weekstr = DateTime.Now.DayOfWeek.ToString();
                //switch (weekstr)
                //{
                //    case "Monday": weekstr = "星期一"; break;
                //    case "Tuesday": weekstr = "星期二"; break;
                //    case "Wednesday": weekstr = "星期三"; break;
                //    case "Thursday": weekstr = "星期四"; break;
                //    case "Friday": weekstr = "星期五"; break;
                //    case "Saturday": weekstr = "星期六"; break;
                //    case "Sunday": weekstr = "星期日"; break;
                //}

                //  Label_Data.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日 ";// + weekstr;

                LoadMenu();
            }
            // LoadQJGG();
        }
        // GetaccessToken();
    }

    /// <summary>
    /// 依据权限加载  左侧菜单列表
    /// </summary>
    private void LoadMenu()
    {
        string strDiv = string.Empty;

        strDiv = "<div class=\"sidebar-shortcuts\" id=\"sidebar-shortcuts\">";
        strDiv += " <div class=\"sidebar-shortcuts-large\" id=\"sidebar-shortcuts-large\">";
        strDiv += "  <button class=\"btn btn-success\">";
        strDiv += "     <i class=\"icon-envelope\"></i>";
        strDiv += "  </button>";

        strDiv += "  <button class=\"btn btn-info\">";
        strDiv += "     <i class=\"icon-tags\"></i>";
        strDiv += "  </button>";

        strDiv += "  <button class=\"btn btn-warning\">";
        strDiv += "      <i class=\"icon-group\"></i>";
        strDiv += "  </button>";

        strDiv += "  <button class=\"btn btn-danger\">";
        strDiv += "      <i class=\"icon-cogs\"></i>";
        strDiv += "  </button>";

        strDiv += " </div>";

        strDiv += "  <div class=\"sidebar-shortcuts-mini\" id=\"sidebar-shortcuts-mini\">";
        strDiv += "   <span class=\"btn btn-success\"></span>";

        strDiv += "   <span class=\"btn btn-info\"></span>";

        strDiv += "   <span class=\"btn btn-warning\"></span>";

        strDiv += "   <span class=\"btn btn-danger\"></span>";

        strDiv += "  </div>";
        strDiv += "</div>";

        strDiv += "<ul class=\"nav nav-list\">";

        string strURL = HttpContext.Current.Request.Url.AbsolutePath.ToString().Substring(0, HttpContext.Current.Request.Url.AbsolutePath.ToString().IndexOf("/", 1) + 1);

        string strURLAll = HttpContext.Current.Request.Url.AbsolutePath.ToString();

        string LoginID = string.Empty;

        try
        {
            LoginID = Request.Cookies["WeChat_Yanwo"]["USERID"].ToString();
        }
        catch
        {
            MessageBox("", "您还未登陆，无权查看该页！<br/>请先登陆！！！", "/Login.aspx");
            return;
        }
        string strSQL = string.Empty;
        if (LoginID == "-24")
        {
            strSQL = "SELECT (SELECT count(ID) FROM S_MK WHERE S_MK.ID=A.id and (A.MKZX='" + strURL + "' OR A.MKZX='" + strURLAll + "' )) Selected,MKMC,MKZX,JDPX,CS,ICO ,A.id From S_MK A where SHOW=0 ORDER BY JDPX ";
        }
        else
        {
            strSQL = "SELECT (SELECT count(ID) FROM S_MK WHERE S_MK.ID=A.id and (A.MKZX='" + strURL + "' OR A.MKZX='" + strURLAll + "' )) Selected,MKMC,MKZX,JDPX,CS,ICO ,A.id";
            strSQL += " from S_MK A,S_QXZ,S_QXZZB,S_YH_QXZ ";
            strSQL += " where A.ID=S_QXZZB.QXID and S_QXZ.ID=S_QXZZB.QXZID and S_QXZ.ID=S_YH_QXZ.QXZID and USERID=" + LoginID + " and JDPX IS NOT NULL AND JDPX<>'' AND SHOW=0  ";
            strSQL += " GROUP BY MKMC,MKZX,JDPX,CS,ICO,A.id ORDER BY JDPX ";
        }
        string strClass = "icon-dashboard";

        string strZCD = string.Empty;

        string strXLAN = string.Empty;

        string strULJW = string.Empty;

        string strActive = string.Empty;

        int JDCS = 0;
        int JDCSUP = 0;
        int JDCSDown = 0;

        OP_Mode.Dtv1 = null;
        if (OP_Mode.SQLRUN(strSQL, "LeftMenu"))
        {

            for (int num = 0; num < OP_Mode.Dtv1.Count; num++)
            {

                JDCS = (int)OP_Mode.Dtv1[num]["CS"];

                if ((int)OP_Mode.Dtv1[num]["Selected"] > 0)
                {
                    strActive = " class=\"active\"";
                }
                else
                {
                    strActive = string.Empty;
                }

                if (num > 1)
                {
                    JDCSUP = (int)OP_Mode.Dtv1[num - 1]["CS"];
                }
                else
                {
                    JDCSUP = 0;
                }


                if (num + 1 < OP_Mode.Dtv1.Count)
                {
                    JDCSDown = (int)OP_Mode.Dtv1[num + 1]["CS"];
                }
                else
                {
                    JDCSDown = 0;
                }

                ///////////////////////////////////////////////
                if (JDCSDown > JDCS)  /// 有子菜单的显示向下图标
                {
                    strZCD = " <b class=\"arrow icon-angle-down\"></b>";
                }
                else
                {
                    strZCD = "";
                }

                /// 设置默认ICO图标
                if (OP_Mode.Dtv1[num]["ICO"].ToString().Length > 0)
                {
                    strClass = OP_Mode.Dtv1[num]["ICO"].ToString().Trim();
                }
                else
                {
                    strClass = "icon-dashboard";
                }

                /// 正常格式输出; class=\"active\"
                strDiv += "<li " + strActive + ">";
                strDiv += "  <a  class=\"dropdown-toggle\" href=\"" + OP_Mode.Dtv1[num]["MKZX"].ToString().Trim() + "\">";
                strDiv += "   <i class=\"" + strClass + "\"></i>";
                strDiv += "   <span class=\"menu-text\">" + OP_Mode.Dtv1[num]["MKMC"].ToString().Trim() + "</span>";
                strDiv += strZCD;
                strDiv += "  </a>";

                if (JDCSDown > JDCS)
                {
                    strDiv += " <ul class=\"submenu\">";
                }
                else
                {
                    if (num != OP_Mode.Dtv1.Count)
                    {
                        strDiv += "</li>";
                    }
                }

                if (num == OP_Mode.Dtv1.Count - 1)
                {
                    for (int ii = 1; ii < JDCS; ii++)
                    {
                        strDiv += "</ul></li>";
                    }
                    /// 添加BUG处理模块
                    strDiv += "<li>  <a  class=\"dropdown-toggle\" href=\"/bug/\">   <i class=\"icon-dashboard\"></i>   <span class=\"menu-text\">操作故障反映</span> <b class=\"arrow icon-angle-down\"></b>  </a> <ul class=\"submenu\"><li  class=\"active\">  <a  class=\"dropdown-toggle\" href=\"/BUG/\">   <i class=\"icon-dashboard\"></i>   <span class=\"menu-text\">故障列表</span>  </a></li></ul></li>";

                    strDiv += "<li class=\"active\"><a class=\"dropdown-toggle\" href=\"#\"><img src=\"/images/luLogo.png\" width=\"25px\" /><span class=\"menu-text\">&nbsp;备案信息</span> <b class=\"arrow icon-angle-down\"></b></a>";
                    strDiv += "     <ul class=\"submenu\">";
                    strDiv += "         <li><a class=\"dropdown-toggle\" target=\"_blank\" href=\"https://beian.miit.gov.cn\"><i class=\"icon-coffee\"></i><span class=\"menu-text\">晥ICP备2021004456号</span>  </a></li>";
                    strDiv += "         <li><a class=\"dropdown-toggle\" href=\"#\"><i class=\"icon-male\"></i><span class=\"menu-text\">合肥普田科技</span>  </a></li>";
                    strDiv += "     </ul>";
                    strDiv += "</li>";
                    strDiv += "<li class=\"active\"><a class=\"dropdown-toggle\" href=\"#\"><img src=\"/images/luLogo.png\" width=\"25px\" /><span class=\"menu-text\">&nbsp;版本信息</span> <b class=\"arrow icon-angle-down\"></b></a>";
                    strDiv += "     <ul class=\"submenu\">";
                    strDiv += "         <li><a class=\"dropdown-toggle\" target=\"_blank\" href=\"http://www.x76.com.cn\"><i class=\"icon-coffee\"></i><span class=\"menu-text\">&copy; 合肥星期陆</span>  </a></li>";
                    strDiv += "         <li><a class=\"dropdown-toggle\" href=\"#\"><i class=\"icon-male\"></i><span class=\"menu-text\">陆晓钧</span>  </a></li>";
                    strDiv += "         <li><a class=\"dropdown-toggle\" href=\"tel://18019961118\"><i class=\"icon-phone\"></i><span class=\"menu-text\">18019961118</span>  </a></li>";
                    strDiv += "         <li><a class=\"dropdown-toggle\" href=\"LoginOut.aspx\"><i class=\"icon-phone\"></i><span class=\"menu-text\">退出系统</span>  </a></li>";
                    strDiv += "     </ul>";
                    strDiv += "</li>";
                    strDiv += "</ul>";
                }
                else
                {
                    if (JDCS > JDCSDown)
                    {
                        for (int ii = JDCSDown; ii < JDCS; ii++)
                        {
                            strDiv += "</ul></li>";
                        }
                    }
                }

                strActive = string.Empty;
            }
        }

        strDiv += "<div class=\"sidebar-collapse\" id=\"sidebar-collapse\">";
        strDiv += "   <i class=\"icon-double-angle-left\" data-icon1=\"icon-double-angle-left\" data-icon2=\"icon-double-angle-right\"></i>";
        strDiv += "</div>";

        strDiv += "<script type=\"text/javascript\">";
        strDiv += " try { ace.settings.check('sidebar', 'collapsed') } catch (e) { }";
        strDiv += "</script>";

        this.sidebar.InnerHtml = strDiv;

    }

    /// <summary>
    /// 退出登录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        HttpCookie aCookie;
        string cookieName;
        int limit = Request.Cookies.Count;
        for (int i = 0; i < limit; i++)
        {
            cookieName = Request.Cookies[i].Name;
            aCookie = new HttpCookie(cookieName);
            aCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(aCookie);
        }

        MessageBox("", "您已成功退出系统！<br/>谢谢使用！", "/Login.aspx");

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

        //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='" + sTemp + "';document.getElementById('MSGTitle').innerHTML='" + sKey + "'", true);
        //this.Page.ClientScript.RegisterStartupScript(typeof(string), sKey, "<script language=JavaScript>$('#MSG').modal('show')</script>");

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

        //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='" + sTemp + "';document.getElementById('MSGTitle').innerHTML='" + sKey + "'", true);
        //this.Page.ClientScript.RegisterStartupScript(typeof(string), sKey, "<script language=JavaScript>$('#MSG').modal('show');$(function () {$('#MSG').on('hide.bs.modal', function () {setTimeout(parent.location.href = '" + sURL + "', 0);})});</script>");

    }

    /// <summary>
    /// 关闭全局公告
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_Close_Click(object sender, EventArgs e)
    {
        this.DivQJGG_body.Visible = false;
        try
        {
            HttpCookie cok = Request.Cookies[Constant.COOKIENAMEUSER];
            cok.Values.Set(Constant.COOKIENAMEUSER_QJGG, "Showed");
            Response.AppendCookie(cok);
        }
        catch
        {

        }
    }
    private string GetWorkToken()
    {
        string sValue = string.Empty, strSQL;
        string AppId = WebConfigurationManager.AppSettings["AgentId"];//与企业微信ID。
        string AppSecret = WebConfigurationManager.AppSettings["Secret"];
        string MSG = string.Empty;

        var client = new System.Net.WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        strSQL = "SELECT * FROM S_TYDM where ITYDMLB=3 and DATEDIFF(MI, LTIME, GETDATE()) < 0";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {/// Token 未过期，直接使用
                sValue = OP_Mode.Dtv[0]["CTYDMZ"].ToString();
            }
            else
            { /// Token 已过期，从新读取
                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", AppId, AppSecret);
                var data = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();
                var obj = serializer.Deserialize<Dictionary<string, string>>(data);

                if (!obj.TryGetValue("access_token", out sValue))
                {
                    foreach (var key in obj.Keys)
                    {
                        MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
                    }
                }
                else
                {

                    strSQL = "UPDATE S_TYDM SET CTIME=GETDATE(), LTIME = DATEADD(S," + obj["expires_in"] + ",GETDATE()),CTYDMZ='" + sValue + "' WHERE ITYDMLB=3";

                    if (OP_Mode.SQLRUN(strSQL))
                    {

                    }
                }
            }
        }

        return sValue;

    }
    /// <summary>
    /// 企业微信登录
    /// </summary>
    private void WeChatWorkLoad()
    {
        string accessToken = string.Empty;
        string DeBugMsg = string.Empty;

        string AppId = WebConfigurationManager.AppSettings["AgentId"];//与企业微信ID。
        string AppSecret = WebConfigurationManager.AppSettings["Secret"];

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

        if (string.IsNullOrEmpty(code))
        {

        }
        else
        {
            string strWeixin_OpenID = string.Empty;

            string STRUSERID = string.Empty;

            if (strWeixin_OpenID == string.Empty || STRUSERID == string.Empty)
            {
                accessToken = GetWorkToken();

                if (accessToken.Length <= 0)
                {
                    MessageBox("", "您非企业员工！<br/>请先登陆！", "/Login.aspx");
                    return;
                }

                DeBugMsg += "<br> 没有所需的OPENID！";

                // this.Label1.Text = "没有所需的OPENID";
                var client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                //var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", AppId, AppSecret);
                //var data = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();
                //var obj = serializer.Deserialize<Dictionary<string, string>>(data);

                //if (!obj.TryGetValue("access_token", out accessToken))
                //{
                //    DeBugMsg += "<br> Token获取错误！";
                //}
                //else
                //{
                //    //opentid = obj["openid"];
                //    //MessageBox("", "opentid：" + opentid);
                //}
                // string tempToken = GetaccessWebToken(code);

                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}", accessToken, code);
                var data = client.DownloadString(url);
                var userInfo = serializer.Deserialize<Dictionary<string, object>>(data);
                DeBugMsg += "userInfo：" + data.ToString();

                //                {
                //                    "errcode": 0,
                //   "errmsg": "ok",
                //   "UserId":"USERID",// 企业用户         OpenId// 非企业会员
                //   "DeviceId":"DEVICEID"
                //}

                string UserName = "testName";
                string HeadUserUrl = "";
                string Mobile = "";
                int vsex = 2;
                try
                {
                    /// 企业用户
                    opentid = userInfo["UserId"].ToString();
                    url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}", accessToken, opentid);
                    data = client.DownloadString(url);
                    var userInfo2 = serializer.Deserialize<Dictionary<string, object>>(data);//gender 性别。0表示未定义，1表示男性，2表示女性
                    UserName = userInfo2["name"].ToString();
                    HeadUserUrl = userInfo2["thumb_avatar"].ToString();
                    Mobile = userInfo2["mobile"].ToString();
                    vsex = Convert.ToInt32(userInfo2["gender"]);

                    //         Label2.Text = "姓名：" + userInfo2["name"].ToString() + "<br>性别：" + userInfo2["gender"].ToString() + "<br>头像：" + userInfo2["thumb_avatar"].ToString();
                }
                catch
                {
                    /// 出错了，则是非企业用户
                    MessageBox("", "您非企业员工！<br/>请先登陆！", "/Login.aspx");
                    return;
                }



                //var vcity = "中国";

                //if (userInfo["sex"].ToString() == "1")
                //{
                //    vsex = 0;
                //}

                //vcity = userInfo["country"].ToString() + userInfo["province"].ToString() + userInfo["city"].ToString();
                //DeBugMsg += "城市：" + vcity;
                //if (opentid.Length == 0)
                //{
                //    opentid = "test111";
                //}

                //UserName = userInfo["nickname"].ToString();
                //DeBugMsg += "昵称：" + UserName;
                //HeadUserUrl = userInfo["headimgurl"].ToString();

                //DeBugMsg += "头像：" + HeadUserUrl;


                string strSQL;
                strSQL = " Select * from S_USERINFO where COPENID='" + opentid.ToString() + "'";

                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        if (Convert.ToInt32(OP_Mode.Dtv[0]["flag"]) != 0)
                        {
                            MessageBox("", "您被禁止登陆！<br>请联系管理员。", "/Login.aspx");
                            return;
                        }

                        /// 如果数据库有ID，则直接登录。
                        Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                        Response.Cookies["WeChat_Yanwo"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                        Response.Cookies["WeChat_Yanwo"]["COPENID"] = opentid.ToString();
                        Response.Cookies["WeChat_Yanwo"]["CNAME"] = HttpUtility.UrlEncode(UserName);
                        Response.Cookies["WeChat_Yanwo"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                        Response.Cookies["WeChat_Yanwo"]["HEADURL"] = HeadUserUrl;

                        Response.Cookies["WeChat_Yanwo"]["LOGIN"] = "true";

                        Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CNAME] = UserName;
                        Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = HeadUserUrl;

                        ///设置COOKIE最长时间
                        Response.Cookies["WeChat_Yanwo"].Expires = DateTime.MaxValue;

                        /// 更新登录时间
                        OP_Mode.SQLRUN("Update S_USERINFO set Ltime=getdate(),SSDZ='" + Mobile + "',HEADURL='" + HeadUserUrl + "' where COPENID='" + opentid.ToString() + "'");

                        return;
                    }
                    else
                    {
                        try
                        {

                            strSQL = " INSERT INTO S_USERINFO (LOGINNAME,PASSWORD,COPENID,CNAME,HEADURL,XB,SSDZ,flag) VALUES ('" + opentid + "','" + opentid + "','" + opentid + "','" + UserName + "','" + HeadUserUrl + "'," + vsex + ",'" + Mobile + "',0)";

                            strSQL += " Select * from S_USERINFO where COPENID='" + opentid + "'";

                            DeBugMsg += "+" + strSQL + "+";

                            if (OP_Mode.SQLRUN(strSQL))
                            {
                                if (OP_Mode.Dtv.Count > 0)
                                {
                                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["COPENID"] = OP_Mode.Dtv[0]["COPENID"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["CNAME"] = HttpUtility.UrlEncode(OP_Mode.Dtv[0]["CNAME"].ToString()); //HttpUtility.UrlDecode(Request.Cookies["SK_WZGY"]["CNAME"].ToString().Trim(), Encoding.GetEncoding("UTF-8"))
                                    Response.Cookies["WeChat_Yanwo"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["HEADURL"] = OP_Mode.Dtv[0]["HEADURL"].ToString().Trim();

                                    Response.Cookies["WeChat_Yanwo"][Constant.COOKIENAMEUSER_CNAME] = OP_Mode.Dtv[0]["CNAME"].ToString().Trim();
                                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = OP_Mode.Dtv[0]["HEADURL"].ToString().Trim();

                                    Response.Cookies["WeChat_Yanwo"]["LOGIN"] = "true";
                                    Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_LGOIN] = "true";
                                    ///设置COOKIE最长时间  不设置时间，窗口关闭则丢失
                                    Response.Cookies["WeChat_Yanwo"].Expires = DateTime.MaxValue;

                                    string MSG = string.Empty;// string.Format("<img class=\"img-rounded\" src=\"{1}\" width=\"60PX\" />欢迎 {0} 注册成功。<br/>祝您生活愉快。", OP_Mode.Dtv[0]["CNAME"].ToString(), OP_Mode.Dtv[0]["HEADURL"].ToString());

                                    MSG = "<img class=\"img-rounded\" src=\"" + OP_Mode.Dtv[0]["HEADURL"].ToString() + "\" width=\"60PX\" />欢迎 " + OP_Mode.Dtv[0]["CNAME"].ToString() + " 注册成功。<br/>祝您生活愉快。";

                                    MessageBox("", MSG);

                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DeBugMsg += "<br>" + ex.ToString();
                            MessageBox("", "4：" + DeBugMsg);
                        }
                    }
                }
                else
                {
                    DeBugMsg += OP_Mode.strErrMsg;
                    MessageBox("", "5：" + DeBugMsg);
                }

            }
        }
    }

    /// <summary>
    /// 微信登录
    /// </summary>
    private void WeChatLoad()
    {
        string accessToken = string.Empty;
        string DeBugMsg = string.Empty;

        string AppId = WebConfigurationManager.AppSettings["CorpId"];//与微信公众账号后台的AppId设置保持一致，区分大小写。
        string AppSecret = WebConfigurationManager.AppSettings["WeixinAppSecret"];

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
                    //MessageBox("", "opentid：" + opentid);
                }

                // string tempToken = GetaccessWebToken(code);

                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", accessToken, opentid);
                data = client.DownloadString(url);
                var userInfo = serializer.Deserialize<Dictionary<string, object>>(data);
                DeBugMsg += "userInfo：" + data.ToString();
                int vsex = 2;

                var vcity = "中国";

                if (userInfo["sex"].ToString() == "1")
                {
                    vsex = 0;
                }

                vcity = userInfo["country"].ToString() + userInfo["province"].ToString() + userInfo["city"].ToString();
                DeBugMsg += "城市：" + vcity;
                if (opentid.Length == 0)
                {
                    opentid = "test111";
                }
                string UserName = "testName";
                string HeadUserUrl = "";

                UserName = userInfo["nickname"].ToString();
                DeBugMsg += "昵称：" + UserName;
                HeadUserUrl = userInfo["headimgurl"].ToString();

                DeBugMsg += "头像：" + HeadUserUrl;


                string strSQL;
                strSQL = " Select * from S_USERINFO where OPENID='" + opentid.ToString() + "'";

                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        if (Convert.ToInt32(OP_Mode.Dtv[0]["flag"]) != 0)
                        {
                            MessageBox("", "您被禁止登陆！<br>请联系管理员。", "/Login.aspx");
                            return;
                        }
                        /// 如果数据库有ID，则直接登录。
                        Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                        Response.Cookies["WeChat_Yanwo"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                        Response.Cookies["WeChat_Yanwo"]["COPENID"] = opentid.ToString();
                        Response.Cookies["WeChat_Yanwo"]["CNAME"] = HttpUtility.UrlEncode(UserName);
                        Response.Cookies["WeChat_Yanwo"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                        Response.Cookies["WeChat_Yanwo"]["HEADURL"] = HeadUserUrl;

                        Response.Cookies["WeChat_Yanwo"]["LOGIN"] = "true";

                        Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CNAME] = UserName;
                        Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = HeadUserUrl;

                        ///设置COOKIE最长时间
                        Response.Cookies["WeChat_Yanwo"].Expires = DateTime.MaxValue;

                        /// 更新登录时间
                        OP_Mode.SQLRUN("Update S_USERINFO set Ltime=getdate(),HEADURL='" + HeadUserUrl + "',XB=" + vsex + " where OPENID='" + opentid.ToString() + "'");

                        return;
                    }
                    else
                    {
                        try
                        {

                            strSQL = " INSERT INTO S_USERINFO (LOGINNAME,PASSWORD,OPENID,CNAME,HEADURL,XB) VALUES ('" + opentid + "','" + opentid + "','" + opentid + "','" + UserName + "','" + HeadUserUrl + "'," + vsex + ")";

                            strSQL += " Select * from S_USERINFO where OPENID='" + opentid + "'";

                            DeBugMsg += "+" + strSQL + "+";

                            if (OP_Mode.SQLRUN(strSQL))
                            {
                                if (OP_Mode.Dtv.Count > 0)
                                {
                                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["COPENID"] = OP_Mode.Dtv[0]["OPENID"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["CNAME"] = HttpUtility.UrlEncode(OP_Mode.Dtv[0]["CNAME"].ToString()); //HttpUtility.UrlDecode(Request.Cookies["SK_WZGY"]["CNAME"].ToString().Trim(), Encoding.GetEncoding("UTF-8"))
                                    Response.Cookies["WeChat_Yanwo"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["HEADURL"] = OP_Mode.Dtv[0]["HEADURL"].ToString().Trim();

                                    Response.Cookies["WeChat_Yanwo"][Constant.COOKIENAMEUSER_CNAME] = OP_Mode.Dtv[0]["CNAME"].ToString().Trim();
                                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = OP_Mode.Dtv[0]["HEADURL"].ToString().Trim();

                                    Response.Cookies["WeChat_Yanwo"]["LOGIN"] = "true";
                                    Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_LGOIN] = "true";
                                    ///设置COOKIE最长时间  不设置时间，窗口关闭则丢失
                                    Response.Cookies["WeChat_Yanwo"].Expires = DateTime.MaxValue;

                                    string MSG = string.Empty;// string.Format("<img class=\"img-rounded\" src=\"{1}\" width=\"60PX\" />欢迎 {0} 注册成功。<br/>祝您生活愉快。", OP_Mode.Dtv[0]["CNAME"].ToString(), OP_Mode.Dtv[0]["HEADURL"].ToString());

                                    MSG = "<img class=\"img-rounded\" src=\"" + OP_Mode.Dtv[0]["HEADURL"].ToString() + "\" width=\"60PX\" />欢迎 " + OP_Mode.Dtv[0]["CNAME"].ToString() + " 注册成功。<br/>祝您生活愉快。";

                                    MessageBox("", MSG);

                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DeBugMsg += "<br>" + ex.ToString();
                            MessageBox("", "4：" + DeBugMsg);
                        }
                    }
                }
                else
                {
                    DeBugMsg += OP_Mode.strErrMsg;
                    MessageBox("", "5：" + DeBugMsg);
                }

            }
        }
        //  MessageBox("", DeBugMsg);
    }
}
