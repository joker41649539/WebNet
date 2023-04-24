using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
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
    public string PostPage(string posturl, string postData, string strUrl, string strCoolin, int sTime)
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
            //request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            //  request.Date = GetDateTime(sTime);


            SetHeaderValue(request.Headers, "accept", "application/json, text/plain, */*");
            SetHeaderValue(request.Headers, "accept-encoding", "gzip, deflate, br");
            SetHeaderValue(request.Headers, "accept-language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            request.ContentLength = data.Length;
            // SetHeaderValue(request.Headers, "content-length", data.Length.ToString());
            request.ContentType = "application/x-www-form-urlencoded";
            SetHeaderValue(request.Headers, "cookie", strCoolin);
            SetHeaderValue(request.Headers, "origin", "https://" + strUrl);
            SetHeaderValue(request.Headers, "referer", "https://" + strUrl + "/game/");
            SetHeaderValue(request.Headers, "sec-fetch-dest", "empty");
            SetHeaderValue(request.Headers, "sec-fetch-mode", "cors");
            SetHeaderValue(request.Headers, "sec-fetch-site", "same-origin");
            SetHeaderValue(request.Headers, "user-agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0");

            outstream = request.GetRequestStream();
            outstream.Write(data, 0, data.Length);
            outstream.Close();
            //发送请求并获取相应回应数据
            response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            instream = response.GetResponseStream();
            //request.AutomaticDecompression = DecompressionMethods.GZip;
            sr = new StreamReader(instream, encoding);

            //返回结果网页（html）代码
            string content = sr.ReadToEnd();

            return content;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            return err;
        }
    }

    //请求 URL: https://www.sy0002.com/game/getLotteryData.do?_t=1682306782314&gameId=41
    //请求方法: GET
    //状态代码: 200 
    //远程地址: 154.218.13.234:443
    //引用者策略: strict-origin-when-cross-origin
    //content-disposition: inline;filename=f.txt
    //content-encoding: gzip
    //content-type: text/html; charset=UTF-8
    //date: Mon, 24 Apr 2023 03:26:23 GMT
    //guard-cache: BYPASS
    //guard-store: BYPASS
    //server: nginx/1.17.3
    //:authority: www.sy0002.com
    //:method: GET
    //:path: /game/getLotteryData.do?_t=1682306782314&gameId=41
    //:scheme: https
    //accept: application/json, text/plain, */*
    //accept-encoding: gzip, deflate, br
    //accept-language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
    //cookie: x-session-token=zTK3%2F%2FVIna8B9HKQhOjFFhV5J4b9tnPNQAVJGW3cyBSHvdwqOkLWHw%3D%3D; checkCode=efb9f77f-c8f8-4193-84f8-982bacdd6501
    //referer: https://www.sy0002.com/game/
    //sec-fetch-dest: empty
    //sec-fetch-mode: cors
    //sec-fetch-site: same-origin
    //user-agent: Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0
    //{"balance":103.648,"unbalancedMoney":4.0,"totalTotalMoney":1.65,"totalMoneyMap":null,"userBetWinList":null,"userBetNew":[{"id":1927033644,"userId":1200405,"userName":"lkjgh688","playId":4144604,"playName":"双","playCateId":446,"betInfo":"","multiple":1,"winCount":null,"money":2.0,"odds":1.95,"rebate":0.0,"addTime":"2023-04-24 11:25:57","turnNum":"2988650","gameId":41,"status":0,"reward":0.0,"rewardRebate":null,"rebateMoney":null,"orderNo":"12230424112557867396446","result":0,"frozenMoney":0.0,"trawMoney":null,"remark":"{\"playName\":\"双\",\"winNums\":\"\",\"odds\":\"1.950\"}","resultMoney":1.9,"openNum":null,"currency":"RMB"},{"id":1927033383,"userId":1200405,"userName":"lkjgh688","playId":4144604,"playName":"双","playCateId":446,"betInfo":"","multiple":1,"winCount":null,"money":2.0,"odds":1.95,"rebate":0.0,"addTime":"2023-04-24 11:25:10","turnNum":"2988650","gameId":41,"status":0,"reward":0.0,"rewardRebate":null,"rebateMoney":null,"orderNo":"12230424112510433198582","result":0,"frozenMoney":0.0,"trawMoney":null,"remark":"{\"playName\":\"双\",\"winNums\":\"\",\"odds\":\"1.950\"}","resultMoney":1.9,"openNum":null,"currency":"RMB"}],"pushMessage":null,"userNoticeMsg":0,"refreshRechType":null,"balanceMap":null,"unbalancedMap":null,"currency":"RMB","maintainStatus":null,"tradingNotice":null,"point":0.0,"refreshGameList":null}
    // unbalancedMoney: 4 // 待结算金额

    public static string UnzipZippedText(string zippedText)
    {
        if (String.IsNullOrEmpty(zippedText))
        {
            return String.Empty;
        }
        string unzipedText = null;
        try
        {
            byte[] buffer = Convert.FromBase64String(zippedText);
            MemoryStream ms = new MemoryStream(buffer);
            GZipStream zipStream = new GZipStream(ms, CompressionMode.Decompress);

            using (StreamReader streamReader = new StreamReader(zipStream))
            {
                unzipedText = streamReader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            unzipedText = String.Empty;
        }

        return unzipedText;
    }

    public static void SetHeaderValue(WebHeaderCollection header, string name, string value)
    {
        var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
        if (property != null)
        {
            var collection = property.GetValue(header, null) as NameValueCollection;
            collection[name] = value;
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
        public string token { get; set; }
        public string serverTime { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public string fullName { get; set; }
        public string loginTime { get; set; }
        public string lastLoginTime { get; set; }
        public float money { get; set; }
        public string email { get; set; }
        public string wx { get; set; }
        public string phone { get; set; }
        public string qq { get; set; }
        public string rechLevel { get; set; }
        public bool hasFundPwd { get; set; }
        public int testFlag { get; set; }
        public int updatePw { get; set; }
        public int updatePayPw { get; set; }
        public int state { get; set; }
        public object hotGames { get; set; }
        public object nickName { get; set; }
        public object iconUrl { get; set; }
        public int setted { get; set; }
        public string platCode { get; set; }
        public object gameIds { get; set; }
        public int testType { get; set; }
        public string currency { get; set; }
        public Userwalletview[] userWalletViews { get; set; }
        public string tradingPhone { get; set; }
        public float tradingCredit { get; set; }
        public int hyType { get; set; }
        public Userrebatelist[] userRebateList { get; set; }
        public bool tradingStandSwitch { get; set; }
        public float point { get; set; }
        public Gameblacklistmap gameBlackListMap { get; set; }
    }

    public class Gameblacklistmap
    {
        public object[] third { get; set; }
        public object[] lottery { get; set; }
    }

    public class Userwalletview
    {
        public float money { get; set; }
        public string currency { get; set; }
    }

    public class Userrebatelist
    {
        public int cateId { get; set; }
        public int rebate { get; set; }
    }


    public class NextNum
    {
        public string issue { get; set; }
        public string endtime { get; set; }
        public object nums { get; set; }
        public string lotteryTime { get; set; }
        public string preIssue { get; set; }
        public string preLotteryTime { get; set; }
        public string preNum { get; set; }
        public object n11 { get; set; }
        public object n12 { get; set; }
        public object n13 { get; set; }
        public object n14 { get; set; }
        public object n15 { get; set; }
        public object n16 { get; set; }
        public bool preIsOpen { get; set; }
        public string serverTime { get; set; }
        public int gameId { get; set; }
    }

    public class UserBet
    {
        public float balance { get; set; }
        public float unbalancedMoney { get; set; }
        public float totalTotalMoney { get; set; }
        public object totalMoneyMap { get; set; }
        public object userBetWinList { get; set; }
        public Userbetnew[] userBetNew { get; set; }
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

    public class Userbetnew
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public int playId { get; set; }
        public string playName { get; set; }
        public int playCateId { get; set; }
        public string betInfo { get; set; }
        public int multiple { get; set; }
        public object winCount { get; set; }
        public float money { get; set; }
        public float odds { get; set; }
        public float rebate { get; set; }
        public string addTime { get; set; }
        public string turnNum { get; set; }
        public int gameId { get; set; }
        public int status { get; set; }
        public float reward { get; set; }
        public object rewardRebate { get; set; }
        public object rebateMoney { get; set; }
        public string orderNo { get; set; }
        public int result { get; set; }
        public float frozenMoney { get; set; }
        public object trawMoney { get; set; }
        public string remark { get; set; }
        public float resultMoney { get; set; }
        public object openNum { get; set; }
        public string currency { get; set; }
    }

}