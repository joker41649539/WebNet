using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class PayNotifyUrl : PageBaseXMFight
{
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);
    protected void Page_Load(object sender, EventArgs e)
    {
        string strNo;
        try
        {

            strNo = Request["XSDID"];

            GetWeiXinPayZT(strNo);
        }
        catch
        {
            MessageBox("", "付款失败！<br>如您确定被扣款了，请联系客服。");
        }
    }


    /// <summary>
    /// 修改付款状态
    /// </summary>
    /// <param name="strNo">订单编号</param>
    public void UpadateFKZT(string strNo)
    {
        string strSQL = "UPDATE w_Buy1 SET FKJG=1,LTIME=GETDATE() WHERE DDNO='" + strNo + "' Select * from w_Buy1 where DDNO='" + strNo + "'";

        if (OP_Mode.SQLRUN(strSQL))
        {
            string strOpenID = "ooUML6EsI6okXuBBhZ-_l4ur204Y";// Request.Cookies["WeChat_Yanwo"]["COPENID"];
            if (strOpenID.Length > 0)
            {
                SendWeiXinDDZFCG(strOpenID, "有人下单咯", OP_Mode.Dtv[0]["ZJE"].ToString(), "不知道买的啥，块去看看", "请尽快处理订单。", "yanwo.x76.com.cn/Manage.aspx");
            }
            MessageBox("", "付款成功！<br>我们会尽快安排发货。", "./");
            return;
        }
    }

    /// <summary>
    /// 依据销售单ID查询订单支付状态
    /// </summary>
    /// <param name="IXSDID"></param>
    public void GetWeiXinPayZT(string strNo)
    {
        string APPID = WebConfigurationManager.AppSettings["CorpId"];
        // string TENPAY = "1";
        string PARTNER = WebConfigurationManager.AppSettings["PARTNER"];// "1259901501";//商户号
        string APPSECRET = WebConfigurationManager.AppSettings["WeixinAppSecret"];
        string PARTNER_KEY = WebConfigurationManager.AppSettings["JSPIKey"];// "6f498ef1c21be21531b39dd1c668c26f";//APPSECRET

        //string Bill_No = string.Format("{0:00000000}", IXSDID);//"00001181";

        HttpContext Context = System.Web.HttpContext.Current;


        //设置package订单参数
        SortedDictionary<string, string> dic = new SortedDictionary<string, string>();

        string strIP = Context.Request.UserHostAddress;// "127.0.0.1";//

        string wx_nonceStr = getNoncestr();

        dic.Add("appid", APPID);
        dic.Add("mch_id", PARTNER);//财付通帐号商家
        dic.Add("nonce_str", wx_nonceStr);//随机数
        dic.Add("out_trade_no", strNo);		//商家订单号

        string get_sign = BuildRequest(dic, PARTNER_KEY);

        string url = "https://api.mch.weixin.qq.com/pay/orderquery";
        string _req_data = "<xml>";
        _req_data += "<appid>" + APPID + "</appid>";
        _req_data += "<mch_id><![CDATA[" + PARTNER + "]]></mch_id> ";
        _req_data += "<nonce_str><![CDATA[" + wx_nonceStr + "]]></nonce_str> ";
        _req_data += "<out_trade_no><![CDATA[" + strNo + "]]></out_trade_no> ";
        _req_data += "<sign><![CDATA[" + get_sign + "]]></sign> ";
        _req_data += "</xml>";

        //通知支付接口，拿到prepay_id
        ReturnValue retValue = StreamReaderUtils.StreamReader(url, Encoding.UTF8.GetBytes(_req_data), System.Text.Encoding.UTF8, true);

        //return retValue.Message;
        ////设置支付参数
        XmlDocument xmldoc = new XmlDocument();

        xmldoc.LoadXml(retValue.Message);

        XmlNode Event = xmldoc.SelectSingleNode("/xml/trade_state");

        string return_json = Event.InnerText;

        if (return_json == "SUCCESS")
        {/// 支付成功，修改支付状态。
            //UpadateFKZT(strNo);
            MessageBox("", "付款成功！<br>我们会尽快安排发货。");
        }
        else
        {
            MessageBox("", "付款失败！<br>如您确定被扣款了，请联系客服。");
        }

    }
}