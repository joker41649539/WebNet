using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JYJG_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_GridView_JG();
            Load_GridView_JG_F();
        }
    }
    #region "GridView_JG 读取教育机构 相关代码"
    /// <summary>

    /// 待审核机构数据读取

    /// </summary>

    private void Load_GridView_JG()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_JG.Attributes["SortExpression"];

        string sortDirection = this.GridView_JG.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_JG_Label_tj.Text.Length > 0)

        {

            strSQL = "SELECT * FROM S_JG where " + this.GridView_JG_Label_tj.Text.Trim() + " and del=0 and Flag=0 ORDER BY ID";

        }

        else

        {

            strSQL = "SELECT * FROM S_JG where del=0 and Flag=0 ORDER BY ID";

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



            this.GridView_JG.DataSource = OP_Mode.Dtv;

            this.GridView_JG.DataBind();

            this.GridView_JG.BottomPagerRow.Visible = true;

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_JG_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_JG.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_JG.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_JG.Attributes["SortExpression"] = sortExpression;

        this.GridView_JG.Attributes["SortDirection"] = sortDirection;

        Load_GridView_JG();

    }

    protected void GridView_JG_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_JG();

    }

    protected void GridView_JG_RowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView_JG.EditIndex = e.NewEditIndex;

        //GridView_JG.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_JG();

    }

    protected void GridView_JG_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        GridView_JG.SelectedIndex = -1;

        GridView_JG.EditIndex = -1;

        Load_GridView_JG();

    }

    protected void GridView_JG_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

        string ID = GridView_JG.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称

        string DB_01 = ((TextBox)GridView_JG.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_02 = ((TextBox)GridView_JG.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_03 = ((TextBox)GridView_JG.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_04 = ((TextBox)GridView_JG.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Replace("'", "\"");

        if (!(DB_01.Length > 0))

        {

            MessageBox("", "机构全称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL = string.Empty;

        strSQL = "Update S_JG SET JGQC='" + DB_01 + "', JGJC='" + DB_02 + "', LOGO='" + DB_03 + "', LXDH='" + DB_04 + "', LTIME=GETDATE() WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "数据更新成功!");

        }

        else

        {

            MessageBox("", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        GridView_JG.SelectedIndex = -1;

        GridView_JG.EditIndex = -1;

        Load_GridView_JG();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_RowCommand(object sender, GridViewCommandEventArgs e)

    {

        if (e.CommandName == "GridView_JG_ADD")

        {

            this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#GridView_JG_ADD').modal('show')</script>");

        }

    }

    /// <summary>

    /// 模块数据保存

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_LinkButton1_Click(object sender, EventArgs e)

    {

        /// 机构全称

        string DB_01 = this.GridView_JG_TextBox_JGQC.Text.Trim().Replace("'", "\"");

        /// 机构简称

        string DB_02 = this.GridView_JG_TextBox_JGJC.Text.Trim().Replace("'", "\"");

        /// LOGO

        string DB_03 = this.GridView_JG_TextBox_LOGO.Text.Trim().Replace("'", "\"");

        /// 联系电话

        string DB_04 = this.GridView_JG_TextBox_LXDH.Text.Trim().Replace("'", "\"");

        string DB_05 = this.GridView_JG_TextBox_JGJJ.Text.Trim().Replace("'", "\"");

        if (!(DB_01.Length > 0))

        {

            MessageBox("", "机构全称不允许为空！<br/>请认真填写。");

            return;

        }
        if (!(DB_02.Length > 0))

        {

            MessageBox("", "机构简称不允许为空！<br/>请认真填写。");

            return;

        }
        if (!(DB_04.Length > 0))

        {

            MessageBox("", "机构联系电话不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL;

        strSQL = "Insert into S_JG ( JGQC, JGJC, LOGO, LXDH, JGJJ,CTIME,LTIME) VALUES ('" + DB_01 + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "',GETDATE(),GETDATE()) ";

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "教育机构信息添加成功!", Request.Url.LocalPath);

        }

        else

        {

            MessageBox("", "教育机构信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        Load_GridView_JG();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //如果是绑定数据行 

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

            {

                ((LinkButton)e.Row.Cells[6].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要给：【\"" + e.Row.Cells[1].Text + "\" 】审核通过吗?')");

            }

        }

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        string ID = GridView_JG.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Update S_JG Set Flag=1,LTime=getdate() where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "指定教育机构审核成功^_^！");

            Load_GridView_JG();

        }

        else

        {

            MessageBox("", "指定教育机构审核失败，请重试。<br/>" + OP_Mode.strErrMsg);

        }

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_JG_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_JG_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_JG_Label1.Text.Length > 0)

        {

            this.GridView_JG_Label1.Text += "<b>并且</b><br />";

            this.GridView_JG_Label_tj.Text += " and ";

        }

        this.GridView_JG_Label1.Text += this.GridView_JG_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_JG_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_JG_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_JG_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_JG_Label_tj.Text += " " + this.GridView_JG_DropDownList1.SelectedValue + " " + this.GridView_JG_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_JG_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_JG_Label_tj.Text += " " + this.GridView_JG_DropDownList1.SelectedValue + " " + this.GridView_JG_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_JG_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_JG_TextBox_CXTJ.Text = string.Empty;

        this.GridView_JG_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_JG_TextBox_CXTJ.Text = string.Empty;

        this.GridView_JG_Label1.Text = string.Empty;

        this.GridView_JG_Label_tj.Text = string.Empty;

        this.GridView_JG_alerts_tj.Visible = false;

        Load_GridView_JG();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_JG();

    }

    protected void GridView_JG_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_JG.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_JG.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_JG.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_JG.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");
        GridView_JG.Rows[e.NewSelectedIndex].Cells[4].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion

    #region "GridView_JG_F 读取教育机构 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_JG_F()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_JG_F.Attributes["SortExpression"];

        string sortDirection = this.GridView_JG_F.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_JG_F_Label_tj.Text.Length > 0)

        {

            strSQL = "SELECT * FROM S_JG where " + this.GridView_JG_F_Label_tj.Text.Trim() + " and flag=1 ORDER BY ID";

        }

        else

        {

            strSQL = "SELECT * FROM S_JG where flag=1 ORDER BY ID";

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



            this.GridView_JG_F.DataSource = OP_Mode.Dtv;

            this.GridView_JG_F.DataBind();
            this.GridView_JG_F.BottomPagerRow.Visible = true;

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_JG_F_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_JG_F.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_JG_F.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_JG_F.Attributes["SortExpression"] = sortExpression;

        this.GridView_JG_F.Attributes["SortDirection"] = sortDirection;

        Load_GridView_JG_F();

    }

    protected void GridView_JG_F_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_JG_F();

    }

    protected void GridView_JG_F_RowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView_JG_F.EditIndex = e.NewEditIndex;

        //GridView_JG_F.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_JG_F();

    }

    protected void GridView_JG_F_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        GridView_JG_F.SelectedIndex = -1;

        GridView_JG_F.EditIndex = -1;

        Load_GridView_JG_F();

    }

    protected void GridView_JG_F_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

        string ID = GridView_JG_F.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称

        string DB_01 = ((TextBox)GridView_JG_F.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_02 = ((TextBox)GridView_JG_F.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_03 = ((TextBox)GridView_JG_F.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_04 = ((TextBox)GridView_JG_F.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Replace("'", "\"");

        if (!(DB_01.Length > 0))

        {

            MessageBox("", "机构全称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL = string.Empty;

        strSQL = "Update S_JG SET JGQC='" + DB_01 + "', JGJC='" + DB_02 + "', LOGO='" + DB_03 + "', LXDH='" + DB_04 + "', LTIME=GETDATE() WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "数据更新成功!");

        }

        else

        {

            MessageBox("", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        GridView_JG_F.SelectedIndex = -1;

        GridView_JG_F.EditIndex = -1;

        Load_GridView_JG_F();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_F_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //如果是绑定数据行 

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

            {

                ((LinkButton)e.Row.Cells[5].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】吗?')");

            }

        }

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_F_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        string ID = GridView_JG_F.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from S_JG where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "指定数据删除成功^_^！");

            Load_GridView_JG_F();

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

    protected void GridView_JG_F_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_JG_F_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_JG_F_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_JG_F_Label1.Text.Length > 0)

        {

            this.GridView_JG_F_Label1.Text += "<b>并且</b><br />";

            this.GridView_JG_F_Label_tj.Text += " and ";

        }

        this.GridView_JG_F_Label1.Text += this.GridView_JG_F_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_JG_F_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_JG_F_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_JG_F_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_JG_F_Label_tj.Text += " " + this.GridView_JG_F_DropDownList1.SelectedValue + " " + this.GridView_JG_F_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_JG_F_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_JG_F_Label_tj.Text += " " + this.GridView_JG_F_DropDownList1.SelectedValue + " " + this.GridView_JG_F_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_JG_F_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_JG_F_TextBox_CXTJ.Text = string.Empty;

        this.GridView_JG_F_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_F_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_JG_F_TextBox_CXTJ.Text = string.Empty;

        this.GridView_JG_F_Label1.Text = string.Empty;

        this.GridView_JG_F_Label_tj.Text = string.Empty;

        this.GridView_JG_F_alerts_tj.Visible = false;

        Load_GridView_JG_F();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_JG_F_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_JG_F();

    }

    protected void GridView_JG_F_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_JG_F.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_JG_F.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_JG_F.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_JG_F.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}