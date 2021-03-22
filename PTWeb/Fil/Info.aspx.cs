using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fil_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUserInfo();
            Load_GridView_Info();
            GetTotal();
        }
    }

    private void LoadUserInfo()
    {
        int iUserID = 0;
        try
        {
            iUserID = Convert.ToInt32(Request.Cookies["WeChat_Yanwo"]["USERID"]);
        }
        catch
        {

        }
        if (iUserID == 0)
        {
            return;
        }


        string strSQL;

        strSQL = "Select * from FIL_Users where ID = " + iUserID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_SumFil.Text = OP_Mode.Dtv[0]["SumFil"].ToString();
                Label_SumPower.Text = OP_Mode.Dtv[0]["SumPower"].ToString();
                Label_Withdraw.Text = OP_Mode.Dtv[0]["WithdrawalFil"].ToString();
                Label_Lock.Text = OP_Mode.Dtv[0]["LockFil"].ToString();
                Label_Release.Text = OP_Mode.Dtv[0]["ReleaseFil"].ToString();
            }
        }
    }

    /// <summary>
    /// 互联网获取数据信息
    /// </summary>
    public void GetTotal()
    {
        //try
        //{
        //   // string HQUrl = "https://filfox.info/zh"; //行情信息
        //    string HQUrl = "https://www.mytokencap.com/currency/fil/821765876"; //行情信息

        //    List<string> result = new List<string>();

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"" + HQUrl + "");
        //    request.Timeout = 4000;
        //    request.ReadWriteTimeout = 4000;
        //    WebResponse response = request.GetResponse();
        //    Stream resStream = response.GetResponseStream();
        //    StreamReader sr = new StreamReader(resStream, Encoding.UTF8);
        //    string content = sr.ReadToEnd();

        //    string totalDataStr;//, totalDataStr_SG, totalDataStr_PK, totalDataStr_TZ, totalDataStr_ZQ;

        //    /// 总余额
        //    string strHQ = "≈¥";

        //    int startIndex = content.IndexOf(strHQ);
        //    int length = content.IndexOf("</div>", startIndex) - startIndex;

        //    /// 获得 总余额
        //    totalDataStr = content.Substring(startIndex, length);

        //    /// 获得 总余额
        //    double NumHQ = Convert.ToDouble(totalDataStr.Substring(strHQ.Length, totalDataStr.Length - strHQ.Length).Replace(",", ""));
        //    // 行情
        //    Label_Fil.Text = (NumHQ).ToString();
        //}
        //catch (Exception ex)
        //{
        //    MessageBox("", ex.ToString());
        //}

        /// https://www.ztpay.org/  账号： 41649539@qq.com  joK121
        /// 
        string Appid = "ztpayj44ocmpkavmgs";
        string AppSecret = "vOAF74hUzs9pGgpNovXNM8jqzuYrG8H2";
        string Url = "https://sapi.ztpay.org/api/v2";

        var client = new System.Net.WebClient();
        client.Encoding = System.Text.Encoding.UTF8;

        string stringSignTemp = "appid=" + Appid + "&method=market&key=" + AppSecret;

        string strMakeSign = "appid=" + Appid + "&method=market&sign=" + GetMD5(stringSignTemp).ToUpper();

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
        Label_Fil.Text  = strTemp.Substring(strTemp.IndexOf("cny") + 5, strTemp.IndexOf(",") - 13);

    }

    #region "GridView_Info 读取产出明细 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_Info()

    {

        LoadDayGrid(Convert.ToDateTime("2021-01-08"), 1);
        //int iUserID = 0;
        //try
        //{
        //    iUserID = Convert.ToInt32(Request.Cookies["WeChat_Yanwo"]["USERID"]);
        //}
        //catch
        //{

        //}
        //if (iUserID == 0)
        //{
        //    return;
        //}

        //// 获取GridView排序数据列及排序方向

        //string sortExpression = this.GridView_Info.Attributes["SortExpression"];

        //string sortDirection = this.GridView_Info.Attributes["SortDirection"];

        //string strSQL;

        //strSQL = "Select Top 100 LTime,DayRelease,ID from FIL_UserReleaseInfo where UserID = " + iUserID + " order by LTime desc";

        //if (OP_Mode.SQLRUN(strSQL))

        //{

        //    /// 设置排序

        //    if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

        //    {

        //        OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

        //    }

        //    /// 设置翻页层始终显示



        //    if (OP_Mode.Dtv.Count == 0)

        //    {

        //        OP_Mode.Dtv.AddNew();

        //    }



        //    this.GridView_Info.DataSource = OP_Mode.Dtv;

        //    this.GridView_Info.DataBind();

        //}

        //else

        //{

        //    MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

        //    return;

        //}

    }

    private void LoadDayGrid(DateTime startTime, int SumPower)
    {
        int iUserID = 0;
        try
        {
            iUserID = Convert.ToInt32(Request.Cookies["WeChat_Yanwo"]["USERID"]);
        }
        catch
        {

        }
        if (iUserID == 0)
        {
            return;
        }

        string strSQL = " declare @StartDate DATETIME = (Select min(EffectiveTime) from Fil_PowerComputer where UserID=" + iUserID + ")";
        strSQL += " declare @EndDate DATETIME = getdate()";// +System.DateTime.Now.add;
        //strSQL += " declare @EndDate DATETIME = '2021-08-16'";
        strSQL += " SELECT CONVERT(VARCHAR(100), dateadd(day, n.number, @StartDate), 23) AS every_time, a.*,(Select isnull(Sum(round(power/SumPower*Gift/180,4)),0) from vfil_gift where DATEDIFF(DAY, LTime,  CONVERT (VARCHAR (100),dateadd(day,n.number,@StartDate),23))<180 and UserID=" + iUserID + " and LTime<CONVERT (VARCHAR (100),dateadd(day,n.number,@StartDate),23))+isnull(a.DayRelease,0) Release FROM";
        strSQL += " master..spt_values n left join(Select gift, sumpower, ltime, sum(POWER) power, sum(Round(POWER / sumpower * Gift * 0.25, 4)) DayRelease, sum(Round(POWER / sumpower * Gift, 4)) SumRelease from vfil_gift where userid = " + iUserID.ToString() + " group by gift, sumpower, ltime) a on a.ltime = CONVERT(VARCHAR(100), dateadd(day, n.number, @StartDate), 23)";
        strSQL += " WHERE n.type = 'p' AND n.number <= DATEDIFF(day, @StartDate, @EndDate)";

        // OP_Mode.Dtv = new;
        if (OP_Mode.SQLRUN(strSQL))
        {
            double SumBalance = 0;
            double SumRelease = 0;
            for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            { // 计算合计信息
                if (OP_Mode.Dtv[i]["Release"].ToString().Length > 0)
                {
                    SumBalance += Convert.ToDouble(OP_Mode.Dtv[i]["Release"]);
                }
                if (OP_Mode.Dtv[i]["SumRelease"].ToString().Length > 0)
                {
                    SumRelease += Convert.ToDouble(OP_Mode.Dtv[i]["SumRelease"]);
                }
            }
            //if (OP_Mode.Dtv.Count > 0)
            //{
            //    DataRowView rowView = OP_Mode.Dtv.AddNew();
            //    rowView["every_time"] = SumRelease.ToString();
            //    rowView["Release"] = SumBalance.ToString();
            //    OP_Mode.Dtv.AddNew();
            //}
            Label_Release.Text = SumBalance.ToString();
            Label_Lock.Text = (SumRelease - SumBalance).ToString();
            Label_SumFil.Text = SumRelease.ToString();
            //for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            //{

            //}

            //for (DateTime dt = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day); dt >= new DateTime(startTime.Year, startTime.Month, startTime.Day); dt = dt.AddDays(-1))
            //{
            //    DataRowView rowView = OP_Mode.Dtv.AddNew();
            //    rowView["LTime"] = dt.ToString("yyyy-MM-dd");
            //    rowView["DayRelease"] = 0;
            //}
        }

        OP_Mode.Dtv.Sort = "every_time desc";
        this.GridView_Info.DataSource = OP_Mode.Dtv;

        this.GridView_Info.DataBind();
    }

    protected void GridView_Info_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_Info.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_Info.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_Info.Attributes["SortExpression"] = sortExpression;

        this.GridView_Info.Attributes["SortDirection"] = sortDirection;

        Load_GridView_Info();

    }

    protected void GridView_Info_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_Info.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_Info.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}