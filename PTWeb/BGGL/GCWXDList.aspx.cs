using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BGGL_GCWXDList : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(35, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有查看工程维修单的权限。", Defaut_QX_URL);
                return;
            }
            Load_GridView_WXD();
        }
    }


    #region "GridView_WXD 读取工程维修单 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_WXD()
    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_WXD.Attributes["SortExpression"];

        string sortDirection = this.GridView_WXD.Attributes["SortDirection"];

        string strSQL;

        if (!QXBool(36, Convert.ToInt32(DefaultUser)))
        {
            if (this.GridView_WXD_Label_tj.Text.Length > 0)
            {
                strSQL = "SELECT w_wxd.*,CNAME FROM w_wxd,S_USERINFO where wxry=s_userinfo.id and wxry="+DefaultUser+" and  " + this.GridView_WXD_Label_tj.Text.Trim() + " and del=0 ORDER BY ltime desc";
            }
            else
            {
                strSQL = "SELECT w_wxd.*,CNAME FROM w_wxd,S_USERINFO where wxry=s_userinfo.id and wxry=" + DefaultUser + " and del=0 ORDER BY ltime desc";
            }
        }
        else
        {
            if (this.GridView_WXD_Label_tj.Text.Length > 0)
            {
                strSQL = "SELECT w_wxd.*,CNAME FROM w_wxd,S_USERINFO where wxry=s_userinfo.id and  " + this.GridView_WXD_Label_tj.Text.Trim() + " and del=0 ORDER BY ltime desc";
            }
            else
            {
                strSQL = "SELECT w_wxd.*,CNAME FROM w_wxd,S_USERINFO where wxry=s_userinfo.id  and del=0 ORDER BY ltime desc";
            }
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



            this.GridView_WXD.DataSource = OP_Mode.Dtv;

            this.GridView_WXD.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_WXD_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_WXD.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_WXD.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_WXD.Attributes["SortExpression"] = sortExpression;

        this.GridView_WXD.Attributes["SortDirection"] = sortDirection;

        Load_GridView_WXD();

    }

    protected void GridView_WXD_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_WXD();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_WXD_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_WXD_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_WXD_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_WXD_Label1.Text.Length > 0)

        {

            this.GridView_WXD_Label1.Text += "<b>并且</b><br />";

            this.GridView_WXD_Label_tj.Text += " and ";

        }

        this.GridView_WXD_Label1.Text += this.GridView_WXD_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_WXD_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_WXD_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_WXD_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_WXD_Label_tj.Text += " " + this.GridView_WXD_DropDownList1.SelectedValue + " " + this.GridView_WXD_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_WXD_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_WXD_Label_tj.Text += " " + this.GridView_WXD_DropDownList1.SelectedValue + " " + this.GridView_WXD_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_WXD_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_WXD_TextBox_CXTJ.Text = string.Empty;

        this.GridView_WXD_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_WXD_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_WXD_TextBox_CXTJ.Text = string.Empty;

        this.GridView_WXD_Label1.Text = string.Empty;

        this.GridView_WXD_Label_tj.Text = string.Empty;

        this.GridView_WXD_alerts_tj.Visible = false;

        Load_GridView_WXD();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_WXD_LinkButton4_Click(object sender, EventArgs e)
    {

        Load_GridView_WXD();

    }

    protected void GridView_WXD_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_WXD.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_WXD.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_WXD.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_WXD.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}