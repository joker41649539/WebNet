using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BCTL_USERINFO : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!QXBool(17, Convert.ToInt32(DefaultUser)))
        {
            MessageBox("", "您没有查看的权限。", Defaut_QX_URL);
            return;
        }
        Load_GridView_USER();

    }

    #region "GridView_USER 读取用户信息 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_USER()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_USER.Attributes["SortExpression"];

        string sortDirection = this.GridView_USER.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_USER_Label_tj.Text.Length > 0)

        {

            strSQL = "SELECT * FROM Hundred where " + this.GridView_USER_Label_tj.Text.Trim() + " AND ((USERS IS NULL OR USERS='" + UserNAME + "') OR ('" + UserNAME + "'='陆晓钧')) ORDER BY ID";

        }

        else

        {

            strSQL = "SELECT * FROM Hundred where (USERS IS NULL OR USERS='" + UserNAME + "') OR ('" + UserNAME + "'='陆晓钧') ORDER BY ID";

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



            this.GridView_USER.DataSource = OP_Mode.Dtv;

            this.GridView_USER.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_USER_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_USER.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_USER.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_USER.Attributes["SortExpression"] = sortExpression;

        this.GridView_USER.Attributes["SortDirection"] = sortDirection;

        Load_GridView_USER();

    }

    protected void GridView_USER_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_USER();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_USER_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //如果是绑定数据行 

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                ((LinkButton)e.Row.Cells[6].Controls[1]).Attributes.Add("onclick", "javascript:return confirm('你确认要把【\"" + e.Row.Cells[1].Text + "\" 】延期到本月底吗?')");
                ((LinkButton)e.Row.Cells[7].Controls[1]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】吗?')");
                //    ((LinkButton)e.Row.Cells[5].Controls[1]).Attributes.Add("onclick", "javascript:return confirm('你确认要把【\"" + e.Row.Cells[1].Text + "\" 】延期到本月底吗?')");
            }

        }

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_USER_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        string ID = GridView_USER.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from Hundred where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "指定数据删除成功^_^！");

            Load_GridView_USER();

        }

        else

        {

            MessageBox("", "指定数据删除错误。<br/>" + OP_Mode.strErrMsg);

        }

    }

    /// <summary>
    /// 延期
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_USER_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string ID = GridView_USER.DataKeys[e.RowIndex].Values[0].ToString();

        int Nian = Convert.ToInt32(DateTime.Now.Year);
        int Yue = Convert.ToInt32(DateTime.Now.Month);

        if (Yue == 12)
        {
            Yue = 1;
            Nian = Nian + 1;
        }
        else
        {
            Yue += 1;
        }

        string EndTime = Nian.ToString() + "-" + Yue.ToString() + "-01 00:00:00";

        string strSQL = "Update Hundred set endtime='" + EndTime + "',users='" + UserNAME + "' where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "指定数据延期成功^_^！");

            Load_GridView_USER();
        }
        else
        {
            MessageBox("", "指定数据延期失败，请重试。<br/>" + OP_Mode.strErrMsg);
        }
    }

    /// <summary>
    /// 满足条件的，全部延期
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_YQ_Click(object sender, EventArgs e)
    {
        if (GridView_USER_Label_tj.Text.Length == 0)
        {
            MessageBox("", "必须先选择查询条件！<br/>查询后，确认结果没有问题才可统一延期。");
            return;
        }
        else
        {
            int Nian = Convert.ToInt32(DateTime.Now.Year);
            int Yue = Convert.ToInt32(DateTime.Now.Month);

            if (Yue == 12)
            {
                Yue = 1;
                Nian = Nian + 1;
            }
            else
            {
                Yue += 1;
            }

            string EndTime = Nian.ToString() + "-" + Yue.ToString() + "-01 00:00:00";

            string strSQL = "Update Hundred set endtime='" + EndTime + "',users='" + UserNAME + "' where " + GridView_USER_Label_tj.Text.Trim();

            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "指定数据延期成功^_^！");

                Load_GridView_USER();
            }
            else
            {
                MessageBox("", "指定数据延期失败，请重试。<br/>" + OP_Mode.strErrMsg);
            }
        }
    }
    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_USER_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_USER_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_USER_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_USER_Label1.Text.Length > 0)

        {

            this.GridView_USER_Label1.Text += "<b>并且</b><br />";

            this.GridView_USER_Label_tj.Text += " and ";

        }

        this.GridView_USER_Label1.Text += this.GridView_USER_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_USER_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_USER_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_USER_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_USER_Label_tj.Text += " " + this.GridView_USER_DropDownList1.SelectedValue + " " + this.GridView_USER_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_USER_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_USER_Label_tj.Text += " " + this.GridView_USER_DropDownList1.SelectedValue + " " + this.GridView_USER_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_USER_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_USER_TextBox_CXTJ.Text = string.Empty;

        this.GridView_USER_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_USER_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_USER_TextBox_CXTJ.Text = string.Empty;

        this.GridView_USER_Label1.Text = string.Empty;

        this.GridView_USER_Label_tj.Text = string.Empty;

        this.GridView_USER_alerts_tj.Visible = false;

        Load_GridView_USER();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_USER_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_USER();

    }

    protected void GridView_USER_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_USER.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_USER.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_USER.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_USER.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion

}