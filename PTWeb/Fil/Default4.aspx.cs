using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void GetTotal(string strURL)
    {
        try
        {
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
            string strKYYE = "></div></span>: ";
            string strWKSC = "挖矿锁仓: ";
            string strWin = "出块奖励 (占比): ";
            string strPowerAdd = "算力增量: ";


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
            ////// 出快奖励
            startIndex = content.IndexOf(strWin);
            length = content.IndexOf("FIL", startIndex) - startIndex;

            /// 获得 出快奖励
            totalDataStr = content.Substring(startIndex, length);

            double NumWin = Convert.ToDouble(totalDataStr.Substring(strWin.Length, totalDataStr.Length - strWin.Length).Replace(",", ""));

            ////// 算力增速
            startIndex = content.IndexOf(strPowerAdd);
            length = content.IndexOf("</p>", startIndex) - startIndex;

            /// 获得 出快奖励
            totalDataStr = content.Substring(startIndex, length);

            string NumPowerAdd = totalDataStr.Substring(strPowerAdd.Length, totalDataStr.Length - strPowerAdd.Length).Replace(",", "");


            //////  用户信息网址
            string UserURL = "https://filfox.info/zh/address/f3sfrn2s523s7rpkedw7efqzlk2wzs7y3sg3ie6xuuyx72pchyk2mzg4ms4q7favb2iv7m6uy3pjlp2e4zob3a";
            request = (HttpWebRequest)WebRequest.Create(@"" + UserURL + "");
            request.Timeout = 4000;
            request.ReadWriteTimeout = 4000;
            response = request.GetResponse();
            resStream = response.GetResponseStream();
            sr = new StreamReader(resStream, Encoding.UTF8);
            content = sr.ReadToEnd();

            /// 总余额
            string strSumYE = " 余额 </dt><dd class=";


            startIndex = content.IndexOf(strSumYE);
            length = content.IndexOf("FIL", startIndex) - startIndex;

            /// 获得 总余额
            totalDataStr = content.Substring(startIndex, length);

            /// 获得 总余额
            double NumSumYE = Convert.ToDouble(totalDataStr.Substring(strSumYE.Length + 8, totalDataStr.Length - strSumYE.Length - 8).Replace(",", ""));

        }
        catch (Exception ex)
        {
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GetTotal("https://filfox.info/zh/address/f063628");
    }
}
