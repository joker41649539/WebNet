using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BBGL_MYBB : PageBase
{
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(Constant.QX_S_MYBB, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有查看的权限。", Defaut_QX_URL);
                return;
            }

            Load_GridView_Report();
        }
    }

    #region "GridView_Report 读取报表列表 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_Report()
    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_Report.Attributes["SortExpression"];

        string sortDirection = this.GridView_Report.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_Report_Label_tj.Text.Length > 0)
        {

            strSQL = "SELECT S_REPORT.ID,CNAME,NCLASS FROM S_QXZ,S_REPORT_QXZ,S_YH_QXZ,S_REPORT WHERE S_QXZ.ID=S_REPORT_QXZ.IQXZID AND S_REPORT.ISHOW=0 AND S_YH_QXZ.QXZID=S_QXZ.ID and S_REPORT.ID=S_REPORT_QXZ.IREPORTID AND USERID=" + DefaultUser.ToString() + " AND " + this.GridView_Report_Label_tj.Text.Trim() + " GROUP BY S_REPORT.ID,CNAME,NCLASS,S_REPORT.IPX ORDER BY S_REPORT.IPX DESC";

        }

        else
        {

            strSQL = "SELECT S_REPORT.ID,CNAME,NCLASS FROM S_QXZ,S_REPORT_QXZ,S_YH_QXZ,S_REPORT WHERE S_QXZ.ID=S_REPORT_QXZ.IQXZID AND S_REPORT.ISHOW=0 AND S_YH_QXZ.QXZID=S_QXZ.ID and S_REPORT.ID=S_REPORT_QXZ.IREPORTID AND USERID=" + DefaultUser.ToString() + " GROUP BY S_REPORT.ID,CNAME,NCLASS,S_REPORT.IPX ORDER BY S_REPORT.IPX DESC";

        }

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

            this.GridView_Report.DataSource = OP_Mode.Dtv;

            this.GridView_Report.DataBind();

            this.GridView_Report.BottomPagerRow.Visible = true;

        }

        else
        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_Report_Sorting(object sender, GridViewSortEventArgs e)
    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_Report.Attributes["SortExpression"])
        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_Report.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_Report.Attributes["SortExpression"] = sortExpression;

        this.GridView_Report.Attributes["SortDirection"] = sortDirection;

        Load_GridView_Report();

    }

    protected void GridView_Report_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        Load_GridView_Report();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_TJADD_Click(object sender, EventArgs e)
    {

        string strDiv = string.Empty;

        if (this.GridView_Report_TextBox_CXTJ.Text.Length == 0)
        {

            this.GridView_Report_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_Report_Label1.Text.Length > 0)
        {

            this.GridView_Report_Label1.Text += "<b>并且</b><br />";

            this.GridView_Report_Label_tj.Text += " and ";

        }

        this.GridView_Report_Label1.Text += this.GridView_Report_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_Report_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_Report_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_Report_DropDownList_SF.SelectedValue == "LIKE")
        {

            this.GridView_Report_Label_tj.Text += " " + this.GridView_Report_DropDownList1.SelectedValue + " " + this.GridView_Report_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_Report_TextBox_CXTJ.Text.Trim().Replace("'", "\"") + "%'";

        }

        else
        {

            this.GridView_Report_Label_tj.Text += " " + this.GridView_Report_DropDownList1.SelectedValue + " " + this.GridView_Report_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_Report_TextBox_CXTJ.Text.Trim().Replace("'", "\"") + "'";

        }

        this.GridView_Report_TextBox_CXTJ.Text = string.Empty;

        this.GridView_Report_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_LinkButton3_Click(object sender, EventArgs e)
    {

        this.GridView_Report_TextBox_CXTJ.Text = string.Empty;

        this.GridView_Report_Label1.Text = string.Empty;

        this.GridView_Report_Label_tj.Text = string.Empty;

        this.GridView_Report_alerts_tj.Visible = false;

        Load_GridView_Report();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_LinkButton4_Click(object sender, EventArgs e)
    {

        Load_GridView_Report();
    }

    #endregion
}