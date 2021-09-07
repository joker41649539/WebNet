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
    /// Ȩ���жϺ���ת��ҳ��
    /// </summary>
    public static string Defaut_QX_URL = "/Remember/Default.aspx";

    /// <summary>
    /// ����Ȩ��ID���û�ID�ж��Ƿ��д˹���Ȩ�ޡ��з���TURE����֮����FALSE;
    /// </summary>
    /// <param name="iQXZ">���жϵ�Ȩ��ID</param>
    /// <param name="IUSER">�û�ID</param>
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
    /// ��ǰ�û�
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
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '�� ʾ', 'content': '����δ��½����Ȩ�鿴��ҳ��<br/>���ȵ�½��', 'modal': true, 'buttons': { 'ȷ��': function () { location.href=\"/Remember/Login.aspx\"; } } })</script>");
                //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='����δ��½����Ȩ�鿴��ҳ��<br/>���ȵ�½��';document.getElementById('MSGTitle').innerHTML='�� ʾ'", true);
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
    /// ����
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
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '�� ʾ', 'content': '����δ��½����Ȩ�鿴��ҳ��<br/>���ȵ�½��', 'modal': true, 'buttons': { 'ȷ��': function () { location.href=\"/Remember/Login.aspx\"; } } })</script>");
                //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='����δ��½����Ȩ�鿴��ҳ��<br/>���ȵ�½��';document.getElementById('MSGTitle').innerHTML='�� ʾ'", true);
                //this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#MSG').modal('show');$(function () {$('#MSG').on('hide.bs.modal', function () {setTimeout(parent.location.href = '/Login.aspx', 0);})});</script>");
            }
            return rValue;
        }
    }

    //if session
    /// <summary>
    /// ��ʾ�б�����
    /// </summary>
    public static string DefaultList = ConfigurationManager.AppSettings["ListRows"];
    /// <summary>
    /// Ĭ������б�����
    /// </summary>
    public static int MaxList = Convert.ToInt16(ConfigurationManager.AppSettings["MaxList"]);
    /// <summary>
    /// Ĭ����վ·��
    /// </summary>
    public static string DefaultWeb = ConfigurationManager.AppSettings["DefaultWeb"];
    /// <summary>
    /// Ĭ����ַǰ׺
    /// </summary>
    public static string DefaultWebURL = ConfigurationManager.AppSettings["DefaultWebURL"];
    public PageBaseRem()
    {
        // MessageBox("1", "123");
    }

    /// <summary>
    /// ��ȡ�ͻ�����ʵIP
    /// </summary>
    /// <returns>�ͻ���IP</returns>
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
    /// ������Ϣ��
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sMessage">��ʾ��Ϣ</param>
    public void MessageBox(string sKey, string sMessage)
    {
        if (sKey == "")
        {
            sKey = "��ʾ��Ϣ";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript ��ʹ��"\'"��ʾ'�ַ���

        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '" + sKey + "', 'content': '" + sTemp + "', 'modal': true, 'buttons': { 'ȷ��': function () {dialog.destroy();dialog.close();} } })</script>");
        //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='" + sTemp + "';document.getElementById('MSGTitle').innerHTML='" + sKey + "'", true);
        //this.Page.ClientScript.RegisterStartupScript(typeof(string), sKey, "<script language=JavaScript>$('#MSG').modal('show')</script>");

    }

    /// <summary>
    /// ģ̬����Ϣ��ʾ������תҳ��
    /// </summary>
    /// <param name="sKey">��ʾ���ڱ���</param>
    /// <param name="sMessage">��Ϣ����</param>
    /// <param name="sURL">��ʾ����תҳ��</param>
    public void MessageBox(string sKey, string sMessage, string sURL)
    {
        if (sKey == "")
        {
            sKey = "��ʾ��Ϣ";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript ��ʹ��"\'"��ʾ'�ַ���
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '" + sKey + "', 'content': '" + sTemp + "', 'modal': true, 'buttons': { 'ȷ��': function () { location.href=\"" + sURL + "\"; } } })</script>");

        //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='" + sTemp + "';document.getElementById('MSGTitle').innerHTML='" + sKey + "'", true);
        //this.Page.ClientScript.RegisterStartupScript(typeof(string), sKey, "<script language=JavaScript>$('#MSG').modal('show');$(function () {$('#MSG').on('hide.bs.modal', function () {setTimeout(parent.location.href = '" + sURL + "', 0);})});</script>");

    }

    /// <summary>
    /// ģ̬����Ϣ��ʾ������תҳ��
    /// </summary>
    /// <param name="UpdatePanel">��ˢ��PANEL��</param>
    /// <param name="sKey">��ʾ���ڱ���</param>
    /// <param name="sMessage">��Ϣ����</param>
    /// <param name="sURL">��ʾ����תҳ��</param>
    public void MessageBox(Control UpdatePanel, string sKey, string sMessage, string sURL)
    {
        if (sKey == "")
        {
            sKey = "��ʾ��Ϣ";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript ��ʹ��"\'"��ʾ'�ַ���

        ScriptManager.RegisterClientScriptBlock(UpdatePanel, this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='" + sTemp + "';document.getElementById('MSGTitle').innerHTML='" + sKey + "'", true);
        ScriptManager.RegisterStartupScript(UpdatePanel, this.GetType(), "sKey", "$('#MSG').modal('show');$(function () {$('#MSG').on('hide.bs.modal', function () {setTimeout(parent.location.href = '" + sURL + "', 0);})});", true);

    }

    /// <summary>
    /// ������Ϣ��
    /// </summary>
    /// <param name="sKey"></param>
    /// <param name="sMessage">��ʾ��Ϣ</param>
    public void MessageBox(Control UpdatePanel, string sKey, string sMessage)
    {
        if (sKey == "")
        {
            sKey = "��ʾ��Ϣ";
        }
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript ��ʹ��"\'"��ʾ'�ַ���

        ScriptManager.RegisterClientScriptBlock(UpdatePanel, this.GetType(), "key", "document.getElementById('ShowMSG').innerHTML='" + sTemp + "';document.getElementById('MSGTitle').innerHTML='" + sKey + "'", true);
        ScriptManager.RegisterStartupScript(UpdatePanel, this.GetType(), "sKey", "$('#MSG').modal('show');", true);

    }

    public static string getNoncestr()
    {
        Random random = new Random();
        return GetMD5(random.Next(1000).ToString(), "GBK");
    }

    //����
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

    /** ��ȡ��д��MD5ǩ����� */
    public static string GetMD5(string encypStr, string charset)
    {
        string retStr;
        MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

        //����md5����
        byte[] inputBye;
        byte[] outputBye;

        //ʹ��GB2312���뷽ʽ���ַ���ת��Ϊ�ֽ����飮
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
        //��ȡ���˺������
        Dictionary<string, string> dicPara = new Dictionary<string, string>();
        /// ����ĸ˳������ַ���
        dicPara = FilterPara(sParaTemp);
        //��ϲ�������
        string prestr = CreateLinkString(dicPara);
        //ƴ��֧����Կ
        string stringSignTemp = prestr + "&key=" + key;

        //��ü��ܽ��
        string myMd5Str = GetMD5(stringSignTemp);

        //����ת��Ϊ��д�ļ��ܴ�
        return myMd5Str.ToUpper();
    }
    //��ϲ�������
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
    /// ��ȥ�����еĿ�ֵ��ǩ������������ĸa��z��˳������
    /// </summary>
    /// <param name="dicArrayPre">����ǰ�Ĳ�����</param>
    /// <returns>���˺�Ĳ�����</returns>
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
    /// ȥ��β��0
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
        string PARTNER = WebConfigurationManager.AppSettings["PARTNER"];// "1259901501";//�̻���
        string APPSECRET = WebConfigurationManager.AppSettings["WeixinAppSecret"];
        string PARTNER_KEY = WebConfigurationManager.AppSettings["JSPIKey"];// "6f498ef1c21be21531b39dd1c668c26f";//APPSECRET
        string strPAYURL = "http://yanwo.x76.com.cn/PayNotifyUrl.aspx";// ���������ݲ���

        HttpContext Context = System.Web.HttpContext.Current;

        if (openid.Length == 0)
        {
            return string.Empty;
        }

        //����package��������
        SortedDictionary<string, string> dic = new SortedDictionary<string, string>();

        string strIP = Context.Request.UserHostAddress;// "127.0.0.1";//

        string total_fee = (Charge_Amt * 100).ToString("f0");
        string wx_timeStamp = "";
        string wx_nonceStr = getNoncestr();

        dic.Add("appid", APPID);
        dic.Add("mch_id", PARTNER);//�Ƹ�ͨ�ʺ��̼�
        dic.Add("device_info", "1000");//��Ϊ��
        dic.Add("nonce_str", wx_nonceStr);
        dic.Add("trade_type", "JSAPI");
        dic.Add("attach", "att1");
        dic.Add("openid", openid);
        dic.Add("out_trade_no", Bill_No);		//�̼Ҷ�����
        dic.Add("total_fee", total_fee); //��Ʒ���,�Է�Ϊ��λ(money * 100).ToString()
        dic.Add("notify_url", strPAYURL.ToLower());//���ղƸ�֪ͨͨ��URL
        dic.Add("body", Body);//��Ʒ����
        dic.Add("spbill_create_ip", strIP);   //�û��Ĺ���ip�������̻�������IP

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

        //֪֧ͨ���ӿڣ��õ�prepay_id
        ReturnValue retValue = StreamReaderUtils.StreamReader(url, Encoding.UTF8.GetBytes(_req_data), System.Text.Encoding.UTF8, true);

        //return retValue.Message;
        ////����֧������
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
    /// ��ҵ΢�ŷ�����Ϣ
    /// </summary>
    /// <param name="WeiXinOpenID">��ԱID�б�����Ϣ�����ߣ�����������á�|���ָ������֧��1000������</param>
    /// <param name="sTitle">����</param>
    /// <param name="tContent">���ݣ�֧��HTML����</param>
    /// <param name="strURL">��Ĭ��Ȩ ������ַ ��Ҫ���� Wechat=0 ��ʾ����ҵ΢�ŵ�¼</param>

    public void SendWorkMsgCard(string WeiXinOpenID, string sTitle, string tContent, string strURL)
    {
        if (WeiXinOpenID != null)
        {
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", GetWorkToken());

            var RUrl = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=wwcb109f513aaa59b1&redirect_uri=http%3a%2f%2f{0}&response_type=code&scope=snsapi_base&state=#wechat_redirect", strURL);
            var data = "{";

            data += "\"touser\":\"" + WeiXinOpenID.Trim() + "\",";     /// ��ԱID�б�����Ϣ�����ߣ�����������á�|���ָ������֧��1000������
            data += "\"msgtype\":\"textcard\",";     /// ��Ƭ��Ϣ
            data += "\"agentid\":\"" + WebConfigurationManager.AppSettings["NAgentId"] + "\","; /// ��ҵӦ��ID��

            data += "\"textcard\":{";
            data += "\"title\":\"" + sTitle + " \","; /// ����
            data += "\"description\":\"" + tContent + " \","; // ���ݣ�HTML���
            data += "\"url\":\"" + RUrl + " \""; /// �������ת�ĵ�ַ
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
    /// ΢���û����� ��˷�����Ϣ��
    /// </summary>
    /// <param name="WeiXinOpenID">΢��ID</param>
    /// <param name="sFrist">��������</param>
    /// <param name="sKey1">��˽��</param>
    /// <param name="sKey2">ԭ��</param>
    /// <param name="sRemark">��ע��Ϣ</param>
    /// <param name="sURL">���ӵ�ַ</param>
    public void SendWeiXinSHJG(string WeiXinOpenID, string sFrist, string sKey1, string sKey2, string sRemark, string sURL)
    {
        /// ���΢��ID�Ƿ���ڣ��������򲻿��Է���΢����Ϣ��
        if (WeiXinOpenID != null)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", GetaccessToken());

            var data = "{";

            data += "\"touser\":\"" + WeiXinOpenID.Trim() + "\",";     /// ΢��ID
            data += "\"template_id\":\"cyY-4hEGma48t98XyV8na9UdJd_gVt3xIfO9vpd6PpE\",";     /// ģ��ID
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
    /// ΢�Ŷ�������֪ͨ
    /// </summary>
    /// <param name="WeiXinOpenID">������OPENID</param>
    /// <param name="sFrist">��������</param>
    /// <param name="sKey1">������</param>
    /// <param name="sKey2">����</param>
    /// <param name="sKey3">��Ӧ��</param>
    /// <param name="sKey4">��ϵ��</param>
    /// <param name="sKey5">��ϵ�绰</param>
    /// <param name="sRemark">��ע��Ϣ</param>
    /// <param name="sURL">���ӵ�ַ</param>
    public void SendWeChatDDFH(string WeiXinOpenID, string sFrist, string sKey1, string sKey2, string sKey3, string sKey4, string sKey5, string sRemark, string sURL)
    {
        /// ���΢��ID�Ƿ���ڣ��������򲻿��Է���΢����Ϣ��
        if (WeiXinOpenID != null)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", GetaccessToken());

            var data = "{";

            data += "\"touser\":\"" + WeiXinOpenID.Trim() + "\",";     /// ΢��ID
            data += "\"template_id\":\"lCRgPdRUbalO_sHpu1re8peCn4ui90Vf1TWE2T0n_x8\",";     /// ģ��ID
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
    /// ���ɻ�ö�ά���ֵ
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
        string AppId = WebConfigurationManager.AppSettings["AgentId"];//����ҵ΢��ID��
        string AppSecret = WebConfigurationManager.AppSettings["Secret"];
        string MSG = string.Empty;

        var client = new System.Net.WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        strSQL = "SELECT * FROM S_TYDM where ITYDMLB=3 and DATEDIFF(MI, LTIME, GETDATE()) < 0";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {/// Token δ���ڣ�ֱ��ʹ��
                sValue = OP_Mode.Dtv[0]["CTYDMZ"].ToString();
            }
            else
            { /// Token �ѹ��ڣ����¶�ȡ
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
        string AppId = "wxf60778eb4d1003de";//��΢�Ź����˺ź�̨��AppId���ñ���һ�£����ִ�Сд��
        string AppSecret = "4224c03a03edeba44cb4aab9b27678be";
        string MSG = string.Empty;

        var client = new System.Net.WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        strSQL = "SELECT * FROM S_TYDM where ITYDMLB=1 and DATEDIFF(MI, LTIME, GETDATE()) < 0";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {/// Token δ���ڣ�ֱ��ʹ��
                sValue = OP_Mode.Dtv[0]["CTYDMZ"].ToString();
            }
            else
            { /// Token �ѹ��ڣ����¶�ȡ
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
    /// ����֧���ɹ�
    /// </summary>
    /// <param name="WeiXinOpenID"></param>
    /// <param name="sFrist">����</param>
    /// <param name="sKey1">֧�����</param>
    /// <param name="sKey2">��Ʒ��Ϣ</param>
    /// <param name="sRemark"></param>
    /// <param name="sURL"></param>
    public void SendWeiXinDDZFCG(string WeiXinOpenID, string sFrist, string sKey1, string sKey2, string sRemark, string sURL)
    {
        /// ���΢��ID�Ƿ���ڣ��������򲻿��Է���΢����Ϣ��
        if (WeiXinOpenID != null)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", GetaccessToken());

            var data = "{";

            data += "\"touser\":\"" + WeiXinOpenID.Trim() + "\",";     /// ΢��ID
            data += "\"template_id\":\"NMG1HZA6J6BTnjeZsvpwziIpnG4jiFPM8nfCvn60RLs\",";     /// ģ��ID
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
    /// ΢�Žӿ�POST����
    /// </summary>
    /// <param name="posturl">string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", GetaccessToken());</param>
    /// <param name="postData">josn����</param>
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
        // ׼������...
        try
        {
            // ���ò���
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
            //�������󲢻�ȡ��Ӧ��Ӧ����
            response = request.GetResponse() as HttpWebResponse;
            //ֱ��request.GetResponse()����ſ�ʼ��Ŀ����ҳ����Post����
            instream = response.GetResponseStream();
            sr = new StreamReader(instream, encoding);
            //���ؽ����ҳ��html������
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
    /// ���ɴ���ά���ר���ƹ�ͼƬ
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string Draw(string strOPENID, int strID, string strHeadImageUrl)
    {
        //����ͼƬ
        string path = Server.MapPath(@"/TuiGuang/White.png");

        System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(path);

        //������ά��ͼƬ��С 240*240px
        System.Drawing.Image qrCodeImage = ReduceImage("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + Ecod(strID), 240, 240);

        //����ͷ��ͼƬ��С 100*100px
        System.Drawing.Image titleImage = ReduceImage(strHeadImageUrl, 50, 50);

        using (Graphics g = Graphics.FromImage(imgSrc))
        {
            //��ר���ƹ��ά��
            g.DrawImage(qrCodeImage, new Rectangle(0,
            0,
            qrCodeImage.Width,
            qrCodeImage.Height),
            0, 0, qrCodeImage.Width, qrCodeImage.Height, GraphicsUnit.Pixel);

            //��ͷ��
            g.DrawImage(titleImage, 240 / 2 - 25, 240 / 2 - 25, titleImage.Width, titleImage.Height);

            // Font font = new Font("����", 30, FontStyle.Bold);

            // g.DrawString(user.nickname, font, new SolidBrush(Color.Red), 110, 10);
        }
        string imageName = strOPENID + ".jpg";
        string newpath = Server.MapPath(@"/TuiGuang/" + imageName);
        imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        return imageName;
    }

    /// <summary>
    /// ΢��JS���ǩ��
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
    /// ΢��JS���ǩ��
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
    /// ΢��JSǩ��
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
    /// ΢��JSǩ��
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
    /// ΢��JSǩ��
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
    /// ���������õ�ַ
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
    /// ��С/�Ŵ�ͼƬ
    /// </summary>
    /// <param name="url">ͼƬ�����ַ</param>
    /// <param name="toWidth">��С/�Ŵ����</param>
    /// <param name="toHeight">��С/�Ŵ�߶�</param>
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