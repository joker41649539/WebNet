using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Gambling_FootBallData : PageBaseGambling
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadFootBallDataByPB();
        }
    }


    private void LoadFootBallDataByPB()
    {
        string strURL = "https://phoile.staker88.com/sports-service/sv/am/events?_g=0&btg=1&c=&d=&ec=&ev=&g=QQ%3D%3D&inl=false&l=1&lg=&lv=&me=0&mk=1&more=false&o=0&ot=1&pa=0&pimo=0%2C1%2C8%2C39%2C3&pn=-1&sp=29&tm=0&v=0&wm=ld&locale=zh_CN&_=1682401281769&withCredentials=true";

        gZipWebClient client = new gZipWebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        string strDataTime = GetTimeStamp(System.DateTime.Now).ToString();

        client.Headers.Add("accept", "application/json, text/plain, */*");
        client.Headers.Add("accept-encoding", "gzip, deflate, br");
        client.Headers.Add("accept-language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
        client.Headers.Add("cookie", "pctag=bf356939-f94e-45e7-a301-6282f0616b8a; _ga=GA1.2.2132813431.1682398821; _gid=GA1.2.761561851.1682398821; specifySport=soccer; u_79=AAAAAwAAAAAEgGGeAAABh7duk3rh3m4vEtvQ2AeGMobM8tauzYEhPWRiMrekg48Lcq1mRA==; lcu=AAAAAwAAAAAEgGGeAAABh7duk3rh3m4vEtvQ2AeGMobM8tauzYEhPWRiMrekg48Lcq1mRA==; __prefs=W251bGwsMSwxLDAsMCxudWxsLGZhbHNlLDAuMDAwMCxmYWxzZSx0cnVlLCJBTEwiLDEsbnVsbF0=; _og=QQ==; oddsFormat=EU; SLID_79=-799729380; _ulp=Tkp5bkdVeENWU0VyMVo0Tm9zUlk5dEZQVFFVYncwa3BmNUNYWWxLSWdFTnBFRVRNeDVNS2dEYlhIeWhoejUyRXZ3eE1ZV1NSWWN4bVJUV2pmOTFvanc9PXw5MDBkNDZjMzc5ZDU2ZmMzNDNhNzAyYjE1NjMxODkzZQ==; _userDefaultView=COMPACT; isEsportsHub_79=; skin=whitelabel; displayMessPopUp=true; _gat=1; PCTR=1840258891191; _dc_gtm_UA-55804949-1=1; _vid=6e2991eaf171426fae3174f524f5ecd9; Rxy=25R6lzO; custid_79=id=2410102CAA&login=202304250301&roundTrip=202304250301&hash=A7D7791127AEE1BF374691512E04AE16; BrowserSessionId_79=2bac05b5-4e9f-4d20-b8f8-52c5e96bb7a7; lang=zh_CN; closeAnnTime=0; isShowAcceptTC=false; locale=zh_CN; auth=true; _loginId=; session={%22userName%22:%22undefined%22%2C%22id%22:%22undefined%22%2C%22role%22:{%22bitMask%22:2%2C%22title%22:%22user%22}}");

        client.Headers.Add("referer", "https://phoile.tender88.com/m/zh-cn/asian/sports/soccer/Today/Matches/0");
        client.Headers.Add("sec-fetch-dest", "empty");
        client.Headers.Add("sec-fetch-mode", "cors");
        client.Headers.Add("sec-fetch-site", "same-origin");
        client.Headers.Add("user-agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0");


        //请求 URL: https://phoile.tender88.com/sports-service/sv/am/events?_g=0&btg=1&c=&d=&ec=&ev=&g=QQ%3D%3D&inl=false&l=1&lg=&lv=&me=0&mk=1&more=false&o=0&ot=1&pa=0&pimo=0%2C1%2C8%2C39%2C3&pn=-1&sp=29&tm=0&v=0&wm=ld&locale=zh_CN&_=1682406102294&withCredentials=true
        //引用者策略: strict - origin - when - cross - origin
        //:authority: phoile.tender88.com
        //:method: GET
        //    : path: / sports - service / sv / am / events ? _g = 0 & btg = 1 & c = &d = &ec = &ev = &g = QQ % 3D % 3D & inl = false & l = 1 & lg = &lv = &me = 0 & mk = 1 & more = false & o = 0 & ot = 1 & pa = 0 & pimo = 0 % 2C1 % 2C8 % 2C39 % 2C3 & pn = -1 & sp = 29 & tm = 0 & v = 0 & wm = ld & locale = zh_CN & _ = 1682406102294 & withCredentials = true
        //:scheme: https
        //accept: application / json, text / plain, */*
        //accept-encoding: gzip, deflate, br
        //accept-language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
        //cookie: pctag=bf356939-f94e-45e7-a301-6282f0616b8a; _ga=GA1.2.2132813431.1682398821; _gid=GA1.2.761561851.1682398821; specifySport=soccer; u_79=AAAAAwAAAAAEgGGeAAABh7duk3rh3m4vEtvQ2AeGMobM8tauzYEhPWRiMrekg48Lcq1mRA==; lcu=AAAAAwAAAAAEgGGeAAABh7duk3rh3m4vEtvQ2AeGMobM8tauzYEhPWRiMrekg48Lcq1mRA==; __prefs=W251bGwsMSwxLDAsMCxudWxsLGZhbHNlLDAuMDAwMCxmYWxzZSx0cnVlLCJBTEwiLDEsbnVsbF0=; _og=QQ==; oddsFormat=EU; SLID_79=-799729380; _ulp=Tkp5bkdVeENWU0VyMVo0Tm9zUlk5dEZQVFFVYncwa3BmNUNYWWxLSWdFTnBFRVRNeDVNS2dEYlhIeWhoejUyRXZ3eE1ZV1NSWWN4bVJUV2pmOTFvanc9PXw5MDBkNDZjMzc5ZDU2ZmMzNDNhNzAyYjE1NjMxODkzZQ==; _userDefaultView=COMPACT; isEsportsHub_79=; skin=whitelabel; displayMessPopUp=true; _gat=1; PCTR=1840258891191; _dc_gtm_UA-55804949-1=1; _vid=6e2991eaf171426fae3174f524f5ecd9; Rxy=25R6lzO; custid_79=id=2410102CAA&login=202304250301&roundTrip=202304250301&hash=A7D7791127AEE1BF374691512E04AE16; BrowserSessionId_79=2bac05b5-4e9f-4d20-b8f8-52c5e96bb7a7; lang=zh_CN; closeAnnTime=0; isShowAcceptTC=false; locale=zh_CN; auth=true; _loginId=; session={%22userName%22:%22undefined%22%2C%22id%22:%22undefined%22%2C%22role%22:{%22bitMask%22:2%2C%22title%22:%22user%22}}
        //referer: https://phoile.tender88.com/m/zh-cn/asian/sports/soccer/Today/Matches/0
        //sec-fetch-dest: empty
        //sec-fetch-mode: cors
        //sec-fetch-site: same-origin
        //user-agent: Mozilla/5.0 (iPhone; CPU iPhone OS 13_2_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0.3 Mobile/15E148 Safari/604.1 Edg/112.0.0.0

        var data = client.DownloadString(strURL);
        dynamic obj = JsonConvert.DeserializeObject(data);

        // 获取"u"属性中的数组
        List<dynamic> u = obj.u;

        // 获取内部数组中的值
        int firstValue = u[0][0];
        List<dynamic> secondValue = u[0][1];
        long thirdValue = u[0][2];
        int fourthValue = u[0][3];

        //        ?jo["l"][0][2][1][2][0][0].ToString()
        //"1572060531"
        //? jo["l"][0][2][1][2][0][1].ToString()
        //"萨卡特科卢卡市普拉滕斯俱乐部"
        //? jo["l"][0][2][1][2][0][2].ToString()
        //"乔科洛足球俱乐部"

        //{\r\n  \"0\": [\r\n    [\r\n      [\r\n        0.0,\r\n        0.0,\r\n        \"0.0\",\r\n        \"1.429\",\r\n        \"2.910\",\r\n        0,\r\n        0,\r\n        2083504211,\r\n        0,\r\n        475.0,\r\n        1\r\n      ]\r\n    ],\r\n    [\r\n      [\r\n        \"1.5\",\r\n        1.5,\r\n        \"3.660\",\r\n        \"1.290\",\r\n        2083504211,\r\n        0,\r\n        475.0,\r\n        1\r\n      ]\r\n    ],\r\n    [\r\n      \"1.162\",\r\n      \"48.780\",\r\n      \"5.670\",\r\n      2083504211,\r\n      0,\r\n      225.0,\r\n      1\r\n    ],\r\n    0,\r\n    null,\r\n    0,\r\n    0,\r\n    [\r\n      0,\r\n      0\r\n    ],\r\n    5,\r\n    [\r\n      0,\r\n      1\r\n    ],\r\n    [\r\n      0,\r\n      0\r\n    ],\r\n    2\r\n  ]\r\n}
        
        
        //var rep = await client.GetAsync(strURL);

            ////var content = await rep.Content.ReadAsStringAsync();
            //if (rep.IsSuccessStatusCode)
            //{
            //    var data = await rep.Content.ReadAsStreamAsync();
            //    // 创建 GZipStream 对象，并将压缩数据流传递给它的构造函数
            //    var decompressedStream = new GZipStream(data, CompressionMode.Decompress);

            //    // 读取解压缩后的数据
            //    var reader = new StreamReader(decompressedStream);
            //    var content = await reader.ReadToEndAsync();


            //    JObject jo = JObject.Parse(content);
            //    var str = jo["l"][0].ToList();// [1].ToString();            
            //}
    }

}