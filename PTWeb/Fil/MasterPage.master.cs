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
            WeChatLoad();

            LoadUserInfo();
            // MessageBox("消息提示","测试信息");
        }
    }

    private bool LoadUserInfo()
    {
        bool rValue = false;

        int iWeChatID = 0;

        try
        {
            iWeChatID = Convert.ToInt32(Request.Cookies["WeChat_Yanwo"]["USERID"]);
        }
        catch
        {

        }

        if (iWeChatID > 0)
        {
            string strSQL = "Select * from Fil_Users Where ID=" + iWeChatID;
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    // 临时登录
                    /// 如果数据库有ID，则直接登录。
                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                    Response.Cookies["WeChat_Yanwo"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                    Response.Cookies["WeChat_Yanwo"]["COPENID"] = OP_Mode.Dtv[0]["WeChatOpenID"].ToString().Trim();
                    Response.Cookies["WeChat_Yanwo"]["CNAME"] = OP_Mode.Dtv[0]["Nick"].ToString().Trim();
                    Response.Cookies["WeChat_Yanwo"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                    Response.Cookies["WeChat_Yanwo"]["HEADURL"] = OP_Mode.Dtv[0]["HeadImage"].ToString().Trim();

                    Response.Cookies["WeChat_Yanwo"]["LOGIN"] = "true";

                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CNAME] = OP_Mode.Dtv[0]["Nick"].ToString().Trim();
                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = OP_Mode.Dtv[0]["HeadImage"].ToString().Trim();

                    ///设置COOKIE最长时间
                    Response.Cookies["WeChat_Yanwo"].Expires = DateTime.MaxValue;


                    /// 给用户ID赋值
                    HiddenField_UserID.Value = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                    Label_Nick.Text = OP_Mode.Dtv[0]["Nick"].ToString().Trim();
                    if (OP_Mode.Dtv[0]["HeadImage"].ToString().Trim().Length > 0)
                    {
                        Image_Header.ImageUrl = OP_Mode.Dtv[0]["HeadImage"].ToString().Trim();
                    }
                    /// 更新登录时间
                    OP_Mode.SQLRUN("Update Fil_Users set Ltime=getdate() where ID=" + iWeChatID);
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
        // 黑瞳账号密码
        string AppId = "wxd78bac9aa2b77eec";//与微信公众账号后台的AppId设置保持一致，区分大小写。
        string AppSecret = "a7a3a066532e3916307fa426dd39a3ca";

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
                strSQL = " Select * from Fil_Users where WeChatOpenID='" + opentid.ToString() + "'";

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
                        OP_Mode.SQLRUN("Update Fil_Users set Ltime=getdate(),HEADImage='" + HeadUserUrl + "' where WeChatOpenID='" + opentid.ToString() + "'");

                        return;
                    }
                    else
                    {
                        try
                        {

                            strSQL = " INSERT INTO Fil_Users (Nick,HEADImage,WeChatOpenID,WeChatName) VALUES ('" + UserName + "','" + HeadUserUrl + "','" + opentid + "','" + UserName + "')";

                            strSQL += " Select * from Fil_Users where WeChatOpenID='" + opentid + "'";

                            DeBugMsg += "+" + strSQL + "+";

                            if (OP_Mode.SQLRUN(strSQL))
                            {
                                if (OP_Mode.Dtv.Count > 0)
                                {
                                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["COPENID"] = OP_Mode.Dtv[0]["WeChatOpenID"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["CNAME"] = HttpUtility.UrlEncode(OP_Mode.Dtv[0]["WeChatName"].ToString()); //HttpUtility.UrlDecode(Request.Cookies["SK_WZGY"]["CNAME"].ToString().Trim(), Encoding.GetEncoding("UTF-8"))
                                    Response.Cookies["WeChat_Yanwo"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                                    Response.Cookies["WeChat_Yanwo"]["HEADURL"] = OP_Mode.Dtv[0]["HEADImage"].ToString().Trim();

                                    Response.Cookies["WeChat_Yanwo"][Constant.COOKIENAMEUSER_CNAME] = OP_Mode.Dtv[0]["WeChatName"].ToString().Trim();
                                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = OP_Mode.Dtv[0]["HEADImage"].ToString().Trim();

                                    Response.Cookies["WeChat_Yanwo"]["LOGIN"] = "true";
                                    Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_LGOIN] = "true";
                                    ///设置COOKIE最长时间  不设置时间，窗口关闭则丢失
                                    Response.Cookies["WeChat_Yanwo"].Expires = DateTime.MaxValue;

                                    string MSG = string.Empty;// string.Format("<img class=\"img-rounded\" src=\"{1}\" width=\"60PX\" />欢迎 {0} 注册成功。<br/>祝您生活愉快。", OP_Mode.Dtv[0]["CNAME"].ToString(), OP_Mode.Dtv[0]["HEADURL"].ToString());

                                    MSG = "<img class=\"img-rounded\" src=\"" + OP_Mode.Dtv[0]["HEADImage"].ToString() + "\" width=\"60PX\" />欢迎 " + OP_Mode.Dtv[0]["CNAME"].ToString() + " 注册成功。<br/>祝您生活愉快。";

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
            if (DeBugMsg.Length > 0)
            {
                MessageBox("", DeBugMsg);
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
