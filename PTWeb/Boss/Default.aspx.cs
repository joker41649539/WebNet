using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Boss_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSumData();
        }
    }

    /// <summary>
    /// 加载统计汇总数量
    /// </summary>
    private void LoadSumData()
    {
        //1、正在施工  依据工程施工人员数量判断是否正在施工
        string strSQL = "Select";
        strSQL += " isnull((Select Count(*) from(Select GCDID from W_GCGD_USERS group by GCDID) a) ,0) GCCount,";
        // 昨日安装积分
        strSQL += " isnull((Select Sum(W_GCGD2.AZFS * W_GCGD_FS.AZFS / 100)  from W_GCGD_FS, W_GCGD2 where GCMXID = W_GCGD2.ID and W_GCGD_FS.azfs > 0 and W_GCGD_FS.CTIME between '" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'),0) YesDayAZFS,";
        // 昨日布线积分
        strSQL += " isnull((Select sum(NFS - ISNULL(OFS, 0)) SumBXFS from(select CEILING(a.FS* W_GCGD2.FS/ 100) NFS,GCMXID from W_GCGD_FS_BXList a,(Select max(ID) bid from W_GCGD_FS_BXList where LTIME between '" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) aa left join(select CEILING(a.FS * W_GCGD2.FS / 100) OFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where LTIME < '" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) bb on aa.GCMXID = bb.GCMXID),0) YesDayBXFS,";
        // 昨日维保积分
        strSQL += " Isnull((Select Sum(SumJF) from W_WXD where Ltime between '" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and getdate() and Del=0 and FLAG=1),0) YesDayWXFS, ";

        // 昨日签到次数
        strSQL += " Isnull((Select count(ID) from W_KQ where CTime between '" + System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "' and getdate()),0) YesQDCount";
        // 施工及布线人员名单
        // SELECT S_USERINFO.ID,CName from S_USERINFO,S_YH_QXZ where FLAG = 0  and S_USERINFO.id = S_YH_QXZ.USERID and(QXZID = 3 or QXZID = 4) group by S_USERINFO.ID,CNAME,SSDZ order by S_USERINFO.ID
        if (OP_Mode.SQLRUN(strSQL))
        {
            //MessageBox("", strSQL);
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_ZZSG.Text = OP_Mode.Dtv[0]["GCCount"].ToString();
                Label_YesteDayJF.Text = (Convert.ToInt32(OP_Mode.Dtv[0]["YesDayAZFS"]) + Convert.ToInt32(OP_Mode.Dtv[0]["YesDayBXFS"]) + Convert.ToInt32(OP_Mode.Dtv[0]["YesDayWXFS"])).ToString();

                Label_YesQD.Text = OP_Mode.Dtv[0]["YesQDCount"].ToString();
            }
        }


        TextBox_SETime.Text = System.DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy") + " - " + System.DateTime.Now.ToString("MM/dd/yyyy");
        LoadJFGrid();
        LoadGC();
    }

    private void LoadGC()
    {
        string strSQL = "Select W_GCGD1.ID,SGDH,GCMC,isnull((Select sum(isnull(W_GCGD_FS.fs*W_GCGD2.FS/100,0)+isnull(W_GCGD_FS.AZFS*W_GCGD2.AZFS/100,0)) from W_GCGD1 a,W_GCGD2,W_GCGD_FS where W_GCGD1.GCDH=W_GCGD2.GCDH and W_GCGD2.ID=W_GCGD_FS.GCMXID and a.ID=W_GCGD1.ID),0)  * 100 / isnull((Select sum(FS+AZFS)  FROM W_GCGD2 where GCDH=W_GCGD1.GCDH),0) ipercent,(Select cname +';' from W_GCGD_USERS,S_USERINFO where GCDID=W_GCGD1.ID and S_USERINFO.ID=USERS group by S_USERINFO.ID,CNAME FOR XML PATH('')) CName from W_GCGD1,W_GCGD_USERS where GCDID=W_GCGD1.ID group by GCMC,SGDH,W_GCGD1.ID,W_GCGD1.GCDH order by W_GCGD1.ID desc";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string sortExpression = GridView_GCInfo.Attributes["SortExpression"];
                string sortDirection = GridView_GCInfo.Attributes["SortDirection"];
                if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
                }
                GridView_GCInfo.DataSource = OP_Mode.Dtv;
                GridView_GCInfo.DataBind();
            }
            else
            {
                GridView_GCInfo.DataSource = null;
                GridView_GCInfo.DataBind();
            }
        }
    }

    /// <summary>
    /// 加载积分
    /// </summary>
    private void LoadJFGrid()
    {
        string strSQL = string.Empty;
        /// 日期期限
        string StartTime = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        string EndTime = System.DateTime.Now.ToString("yyyy-MM-dd");

        try
        {
            StartTime = Convert.ToDateTime(TextBox_SETime.Text.Substring(0, 10)).ToString("yyyy-MM-dd");
            EndTime = Convert.ToDateTime(TextBox_SETime.Text.Substring(TextBox_SETime.Text.Length - 10, 10)).ToString("yyyy-MM-dd");
        }
        catch
        {
            TextBox_SETime.Text = Convert.ToDateTime(StartTime).ToString("MM/dd/yyyy") + " - " + Convert.ToDateTime(EndTime).ToString("MM/dd/yyyy");
        }

        /// 依据权限组选择人员，然后统计分数
        strSQL = "Select *,AZJF+YesDayBXFS+YesDayWXFS SumFS from ";
        strSQL += " (SELECT S_USERINFO.ID,CName";
        strSQL += " ,isnull((Select sum(W_GCGD2.AZFS * W_GCGD_FS.AZFS / 100) from W_GCGD_FS, W_GCGD2 where GCMXID = W_GCGD2.ID and W_GCGD_FS.azfs > 0 and W_GCGD_FS.CTIME between '" + StartTime + "' and '" + EndTime + "' and USERID = S_USERINFO.ID),0) AZJF";
        strSQL += " ,isnull((Select sum(NFS - ISNULL(OFS, 0)) SumBXFS from(select CEILING(a.FS * W_GCGD2.FS / 100) NFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where LTIME between '" + StartTime + "' and '" + EndTime + "' and USERID = S_USERINFO.ID group by GCMXID, UserID) b, W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) aa left join(select CEILING(a.FS * W_GCGD2.FS / 100) OFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where LTIME < '" + StartTime + "' and USERID = S_USERINFO.ID group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) bb on aa.GCMXID = bb.GCMXID),0) YesDayBXFS";
        strSQL += " ,Isnull((Select Sum(SumJF) from W_WXD where Ltime between '" + StartTime + "' and '" + EndTime + "' and W_WXD.WXRY = S_USERINFO.ID and Del = 0 and FLAG = 1),0) YesDayWXFS";
        strSQL += " from S_USERINFO,S_YH_QXZ where FLAG = 0  and S_USERINFO.id = S_YH_QXZ.USERID and(QXZID = 3 or QXZID = 4) group by S_USERINFO.ID,CNAME,SSDZ) aa";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string sortExpression = GridView_JF.Attributes["SortExpression"];
                string sortDirection = GridView_JF.Attributes["SortDirection"];
                if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
                }
                GridView_JF.DataSource = OP_Mode.Dtv;
                GridView_JF.DataBind();
            }
            else
            {
                GridView_JF.DataSource = null;
                GridView_JF.DataBind();
            }
        }
    }

    protected void GridView_JF_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列
        string sortExpression = e.SortExpression.ToString();
        // 假定为排序方向为“顺序”
        string sortDirection = "ASC";
        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改
        if (sortExpression == GridView_JF.Attributes["SortExpression"])
        {
            //获得下一次的排序状态
            sortDirection = (GridView_JF.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }
        // 重新设定GridView排序数据列及排序方向
        GridView_JF.Attributes["SortExpression"] = sortExpression;
        GridView_JF.Attributes["SortDirection"] = sortDirection;
        LoadJFGrid();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadJFGrid();
    }

    protected void GridView_JF_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // 得到该控件
        GridView theGrid = sender as GridView;
        int newPageIndex = 0;
        if (e.NewPageIndex == -3)
        {
            //点击了Go按钮
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = theGrid.BottomPagerRow;

            if (pagerRow != null)
            {
                //得到text控件
                txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
            }

            if (txtNewPageIndex != null)
            {
                //得到索引
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            //点击了其他的按钮
            newPageIndex = e.NewPageIndex;
        }

        //防止新索引溢出

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;

        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        //得到新的值
        theGrid.PageIndex = newPageIndex;
        //重新绑定
        LoadJFGrid();

    }

    protected void GridView_GCInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // 得到该控件
        GridView theGrid = sender as GridView;
        int newPageIndex = 0;
        if (e.NewPageIndex == -3)
        {
            //点击了Go按钮
            TextBox txtNewPageIndex = null;

            GridViewRow pagerRow = theGrid.BottomPagerRow;

            if (pagerRow != null)
            {
                //得到text控件
                txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
            }

            if (txtNewPageIndex != null)
            {
                //得到索引
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
            }
        }
        else
        {
            //点击了其他的按钮
            newPageIndex = e.NewPageIndex;
        }

        //防止新索引溢出

        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;

        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        //得到新的值
        theGrid.PageIndex = newPageIndex;
        //重新绑定
        LoadGC();
    }

    protected void GridView_GCInfo_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列
        string sortExpression = e.SortExpression.ToString();
        // 假定为排序方向为“顺序”
        string sortDirection = "ASC";
        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改
        if (sortExpression == GridView_GCInfo.Attributes["SortExpression"])
        {
            //获得下一次的排序状态
            sortDirection = (GridView_GCInfo.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }
        // 重新设定GridView排序数据列及排序方向
        GridView_GCInfo.Attributes["SortExpression"] = sortExpression;
        GridView_GCInfo.Attributes["SortDirection"] = sortDirection;
        LoadGC();
    }
}