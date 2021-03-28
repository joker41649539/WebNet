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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public partial class Fil_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetNewsByWeb();
    }


    /// <summary>
    /// 网络上获取新闻
    /// </summary>
    private void GetNewsByWeb()
    {
        string Url = "http://api.tianapi.com/digiccy/index?key=718245142813425a7adab4f1cd4f64b4";

        var client = new System.Net.WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        var data = client.DownloadString(Url);
        var jo = (JObject)JsonConvert.DeserializeObject(data);
        JArray data1 = jo.Value<JArray>("newslist");
        var jon = jo["newslist"];

        foreach (var node in data1)
        {

            JArray data2 = jo.Value<JArray>("newslist");

        }



        TextBox1.Text += jon.ToString() + "//r//n";

        //MessageBox("", obj["newslist"].ToString());
    }

    //var jon1 = jon["title"];
    //var data1 = jo["newslist"].ToString().Substring(1, jo["newslist"].ToString().Length - 2);

    //JObject jo1 = (JObject)JsonConvert.DeserializeObject(data1);

    //  { "code":200,"msg":"success","newslist":[{ "id":"93f1cb182cf8b545bcd61c82dfa73425","ctime":"2021-03-27 13:57","title":"特斯拉成首家接受数字货币支付的汽车制造商","description":"原标题：特斯拉成首家接受数字货币支付的汽车制造商来源：东方财富网原标题：特斯拉成首家接受数字货币支付的汽车制造商上个月，特斯拉被曝购买了价值15亿美","source":"币圈资讯","picUrl":"http:\/\/n.sinaimg.cn\/spider2021327\/705\/w480h225\/20210327\/4a15-kmvwsvy5497945.jpg","url":"http:\/\/finance.sina.com.cn\/stock\/relnews\/us\/2021-03-27\/doc-ikknscsk2295331.shtml"},{ "id":"b3c7b9456878c019b652e2598efea6cb","ctime":"2021-03-27 18:28","title":"中国央行建议制定全球央行数字货币规则","description":"联合早报讯：中国25日提议，要为央行数字货币制订一套全球规则，涉及全球使用、以及监督和信息共享等高度敏感的问题。据路透社报道，世界各地一些央行正考虑开发数字货","source":"币圈资讯","picUrl":"http:\/\/n.sinaimg.cn\/sinakd20210327s\/480\/w640h640\/20210327\/cc70-kmvwsvy6158817.jpg","url":"http:\/\/t.cj.sina.com.cn\/articles\/view\/2550216490\/9801372a01900wbkf"},{ "id":"57ffe9a61abbc02e87af124d020bfcfe","ctime":"2021-03-26 19:04","title":"投资者提问：请问现在六大银行都使用数字货币了公司的产品有没有收到订单？公司...","description":"投资者提问：请问现在六大银行都使用数字货币了公司的产品有没有收到订单？公司产品已经使用到数字货币了吗？董秘回答(国民技术SZ300077)：尊敬的投资者您","source":"币圈资讯","picUrl":"","url":"http:\/\/finance.sina.com.cn\/stock\/relnews\/dongmiqa\/2021-03-26\/doc-ikknscsk1845905.shtml"},{ "id":"834e72d986c0b2abb53dc0b7a624f171","ctime":"2021-03-26 19:05","title":"国民技术：当前数字货币处于小规模应用试点阶段，技术路线、应用格局均存在较大不确定性","description":"原标题：国民技术：当前数字货币处于小规模应用试点阶段，技术路线、应用格局均存在较大不确定性来源：每日经济新闻每经AI快讯，有投资者在投资者互动平台提问","source":"币圈资讯","picUrl":"","url":"http:\/\/finance.sina.com.cn\/stock\/relnews\/cn\/2021-03-26\/doc-ikknscsk1847344.shtml"},{ "id":"4d58af546b25c016716628c855e08f4c","ctime":"2021-03-26 19:17","title":"人民银行数研所发布首期法定数字货币创新研究开放课题","description":"财联社3月26日讯，今日，中国人民银行数字货币研究所正式对外发布“法定数字货币创新研究开放课题（2021年度）”。人民银行数字货币研究所牵头并组织实施开放课题研","source":"币圈资讯","picUrl":"","url":"http:\/\/k.sina.cn\/article_6192937794_17120bb4202001ixzp.html"},{ "id":"f95ebf3f5cef196e76a80e0fa2a92030","ctime":"2021-03-26 19:24","title":"央行数研所发布首期法定数字货币创新研究开放课题","description":"　　原标题：人民银行数研所发布首期法定数字货币创新研究开放课题　　为贯彻落实《中共中央关于制定国民经济和社会发展第十四个五年规划和二〇三五年远景目标的建议》","source":"币圈资讯","picUrl":"","url":"http:\/\/finance.sina.com.cn\/money\/bank\/bank_hydt\/2021-03-26\/doc-ikkntiam8693294.shtml"},{ "id":"13dd761df40b466b20c2bd14ed565156","ctime":"2021-03-26 19:30","title":"中国央行提议：需制订数字货币全球规则","description":"本文为「金十数据」原创文章，未经许可，禁止转载，违者必究。据联合早报3月26日最新报道，在昨日的国际清算银行（BIS）创新峰会上，中国央行首次提议，要为央行数","source":"币圈资讯","picUrl":"http:\/\/n.sinaimg.cn\/default\/feedbackpics\/transform\/116\/w550h366\/20180418\/Zej4-fzihnep5208706.png","url":"http:\/\/finance.sina.com.cn\/roll\/2021-03-26\/doc-ikknscsk1870322.shtml"},{ "id":"c6dcc2a3be5a622d171b8826e97e5756","ctime":"2021-03-26 19:51","title":"【金融街发布】央行数研所发布开放课题 构建法定数字货币协同创新研究体系","description":"原标题：【金融街发布】央行数研所发布开放课题构建法定数字货币协同创新研究体系新华财经北京3月26日电为稳妥推进数字货币研发，助力构建法定数字货币协同创新研","source":"币圈资讯","picUrl":"http:\/\/n.sinaimg.cn\/sinakd2021326s\/72\/w640h232\/20210326\/a12c-kmvwsvy3229985.jpg","url":"http:\/\/finance.sina.com.cn\/jjxw\/2021-03-26\/doc-ikknscsk1872038.shtml"},{ "id":"76bf4682e5ddf3b191e9142f117d9150","ctime":"2021-03-26 20:45","title":"计算机行业：数字货币测试全面铺开 推广前哨已吹响","description":"事件：根据上海证券报报道，数字人民币测试正进入全面提速阶段，六大国有银行已经开始推广数字人民币货币钱包。在银行营业网点中，客户只需要提出白名单申请，就可以在央行","source":"币圈资讯","picUrl":"http:\/\/n.sinaimg.cn\/finance\/news\/ShenDuYanJiu2.jpg","url":"http:\/\/stock.finance.sina.com.cn\/stock\/go.php\/vReport_Show\/kind\/lastest\/rptid\/670083396891\/index.phtml"},{ "id":"931e1e2c1d06624b65c5772f4ad3dc40","ctime":"2021-03-26 21:05","title":"法定数字货币课题申请指南来了 研究方向涉及5G技术应用场景创新","description":"　　原标题：法定数字货币课题申请指南来了！研究方向涉及5G技术应用场景创新　　上证报中国证券网讯（记者黄紫豪）人民银行26日发布《法定数字货币创新研究开放","source":"币圈资讯","picUrl":"http:\/\/n.sinaimg.cn\/default\/feedbackpics\/transform\/116\/w550h366\/20180409\/UaCg-fyvtmxe2860227.png","url":"http:\/\/finance.sina.com.cn\/chanjing\/cyxw\/2021-03-26\/doc-ikkntiam8731717.shtml"}]}

    //var serializer = new JavaScriptSerializer();
    //var obj = serializer.Deserialize<Dictionary<string, string>>(data);


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