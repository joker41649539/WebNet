using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Net;
using System.IO;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Web.Configuration;
using System.Xml;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class PageBaseRem : System.Web.UI.Page
{
    public static string DefaultConStr = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

    public static OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    // OpModeJBZ OP_ModeJBZ = new OpModeJBZ(JBZConStr, 0);

    #region "Web Service"

    //    public localhost.Service WebService = new localhost.Service();

    #endregion

    /// <summary>
    /// 权限判断后跳转的页面
    /// </summary>
    public static string Defaut_QX_URL = "/Remember/Default.aspx";

    /// <summary>
    /// 依据权限ID和用户ID判断是否有此功能权限。有返回TURE，反之返回FALSE;
    /// </summary>
    /// <param name="iQXZ">需判断的权限ID</param>
    /// <param name="IUSER">用户ID</param>
    /// <returns></returns>
    public bool QXBool(int iQXZ, int? IUSER)
    {
        bool rValue = false;
        if (IUSER == -24)
        {
            rValue = true;
        }
        //string strSQL = "SELECT S_QXZZB.QXZID FROM S_QXZZB,S_YH_QXZ WHERE S_YH_QXZ.QXZID=S_QXZZB.QXZID AND QXID=" + iQXZ.ToString() + " AND USERID=" + IUSER.ToString();
        OP_Mode.Dtv = null;
        //if (OP_Mode.SQLRUN(strSQL))
        if (OP_Mode.GET_QX(Convert.ToInt32(IUSER), iQXZ))
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
                rValue = Request.Cookies["WeChat_Remember"]["USERID"];
            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '提 示', 'content': '您还未登陆，无权查看该页！<br/>请先登陆！', 'modal': true, 'buttons': { '确定': function () { location.href=\"/Remember/Login.aspx\"; } } })</script>");
                //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='您还未登陆，无权查看该页！<br/>请先登陆！';document.getElementById('MSGTitle').innerHTML='提 示'", true);
                //this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#MSG').modal('show');$(function () {$('#MSG').on('hide.bs.modal', function () {setTimeout(parent.location.href = '/Login.aspx', 0);})});</script>");
            }

            return rValue;
        }
    }
    public bool IsInt(string value)
    {
        return Regex.IsMatch(value, @"^[+-]?\d*$");
    }
    /// <summary>
    /// 姓名
    /// </summary>
    public string UserNAME
    {
        get
        {
            string rValue = "";

            try
            {
                rValue = HttpUtility.UrlDecode(Request.Cookies["WeChat_Remember"]["CNAME"], Encoding.GetEncoding("UTF-8"));
            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '提 示', 'content': '您还未登陆，无权查看该页！<br/>请先登陆！', 'modal': true, 'buttons': { '确定': function () { location.href=\"/Remember/Login.aspx\"; } } })</script>");
                //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='您还未登陆，无权查看该页！<br/>请先登陆！';document.getElementById('MSGTitle').innerHTML='提 示'", true);
                //this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#MSG').modal('show');$(function () {$('#MSG').on('hide.bs.modal', function () {setTimeout(parent.location.href = '/Login.aspx', 0);})});</script>");
            }
            return rValue;
        }
    }

    //if session
    /// <summary>
    /// 显示列表条数
    /// </summary>
    public static string DefaultList = ConfigurationManager.AppSettings["ListRows"];
    /// <summary>
    /// 默认最大列表条数
    /// </summary>
    public static int MaxList = Convert.ToInt16(ConfigurationManager.AppSettings["MaxList"]);
    /// <summary>
    /// 默认网站路径
    /// </summary>
    public static string DefaultWeb = ConfigurationManager.AppSettings["DefaultWeb"];
    /// <summary>
    /// 默认网址前缀
    /// </summary>
    public static string DefaultWebURL = ConfigurationManager.AppSettings["DefaultWebURL"];
    public PageBaseRem()
    {
        // MessageBox("1", "123");
    }

    /// <summary>
    /// 获取客户端真实IP
    /// </summary>
    /// <returns>客户端IP</returns>
    /// <remarks ></remarks>
    public string getIP()
    {
        string user_IP;
        if (Request.ServerVariables["HTTP_VIA"] != null)
        {
            user_IP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else
        {
            user_IP = Request.ServerVariables["REMOTE_ADDR"].ToString();
        }
        return user_IP;
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
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '" + sKey + "', 'content': '" + sTemp + "', 'modal': true, 'buttons': { '确定': function () { location.href=\"" + sURL + "\"; } } })</script>");

        //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='" + sTemp + "';document.getElementById('MSGTitle').innerHTML='" + sKey + "'", true);
        //this.Page.ClientScript.RegisterStartupScript(typeof(string), sKey, "<script language=JavaScript>$('#MSG').modal('show');$(function () {$('#MSG').on('hide.bs.modal', function () {setTimeout(parent.location.href = '" + sURL + "', 0);})});</script>");

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
    /// 弹出消息框
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sMessage">提示消息</param>
    public void MessageBox(Control UpdatePanel, string sKey, string sMessage)
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
        ScriptManager.RegisterStartupScript(UpdatePanel, this.GetType(), "sKey", "$('#MSG').modal('show');", true);

    }

    public static string getNoncestr()
    {
        Random random = new Random();
        return GetMD5(random.Next(1000).ToString(), "GBK");
    }

    //加密
    public static string GetMD5(string pwd)
    {
        MD5 md5Hasher = MD5.Create();

        byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(pwd));

        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        return sBuilder.ToString();
    }

    /** 获取大写的MD5签名结果 */
    public static string GetMD5(string encypStr, string charset)
    {
        string retStr;
        MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

        //创建md5对象
        byte[] inputBye;
        byte[] outputBye;

        //使用GB2312编码方式把字符串转化为字节数组．
        try
        {
            inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
        }
        catch (Exception ex)
        {
            inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
        }
        outputBye = m5.ComputeHash(inputBye);

        retStr = System.BitConverter.ToString(outputBye);
        retStr = retStr.Replace("-", "").ToUpper();
        return retStr;
    }

    public static string getTimestamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds).ToString();
    }

    public static string BuildRequest(SortedDictionary<string, string> sParaTemp, string key)
    {
        //获取过滤后的数组
        Dictionary<string, string> dicPara = new Dictionary<string, string>();
        /// 按字母顺序组合字符串
        dicPara = FilterPara(sParaTemp);
        //组合参数数组
        string prestr = CreateLinkString(dicPara);
        //拼接支付密钥
        string stringSignTemp = prestr + "&key=" + key;

        //获得加密结果
        string myMd5Str = GetMD5(stringSignTemp);

        //返回转换为大写的加密串
        return myMd5Str.ToUpper();
    }
    //组合参数数组
    public static string CreateLinkString(Dictionary<string, string> dicArray)
    {
        StringBuilder prestr = new StringBuilder();
        foreach (KeyValuePair<string, string> temp in dicArray)
        {
            prestr.Append(temp.Key + "=" + temp.Value + "&");
        }

        int nLen = prestr.Length;
        prestr.Remove(nLen - 1, 1);

        return prestr.ToString();
    }

    /// <summary>
    /// 除去数组中的空值和签名参数并以字母a到z的顺序排序
    /// </summary>
    /// <param name="dicArrayPre">过滤前的参数组</param>
    /// <returns>过滤后的参数组</returns>
    public static Dictionary<string, string> FilterPara(SortedDictionary<string, string> dicArrayPre)
    {
        Dictionary<string, string> dicArray = new Dictionary<string, string>();
        foreach (KeyValuePair<string, string> temp in dicArrayPre)
        {
            if (temp.Key != "sign" && !string.IsNullOrEmpty(temp.Value))
            {
                dicArray.Add(temp.Key, temp.Value);
            }
        }

        return dicArray;
    }

    /// <summary>
    /// 去除尾数0
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string stingGo(string str)
    {
        return str.TrimEnd('0');
    }


    public string LoadPayID(string openid, string Bill_No, decimal Charge_Amt, string Body)
    {
        string APPID = WebConfigurationManager.AppSettings["CorpId"];
        // string TENPAY = "1";
        string PARTNER = WebConfigurationManager.AppSettings["PARTNER"];// "1259901501";//商户号
        string APPSECRET = WebConfigurationManager.AppSettings["WeixinAppSecret"];
        string PARTNER_KEY = WebConfigurationManager.AppSettings["JSPIKey"];// "6f498ef1c21be21531b39dd1c668c26f";//APPSECRET
        string strPAYURL = "http://yanwo.x76.com.cn/PayNotifyUrl.aspx";// 不允许传递参数

        HttpContext Context = System.Web.HttpContext.Current;

        if (openid.Length == 0)
        {
            return string.Empty;
        }

        //设置package订单参数
        SortedDictionary<string, string> dic = new SortedDictionary<string, string>();

        string strIP = Context.Request.UserHostAddress;// "127.0.0.1";//

        string total_fee = (Charge_Amt * 100).ToString("f0");
        string wx_timeStamp = "";
        string wx_nonceStr = getNoncestr();

        dic.Add("appid", APPID);
        dic.Add("mch_id", PARTNER);//财付通帐号商家
        dic.Add("device_info", "1000");//可为空
        dic.Add("nonce_str", wx_nonceStr);
        dic.Add("trade_type", "JSAPI");
        dic.Add("attach", "att1");
        dic.Add("openid", openid);
        dic.Add("out_trade_no", Bill_No);		//商家订单号
        dic.Add("total_fee", total_fee); //商品金额,以分为单位(money * 100).ToString()
        dic.Add("notify_url", strPAYURL.ToLower());//接收财付通通知的URL
        dic.Add("body", Body);//商品描述
        dic.Add("spbill_create_ip", strIP);   //用户的公网ip，不是商户服务器IP

        string get_sign = BuildRequest(dic, PARTNER_KEY);

        string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        string _req_data = "<xml>";
        _req_data += "<appid>" + APPID + "</appid>";
        _req_data += "<mch_id><![CDATA[" + PARTNER + "]]></mch_id> ";
        _req_data += "<device_info><![CDATA[1000]]></device_info> ";
        _req_data += "<nonce_str><![CDATA[" + wx_nonceStr + "]]></nonce_str> ";
        _req_data += "<trade_type><![CDATA[JSAPI]]></trade_type> ";
        _req_data += "<attach><![CDATA[att1]]></attach>";
        _req_data += "<openid><![CDATA[" + openid + "]]></openid> ";
        _req_data += "<out_trade_no><![CDATA[" + Bill_No + "]]></out_trade_no> ";
        _req_data += "<total_fee><![CDATA[" + total_fee + "]]></total_fee> ";
        _req_data += "<notify_url><![CDATA[" + strPAYURL.ToLower() + "]]></notify_url> ";
        _req_data += "<body><![CDATA[" + Body + "]]></body> ";
        _req_data += "<spbill_create_ip><![CDATA[" + strIP + "]]></spbill_create_ip> ";
        _req_data += "<sign><![CDATA[" + get_sign + "]]></sign> ";
        _req_data += "</xml>";

        //通知支付接口，拿到prepay_id
        ReturnValue retValue = StreamReaderUtils.StreamReader(url, Encoding.UTF8.GetBytes(_req_data), System.Text.Encoding.UTF8, true);

        //return retValue.Message;
        ////设置支付参数
        XmlDocument xmldoc = new XmlDocument();

        xmldoc.LoadXml(retValue.Message);

        XmlNode Event = xmldoc.SelectSingleNode("/xml/prepay_id");

        string return_json = "";

        if (Event != null)
        {
            string _prepay_id = Event.InnerText;

            SortedDictionary<string, string> pay_dic = new SortedDictionary<string, string>();

            wx_timeStamp = getTimestamp();
            wx_nonceStr = getNoncestr();

            string _package = "prepay_id=" + _prepay_id;

            pay_dic.Add("appId", APPID);
            pay_dic.Add("timeStamp", wx_timeStamp);
            pay_dic.Add("nonceStr", wx_nonceStr);
            pay_dic.Add("package", _package);
            pay_dic.Add("signType", "MD5");

            string get_PaySign = BuildRequest(pay_dic, PARTNER_KEY);

            return_json = JsonUtils.SerializeToJson(new
            {
                appId = APPID,
                timeStamp = wx_timeStamp,
                nonceStr = wx_nonceStr,
                package = _package,
                signType = "MD5",
                paySign = get_PaySign
            });
        }

        return return_json;

    }
    /// <summary>
    /// 企业微信发送信息
    /// </summary>
    /// <param name="WeiXinOpenID">成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。</param>
    /// <param name="sTitle">标题</param>
    /// <param name="tContent">内容，支持HTML语言</param>
    /// <param name="strURL">静默授权 完整网址 需要加上 Wechat=0 表示是企业微信登录</param>

    public void SendWorkMsgCard(string WeiXinOpenID, string sTitle, string tContent, string strURL)
    {
        if (WeiXinOpenID != null)
        {
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", GetWorkToken());

            var RUrl = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=wwcb109f513aaa59b1&redirect_uri=http%3a%2f%2f{0}&response_type=code&scope=snsapi_base&state=#wechat_redirect", strURL);
            var data = "{";

            data += "\"touser\":\"" + WeiXinOpenID.Trim() + "\",";     /// 成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。
            data += "\"msgtype\":\"textcard\",";     /// 卡片消息
            data += "\"agentid\":\"" + WebConfigurationManager.AppSettings["NAgentId"] + "\","; /// 企业应用ID号

            data += "\"textcard\":{";
            data += "\"title\":\"" + sTitle + " \","; /// 标题
            data += "\"description\":\"" + tContent + " \","; // 内容，HTML语句
            data += "\"url\":\"" + RUrl + " \""; /// 点击后跳转的地址
            data += "}";

            data += "}";
            // https://open.weixin.qq.com/connect/oauth2/authorize?appid=wwcb109f513aaa59b1&redirect_uri=http%3a%2f%2fptweb.x76.com.cn/Default.aspx%3fWechat%3d0&response_type=code&scope=snsapi_base&state=#wechat_redirect
            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, string>>(PostWeixinPage(url, data));

            //foreach (var key in obj.Keys)
            //{
            //    MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
            //}
        }
    }

    /// <summary>
    /// 微信用户发送 审核反馈信息。
    /// </summary>
    /// <param name="WeiXinOpenID">微信ID</param>
    /// <param name="sFrist">标题内容</param>
    /// <param name="sKey1">审核结果</param>
    /// <param name="sKey2">原因</param>
    /// <param name="sRemark">备注信息</param>
    /// <param name="sURL">链接地址</param>
    public void SendWeiXinSHJG(string WeiXinOpenID, string sFrist, string sKey1, string sKey2, string sRemark, string sURL)
    {
        /// 检测微信ID是否存在，不存在则不可以发送微信消息。
        if (WeiXinOpenID != null)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", GetaccessToken());

            var data = "{";

            data += "\"touser\":\"" + WeiXinOpenID.Trim() + "\",";     /// 微信ID
            data += "\"template_id\":\"cyY-4hEGma48t98XyV8na9UdJd_gVt3xIfO9vpd6PpE\",";     /// 模板ID
            data += "\"url\":\"" + sURL + "\",";
            data += "\"topcolor\":\"#FF0000\",";
            data += "\"data\":{";

            data += "\"first\": {";
            data += "\"value\":\"" + sFrist + " \",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"keyword1\":{";
            data += "\"value\":\"" + sKey1 + "\",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"keyword2\":{";
            data += "\"value\":\"" + sKey2 + "\",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"remark\":{";
            data += "\"value\":\"" + sRemark + "\",";
            data += "\"color\":\"#173177\"";
            data += "}";

            data += "}";

            data += "}";

            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, string>>(PostWeixinPage(url, data));

            string MSG = "openid:" + WeiXinOpenID;

            foreach (var key in obj.Keys)
            {
                MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
            }
        }
    }
    /// <summary>
    /// 微信订单发货通知
    /// </summary>
    /// <param name="WeiXinOpenID">收信人OPENID</param>
    /// <param name="sFrist">顶部文字</param>
    /// <param name="sKey1">订单号</param>
    /// <param name="sKey2">日期</param>
    /// <param name="sKey3">供应商</param>
    /// <param name="sKey4">联系人</param>
    /// <param name="sKey5">联系电话</param>
    /// <param name="sRemark">备注信息</param>
    /// <param name="sURL">链接地址</param>
    public void SendWeChatDDFH(string WeiXinOpenID, string sFrist, string sKey1, string sKey2, string sKey3, string sKey4, string sKey5, string sRemark, string sURL)
    {
        /// 检测微信ID是否存在，不存在则不可以发送微信消息。
        if (WeiXinOpenID != null)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", GetaccessToken());

            var data = "{";

            data += "\"touser\":\"" + WeiXinOpenID.Trim() + "\",";     /// 微信ID
            data += "\"template_id\":\"lCRgPdRUbalO_sHpu1re8peCn4ui90Vf1TWE2T0n_x8\",";     /// 模板ID
            data += "\"url\":\"" + sURL + "\",";
            data += "\"topcolor\":\"#FF0000\",";
            data += "\"data\":{";

            data += "\"first\": {";
            data += "\"value\":\"" + sFrist + " \",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"keyword1\":{";
            data += "\"value\":\"" + sKey1 + "\",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"keyword2\":{";
            data += "\"value\":\"" + sKey2 + "\",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"keyword3\":{";
            data += "\"value\":\"" + sKey3 + "\",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"keyword4\":{";
            data += "\"value\":\"" + sKey4 + "\",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"keyword5\":{";
            data += "\"value\":\"" + sKey5 + "\",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"remark\":{";
            data += "\"value\":\"" + sRemark + "\",";
            data += "\"color\":\"#173177\"";
            data += "}";

            data += "}";

            data += "}";

            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, string>>(PostWeixinPage(url, data));

            string MSG = "openid:" + WeiXinOpenID;

            foreach (var key in obj.Keys)
            {
                MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
            }
        }
    }

    /// <summary>
    /// 生成获得二维码的值
    /// </summary>
    public string Ecod(int strID)
    {
        string sValue = string.Empty;
        var url = string.Format(" https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", GetaccessToken());

        var data = "{\"action_name\": \"QR_LIMIT_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + strID + "}}}";

        var serializer = new JavaScriptSerializer();
        var obj = serializer.Deserialize<Dictionary<string, string>>(PostWeixinPage(url, data));
        if (!obj.TryGetValue("ticket", out sValue))
        {

        }
        // var imageurl = string.Format("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}", sValue);
        return sValue;
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

    public string GetaccessToken()
    {
        string sValue = string.Empty, strSQL;
        string AppId = "wxf60778eb4d1003de";//与微信公众账号后台的AppId设置保持一致，区分大小写。
        string AppSecret = "4224c03a03edeba44cb4aab9b27678be";
        string MSG = string.Empty;

        var client = new System.Net.WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        strSQL = "SELECT * FROM S_TYDM where ITYDMLB=1 and DATEDIFF(MI, LTIME, GETDATE()) < 0";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {/// Token 未过期，直接使用
                sValue = OP_Mode.Dtv[0]["CTYDMZ"].ToString();
            }
            else
            { /// Token 已过期，从新读取
                var url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", AppId, AppSecret);
                var data = client.DownloadString(url);

                // var userInfo = serializer.Deserialize<Dictionary<string, object>>(data);

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
                    //MSG = (Convert.ToDecimal(obj["expires_in"]) / 60).ToString();

                    strSQL = "UPDATE S_TYDM SET CTIME=GETDATE(), LTIME = DATEADD(S," + obj["expires_in"] + ",GETDATE()),CTYDMZ='" + sValue + "' WHERE ITYDMLB=1";

                    if (OP_Mode.SQLRUN(strSQL))
                    {

                    }
                }
            }
        }

        return sValue;

    }

    /// <summary>
    /// 订单支付成功
    /// </summary>
    /// <param name="WeiXinOpenID"></param>
    /// <param name="sFrist">标题</param>
    /// <param name="sKey1">支付金额</param>
    /// <param name="sKey2">商品信息</param>
    /// <param name="sRemark"></param>
    /// <param name="sURL"></param>
    public void SendWeiXinDDZFCG(string WeiXinOpenID, string sFrist, string sKey1, string sKey2, string sRemark, string sURL)
    {
        /// 检测微信ID是否存在，不存在则不可以发送微信消息。
        if (WeiXinOpenID != null)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", GetaccessToken());

            var data = "{";

            data += "\"touser\":\"" + WeiXinOpenID.Trim() + "\",";     /// 微信ID
            data += "\"template_id\":\"NMG1HZA6J6BTnjeZsvpwziIpnG4jiFPM8nfCvn60RLs\",";     /// 模板ID
            data += "\"url\":\"" + sURL + "\",";
            data += "\"topcolor\":\"#FF0000\",";
            data += "\"data\":{";

            data += "\"first\": {";
            data += "\"value\":\"" + sFrist + " \",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"orderMoneySum\":{";
            data += "\"value\":\"" + sKey1 + "\",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"orderProductName\":{";
            data += "\"value\":\"" + sKey2 + "\",";
            data += "\"color\":\"#173177\"";
            data += "},";
            data += "\"remark\":{";
            data += "\"value\":\"" + sRemark + "\",";
            data += "\"color\":\"#173177\"";
            data += "}";

            data += "}";

            data += "}";

            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, string>>(PostWeixinPage(url, data));

            string MSG = "openid:" + WeiXinOpenID;

            foreach (var key in obj.Keys)
            {
                MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
            }
        }
    }

    /// <summary>
    /// 微信接口POST请求
    /// </summary>
    /// <param name="posturl">string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", GetaccessToken());</param>
    /// <param name="postData">josn数据</param>
    /// <returns></returns>
    public string PostWeixinPage(string posturl, string postData)
    {
        Stream outstream = null;
        Stream instream = null;
        StreamReader sr = null;
        HttpWebResponse response = null;
        HttpWebRequest request = null;
        Encoding encoding = Encoding.UTF8;
        byte[] data = encoding.GetBytes(postData);
        // 准备请求...
        try
        {
            // 设置参数
            request = WebRequest.Create(posturl) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            outstream = request.GetRequestStream();
            outstream.Write(data, 0, data.Length);
            outstream.Close();
            //发送请求并获取相应回应数据
            response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            instream = response.GetResponseStream();
            sr = new StreamReader(instream, encoding);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            string err = string.Empty;

            // MessageBox("A", postData + "|||11111||||||<br/>" + posturl + "||22222|||||||<br/>" + content);

            //Response.Write(content);
            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }
    /// <summary>
    /// 生成带二维码的专属推广图片
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string Draw(string strOPENID, int strID, string strHeadImageUrl)
    {
        //背景图片
        string path = Server.MapPath(@"/TuiGuang/White.png");

        System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(path);

        //处理二维码图片大小 240*240px
        System.Drawing.Image qrCodeImage = ReduceImage("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + Ecod(strID), 240, 240);

        //处理头像图片大小 100*100px
        System.Drawing.Image titleImage = ReduceImage(strHeadImageUrl, 50, 50);

        using (Graphics g = Graphics.FromImage(imgSrc))
        {
            //画专属推广二维码
            g.DrawImage(qrCodeImage, new Rectangle(0,
            0,
            qrCodeImage.Width,
            qrCodeImage.Height),
            0, 0, qrCodeImage.Width, qrCodeImage.Height, GraphicsUnit.Pixel);

            //画头像
            g.DrawImage(titleImage, 240 / 2 - 25, 240 / 2 - 25, titleImage.Width, titleImage.Height);

            // Font font = new Font("宋体", 30, FontStyle.Bold);

            // g.DrawString(user.nickname, font, new SolidBrush(Color.Red), 110, 10);
        }
        string imageName = strOPENID + ".jpg";
        string newpath = Server.MapPath(@"/TuiGuang/" + imageName);
        imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        return imageName;
    }

    /// <summary>
    /// 微信JS获得签名
    /// </summary>
    /// <param name="nonecStr"></param>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    public string GenSignature(string nonecStr, string timeStamp)
    {
        string jsApiTicket = GetJsApiTicket();
        string url = Request.Url.ToString();

        string sourceData = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", jsApiTicket, nonecStr, timeStamp, url);

        using (SHA1 sha1 = new SHA1CryptoServiceProvider())
        {
            byte[] sourceDataBytes = Encoding.ASCII.GetBytes(sourceData);
            byte[] hashDataBytes = sha1.ComputeHash(sourceDataBytes);
            string hash = BitConverter.ToString(hashDataBytes).Replace("-", "");
            hash = hash.ToLower();
            return hash;
        }
    }

    /// <summary>
    /// 微信JS获得签名
    /// </summary>
    /// <param name="nonecStr"></param>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    public string GenSignature_Woker(string nonecStr, string timeStamp)
    {
        string jsApiTicket = GetJsApiTicket_Woker();
        string url = Request.Url.ToString();

        string sourceData = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", jsApiTicket, nonecStr, timeStamp, url);

        using (SHA1 sha1 = new SHA1CryptoServiceProvider())
        {
            byte[] sourceDataBytes = Encoding.ASCII.GetBytes(sourceData);
            byte[] hashDataBytes = sha1.ComputeHash(sourceDataBytes);
            string hash = BitConverter.ToString(hashDataBytes).Replace("-", "");
            hash = hash.ToLower();
            return hash;
        }
    }
    /// <summary>
    /// 微信JS签名
    /// </summary>
    /// <returns></returns>
    public string GetJsApiTicket_Woker()
    {
        string jsApiTicket = string.Empty;
        using (var client = new System.Net.WebClient()
        {
            Encoding = System.Text.Encoding.UTF8
        })
        {
            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}", GetWorkToken());
            string data = client.DownloadString(url);

            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, string>>(data);

            if (!obj.TryGetValue("ticket", out jsApiTicket))
            {

            }
            else
            {

            }
        }

        return jsApiTicket;
    }
    /// <summary>
    /// 微信JS签名
    /// </summary>
    /// <returns></returns>
    public string GetJsApiTicket()
    {
        string jsApiTicket = string.Empty;
        using (var client = new System.Net.WebClient()
        {
            Encoding = System.Text.Encoding.UTF8
        })
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token={0}", GetaccessToken());
            string data = client.DownloadString(url);

            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, string>>(data);

            if (!obj.TryGetValue("ticket", out jsApiTicket))
            {

            }
            else
            {

            }
        }

        return jsApiTicket;
    }

    /// <summary>
    /// 微信JS签名
    /// </summary>
    /// <returns></returns>
    public string GetWorkJsApiTicket()
    {
        string jsApiTicket = string.Empty;
        using (var client = new System.Net.WebClient()
        {
            Encoding = System.Text.Encoding.UTF8
        })
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token={0}", GetaccessToken());
            string data = client.DownloadString(url);

            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, string>>(data);

            if (!obj.TryGetValue("ticket", out jsApiTicket))
            {

            }
            else
            {

            }
        }

        return jsApiTicket;
    }

    /// <summary>
    /// 依据坐标获得地址
    /// </summary>
    /// <returns></returns>
    public string GetZBToString(string latitude, string longitude)
    {
        string QQMapKey = "OB4BZ-D4W3U-B7VVO-4PJWW-6TKDJ-WPB77";

        string rValue = string.Empty;
        using (var client = new System.Net.WebClient()
        {
            Encoding = System.Text.Encoding.UTF8
        })
        {
            string url = string.Format("https://apis.map.qq.com/ws/geocoder/v1/?location={0},{1}&get_poi=1&key={2}", latitude, longitude, QQMapKey);
            var data = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, string>>(data);
            var MapInfo = serializer.Deserialize<Dictionary<string, object>>(data);

            if (MapInfo["address"].ToString().Length > 0)
            {
                // vsex = 0;
                rValue = MapInfo["address"].ToString();
            }
            else
            {
                rValue = data;
            }
        }

        return rValue;
    }

    /// <summary>
    /// 缩小/放大图片
    /// </summary>
    /// <param name="url">图片网络地址</param>
    /// <param name="toWidth">缩小/放大宽度</param>
    /// <param name="toHeight">缩小/放大高度</param>
    /// <returns></returns>
    public System.Drawing.Image ReduceImage(string url, int toWidth, int toHeight)
    {
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream responseStream = response.GetResponseStream();

        System.Drawing.Image originalImage = System.Drawing.Image.FromStream(responseStream);
        if (toWidth <= 0 && toHeight <= 0)
        {
            return originalImage;
        }
        else if (toWidth > 0 && toHeight > 0)
        {
            if (originalImage.Width < toWidth && originalImage.Height < toHeight)
                return originalImage;
        }
        else if (toWidth <= 0 && toHeight > 0)
        {
            if (originalImage.Height < toHeight)
                return originalImage;
            toWidth = originalImage.Width * toHeight / originalImage.Height;
        }
        else if (toHeight <= 0 && toWidth > 0)
        {
            if (originalImage.Width < toWidth)
                return originalImage;
            toHeight = originalImage.Height * toWidth / originalImage.Width;
        }
        System.Drawing.Image toBitmap = new Bitmap(toWidth, toHeight);
        using (Graphics g = Graphics.FromImage(toBitmap))
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(originalImage,
                        new Rectangle(0, 0, toWidth, toHeight),
                        new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                        GraphicsUnit.Pixel);
            originalImage.Dispose();
            return toBitmap;
        }
    }
}
