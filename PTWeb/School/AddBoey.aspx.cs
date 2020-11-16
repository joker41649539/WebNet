using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class School_AddBoey : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_GridView_Boey();
        }
    }

    #region "GridView_Boey 读取Boey信息 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_Boey()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_Boey.Attributes["SortExpression"];

        string sortDirection = this.GridView_Boey.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_Boey_Label_tj.Text.Length > 0)

        {

            strSQL = "SELECT * FROM Boey where " + this.GridView_Boey_Label_tj.Text.Trim() + " ORDER BY ID";

        }

        else

        {

            strSQL = "SELECT * FROM Boey ORDER BY ID";

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



            this.GridView_Boey.DataSource = OP_Mode.Dtv;

            this.GridView_Boey.DataBind();

            this.GridView_Boey.BottomPagerRow.Visible = true;

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_Boey_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_Boey.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_Boey.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_Boey.Attributes["SortExpression"] = sortExpression;

        this.GridView_Boey.Attributes["SortDirection"] = sortDirection;

        Load_GridView_Boey();

    }

    protected void GridView_Boey_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_Boey();

    }

    protected void GridView_Boey_RowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView_Boey.EditIndex = e.NewEditIndex;

        //GridView_Boey.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_Boey();

    }

    protected void GridView_Boey_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        GridView_Boey.SelectedIndex = -1;

        GridView_Boey.EditIndex = -1;

        Load_GridView_Boey();

    }

    protected void GridView_Boey_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

        string ID = GridView_Boey.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称

        string DB_01 = ((TextBox)GridView_Boey.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_02 = ((TextBox)GridView_Boey.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_03 = ((TextBox)GridView_Boey.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");

        if (!(DB_01.Length > 0))

        {

            MessageBox("", "图片类别不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL = string.Empty;

        strSQL = "Update Boey SET Class='" + DB_01 + "', ImgUrl='" + DB_02 + "', Remark='" + DB_03 + "', LTIME=GETDATE() WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "数据更新成功!");

        }

        else

        {

            MessageBox("", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        GridView_Boey.SelectedIndex = -1;

        GridView_Boey.EditIndex = -1;

        Load_GridView_Boey();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Boey_RowCommand(object sender, GridViewCommandEventArgs e)

    {

        if (e.CommandName == "GridView_Boey_ADD")

        {

            this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#GridView_Boey_ADD').modal('show')</script>");

        }

    }

    /// <summary>

    /// 模块数据保存

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Boey_LinkButton1_Click(object sender, EventArgs e)

    {

        /// 图片类别

        string DB_01 = this.GridView_Boey_TextBox_Class.Text.Trim().Replace("'", "\"");

        /// 图片地址

        string DB_02 = "";

        /// 说明

        string DB_03 = this.GridView_Boey_TextBox_Remark.Text.Trim().Replace("'", "\"");

        if (!(DB_01.Length > 0))

        {

            MessageBox("", "登录名称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL;

        strSQL = "Insert into Boey ( Class, ImgUrl, Remark,CTIME,LTIME) VALUES ('" + DB_01 + "','" + DB_02 + "','" + DB_03 + "',GETDATE(),GETDATE()) ";

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "Boey信息信息添加成功!", Request.Url.LocalPath);

        }

        else

        {

            MessageBox("", "Boey信息信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        Load_GridView_Boey();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Boey_RowDataBound(object sender, GridViewRowEventArgs e)

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

    protected void GridView_Boey_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        string ID = GridView_Boey.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from Boey where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "指定数据删除成功^_^！");

            Load_GridView_Boey();

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

    protected void GridView_Boey_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_Boey_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_Boey_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_Boey_Label1.Text.Length > 0)

        {

            this.GridView_Boey_Label1.Text += "<b>并且</b><br />";

            this.GridView_Boey_Label_tj.Text += " and ";

        }

        this.GridView_Boey_Label1.Text += this.GridView_Boey_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_Boey_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_Boey_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_Boey_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_Boey_Label_tj.Text += " " + this.GridView_Boey_DropDownList1.SelectedValue + " " + this.GridView_Boey_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_Boey_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_Boey_Label_tj.Text += " " + this.GridView_Boey_DropDownList1.SelectedValue + " " + this.GridView_Boey_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_Boey_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_Boey_TextBox_CXTJ.Text = string.Empty;

        this.GridView_Boey_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Boey_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_Boey_TextBox_CXTJ.Text = string.Empty;

        this.GridView_Boey_Label1.Text = string.Empty;

        this.GridView_Boey_Label_tj.Text = string.Empty;

        this.GridView_Boey_alerts_tj.Visible = false;

        Load_GridView_Boey();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Boey_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_Boey();

    }

    protected void GridView_Boey_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_Boey.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_Boey.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_Boey.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}