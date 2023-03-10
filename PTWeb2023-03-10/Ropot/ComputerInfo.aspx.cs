using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ropot_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string LoginID = string.Empty;

            try
            {
                LoginID = Request.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID].ToString();
            }
            catch
            {

            }

            if (LoginID.Length > 0)
            {
                Load_GridView_Info();
            }
            else
            {
                MessageBox("", "您还未登录，请先登录。", "/Ropot/login.aspx");
                //Response.Redirect("/Ropot/login.aspx", false);
            }

        }
    }

    #region "GridView_Info 读取游戏信息 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_Info()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_Info.Attributes["SortExpression"];

        string sortDirection = this.GridView_Info.Attributes["SortDirection"];

        string strSQL = " Delete from BC_GameInfo where LTime < DATEADD(dd,-1,getdate()) ";

        if (this.GridView_Info_Label_tj.Text.Length > 0)
        {
            strSQL = "SELECT * FROM Hundred where " + this.GridView_Info_Label_tj.Text.Trim() + " ORDER BY ID";
        }
        else
        {
            strSQL = "SELECT * FROM Hundred ORDER BY ID";
        }

        if (OP_Mode.SQLRUN(strSQL))
        {

            /// 设置排序

            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
            {
                OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
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

    protected void GridView_Info_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_Info();

    }

    protected void GridView_Info_RowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView_Info.EditIndex = e.NewEditIndex;

        //GridView_Info.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_Info();

    }

    protected void GridView_Info_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        GridView_Info.SelectedIndex = -1;

        GridView_Info.EditIndex = -1;

        Load_GridView_Info();

    }

    protected void GridView_Info_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

        string ID = GridView_Info.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称


        string DB_02 = ((TextBox)GridView_Info.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        string strSQL = string.Empty;

        strSQL = "Update Hundred SET EndTime='" + DB_02 + "' WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "数据更新成功!");

        }

        else

        {

            MessageBox("", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        GridView_Info.SelectedIndex = -1;

        GridView_Info.EditIndex = -1;

        Load_GridView_Info();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Info_RowCommand(object sender, GridViewCommandEventArgs e)

    {

        if (e.CommandName == "GridView_Info_ADD")

        {

            this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#GridView_Info_ADD').modal('show')</script>");

        }

    }

    /// <summary>

    /// 模块数据保存

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Info_LinkButton1_Click(object sender, EventArgs e)

    {

        /// 电脑名称

        string DB_01 = this.GridView_Info_TextBox_JQMC.Text.Trim().Replace("'", "\"");

        /// 到期时间

        string DB_02 = this.GridView_Info_TextBox_EndTime.Text.Trim().Replace("'", "\"");

        /// 登陆时间

        string DB_03 = this.GridView_Info_TextBox_LTime.Text.Trim().Replace("'", "\"");

        if (!(DB_01.Length > 0))

        {

            MessageBox("", "登录名称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL;

        strSQL = "Insert into Hundred ( JQMC, EndTime, LTime,CTIME,LTIME) VALUES ('" + DB_01 + "','" + DB_02 + "','" + DB_03 + "',GETDATE(),GETDATE()) ";

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "游戏信息信息添加成功!", Request.Url.LocalPath);

        }

        else

        {

            MessageBox("", "游戏信息信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        Load_GridView_Info();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Info_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //如果是绑定数据行 

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

            {

                ((LinkButton)e.Row.Cells[4].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】吗?')");

            }

        }

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Info_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        string ID = GridView_Info.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from Hundred where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "指定数据删除成功^_^！");

            Load_GridView_Info();

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

    protected void GridView_Info_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_Info_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_Info_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_Info_Label1.Text.Length > 0)

        {

            this.GridView_Info_Label1.Text += "<b>并且</b><br />";

            this.GridView_Info_Label_tj.Text += " and ";

        }

        this.GridView_Info_Label1.Text += this.GridView_Info_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_Info_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_Info_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_Info_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_Info_Label_tj.Text += " " + this.GridView_Info_DropDownList1.SelectedValue + " " + this.GridView_Info_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_Info_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_Info_Label_tj.Text += " " + this.GridView_Info_DropDownList1.SelectedValue + " " + this.GridView_Info_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_Info_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_Info_TextBox_CXTJ.Text = string.Empty;

        this.GridView_Info_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Info_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_Info_TextBox_CXTJ.Text = string.Empty;

        this.GridView_Info_Label1.Text = string.Empty;

        this.GridView_Info_Label_tj.Text = string.Empty;

        this.GridView_Info_alerts_tj.Visible = false;

        Load_GridView_Info();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Info_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_Info();

    }

    protected void GridView_Info_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_Info.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_Info.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_Info.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}