using Newtonsoft.Json;
using System;
using System.Data;

public partial class Gambling_Canada28 : PageBaseGambling
{
    public int MaxHistoryCount = 10;// 最多显示历史行数
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            //  LoadGamblingResult();
            MessageBox("刷新了");
        }
    }
    private void LoadData()
    {
        TextBox_Url.Text = "www.sy0002.com";
        TextBox_Cookie.Text = "x-session-token=IDjAmiAZJzrHp996%2BQmUP9uV87cF9bvQnu3xsYKz0NsnzRR8Ykb7j6jfywY%3D; checkCode=29ba55a7-3327-4a8d-b136-3329c86e43f1";
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadGamblingResult();
        LoadUserInfo();
    }

    /// <summary>
    /// 加载开奖结果
    /// </summary>
    private void LoadGamblingResult()
    {
        gZipWebClient client = new gZipWebClient();
        //  var client = new System.Net.WebClient();
        // client.Encoding = System.Text.Encoding.Unicode;
        //web.Encoding = System.Text.Encoding.UTF8;
        //https://www.sy0002.com/static//data/2023042341HistoryLottery.json?_=1682218907
        string strURL = TextBox_Url.Text.Trim();
        string strData = System.DateTime.Now.ToString("yyyyMMdd") + "41";
        string strDataTime = GetTimeStamp(System.DateTime.Now).ToString();

        //client.Headers.Add("authority", strURL);
        //client.Headers.Add("method", "GET");
        //client.Headers.Add("path", "/static//data/2023042341HistoryLottery.json?_=1682218907");
        //client.Headers.Add("scheme", "https");

        client.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
        client.Headers.Add("accept-encoding", "gzip, deflate, br");
        client.Headers.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
        client.Headers.Add("cache-control", "max-age=0");

        client.Headers.Add("sec-fetch-dest", "document");
        client.Headers.Add("sec-fetch-mode", "navigate");
        client.Headers.Add("sec-fetch-site", "none");
        client.Headers.Add("sec-fetch-user", "?1");
        client.Headers.Add("upgrade-insecure-requests", "1");
        client.Headers.Add("user-agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0");

        var url = string.Format("https://{0}/static//data/{1}HistoryLottery.json?_={2}", strURL, strData, strDataTime);

        var data = "{data:" + client.DownloadString(url) + "}";
        //   var data = "{\"totalRecords\":50,\"data\":[{\"section\":\"2988319\",\"openCode\":\"6,5,0\",\"openTime\":1682233530000},{\"section\":\"2988318\",\"openCode\":\"4,5,5\",\"openTime\":1682233320000},{\"section\":\"2988317\",\"openCode\":\"1,3,5\",\"openTime\":1682233110000},{\"section\":\"2988316\",\"openCode\":\"8,9,0\",\"openTime\":1682232900000},{\"section\":\"2988315\",\"openCode\":\"4,1,9\",\"openTime\":1682232690000},{\"section\":\"2988314\",\"openCode\":\"6,3,8\",\"openTime\":1682232480000},{\"section\":\"2988313\",\"openCode\":\"8,0,5\",\"openTime\":1682232270000},{\"section\":\"2988312\",\"openCode\":\"6,0,0\",\"openTime\":1682232060000},{\"section\":\"2988311\",\"openCode\":\"0,6,1\",\"openTime\":1682231850000},{\"section\":\"2988310\",\"openCode\":\"4,0,7\",\"openTime\":1682231640000},{\"section\":\"2988309\",\"openCode\":\"6,6,0\",\"openTime\":1682231430000},{\"section\":\"2988308\",\"openCode\":\"7,6,2\",\"openTime\":1682231220000},{\"section\":\"2988307\",\"openCode\":\"1,0,5\",\"openTime\":1682231010000},{\"section\":\"2988306\",\"openCode\":\"2,9,1\",\"openTime\":1682230800000},{\"section\":\"2988305\",\"openCode\":\"2,8,3\",\"openTime\":1682230590000},{\"section\":\"2988304\",\"openCode\":\"9,8,1\",\"openTime\":1682230380000},{\"section\":\"2988303\",\"openCode\":\"0,6,8\",\"openTime\":1682230170000},{\"section\":\"2988302\",\"openCode\":\"4,8,7\",\"openTime\":1682229960000},{\"section\":\"2988301\",\"openCode\":\"8,8,6\",\"openTime\":1682229750000},{\"section\":\"2988300\",\"openCode\":\"2,7,2\",\"openTime\":1682229540000},{\"section\":\"2988299\",\"openCode\":\"3,8,2\",\"openTime\":1682229330000},{\"section\":\"2988298\",\"openCode\":\"6,8,9\",\"openTime\":1682229120000},{\"section\":\"2988297\",\"openCode\":\"7,0,8\",\"openTime\":1682228910000},{\"section\":\"2988296\",\"openCode\":\"9,0,7\",\"openTime\":1682228700000},{\"section\":\"2988295\",\"openCode\":\"2,7,4\",\"openTime\":1682228490000},{\"section\":\"2988294\",\"openCode\":\"6,4,3\",\"openTime\":1682228280000},{\"section\":\"2988293\",\"openCode\":\"7,3,3\",\"openTime\":1682228070000},{\"section\":\"2988292\",\"openCode\":\"3,1,8\",\"openTime\":1682227860000},{\"section\":\"2988291\",\"openCode\":\"4,0,4\",\"openTime\":1682227650000},{\"section\":\"2988290\",\"openCode\":\"6,5,8\",\"openTime\":1682227440000},{\"section\":\"2988289\",\"openCode\":\"2,6,1\",\"openTime\":1682227230000},{\"section\":\"2988288\",\"openCode\":\"4,5,7\",\"openTime\":1682227020000},{\"section\":\"2988287\",\"openCode\":\"0,1,7\",\"openTime\":1682226810000},{\"section\":\"2988286\",\"openCode\":\"5,9,3\",\"openTime\":1682226600000},{\"section\":\"2988285\",\"openCode\":\"6,9,2\",\"openTime\":1682226390000},{\"section\":\"2988284\",\"openCode\":\"8,0,9\",\"openTime\":1682226180000},{\"section\":\"2988283\",\"openCode\":\"4,0,6\",\"openTime\":1682225970000},{\"section\":\"2988282\",\"openCode\":\"1,3,5\",\"openTime\":1682225760000},{\"section\":\"2988281\",\"openCode\":\"3,9,5\",\"openTime\":1682225550000},{\"section\":\"2988280\",\"openCode\":\"2,3,6\",\"openTime\":1682225340000},{\"section\":\"2988279\",\"openCode\":\"6,8,1\",\"openTime\":1682225130000},{\"section\":\"2988278\",\"openCode\":\"1,5,3\",\"openTime\":1682224920000},{\"section\":\"2988277\",\"openCode\":\"2,3,8\",\"openTime\":1682224710000},{\"section\":\"2988276\",\"openCode\":\"9,0,1\",\"openTime\":1682224500000},{\"section\":\"2988275\",\"openCode\":\"9,8,5\",\"openTime\":1682224290000},{\"section\":\"2988274\",\"openCode\":\"8,8,8\",\"openTime\":1682224080000},{\"section\":\"2988273\",\"openCode\":\"2,9,1\",\"openTime\":1682223870000},{\"section\":\"2988272\",\"openCode\":\"1,5,2\",\"openTime\":1682223660000},{\"section\":\"2988271\",\"openCode\":\"0,8,8\",\"openTime\":1682223450000},{\"section\":\"2988270\",\"openCode\":\"8,4,7\",\"openTime\":1682223240000}]}";
        Rootobject rb = JsonConvert.DeserializeObject<Rootobject>(data);

        DataTable dt = new DataTable();
        dt.Columns.Add("turnNum");
        dt.Columns.Add("openNum");
        dt.Columns.Add("Big");
        dt.Columns.Add("openTime");
        for (int i = 0; i < rb.data.Length; i++)
        {

            if (i >= MaxHistoryCount)
            {
                break;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                dt.Rows[i][0] = rb.data[i].turnNum;
                dt.Rows[i][1] = rb.data[i].openNum;
                if (Convert.ToInt32(rb.data[i].n1) + Convert.ToInt32(rb.data[i].n2) + Convert.ToInt32(rb.data[i].n3) > 18)
                {
                    dt.Rows[i][2] = "大";
                }
                else
                {
                    dt.Rows[i][2] = "小";
                }
                // dt.Rows[i][2] = Convert.ToInt32(rb.data[i].n1) + Convert.ToInt32(rb.data[i].n2) + Convert.ToInt32(rb.data[i].n3);
                dt.Rows[i][3] = Convert.ToDateTime(rb.data[i].openTime).ToString("MM-dd HH:mm").ToString();

                TextBox1.Text += rb.data[i].turnNum + "|" + rb.data[i].openNum + "|" + Convert.ToDateTime(rb.data[i].openTime).ToString("MM-dd HH:mm");
            }
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void timerTest_Tick(object sender, EventArgs e)
    {
        LoadGamblingResult();
    }

    private void LoadUserInfo()
    {
        gZipWebClient client = new gZipWebClient();
        string strURL = TextBox_Url.Text.Trim();
        string strDataTime = GetTimeStamp(System.DateTime.Now).ToString();

        var url = string.Format("https://{0}/api/init.do?_t={1}", strURL, strDataTime);

        client.Headers.Add("accept", "application/json, text/plain, */*");
        client.Headers.Add("accept-encoding", "gzip, deflate, br");
        client.Headers.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
        client.Headers.Add("cookie", TextBox_Cookie.Text);

        client.Headers.Add("referer", "https://" + strURL + "/game/");
        client.Headers.Add("sec-fetch-dest", "empty");
        client.Headers.Add("sec-fetch-mode", "cors");
        client.Headers.Add("sec-fetch-site", "same-origin");
        client.Headers.Add("user-agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0");

        var data = client.DownloadString(url);
        UserInfo User = JsonConvert.DeserializeObject<UserInfo>(data);

        TextBox1.Text += "余额：" + User.userWalletViews[0].money;
    }

    //    accept: application/json, text/plain, */*
    //accept-encoding: gzip, deflate, br
    //accept-language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
    //cookie: x-session-token=IDjAmiAZJzrHp996%2BQmUP9uV87cF9bvQnu3xsYKz0NsnzRR8Ykb7j6jfywY%3D; checkCode=29ba55a7-3327-4a8d-b136-3329c86e43f1
    //referer: https://www.sy0002.com/game/
    //sec-fetch-dest: empty
    //sec-fetch-mode: cors
    //sec-fetch-site: same-origin
    //user-agent: Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0

    private void PostBet(int BetMoney, string BetContent, string BetNum)
    {
        string postData = string.Empty;

        string strURL = TextBox_Url.Text.Trim();
        string strDataTime = GetTimeStamp(System.DateTime.Now).ToString();
        //4144601 大
        //4144602 小

        string strBetCount = "0";

        if (BetContent == "大")
        {
            strBetCount = "4144601";
        }
        else if (BetContent == "小")
        {
            strBetCount = "4144602";
        }

        postData = "{";
        postData += "gameId:41,";
        postData += "totalNums:totalNums,";
        postData += "totalMoney:" + BetMoney + ",";
        postData += "betSrc:0,";
        postData += "turnNum:" + BetNum + ",";
        postData += "betBean[0].playId:" + strBetCount + ",";
        postData += "betBean[0]:" + BetMoney + "";
        postData += "]";

        var url = string.Format("https://{0}/bet/bet.do?_t={1}", strURL, strDataTime);

        PostPage(url, postData, TextBox_Url.Text, TextBox_Cookie.Text);
    }

    private string LoadNextNum()
    {
        string sRvalue = string.Empty;
        gZipWebClient client = new gZipWebClient();
        string strURL = TextBox_Url.Text.Trim();
        string strDataTime = GetTimeStamp(System.DateTime.Now).ToString();

        var url = string.Format("https://{0}/lottery/getNextIssue.do?_t={1}&gameId=41", strURL, strDataTime);

        client.Headers.Add("accept", "application/json, text/plain, */*");
        client.Headers.Add("accept-encoding", "gzip, deflate, br");
        client.Headers.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
        client.Headers.Add("cookie", TextBox_Cookie.Text);

        client.Headers.Add("referer", "https://" + strURL + "/game/");
        client.Headers.Add("sec-fetch-dest", "empty");
        client.Headers.Add("sec-fetch-mode", "cors");
        client.Headers.Add("sec-fetch-site", "same-origin");
        client.Headers.Add("user-agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0");

        var data = client.DownloadString(url);
        NextNum nextNum = JsonConvert.DeserializeObject<NextNum>(data);

        TextBox1.Text += "下一局：" + nextNum.issue;
        sRvalue = nextNum.issue;
        return sRvalue;
    }

    //请求 URL: https://www.sy0002.com/lottery/getNextIssue.do?_t=1682259564108&gameId=41
    //请求方法: GET
    //状态代码: 200 
    //远程地址: 154.218.13.234:443
    //引用者策略: strict-origin-when-cross-origin

    //accept: application/json, text/plain, */*
    //accept-encoding: gzip, deflate, br
    //accept-language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
    //cookie: x-session-token=IDjAmiAZJzrHp996%2BQmUP9uV87cF9bvQnu3xsYKz0NsnzRR8Ykb7j6jfywY%3D; checkCode=29ba55a7-3327-4a8d-b136-3329c86e43f1
    //referer: https://www.sy0002.com/game/
    //sec-fetch-dest: empty
    //sec-fetch-mode: cors
    //sec-fetch-site: same-origin
    //user-agent: Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0
    //请求 URL: https://www.sy0002.com/bet/bet.do?_t=1682239065642
    //请求方法: POST
    //状态代码: 200 
    //远程地址: 154.218.13.234:443
    //引用者策略: strict-origin-when-cross-origin

    //content-disposition: inline;filename=f.txt
    //content-encoding: gzip
    //content-type: text/html; charset=UTF-8
    //date: Sun, 23 Apr 2023 08:37:45 GMT
    //guard-cache: BYPASS
    //guard-store: BYPASS
    //server: nginx/1.17.3
    //:authority: www.sy0002.com
    //:method: POST
    //:path: /bet/bet.do?_t=1682239065642
    //:scheme: https

    //accept: application/json, text/plain, */*
    //accept-encoding: gzip, deflate, br
    //accept-language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
    //content-length: 112
    //content-type: application/x-www-form-urlencoded
    //cookie: x-session-token=29E9lOpUfamRjyHlwuKD1L2umR2oUaOR%2FYl70rdcgB7aaw1Gm4yN8A%3D%3D; checkCode=83b01372-1e8f-44ad-840c-8c9c5772e3a6
    //origin: https://www.sy0002.com
    //referer: https://www.sy0002.com/game/
    //sec-fetch-dest: empty
    //sec-fetch-mode: cors
    //sec-fetch-site: same-origin
    //user-agent: Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0

    // post 内容
    //gameId: 41
    //totalNums: 1
    //totalMoney: 1
    //betSrc: 0
    //turnNum: 2988346
    //betBean[0].playId: 4144601 大
    //betBean[0].money: 1

    //gameId: 41
    //totalNums: 1
    //totalMoney: 1
    //betSrc: 0
    //turnNum: 2988352
    //betBean[0].playId: 4144601
    //betBean[0].money: 1

    //gameId: 41
    //totalNums: 1
    //totalMoney: 2
    //betSrc: 0
    //turnNum: 2988352
    //betBean[0].playId: 4144602 小
    //betBean[0].money: 2

    //请求 URL: https://www.sy0002.com/game/getLotteryData.do?_t=1682239054942&gameId=41
    //请求方法: GET
    //状态代码: 200 
    //远程地址: 154.218.13.234:443
    //引用者策略: strict-origin-when-cross-origin
    //content-disposition: inline;filename=f.txt
    //content-encoding: gzip
    //content-type: text/html; charset=UTF-8
    //date: Sun, 23 Apr 2023 08:37:34 GMT
    //guard-cache: BYPASS
    //guard-store: BYPASS
    //server: nginx/1.17.3
    //:authority: www.sy0002.com
    //:method: GET
    //:path: /game/getLotteryData.do?_t=1682239054942&gameId=41
    //:scheme: https
    //accept: application/json, text/plain, */*
    //accept-encoding: gzip, deflate, br
    //accept-language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
    //cookie: x-session-token=29E9lOpUfamRjyHlwuKD1L2umR2oUaOR%2FYl70rdcgB7aaw1Gm4yN8A%3D%3D; checkCode=83b01372-1e8f-44ad-840c-8c9c5772e3a6
    //referer: https://www.sy0002.com/game/
    //sec-fetch-dest: empty
    //sec-fetch-mode: cors
    //sec-fetch-site: same-origin
    //user-agent: Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        PostBet(1, "大", LoadNextNum());
    }
}