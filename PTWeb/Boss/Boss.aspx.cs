using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.Animation;

public partial class Boss_Boss : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefautl();
            LoadPartner();
            LoadGCInfo();
        }
    }
    private void LoadDefautl()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    private void LoadPartner()
    {
        //string strSQL = string.Empty;
        ///// 日期期限
        //string StartTime = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        //string EndTime = System.DateTime.Now.ToString("yyyy-MM-dd");

        //try
        //{
        //    StartTime = Convert.ToDateTime(TextBox_SETime.Text.Substring(0, 10)).ToString("yyyy-MM-dd");
        //    EndTime = Convert.ToDateTime(TextBox_SETime.Text.Substring(TextBox_SETime.Text.Length - 10, 10)).ToString("yyyy-MM-dd");
        //}
        //catch
        //{
        //    TextBox_SETime.Text = Convert.ToDateTime(StartTime).ToString("MM/dd/yyyy") + " - " + Convert.ToDateTime(EndTime).ToString("MM/dd/yyyy");
        //}

        //string sortExpression = this.GridView_Partner.Attributes["SortExpression"];
        //string sortDirection = this.GridView_Partner.Attributes["SortDirection"];

        //strSQL = "Select *,AZJF+YesDayBXFS+YesDayWXFS SumFS from ";
        //strSQL += " (SELECT S_USERINFO.ID,CName,isnull((Select top 1 '['+format(CTime,'yyyy-MM-dd HH:mm')+']'+ZB_Name from W_KQ where UserID=S_USERINFO.ID order by ctime desc),'') QD";
        //strSQL += " ,isnull((Select sum(W_GCGD2.AZFS * W_GCGD_FS.AZFS / 100) from W_GCGD_FS, W_GCGD2 where GCMXID = W_GCGD2.ID and W_GCGD_FS.azfs > 0 and W_GCGD_FS.CTIME between '" + StartTime + "' and '" + EndTime + "' and USERID = S_USERINFO.ID),0) AZJF";
        //strSQL += " ,isnull((Select sum(NFS - ISNULL(OFS, 0)) SumBXFS from(select CEILING(a.FS * W_GCGD2.FS / 100) NFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where LTIME between '" + StartTime + "' and '" + EndTime + "' and USERID = S_USERINFO.ID group by GCMXID, UserID) b, W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) aa left join(select CEILING(a.FS * W_GCGD2.FS / 100) OFS, GCMXID from W_GCGD_FS_BXList a, (Select max(ID) bid from W_GCGD_FS_BXList where LTIME < '" + StartTime + "' and USERID = S_USERINFO.ID group by GCMXID, UserID) b,W_GCGD2 where a.ID = bid and a.GCMXID = W_GCGD2.ID) bb on aa.GCMXID = bb.GCMXID),0) YesDayBXFS";
        //strSQL += " ,Isnull((Select Sum(SumJF) from W_WXD where Ltime between '" + StartTime + "' and '" + EndTime + "' and W_WXD.WXRY = S_USERINFO.ID and Del = 0 and FLAG = 1),0) YesDayWXFS";
        //strSQL += " from S_USERINFO,S_YH_QXZ where FLAG = 0  and S_USERINFO.id = S_YH_QXZ.USERID and(QXZID = 3 or QXZID = 4) group by S_USERINFO.ID,CNAME,SSDZ) aa order by QD desc";

        //if (OP_Mode.SQLRUN(strSQL))
        //{
        //    if (OP_Mode.Dtv.Count > 0)
        //    {//加载待审核
        //        /// 设置排序
        //        if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
        //        {
        //            OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
        //        }
        //        GridView_Partner.DataSource = OP_Mode.Dtv;
        //        GridView_Partner.DataBind();
        //    }
        //}
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadPartner();
    }

    private void LoadGCInfo()
    {
        //string strSQL = string.Empty;
        //string sortExpression = this.GridView_GC.Attributes["SortExpression"];
        //string sortDirection = this.GridView_GC.Attributes["SortDirection"];

        //strSQL = "Select *,case yjgs when 0 then 0 else YWC*100/YJGS end ipercent from (Select SGDH,GCDD,GCMC,format(max(W_WorkPlan.CTime),'yyyy-MM-dd') Times,isnull((Select sum(FS+AZFS) from W_GCGD2 where GCDH=W_GCGD1.GCDH),0) YJGS,isnull((Select sum(W_GCGD2.FS*W_GCGD_FS.FS/100+W_GCGD2.AZFS*W_GCGD_FS.AZFS/100) from W_GCGD2,W_GCGD_FS where GCDH=W_GCGD1.GCDH and GCMXID=W_GCGD2.ID),0) YWC from W_WorkPlan,W_GCGD1 where nFlag='工程' and GCID=W_GCGD1.ID group by GCDD,GCDH,GCMC,SGDH) a order by Times desc";

        //if (OP_Mode.SQLRUN(strSQL))
        //{
        //    if (OP_Mode.Dtv.Count > 0)
        //    {//加载待审核
        //        / 设置排序
        //        if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
        //        {
        //            OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
        //        }
        //        GridView_GC.DataSource = OP_Mode.Dtv;
        //        GridView_GC.DataBind();
        //    }
        //}
    }
}