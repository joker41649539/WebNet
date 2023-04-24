using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;

public partial class Gambling_Canada28 : PageBaseGambling
{
    public int MaxHistoryCount = 20;// 最多显示历史行数
    public string CookinCanada = "Canada28";// 加拿大28COOKIN
                                            // public DataTable dtBet = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            LoadGamblingResult();
            MessageBox("刷新了");
        }
    }
    private void LoadData()
    {
        //dtBet.Columns.Add("TurnNum");
        //dtBet.Columns.Add("PlayName");
        //dtBet.Columns.Add("Win");
        //dtBet.Columns.Add("Time");

        if (Request.Cookies[CookinCanada] != null)
        {
            TextBox_Url.Text = Request.Cookies[CookinCanada]["URL"];
            TextBox_Cookie.Text = Request.Cookies[CookinCanada]["UserInfo"].Replace('|', ';');
            TextBox_Bet.Text = Request.Cookies[CookinCanada]["BetNum"].Replace('|', ';');
        }
        else
        {
            TextBox_Url.Text = "www.sy0002.com";
            TextBox_Cookie.Text = "x-session-token=zTK3%2F%2FVIna8B9HKQhOjFFhV5J4b9tnPNQAVJGW3cyBSHvdwqOkLWHw%3D%3D; checkCode=efb9f77f-c8f8-4193-84f8-982bacdd6501";
            TextBox_Bet.Text = "50;150;350;750;1550";
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadGamblingResult();
    }

    /// <summary>
    /// 加载开奖结果
    /// </summary>
    private void LoadGamblingResult()
    {
        try
        {
            gZipWebClient client = new gZipWebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string strURL = TextBox_Url.Text.Trim();
            string strData = System.DateTime.Now.ToString("yyyyMMdd") + "41";
            string strDataTime = GetTimeStamp(System.DateTime.Now).ToString();
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
            Rootobject rb = JsonConvert.DeserializeObject<Rootobject>(data);

            DataTable dt = new DataTable();
            dt.Columns.Add("turnNum");
            dt.Columns.Add("openNum");
            dt.Columns.Add("Big");
            dt.Columns.Add("double");
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
                    dt.Rows[i][1] = (Convert.ToInt32(rb.data[i].n1) + Convert.ToInt32(rb.data[i].n2) + Convert.ToInt32(rb.data[i].n3)).ToString() + "  [" + rb.data[i].openNum + "]";
                    if (Convert.ToInt32(rb.data[i].n1) + Convert.ToInt32(rb.data[i].n2) + Convert.ToInt32(rb.data[i].n3) > 13)
                    {
                        dt.Rows[i][2] = "大";
                    }
                    else
                    {
                        dt.Rows[i][2] = "小";
                    }
                    if ((Convert.ToInt32(rb.data[i].n1) + Convert.ToInt32(rb.data[i].n2) + Convert.ToInt32(rb.data[i].n3)) % 2 == 0)
                    {
                        dt.Rows[i][3] = "双";
                    }
                    else
                    {
                        dt.Rows[i][3] = "单";
                    }

                    dt.Rows[i][4] = Convert.ToDateTime(rb.data[i].openTime).ToString("MM-dd HH:mm").ToString();

                    /// 输赢判断
                    if (dt.Rows[i][0].ToString() == Label_TurnNum.Text)
                    { //Win
                        if (dt.Rows[i][2].ToString() == Label_PlayName.Text)
                        {// 大小，下中了
                            Label_BetSN.Text = "0";// 复位序号
                            TextBox1.Text += "下中了。\r\n";
                        }
                        else
                        {
                            if (dt.Rows[i][3].ToString() == Label_PlayName.Text)
                            {// 单双，下中了
                                Label_BetSN.Text = "0";// 复位序号
                                TextBox1.Text += "下中了。\r\n";
                            }
                            else
                            {
                                TextBox1.Text += "未下中。\r\n";
                                Label_BetSN.Text = (Convert.ToInt32(Label_BetSN.Text) + 1).ToString();// 未中，SN+1;
                                if (Convert.ToInt32(Label_BetSN.Text) > (TextBox_Bet.Text).Split(';').Length - 1)
                                { // 炸了，复位注码序号
                                    TextBox1.Text += "未下中，炸了。\r\n";
                                    Label_BetSN.Text = "0";
                                }
                            }
                        }
                        Label_TurnNum.Text = "无";
                        Label_PlayName.Text = "无";
                        Label_BetCount.Text = "0";
                    }
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
            // 列表加载完后加载余额和下局信息。
            LoadUserInfo();// 读取余额
            LoadNextNum();// 读取下一局局号
            LoadBetCount();//读取待开奖情况
        }
        catch
        {
            MessageBox("开奖结果读取错误。");
        }
    }

    /// <summary>
    /// 读取余额
    /// </summary>
    /// <returns></returns>

    private double LoadUserInfo()
    {
        double rValue = 0;
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
        rValue = Convert.ToDouble(User.userWalletViews[0].money);
        Label_money.Text = User.userWalletViews[0].money.ToString();
        return rValue;
    }


    private void PostBet(int BetMoney, string BetContent, string BetNum)
    {
        string postData = string.Empty;

        string strURL = TextBox_Url.Text.Trim();
        string strDataTime = GetTimeStamp(System.DateTime.Now).ToString();
        string strBetCount = "0";

        if (BetContent == "大")
        {
            strBetCount = "4144601";
        }
        else if (BetContent == "小")
        {
            strBetCount = "4144602";
        }
        else if (BetContent == "单")
        {
            strBetCount = "4144603";
        }
        else if (BetContent == "双")
        {
            strBetCount = "4144604";
        }

        postData = "gameId=41&totalNums=1&totalMoney=" + BetMoney + "&betSrc=0&turnNum=" + BetNum + "&betBean%5B0%5D.playId=" + strBetCount + "&betBean%5B0%5D.money=" + BetMoney;

        var url = string.Format("https://{0}/bet/bet.do?_t={1}", strURL, strDataTime);

        PostPage(url, postData, TextBox_Url.Text, TextBox_Cookie.Text, Convert.ToInt32(strDataTime));
    }

    /// <summary>
    /// 获取下局编号
    /// </summary>
    /// <returns></returns>
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

        Label_NextNum.Text = nextNum.issue.ToString();
        Label_EndTime.Text = nextNum.endtime;
        //TextBox1.Text += "下一局：" + nextNum.issue + "截止时间：" + nextNum.endtime;
        sRvalue = nextNum.issue;
        return sRvalue;
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
    //{\"balance\":102.192,\"unbalancedMoney\":1.0,\"totalTotalMoney\":-2.806,\"totalMoneyMap\":null,\"userBetWinList\":null,\"userBetNew\":[{\"id\":1927058033,\"userId\":1200405,\"userName\":\"lkjgh688\",\"playId\":4144601,\"playName\":\"澶?,\"playCateId\":446,\"betInfo\":\"\",\"multiple\":1,\"winCount\":null,\"money\":1.0,\"odds\":1.95,\"rebate\":0.0,\"addTime\":\"2023-04-24 12:56:48\",\"turnNum\":\"2988676\",\"gameId\":41,\"status\":0,\"reward\":0.0,\"rewardRebate\":null,\"rebateMoney\":null,\"orderNo\":\"12230424125648828921501\",\"result\":0,\"frozenMoney\":0.0,\"trawMoney\":null,\"remark\":\"{\\\"playName\\\":\\\"澶\",\\\"winNums\\\":\\\"\\\",\\\"odds\\\":\\\"1.950\\\"}\",\"resultMoney\":0.95,\"openNum\":null,\"currency\":\"RMB\"}],\"pushMessage\":null,\"userNoticeMsg\":0,\"refreshRechType\":null,\"balanceMap\":null,\"unbalancedMap\":null,\"currency\":\"RMB\",\"maintainStatus\":null,\"tradingNotice\":null,\"point\":0.0,\"refreshGameList\":null}
    // unbalancedMoney: 4 // 待结算金额

    /// <summary>
    /// 获取下注金额
    /// </summary>
    /// <returns></returns>
    private double LoadBetCount()
    {
        double sRvalue = 0;
        gZipWebClient client = new gZipWebClient();
        client.Encoding = Encoding.UTF8;
        string strURL = TextBox_Url.Text.Trim();
        string strDataTime = GetTimeStamp(System.DateTime.Now).ToString();

        var url = string.Format("https://{0}/game/getLotteryData.do?_t={1}&gameId=41", strURL, strDataTime);

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
        UserBet UB = JsonConvert.DeserializeObject<UserBet>(data);

        Label_BetCount.Text = UB.unbalancedMoney.ToString();
        Label_Win.Text = UB.totalTotalMoney.ToString();//利润
        if (UB.userBetNew != null)
        {
            Label_TurnNum.Text = UB.userBetNew[0].turnNum.ToString();
            Label_PlayName.Text = UB.userBetNew[0].playName.ToString();
        }
        sRvalue = Convert.ToDouble(UB.unbalancedMoney);
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
        int betCount = 1;
        string BetContent = "单";
        BetTrue(betCount, BetContent);
    }

    private bool BetTrue(int BetCount, string BetContent)
    {
        bool rValue = false;
        LoadNextNum(); //首先更新一下余额
        double Old_Money = Convert.ToDouble(Label_money.Text);

        if (Old_Money < BetCount)
        {
            TextBox1.Text += "[" + Label_NextNum.Text + "] 下注失败，需下注 [" + BetCount.ToString() + " 元" + BetContent + "]，余额为[" + Old_Money + "]。\r\n";
            return false;
        }

        if (Convert.ToDateTime(Label_EndTime.Text) <= System.DateTime.Now)
        {
            TextBox1.Text += "[" + Label_NextNum.Text + "] 下注失败，超过下注时间。\r\n";
            return false;
        }

        PostBet(BetCount, BetContent, LoadNextNum());// 下注

        LoadBetCount();// 读取待开奖金额
        LoadUserInfo();// 完成后再查询下结果
        double New_Money = Convert.ToDouble(Label_money.Text);

        if (Convert.ToInt32(Old_Money - New_Money) == BetCount)
        {// 
            //dtBet.Columns.Add("TurnNum");
            //dtBet.Columns.Add("PlayName");
            //dtBet.Columns.Add("Win");
            //dtBet.Columns.Add("Time");

            TextBox1.Text += "[" + Label_NextNum.Text + "] 成功下注 [" + BetCount.ToString() + " 元 " + BetContent + "]。\r\n";
            rValue = true;
        }
        return rValue;
    }

    /// <summary>
    /// 保存cookin
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Cookies[CookinCanada]["UserInfo"] = TextBox_Cookie.Text.Replace(';', '|');
        Response.Cookies[CookinCanada]["URL"] = TextBox_Url.Text;
        Response.Cookies[CookinCanada]["BetNum"] = TextBox_Bet.Text.Replace(';', '|');
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (CheckBox_Auto.Checked)
        {
            if (Label_TurnNum.Text == "无"|| Label_TurnNum.Text == "0")
            {// 等于无下注操作
                BetTrue();
            }
            LoadGamblingResult();
            MessageBox("刷新了");
        }
    }

    /// <summary>
    /// 下注操作
    /// </summary>
    private void BetTrue()
    {
        int BetCount = 0;
        try
        {
            BetCount = Convert.ToInt32(TextBox_Bet.Text.Split(';')[Convert.ToInt32(Label_BetSN.Text)]);
        }
        catch
        {
            MessageBox("注码序号错误，请检查。");
            return;
        }
        if (GridView1.Rows.Count > 3)
        {
            if (GridView1.Rows[0].Cells[2].Text == GridView1.Rows[1].Cells[2].Text & GridView1.Rows[1].Cells[2].Text == GridView1.Rows[2].Cells[2].Text & GridView1.Rows[2].Cells[2].Text == GridView1.Rows[3].Cells[2].Text)
            { // 
                if (GridView1.Rows[0].Cells[2].Text == "大")
                {
                    BetTrue(BetCount, "小");
                }
                else
                {
                    BetTrue(BetCount, "大");
                }
            }
            if (GridView1.Rows[0].Cells[3].Text == GridView1.Rows[1].Cells[3].Text & GridView1.Rows[1].Cells[3].Text == GridView1.Rows[2].Cells[3].Text & GridView1.Rows[2].Cells[3].Text == GridView1.Rows[3].Cells[3].Text)
            { // 
                if (GridView1.Rows[0].Cells[3].Text == "单")
                {
                    BetTrue(BetCount, "双");
                }
                else
                {
                    BetTrue(BetCount, "单");
                }
            }
        }
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        // LoadBetCount();
        // TextBox1.Text += "测试一下\r\n";
        //  MessageBox(TextBox_Bet.Text.Split(';').Length.ToString());
    }
}