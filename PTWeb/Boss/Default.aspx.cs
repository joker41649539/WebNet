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
            LoadPartner();
            LoadGC3();
            LoadGC0();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void LoadPartner()
    {
        string TempDiv = string.Empty;
        string strSQL = string.Empty;
        /// 日期期限
        string StartTime = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        string EndTime = System.DateTime.Now.ToString("yyyy-MM-dd");

        //try
        //{
        //    StartTime = Convert.ToDateTime(TextBox_SETime.Text.Substring(0, 10)).ToString("yyyy-MM-dd");
        //    EndTime = Convert.ToDateTime(TextBox_SETime.Text.Substring(TextBox_SETime.Text.Length - 10, 10)).ToString("yyyy-MM-dd");
        //}
        //catch
        //{
        //    TextBox_SETime.Text = Convert.ToDateTime(StartTime).ToString("MM/dd/yyyy") + " - " + Convert.ToDateTime(EndTime).ToString("MM/dd/yyyy");
        //}

        string sortExpression = this.GridView_Boss1.Attributes["SortExpression"];
        string sortDirection = this.GridView_Boss1.Attributes["SortDirection"];

        strSQL = "Select *,AZJF+YesDayBXFS+YesDayWXFS SumFS from ";
        strSQL += " (SELECT S_USERINFO.ID,CName,isnull((Select top 1 '['+format(CTime,'yyyy-MM-dd HH:mm')+']'+ZB_Name from W_KQ where UserID=S_USERINFO.ID order by ctime desc),'') QD";
        strSQL += " ,isnull((Select top 1 MapID from W_KQ where UserID = S_USERINFO.ID order by ctime desc),'') MapID";
        strSQL += " ,isnull((Select sum(W_GCGD2.AZFS * W_GCGD_FS.AZFS / 100) from W_GCGD_FS, W_GCGD2 where GCMXID = W_GCGD2.ID and W_GCGD_FS.azfs > 0 and W_GCGD_FS.CTIME between '" + StartTime + "' and '" + EndTime + "' and USERID = S_USERINFO.ID),0) AZJF";
        strSQL += " ,isnull((Select sum(NFS - ISNULL(OFS, 0)) SumBXFS from(select CEILING(a.FS * W_GCGD2.FS / 100) NFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where LTIME between '" + StartTime + "' and '" + EndTime + "' and USERID = S_USERINFO.ID group by GCMXID, UserID) b, W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) aa left join(select CEILING(a.FS * W_GCGD2.FS / 100) OFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where LTIME < '" + StartTime + "' and USERID = S_USERINFO.ID group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) bb on aa.GCMXID = bb.GCMXID),0) YesDayBXFS";
        strSQL += " ,Isnull((Select Sum(SumJF) from W_WXD where Ltime between '" + StartTime + "' and '" + EndTime + "' and W_WXD.WXRY = S_USERINFO.ID and Del = 0 and FLAG = 1),0) YesDayWXFS";
        strSQL += " from S_USERINFO,S_YH_QXZ where FLAG = 0  and S_USERINFO.id = S_YH_QXZ.USERID and(QXZID = 3 or QXZID = 4) group by S_USERINFO.ID,CNAME,SSDZ) aa order by QD desc";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {//加载待审核

                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    TempDiv += "<div class=\"well row\">";
                    TempDiv += "    <div class=\"col-xs-12\">";
                    TempDiv += "        <h4><a href=\"/CWGL/SearchQD.aspx?UserName=" + OP_Mode.Dtv[i]["CNAME"].ToString() + "\" class=\"left\"><b>" + OP_Mode.Dtv[i]["CNAME"].ToString() + "</b></a>&nbsp;";
                    if (Convert.ToInt32(OP_Mode.Dtv[i]["SumFS"]) == 0)
                    {
                        TempDiv += " <span class=\"label pull-right\">";
                    }
                    else
                    {
                        TempDiv += " <span class=\"label label-success pull-right\">";
                    }
                    TempDiv += " 昨日积分累计：" + OP_Mode.Dtv[i]["SumFS"].ToString() + "</span></h4>";
                    TempDiv += "       <h3> <p>";
                    TempDiv += "            <i class=\"icon-globe\"></i>&nbsp;" + OP_Mode.Dtv[i]["QD"].ToString() + "";

                    if (OP_Mode.Dtv[i]["MapID"].ToString().Length > 0)
                    {
                        TempDiv += "            <span class=\"label label-warning\">指定签到点</span>";
                    }
                    TempDiv += "        </p> </h3>";
                    TempDiv += "        <h5>";
                    if (Convert.ToInt32(OP_Mode.Dtv[i]["YesDayBXFS"]) == 0)
                    {
                        TempDiv += " <span class=\"label\">";
                    }
                    else
                    {
                        TempDiv += " <span class=\"label label-success\">";
                    }
                    TempDiv += " 布线：" + OP_Mode.Dtv[i]["YesDayBXFS"].ToString() + "</span>&nbsp;";
                    if (Convert.ToInt32(OP_Mode.Dtv[i]["AZJF"]) == 0)
                    {
                        TempDiv += " <span class=\"label\">";
                    }
                    else
                    {
                        TempDiv += " <span class=\"label label-success\">";
                    }
                    TempDiv += "安装：" + OP_Mode.Dtv[i]["AZJF"].ToString() + "</span>&nbsp;";

                    if (Convert.ToInt32(OP_Mode.Dtv[i]["YesDayWXFS"]) == 0)
                    {
                        TempDiv += " <span class=\"label\">";
                    }
                    else
                    {
                        TempDiv += " <span class=\"label label-success\">";
                    }

                    TempDiv += "维保：" + OP_Mode.Dtv[i]["YesDayWXFS"].ToString() + "</span></h5>";
                    TempDiv += "    </div>";
                    TempDiv += "</div>";
                }

                if (TempDiv.Length > 0)
                {
                    Div_User.InnerHtml = TempDiv;
                    /// 设置排序
                    if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
                    {
                        OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
                    }
                    GridView_Boss1.DataSource = OP_Mode.Dtv;
                    GridView_Boss1.DataBind();
                }
            }
        }
    }

    private void LoadGC2()
    {
        string strSQL = "Select ID,SGDH,GCDD,GCMC,Remark from W_GCGD1 where IFLAG=2 order by CTime desc";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string sortExpression = GridView_GC2.Attributes["SortExpression"];
                string sortDirection = GridView_GC2.Attributes["SortDirection"];
                if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
                }
                Label_ZT.Text = OP_Mode.Dtv.Count.ToString();
                GridView_GC2.DataSource = OP_Mode.Dtv;
                GridView_GC2.DataBind();
            }
            else
            {
                GridView_GC2.DataSource = null;
                GridView_GC2.DataBind();
            }
        }
    }
    private void LoadGC3()
    {
        string strSQL = "Select W_GCGD1.ID,GCDD,SGDH,GCMC,isnull((Select sum(isnull(W_GCGD_FS.fs*W_GCGD2.FS/100,0)+isnull(W_GCGD_FS.AZFS*W_GCGD2.AZFS/100,0)) from W_GCGD1 a,W_GCGD2,W_GCGD_FS where W_GCGD1.GCDH=W_GCGD2.GCDH and W_GCGD2.ID=W_GCGD_FS.GCMXID and a.ID=W_GCGD1.ID),0)  * 100 / isnull((Select sum(FS+AZFS)  FROM W_GCGD2 where GCDH=W_GCGD1.GCDH),0) ipercent,(Select cname +';' from W_GCGD_USERS,S_USERINFO where GCDID=W_GCGD1.ID and S_USERINFO.ID=USERS group by S_USERINFO.ID,CNAME FOR XML PATH('')) CName from W_GCGD1,W_GCGD_USERS where GCDID=W_GCGD1.ID and W_GCGD1.iFlag=3 group by GCMC,SGDH,W_GCGD1.ID,W_GCGD1.GCDH,GCDD order by W_GCGD1.ID desc";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string sortExpression = GridView_GC3.Attributes["SortExpression"];
                string sortDirection = GridView_GC3.Attributes["SortDirection"];
                if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
                }
                Label_ZZ.Text = OP_Mode.Dtv.Count.ToString();
                GridView_GC3.DataSource = OP_Mode.Dtv;
                GridView_GC3.DataBind();
            }
            else
            {
                GridView_GC3.DataSource = null;
                GridView_GC3.DataBind();
            }
        }
    }
    private void LoadGC0()
    {
        string strSQL = "Select ID,SGDH,GCDD,GCMC,Remark from W_GCGD1 where IFLAG=0 order by CTime desc";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string sortExpression = GridView_GC0.Attributes["SortExpression"];
                string sortDirection = GridView_GC0.Attributes["SortDirection"];
                if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
                }
                Label_DD.Text = OP_Mode.Dtv.Count.ToString();
                GridView_GC0.DataSource = OP_Mode.Dtv;
                GridView_GC0.DataBind();
            }
            else
            {
                GridView_GC0.DataSource = null;
                GridView_GC0.DataBind();
            }
        }
    }

    protected void GridView_Boss1_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列
        string sortExpression = e.SortExpression.ToString();
        // 假定为排序方向为“顺序”
        string sortDirection = "ASC";
        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改
        if (sortExpression == this.GridView_Boss1.Attributes["SortExpression"])
        {
            //获得下一次的排序状态
            sortDirection = (this.GridView_Boss1.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }
        // 重新设定GridView排序数据列及排序方向
        this.GridView_Boss1.Attributes["SortExpression"] = sortExpression;
        this.GridView_Boss1.Attributes["SortDirection"] = sortDirection;

        LoadPartner();
    }
}