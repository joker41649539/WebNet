using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

public partial class Fil_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Test();
    }

    private void Test()
    {
        string Appid = "ztpayj44ocmpkavmgs";
        string AppSecret = "vOAF74hUzs9pGgpNovXNM8jqzuYrG8H2";
        string Url = "https://sapi.ztpay.org/api/v2";

        var client = new System.Net.WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        string stringSignTemp = "appid=" + Appid + "&method=market&key=" + AppSecret;

        string strMakeSign = "appid=" + Appid + "&method=market&sign=" + GetMD5(stringSignTemp).ToUpper();

        //var url = string.Format("https://sapi.ztpay.org/api/v2?appid={0}&method={1}&sign={2}", Appid, "market", strMakeSign);
        //var data = client.DownloadString(url);
        //var serializer = new JavaScriptSerializer();
        //var obj = serializer.Deserialize<Dictionary<string, string>>(data);

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        request.Method = "POST";

        byte[] bytes = Encoding.UTF8.GetBytes(strMakeSign);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = bytes.Length;
        Stream myResponseStream = request.GetRequestStream();
        myResponseStream.Write(bytes, 0, bytes.Length);

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        string retString = myStreamReader.ReadToEnd();

        myStreamReader.Close();
        myResponseStream.Close();

        string strTemp = retString.ToString().Substring(retString.IndexOf("fil"));

        // { "code":0,"message":"行情获取成功","data":{"fil":{ "gains":-0.57,"cny":540.68,"usd":82.7361,"high":85.7288,"high_cny":560.24,"low":81.372,"low_cny":531.77} },"time":"2021-03-20 22:06:16"}
        TextBox1.Text = strTemp.Substring(strTemp.IndexOf("cny") + 5, strTemp.IndexOf(",") - 13) + "    ";
        TextBox1.Text += strTemp;
        // Response.Write(response);
    }
}