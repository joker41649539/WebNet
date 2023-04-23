using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// PageBaseGambling 的摘要说明
/// </summary>
public class PageBaseGambling : System.Web.UI.Page
{
    public static string DefaultConStr = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

    public static OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    public PageBaseGambling()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 弹出消息框
    /// </summary>
    /// <param name="sMessage">提示消息</param>
    public void MessageBox(string sMessage)
    {
        string sTemp = sMessage;
        sTemp = sTemp.Replace("\r", @"\\r");
        sTemp = sTemp.Replace("\n", @"\\n");
        sTemp = sTemp.Replace("'", @"\'");    // javascript 中使用"\'"显示'字符。

        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>dialog = jqueryAlert({'content': '" + sTemp + "'})</script>");
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

    /// <summary>
    /// 获取时间戳Timestamp 
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public int GetTimeStamp(DateTime dt)
    {
        DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
        int timeStamp = Convert.ToInt32((dt - dateStart).TotalSeconds);
        return timeStamp;
    }

    /// <summary>  
    /// 时间戳Timestamp转换成日期  
    /// </summary>  
    /// <param name="timeStamp"></param>  
    /// <returns></returns>  
    public DateTime GetDateTime(int timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = ((long)timeStamp * 10000000);
        TimeSpan toNow = new TimeSpan(lTime);
        DateTime targetDt = dtStart.Add(toNow);
        return targetDt;
    }

    public class gZipWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            //自动gzip解压
            request.AutomaticDecompression = DecompressionMethods.GZip;
            return request;
        }
    }

    /// <summary>
    /// POST请求
    /// </summary>
    /// <param name="posturl">string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", GetaccessToken());</param>
    /// <param name="postData">josn数据</param>
    /// <returns></returns>
    public string PostPage(string posturl, string postData, string strUrl)
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

            request.ContentLength = data.Length;
            request.Headers.Add("accept", "application/json, text/plain, */*");
            request.Headers.Add("accept-encoding", "gzip, deflate, br");
            request.Headers.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            request.Headers.Add("content-length", "112");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("cookie", "x-session-token=29E9lOpUfamRjyHlwuKD1L2umR2oUaOR%2FYl70rdcgB7aaw1Gm4yN8A%3D%3D; checkCode=83b01372-1e8f-44ad-840c-8c9c5772e3a6");

            request.Headers.Add("origin", "https://" + strUrl);

            request.Headers.Add("referer", "https://" + strUrl + "/game/");
            request.Headers.Add("sec-fetch-dest", "empty");
            request.Headers.Add("sec-fetch-mode", "cors");
            request.Headers.Add("sec-fetch-site", "same-origin");
            request.Headers.Add("user-agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0");

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

            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return string.Empty;
        }
    }

    public class Rootobject
    {
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string betEndTime { get; set; }
        public string turnNum { get; set; }
        public string openNum { get; set; }
        public string openTime { get; set; }
        public int gameId { get; set; }
        public int status { get; set; }
        public string remark { get; set; }
        public int n1 { get; set; }
        public int n2 { get; set; }
        public int n3 { get; set; }
        public object n4 { get; set; }
        public object n5 { get; set; }
        public object n6 { get; set; }
        public object n7 { get; set; }
        public object n8 { get; set; }
        public object n9 { get; set; }
        public object n10 { get; set; }
        public object n11 { get; set; }
        public object n12 { get; set; }
        public object n13 { get; set; }
        public object n14 { get; set; }
        public object n15 { get; set; }
        public object n16 { get; set; }
        public object n17 { get; set; }
        public object n18 { get; set; }
        public object n19 { get; set; }
        public object n20 { get; set; }
        public string statDate { get; set; }
    }


    public class UserInfo
    {
        public float balance { get; set; }
        public float unbalancedMoney { get; set; }
        public float totalTotalMoney { get; set; }
        public object totalMoneyMap { get; set; }
        public object userBetWinList { get; set; }
        public object userBetNew { get; set; }
        public object pushMessage { get; set; }
        public int userNoticeMsg { get; set; }
        public object refreshRechType { get; set; }
        public object balanceMap { get; set; }
        public object unbalancedMap { get; set; }
        public string currency { get; set; }
        public object maintainStatus { get; set; }
        public object tradingNotice { get; set; }
        public float point { get; set; }
        public object refreshGameList { get; set; }
    }


}