using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SQGL_YZSQ : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_GridView_YZ();
        }
    }

    #region "GridView_YZ 读取印章授权 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_YZ()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_YZ.Attributes["SortExpression"];

        string sortDirection = this.GridView_YZ.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_YZ_Label_tj.Text.Length > 0)

        {

            strSQL = "SELECT  W_SQ.*,CNAME FROM w_sq,S_USERINFO where iDel=0 and SQR=S_USERINFO.ID And " + this.GridView_YZ_Label_tj.Text.Trim() + " ORDER BY ID";

        }

        else

        {

            strSQL = "SELECT  W_SQ.*,CNAME FROM w_sq,S_USERINFO where iDel=0 and SQR=S_USERINFO.ID ORDER BY ID";

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



            this.GridView_YZ.DataSource = OP_Mode.Dtv;

            this.GridView_YZ.DataBind();

            this.GridView_YZ.BottomPagerRow.Visible = true;

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_YZ_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_YZ.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_YZ.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_YZ.Attributes["SortExpression"] = sortExpression;

        this.GridView_YZ.Attributes["SortDirection"] = sortDirection;

        Load_GridView_YZ();

    }

    protected void GridView_YZ_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_YZ();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_YZ_RowCommand(object sender, GridViewCommandEventArgs e)

    {

        if (e.CommandName == "GridView_YZ_ADD")

        {

            this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#GridView_YZ_ADD').modal('show')</script>");

        }

    }

    /// <summary>

    /// 模块数据保存

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_YZ_LinkButton1_Click(object sender, EventArgs e)

    {

        /// 标题

        string DB_01 = this.GridView_YZ_TextBox_cTitle.Text.Trim().Replace("'", "\"");

        /// 状态

        string DB_02 = this.GridView_YZ_TextBox_SQSM.Text.Trim().Replace("'", "\"");

        if (DB_01.Length == 0 || DB_02.Length == 0)
        {
            MessageBox("", "标题及说明不允许为空！<br/>请认真填写。");

            return;
        }

        string strSQL;

        strSQL = "Insert into w_sq ( STitle, SContent, SQR,SPRQ,ICLASS,IFLAG) VALUES ('" + DB_01 + "','" + DB_02 + "'," + DefaultUser + ",getdate(),0,0) ";

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "印章授权信息添加成功!", Request.Url.LocalPath);

        }

        else

        {

            MessageBox("", "印章授权信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        Load_GridView_YZ();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_YZ_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //如果是绑定数据行 

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

            {

                ((LinkButton)e.Row.Cells[3].Controls[1]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除这条数据吗?')");

            }

        }

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_YZ_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        string ID = GridView_YZ.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Update w_sq set iDel=1,Ltime=Getdate() where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "指定数据删除成功^_^！");

            Load_GridView_YZ();

        }

        else

        {

            MessageBox("", "指定数据删除错误。<br/>" + OP_Mode.strErrMsg);

        }

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_YZ_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_YZ_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_YZ_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_YZ_Label1.Text.Length > 0)

        {

            this.GridView_YZ_Label1.Text += "<b>并且</b><br />";

            this.GridView_YZ_Label_tj.Text += " and ";

        }

        this.GridView_YZ_Label1.Text += this.GridView_YZ_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_YZ_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_YZ_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_YZ_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_YZ_Label_tj.Text += " " + this.GridView_YZ_DropDownList1.SelectedValue + " " + this.GridView_YZ_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_YZ_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_YZ_Label_tj.Text += " " + this.GridView_YZ_DropDownList1.SelectedValue + " " + this.GridView_YZ_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_YZ_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_YZ_TextBox_CXTJ.Text = string.Empty;

        this.GridView_YZ_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_YZ_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_YZ_TextBox_CXTJ.Text = string.Empty;

        this.GridView_YZ_Label1.Text = string.Empty;

        this.GridView_YZ_Label_tj.Text = string.Empty;

        this.GridView_YZ_alerts_tj.Visible = false;

        Load_GridView_YZ();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_YZ_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_YZ();

    }

    protected void GridView_YZ_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_YZ.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_YZ.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_YZ.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_YZ.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}