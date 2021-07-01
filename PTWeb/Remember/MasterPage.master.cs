using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Remember_MasterPage : System.Web.UI.MasterPage
{   /// <summary>
    /// 数据库连接字符串  15255466664
    /// </summary>
    public static string DefaultConStr = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

    OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    protected void Page_Load(object sender, EventArgs e)
    {
        WeChatLoad();
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            label_UserName.Text = Request.Cookies["WeChat_Yanwo"]["CNAME"];
        }
        catch
        {

        }
        string strSQL = "Select count(ID) DayCount,(Select count(ID) from Remember Where ltime>'" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' and NextTime >='" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + ") FinshCount from Remember Where NextTime < '" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iFlag=0 And iUserID = " + DefaultUser + "";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                if (Convert.ToInt32(OP_Mode.Dtv[0][0]) > 0)
                {
                    Label_DayCount.Text = OP_Mode.Dtv[0][0].ToString();
                    Label_DayCount.Visible = true;
                }
                else
                {
                    Label_DayCount.Visible = false;
                }
                if (Convert.ToInt32(OP_Mode.Dtv[0][1]) > 0)
                {
                    Label_Finsh.Text = OP_Mode.Dtv[0][1].ToString();
                    Label_Finsh.Visible = true;
                }
                else
                {
                    Label_Finsh.Visible = false;
                }
            }
            try
            {
                label_UserName.Text = Request.Cookies["WeChat_Yanwo"]["CNAME"].ToString();
            }
            catch
            {

            }
        }

    }
    /// <summary>
    /// 当前用户
    /// </summary>
    public string DefaultUser
    {
        get
        {
            string rValue = string.Empty;
            try
            {
                rValue = Request.Cookies["WeChat_Yanwo"]["USERID"];
                LinkButton1.Visible = true;
                LinkButton1.PostBackUrl = "/Remember/LoginOut.aspx";
                LinkButton2.Visible = false;
                LinkButton2.PostBackUrl = "#";
            }
            catch
            {
                LinkButton1.Visible = false;
                LinkButton1.PostBackUrl = "/Remember/LoginOut.aspx";
                LinkButton2.Visible = true;
                LinkButton2.PostBackUrl = "/Remember/Login.aspx";
            }
            return rValue;
        }
    }
    /// <summary>
    /// 微信登录
    /// </summary>
    private void WeChatLoad()
    {
        string accessToken = string.Empty;
        string DeBugMsg = string.Empty;
        // 东之燕 账号
        string AppId = "wxf60778eb4d1003de";//与微信公众账号后台的AppId设置保持一致，区分大小写。
        string AppSecret = "21c72eab57d27d92cdc87870d350fd01";

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
        // https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxd78bac9aa2b77eec&redirect_uri=http://ptweb.x76.com.cn/Fil&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect
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
                strSQL = " Select * from Remember_User where COPENID='" + opentid.ToString() + "'";

                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
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

                        /// 账号赋值
                        label_UserName.Text = UserName;

                        ///设置COOKIE最长时间
                        Response.Cookies["WeChat_Yanwo"].Expires = DateTime.MaxValue;

                        /// 更新登录时间
                        OP_Mode.SQLRUN("Update Remember_User set Ltime=getdate(),HEADURL='" + HeadUserUrl + "' where COPENID='" + opentid.ToString() + "'");

                        return;
                    }
                    else
                    {
                        try
                        {

                            strSQL = " INSERT INTO Remember_User (LOGINNAME,PASSWORD,HEADURL,COPENID,CNAME) VALUES ('" + opentid + "','" + opentid + "','" + HeadUserUrl + "','" + opentid + "','" + UserName + "')";

                            strSQL += " Select * from Remember_User where COPENID='" + opentid + "'";

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

                                    /// 账号赋值
                                    label_UserName.Text = UserName;
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
            if (DeBugMsg.Length > 0)
            {
                MessageBox("", DeBugMsg);
            }
        }

    }
    /// <summary>
    /// 姓名
    /// </summary>
    public string UserNAME
    {
        get
        {
            string rValue = "游 客";

            try
            {
                rValue = HttpUtility.UrlDecode(Request.Cookies["WeChat_Yanwo"]["CNAME"]);
                LinkButton1.Visible = true;
                LinkButton1.PostBackUrl = "/Remember/LoginOut.aspx";
                LinkButton2.Visible = false;
                LinkButton2.PostBackUrl = "#";
            }
            catch
            {
                LinkButton1.Visible = false;
                LinkButton1.PostBackUrl = "/Remember/LoginOut.aspx";
                LinkButton2.Visible = true;
                LinkButton2.PostBackUrl = "/Remember/Login.aspx";
            }
            return rValue;
        }
    }

    public string HeadUrl
    {
        get
        {
            string rValue = "/images/lulogoY.png";
            try
            {
                rValue = Request.Cookies["WeChat_Yanwo"]["HEADURL"];
                if (rValue.Length < 3)
                {
                    rValue = "/images/lulogoY.png";
                }
            }
            catch (Exception ex)
            {
                //MessageBox("", "错误？" + ex.ToString());
            }
            return rValue;
        }
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
