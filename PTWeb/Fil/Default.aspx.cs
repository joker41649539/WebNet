using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fil_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        Label_DayNow.Text = System.DateTime.Now.ToString("yyyy-MM-dd") + " 汇总";
        LoadData();
        Label_YL.Text = (Convert.ToDecimal(Label_YE.Text) + Convert.ToDecimal(Label_RMB.Text) - Convert.ToDecimal(450000)).ToString();
        //}
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    private void LoadData()
    {
        string strSQL = "Select top 1 * from Fil_Summary where  CONVERT(varchar(100), GETDATE(), 23)= CONVERT(varchar(100),CTIME, 23)";
        if (!OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "错误：" + OP_Mode.strErrMsg);
        }
        else
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Double NumSumYE, NumKYYE, NumHQ, NumWKSC, NumWin, NumSumPower, NumAverage;
                string NumPowerAdd;
                NumSumYE = Convert.ToDouble(OP_Mode.Dtv[0]["FilYE"].ToString());
                NumKYYE = Convert.ToDouble(OP_Mode.Dtv[0]["FilYE"].ToString());
                NumPowerAdd = OP_Mode.Dtv[0]["PowerAdd"].ToString();
                NumHQ = Convert.ToDouble(OP_Mode.Dtv[0]["FilRmb"].ToString());
                NumWKSC = Convert.ToDouble(OP_Mode.Dtv[0]["Lock"].ToString());
                NumWin = Convert.ToDouble(OP_Mode.Dtv[0]["Gift"].ToString());
                NumSumPower = Convert.ToDouble(OP_Mode.Dtv[0]["SumPower"].ToString());
                NumAverage = Convert.ToDouble(OP_Mode.Dtv[0]["Average"].ToString());
                Label_DayNow.Text = Convert.ToDateTime(OP_Mode.Dtv[0]["CTime"]).ToString();
                //////////////////////////////////////////////
                /// Fil 总余额
                Label_FilYE.Text = (NumSumYE).ToString("F2");
                /// 日增长 
                Label_RZZ.Text = NumPowerAdd.ToString();
                /// 总算力
                Label_ZSL.Text = NumSumPower.ToString();
                // 运行时间
                Label_Day.Text = GetDuration(System.DateTime.Now, Convert.ToDateTime("2021-01-01")).ToString();
                // 行情
                Label_RMB.Text = (NumHQ).ToString("F2");
                // 挖矿锁仓
                Label_PowerLock.Text = NumWKSC.ToString();
                // 出快奖励
                Label_CK.Text = NumWin.ToString();
                // 全网平均
                Label_PJ.Text = NumAverage.ToString();
            }
            else
            {/// 未存储过数据，通过网路更新数据
                GetTotal();
                GetNewsByWeb();
            }
        }

    }
    /// <summary>
    /// 获取币圈新闻
    /// </summary>
    private void GetNewsByWeb()
    {
        //string Url = "http://api.tianapi.com/digiccy/index?key=718245142813425a7adab4f1cd4f64b4&num=10";

        //var client = new System.Net.WebClient();
        //client.Encoding = System.Text.Encoding.UTF8;

        //var data = client.DownloadString(Url);
        //var jo = (JObject)JsonConvert.DeserializeObject(data);
        //JArray data1 = jo.Value<JArray>("newslist");
        //Newtonsoft.Json.Linq.JObject js = jo as Newtonsoft.Json.Linq.JObject;//把上面的obj转换为 Jobject对象
        //JArray jarray = (JArray)js["newslist"];

        //string strSQL = "";

        //foreach (var node in jarray)
        //{
        //    NewslistItem itm = JsonConvert.DeserializeObject<NewslistItem>(node.ToString());

        //    strSQL = "insert into Fil_News(Title,Url,NewsID,PicUrl,Description,LTime) values ('" + itm.title + "','" + itm.url + "','" + itm.id + "','" + itm.picUrl + "','" + itm.description + "','" + itm.ctime + "')";

        //    if (!OP_Mode.SQLRUN(strSQL))
        //    {
        //        // MessageBox("", OP_Mode.strErrMsg);
        //        break;
        //    }
        //}
    }
    public class NewslistItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ctime { get; set; }
        /// <summary>
        /// 特斯拉成首家接受数字货币支付的汽车制造商
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 原标题：特斯拉成首家接受数字货币支付的汽车制造商来源：东方财富网原标题：特斯拉成首家接受数字货币支付的汽车制造商上个月，特斯拉被曝购买了价值15亿美
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 币圈资讯
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string picUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
    }

    /// <summary>
    /// 保存数据到数据库
    /// </summary>
    private void SaveData()
    {
        string strSQL = "Insert into Fil_Summary (SumRMBYE,SumGift,SumPower,PowerAdd,Lock,FilYE,FilRmb,Hardware,Average,Gift) values (" + Label_RMB.Text + "," + Label_CK.Text + "," + Label_ZSL.Text + ",(" + Label_ZSL.Text + " - (Select top 1 SumPower from Fil_Summary order by CTIME desc))," + Label_PowerLock.Text + "," + Label_FilYE.Text + "," + Label_RMB.Text + "," + Label_YJ.Text + "," + Label_PJ.Text + "," + Label_CK.Text + " - (Select top 1 sumgift from Fil_Summary order by CTIME desc))";
        if (!OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "错误：" + OP_Mode.strErrMsg);
        }
        else
        {
            DataInsert();// 插入每天所有用户的明细数据
        }
    }

    /// <summary>
    /// 互联网获取数据信息
    /// </summary>
    public void GetTotal()
    {
        try
        {
            string strURL = "https://filfox.info/en/address/f063628";// 旷工账户信息
            string UserURL = "https://filfox.info/en/address/f3sfrn2s523s7rpkedw7efqzlk2wzs7y3sg3ie6xuuyx72pchyk2mzg4ms4q7favb2iv7m6uy3pjlp2e4zob3a"; // 节点账户信息
            string HQUrl = "https://filfox.info/en"; //行情信息

            List<string> result = new List<string>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"" + strURL + "");
            request.Timeout = 4000;
            request.ReadWriteTimeout = 4000;
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, Encoding.UTF8);
            string content = sr.ReadToEnd();

            string totalDataStr;//, totalDataStr_SG, totalDataStr_PK, totalDataStr_TZ, totalDataStr_ZQ;

            /// 可用余额
            string strKYYE = "</span>: ";
            string strWKSC = "Locked Rewards: ";
            string strWin = "Total Reward:";
            string strPowerAdd = "算力增速: ";
            string strSumPower = "Adjusted Power </p><div class=";


            int startIndex = content.IndexOf(strKYYE);
            int length = content.IndexOf("FIL", startIndex) - startIndex;

            /// 获得可用余额
            totalDataStr = content.Substring(startIndex, length);

            /// 获得可用余额
            double NumKYYE = Convert.ToDouble(totalDataStr.Substring(strKYYE.Length, totalDataStr.Length - strKYYE.Length).Replace(",", ""));

            startIndex = content.IndexOf(strWKSC);
            length = content.IndexOf("FIL", startIndex) - startIndex;

            /// 获得锁仓金额
            totalDataStr = content.Substring(startIndex, length);

            double NumWKSC = Convert.ToDouble(totalDataStr.Substring(strWKSC.Length, totalDataStr.Length - strWKSC.Length).Replace(",", ""));
            ////// 累计 出快奖励   
            startIndex = content.IndexOf(strWin);
            length = content.IndexOf("FIL", startIndex) - startIndex;

            /// 获得 出快奖励
            totalDataStr = content.Substring(startIndex, length);

            double NumWin = Convert.ToDouble(totalDataStr.Substring(strWin.Length, totalDataStr.Length - strWin.Length).Replace(",", ""));

            //////// 算力增速
            //startIndex = content.IndexOf(strPowerAdd);
            //length = content.IndexOf("/", startIndex) - startIndex;

            ///// 获得 算力增速
            //totalDataStr = content.Substring(startIndex, length);

            //string NumPowerAdd = totalDataStr.Substring(strPowerAdd.Length, totalDataStr.Length - strPowerAdd.Length).Replace(",", "");

            ////////////////
            ////// 总算力
            startIndex = content.IndexOf(strSumPower);
            length = content.IndexOf(" TiB </p>", startIndex) - startIndex;

            /// 获得 总算力
            totalDataStr = content.Substring(startIndex, length);

            string NumSumPower = totalDataStr.Substring(strSumPower.Length + 76, totalDataStr.Length - strSumPower.Length - 76).Replace(",", "");

            //////  用户信息网址
            request = (HttpWebRequest)WebRequest.Create(@"" + UserURL + "");
            response = request.GetResponse();
            resStream = response.GetResponseStream();
            sr = new StreamReader(resStream, Encoding.UTF8);
            content = sr.ReadToEnd();

            /// 总余额
            string strSumYE = " Balance </dt><dd class=";


            startIndex = content.IndexOf(strSumYE);
            length = content.IndexOf("FIL", startIndex) - startIndex;

            /// 获得 总余额
            totalDataStr = content.Substring(startIndex, length);

            /// 获得 总余额
            double NumSumYE = Convert.ToDouble(totalDataStr.Substring(strSumYE.Length + 8, totalDataStr.Length - strSumYE.Length - 8).Replace(",", ""));
            //////////////////////////////////////////////// 获得总行情
            ////////  用户信息网址
            request = (HttpWebRequest)WebRequest.Create(@"" + HQUrl + "");
            response = request.GetResponse();
            resStream = response.GetResponseStream();
            sr = new StreamReader(resStream, Encoding.UTF8);
            content = sr.ReadToEnd();

            ///// 美元价值
            //string strHQ = "%";


            //startIndex = content.IndexOf(strHQ);
            //length = content.IndexOf("</div>", startIndex) - startIndex;

            ///// 获得 总余额
            //totalDataStr = content.Substring(startIndex, length);

            ///// 获得 总余额
            //double NumHQ = Convert.ToDouble(totalDataStr.Substring(strHQ.Length, totalDataStr.Length - strHQ.Length).Replace(",", ""));

            //////////////////////////////////////////////
            /// 总余额       <!---->Average value in last 24h of the ratio of total block rewards at every tipset and corresponding adjusted storage power.</div><span class="el-popover__reference-wrapper"><div><img src="/dist/img/tip.2db31cb.svg" alt="tip" class="h-3"></div></span></span></div><div class="text-left lg:text-center text-sm lg:text-2xl items-start lg:mx-auto">
            string strPJ = "<!---->Average value in last 24h of the ratio of total block rewards at every tipset and corresponding adjusted storage power.</div><span class=\"el-popover__reference-wrapper\"><div><img src=\"/dist/img/tip.2db31cb.svg\" alt=\"tip\" class=\"h-3\"></div></span></span></div><div class=\"text-left lg:text-center text-sm lg:text-2xl items-start lg:mx-auto\">";


            startIndex = content.IndexOf(strPJ);
            length = content.IndexOf(" FIL/TiB", startIndex) - startIndex;

            /// 获得 总余额
            totalDataStr = content.Substring(startIndex, length);

            /// 获得 平均值
            double NumPJ = Convert.ToDouble(totalDataStr.Substring(strPJ.Length, totalDataStr.Length - strPJ.Length).Replace(",", ""));

            /// Fil 总余额
            Label_FilYE.Text = (NumSumYE + NumKYYE).ToString("F2");
            /// 日增长 
          //  Label_RZZ.Text = NumPowerAdd.ToString();
            /// 总算力
            Label_ZSL.Text = NumSumPower.ToString();
            // 运行时间
            Label_Day.Text = GetDuration(System.DateTime.Now, Convert.ToDateTime("2021-01-01")).ToString();
            // 行情
            //Label_RMB.Text = (NumHQ * 6.4 * (NumSumYE + NumKYYE)).ToString("F2");
            // 挖矿锁仓
            Label_PowerLock.Text = NumWKSC.ToString();
            // 出快奖励
            Label_CK.Text = NumWin.ToString();
            /// 获得全网奖励平均值
            Label_PJ.Text = NumPJ.ToString();

            /// 保存数据到数据库
            SaveData();
        }
        catch (Exception ex)
        {
            MessageBox("", ex.ToString());
        }
    }

    /// <summary>
    /// 获得天数
    /// </summary>
    /// <param name="finish"></param>
    /// <param name="start"></param>
    /// <returns></returns>
    protected int GetDuration(DateTime finish, DateTime start)
    {
        return (finish - start).Days;
    }

    /// <summary>
    /// 数据处理
    /// </summary>
    private void DataInsert()
    {
        //1、删除当天数据
        //2、插入当天算力数据
        string strSQL = "Delete  from Fil_ComputerRelease where CONVERT(varchar(100),CTIME, 23) =CONVERT(varchar(100),getdate(), 23)";
        strSQL += " insert into Fil_ComputerRelease(SumReleaseFil, NowReleaseFil, WaitReleaseFil, ReleasePower, ReleaseDays, PowerComputerID, InvestmentYuan, ProduceYuan, Ctime, LTime)";
        strSQL += " Select Average*Power sumpower,Average* Power*0.25 + Average * Power * 0.75 / 180 * DATEDIFF(DAY, Fil_Summary.CTIME, getdate()),Average* Power-(Average * Power * 0.25 + Average * Power * 0.75 / 180 * DATEDIFF(DAY, Fil_Summary.CTIME, getdate())),Power,DATEDIFF(DAY, Fil_Summary.CTIME, getdate()),Fil_PowerComputer.ID,0,0, CONVERT(varchar(100), Fil_Summary.CTIME, 23) ,getdate()";
        strSQL += " from Fil_Summary, Fil_PowerComputer where Average> 0 and CONVERT(varchar(100),Fil_Summary.CTIME, 23) = CONVERT(varchar(100), getdate(), 23) and Fil_PowerComputer.EffectiveTime<getdate() and Fil_PowerComputer.EndTime>getdate() order by Fil_Summary.CTime";
        if (OP_Mode.SQLRUN(strSQL))
        {
            /// 2、插入当天算力数据
            strSQL = " Delete from FIL_UserReleaseInfo where CONVERT(varchar(100), CTIME, 23) = CONVERT(varchar(100), getdate(), 23) ";
            strSQL += " insert into FIL_UserReleaseInfo(UserID, DayRelease, DayAverage)";
            strSQL += " Select Fil_PowerComputer.userid,sum(SumReleaseFil * 0.25 + SumReleaseFil * 0.75 / 180 * DATEDIFF(DAY, Fil_Summary.CTIME, getdate())) + a.Release,Average from Fil_ComputerRelease,Fil_PowerComputer,Fil_Summary ,";
            strSQL += " (Select sum(SumReleaseFil * 0.75 / 180 * DATEDIFF(DAY, Fil_ComputerRelease.CTIME, getdate())) Release,UserID from Fil_ComputerRelease,Fil_PowerComputer";
            strSQL += " where Fil_PowerComputer.ID = PowerComputerID";
            strSQL += " and CONVERT(varchar(100),Fil_ComputerRelease.CTIME, 23) != CONVERT(varchar(100), getdate(), 23) and DATEDIFF(DAY,Fil_ComputerRelease.CTIME,getdate())<180";
            strSQL += " group by UserID) a";
            strSQL += " where Fil_PowerComputer.ID = PowerComputerID";
            strSQL += " and CONVERT(varchar(100),Fil_ComputerRelease.CTIME, 23) = CONVERT(varchar(100), Fil_Summary.CTIME, 23)";
            strSQL += " and CONVERT(varchar(100),Fil_ComputerRelease.CTIME, 23) = CONVERT(varchar(100), getdate(), 23)";
            strSQL += " and a.UserID = Fil_PowerComputer.UserID";
            strSQL += " group by Fil_PowerComputer.UserID,Average,a.Release";

            if (OP_Mode.SQLRUN(strSQL))
            {

            }
        }

        /// 插入所有有效数据

        //        insert into Fil_ComputerRelease(SumReleaseFil, NowReleaseFil, WaitReleaseFil, ReleasePower, ReleaseDays, PowerComputerID, InvestmentYuan, ProduceYuan, Ctime, LTime)
        //Select Average*Power sumpower,Average* Power*0.25 + Average * Power * 0.75 / 180 * DATEDIFF(DAY, Fil_Summary.CTIME, getdate()),Average* Power-(Average * Power * 0.25 + Average * Power * 0.75 / 180 * DATEDIFF(DAY, Fil_Summary.CTIME, getdate())),Power,DATEDIFF(DAY, Fil_Summary.CTIME, getdate()),Fil_PowerComputer.ID,0,0, CONVERT(varchar(100), Fil_Summary.CTIME, 23) ,getdate()
        //from Fil_Summary, Fil_PowerComputer where Average> 0 and Fil_PowerComputer.EffectiveTime < getdate() and Fil_PowerComputer.EndTime > getdate() and Fil_Summary.CTIME >= Fil_PowerComputer.EffectiveTime and Fil_Summary.CTIME <= Fil_PowerComputer.EndTime  order by Fil_Summary.CTime

    }

}