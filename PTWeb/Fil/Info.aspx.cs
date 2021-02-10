using System;
using System.Collections.Generic;
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
        try
        {
            string HQUrl = "https://filfox.info/zh"; //行情信息

            List<string> result = new List<string>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"" + HQUrl + "");
            request.Timeout = 4000;
            request.ReadWriteTimeout = 4000;
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, Encoding.UTF8);
            string content = sr.ReadToEnd();

            string totalDataStr;//, totalDataStr_SG, totalDataStr_PK, totalDataStr_TZ, totalDataStr_ZQ;

            /// 总余额
            string strHQ = "$";

            int startIndex = content.IndexOf(strHQ);
            int length = content.IndexOf("</div>", startIndex) - startIndex;

            /// 获得 总余额
            totalDataStr = content.Substring(startIndex, length);

            /// 获得 总余额
            double NumHQ = Convert.ToDouble(totalDataStr.Substring(strHQ.Length, totalDataStr.Length - strHQ.Length).Replace(",", ""));
            // 行情
            Label_Fil.Text = (NumHQ).ToString();
        }
        catch (Exception ex)
        {
            MessageBox("", ex.ToString());
        }
    }

    #region "GridView_Info 读取产出明细 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_Info()

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

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_Info.Attributes["SortExpression"];

        string sortDirection = this.GridView_Info.Attributes["SortDirection"];

        string strSQL;

        strSQL = "Select Top 100 LTime,DayRelease,ID from FIL_UserReleaseInfo where UserID = " + iUserID + " order by LTime desc";

        if (OP_Mode.SQLRUN(strSQL))

        {

            /// 设置排序

            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

            {

                OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

            }

            /// 设置翻页层始终显示



            if (OP_Mode.Dtv.Count == 0)

            {

                OP_Mode.Dtv.AddNew();

            }



            this.GridView_Info.DataSource = OP_Mode.Dtv;

            this.GridView_Info.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

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