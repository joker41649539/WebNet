using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : PageBase
{

    #region pageParameters
    public string appId { get; set; }
    public string timeStamp { get; set; }

    public string nonceStr { get; set; }

    public string signature { get; set; }
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Test();
            // TextBox4.Text = GetClientInternetIP();
            this.appId = WebConfigurationManager.AppSettings["CorpId"];
            this.timeStamp = getTimestamp();
            this.nonceStr = getNoncestr();
            this.signature = GenSignature(this.nonceStr, this.timeStamp);
            this.DataBind();

            Label1.Text = Request["code"];
        }
    }

    private string GenSignature(string nonecStr, string timeStamp)
    {
        string jsApiTicket = GetJsApiTicket();
        string url = Request.Url.AbsoluteUri;

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

    private string GetJsApiTicket()
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
                //foreach (var key in obj.Keys)
                //{
                //    MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
                //}
            }
            else
            {
                //MSG = (Convert.ToDecimal(obj["expires_in"]) / 60).ToString();

                //strSQL = "UPDATE S_TYDM SET CTIME=GETDATE(), LTIME = DATEADD(S," + obj["expires_in"] + ",GETDATE()),CTYDMZ='" + sValue + "' WHERE ITYDMLB=1";

                //if (OP_Mode.SQLRUN(strSQL))
                //{

                //}
                //foreach (var key in obj.Keys)
                //{
                //    MSG += "<br/>" + string.Format("{0}: {1}", key, obj[key]) + "<br/>";
                //}

                //https://api.weixin.qq.com/cgi-bin/groups/getid?access_token=w-_XJt6nrpn3U-X1DLPBN8tGLEt5YlV9hJmLXQOQoOrlK5jSRJ7qJPV00PMvnW5SDIMvavmzvpmTyBw2cSFgcirTZ6s6-yPnp-td-P2H4EI&openid=ollQItx5i3C0IUC_sQRvEzzQfXE4&lang=zh_CN
            }
        }

        return jsApiTicket;
    }

    private void Test()
    {
        string strTemp = string.Empty;
        strTemp += "<script src='http://res.wx.qq.com/open/js/jweixin-1.0.0.js'></script>\r\n";
        strTemp += "<script>\r\n";
        strTemp += " wx.config({\r\n";
        strTemp += " debug: true, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。\r\n";
        strTemp += "        appId: '" + WebConfigurationManager.AppSettings["CorpId"] + "', // 必填，企业号的唯一标识，此处填写企业号corpid\r\n";
        strTemp += "        timestamp: '" + getTimestamp() + "', // 必填，生成签名的时间戳\r\n";
        strTemp += "        signature: '" + GetaccessToken() + "',// 必填，签名，见附录1\r\n";
        strTemp += "        jsApiList: [\r\n";
        strTemp += "            'openLocation',\r\n";
        strTemp += "            'getLocation'\r\n";
        strTemp += "       ]\r\n";
        strTemp += "   });\r\n";
        strTemp += " wx.error(function(res) {\r\n";
        strTemp += "    alert(res.errMsg);\r\n";
        strTemp += "  });\r\n";
        strTemp += "  </script>\r\n";

        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", strTemp, false);
    }

    /// <summary>
    /// 发送测试消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        SendWeChatDDFH("ooUML6EsI6okXuBBhZ-_l4ur204Y", "11", "11", "11", "11", "11", "11", "11", "#");
    }
}