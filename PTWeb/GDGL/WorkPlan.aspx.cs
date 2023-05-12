using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_WorkPlan : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(53, Convert.ToInt32(DefaultUser)))
            {/// 工作计划安排权限
                MessageBox("", "您没有查看此页面的权限。", "/Default.aspx");
            }
            else
            {
                if (System.DateTime.Now.Hour > 16)
                {// 下午5点以后自动为第二天
                    TextBox_Time.Text = System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }
                else
                {
                    TextBox_Time.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                }
                LoadData();
                LoadGC();
            }
        }
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    private void LoadData()
    {

        string sortExpression = this.GridView_WorkPlan.Attributes["SortExpression"];

        string sortDirection = this.GridView_WorkPlan.Attributes["SortDirection"];
        string strSQL = String.Empty;

        string STime = TextBox_Time.Text.Replace("'", "");
        //string ETime = Convert.ToDateTime(STime).AddDays(-1).ToString("yyyy-MM-dd");

        /// 查询工程和布线所有人员名单。
        strSQL = "SELECT S_USERINFO.ID,CName,GCID,WID,a.UserID,CZRID,nFlag,a.LTime,GCDD,GCMC,a.Remark,case gcid when 0 then '['+nFlag+']'+a.Remark else  '['+nFlag+']'+GCMC end NRemark from S_USERINFO left join (Select GCID,UserID,CZRID,nFlag,W_WorkPlan.LTime,GCDD,GCMC,W_WorkPlan.Remark,W_WorkPlan.ID WID from W_WorkPlan left join W_GCGD1 on GCID= W_GCGD1.id where W_WorkPlan.ltime between '" + STime + "' and '" + STime + "') a on UserID=S_USERINFO.ID,S_YH_QXZ where (FLAG=0  and S_USERINFO.id=S_YH_QXZ.USERID and (QXZID =3 or QXZID=4)) or FLAG=4 group by S_USERINFO.ID,CNAME,GCID,a.UserID,CZRID,nFlag,a.LTime,GCDD,GCMC,a.Remark,WID order by S_USERINFO.ID";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                /// 设置排序
                if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
                }
                GridView_WorkPlan.DataSource = OP_Mode.Dtv;
                GridView_WorkPlan.DataBind();
            }
        }
    }

    private void LoadGC()
    {
        string sortExpression = this.GridView_GC.Attributes["SortExpression"];

        string sortDirection = this.GridView_GC.Attributes["SortDirection"];
        string strSQL = "";
        string strSearchTJ = TextBox_GCMC.Text.Replace("'", "");

        if (strSearchTJ.Length > 0)
        {
            strSQL = "Select * from W_GCGD1 where GCMC like '%" + strSearchTJ + "%' order by CTIME desc";
        }
        else
        {
            strSQL = "Select * from W_GCGD1 order by CTIME desc";
        }
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                /// 设置排序
                if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
                }
                GridView_GC.DataSource = OP_Mode.Dtv;
                GridView_GC.DataBind();
            }
        }
    }

    /// <summary>
    /// 选择变化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void GridView_WorkPlan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView_WorkPlan_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            /// 存储USERid
            HiddenField_UserID.Value = GridView_WorkPlan.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            // MessageBox("ID号：" + GridView_WorkPlan.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[1].ToString());
            //打开模态窗口
            this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>$(\"#GCList\").modal('show');</script>");
        }
    }

    protected void GridView_GC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string strGCMC = string.Empty;
        if (e.CommandName == "Select")
        {
            strGCMC = GridView_GC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[1].ToString() + " " + TextBox_Remark.Text.Replace("'", "");

            InsertWorkPlan(Convert.ToInt32(HiddenField_UserID.Value), Convert.ToInt32(GridView_GC.DataKeys[Convert.ToInt32(e.CommandArgument)].Value), Convert.ToDateTime(TextBox_Time.Text.Replace("'", "")), TextBox_Remark.Text.Replace("'", ""), "工程", strGCMC);
            // MessageBox("用户编号：" + HiddenField_UserID.Value + " 工程编号：" + GridView_GC.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            HiddenField_UserID.Value = null;
        }
    }

    /// <summary>
    /// 插入工作计划数据
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="GCID"></param>
    /// <param name="STime"></param>
    private void InsertWorkPlan(int UserID, int GCID, DateTime STime, string strRemark, string nFlag, string strGCMC)
    {
        string strSQL = "insert into w_workPlan (UserID,GCID,CZRID,LTime,Remark,nFlag) values (" + UserID + "," + GCID + "," + DefaultUser + ",'" + STime + "','" + strRemark + "','" + nFlag + "')";

        strSQL += " Select * from S_USERINFO where id=" + UserID;

        string OpenID = string.Empty;

        if (OP_Mode.SQLRUN(strSQL))
        {/// 数据插入成功，刷新用户数据
            if (OP_Mode.Dtv.Count > 0)
            {
                OpenID = OP_Mode.Dtv[0]["OpenID"].ToString();
                if (OpenID.Length > 0)
                {
                    SendMSGByWeChart(OpenID, "", "[" + UserNAME + "] 给您安排了新的工作计划", "[" + nFlag + "] " + strGCMC, TextBox_Time.Text.Replace("'", ""), "请您准时到目的地工作，并进行签到打卡。");
                }
            }
            LoadData();
        }
        else
        {
            MessageBox("", "错误：" + OP_Mode.strErrMsg);
        }
    }

    protected void GridView_GC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // 得到该控件

        GridView theGrid = sender as GridView;

        int newPageIndex = 0;

        if (e.NewPageIndex == -3)
        {
            //点击了Go按钮
            TextBox txtNewPageIndex = null;
            //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow
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
        //打开模态窗口
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>$(\"#GCList\").modal('show');</script>");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        LoadGC();
        //打开模态窗口
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>$(\"#GCList\").modal('show');</script>");
    }

    protected void GridView_WorkPlan_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列
        string sortExpression = e.SortExpression.ToString();
        // 假定为排序方向为“顺序”
        string sortDirection = "ASC";
        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改
        if (sortExpression == this.GridView_WorkPlan.Attributes["SortExpression"])
        {
            //获得下一次的排序状态
            sortDirection = (this.GridView_WorkPlan.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }
        // 重新设定GridView排序数据列及排序方向
        this.GridView_WorkPlan.Attributes["SortExpression"] = sortExpression;
        this.GridView_WorkPlan.Attributes["SortDirection"] = sortDirection;
        LoadData();
    }

    protected void GridView_GC_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列
        string sortExpression = e.SortExpression.ToString();
        // 假定为排序方向为“顺序”
        string sortDirection = "ASC";
        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改
        if (sortExpression == this.GridView_GC.Attributes["SortExpression"])
        {
            //获得下一次的排序状态
            sortDirection = (this.GridView_GC.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }
        // 重新设定GridView排序数据列及排序方向
        this.GridView_GC.Attributes["SortExpression"] = sortExpression;
        this.GridView_GC.Attributes["SortDirection"] = sortDirection;
        LoadGC();
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>$(\"#GCList\").modal('show');</script>");
    }

    /// <summary>
    /// 删除工作计划数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_WorkPlan_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int WID = Convert.ToInt32(GridView_WorkPlan.DataKeys[Convert.ToInt32(e.RowIndex)].Values[1]);
            if (WID > 0)
            {
                string strSQL = "Delete from w_workPlan where ID=" + WID;
                if (OP_Mode.SQLRUN(strSQL))
                {
                    MessageBox("指定数据删除成功。");
                    LoadData();
                }
            }
        }
        catch
        {

        }
    }

    /// <summary>
    /// 日期查询 人员工作计划信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue != "工程" && TextBox_Remark.Text.Replace("'", "").Length <= 0)
        {
            MessageBox("非工程则必须填写说明信息。");
        }
        else
        {
            InsertWorkPlan(Convert.ToInt32(HiddenField_UserID.Value), 0, Convert.ToDateTime(TextBox_Time.Text.Replace("'", "")), TextBox_Remark.Text.Replace("'", ""), RadioButtonList1.SelectedValue, TextBox_Remark.Text.Replace("'", ""));
        }
    }
}