using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dance_ManageClass : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_GridView_Class();
        }
    }
    #region "GridView_Class 读取课程管理 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_Class()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_Class.Attributes["SortExpression"];

        string sortDirection = this.GridView_Class.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_Class_Label_tj.Text.Length > 0)

        {

            strSQL = "SELECT * FROM Dance_Class where " + this.GridView_Class_Label_tj.Text.Trim() + " ORDER BY ID";

        }

        else

        {

            strSQL = "Select ID,classname,Flag,PX,school,ClassTeacher,CONVERT(varchar(100), ClassTimeStart, 24) STime,CONVERT(varchar(100), ClassTimeEnd, 24) ETime,ClassWeek,MaxMen,(Select Count(ID) from Dance_Arrange where classID=Dance_Class.ID) ArrAngeCount from Dance_Class where Flag=0 order by PX,ClassTimeStart";

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



            this.GridView_Class.DataSource = OP_Mode.Dtv;

            this.GridView_Class.DataBind();

            this.GridView_Class.BottomPagerRow.Visible = true;

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_Class_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_Class.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_Class.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_Class.Attributes["SortExpression"] = sortExpression;

        this.GridView_Class.Attributes["SortDirection"] = sortDirection;

        Load_GridView_Class();

    }

    protected void GridView_Class_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_Class();

    }

    protected void GridView_Class_RowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView_Class.EditIndex = e.NewEditIndex;

        //GridView_Class.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_Class();

    }

    protected void GridView_Class_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        GridView_Class.SelectedIndex = -1;

        GridView_Class.EditIndex = -1;

        Load_GridView_Class();

    }

    protected void GridView_Class_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

        string ID = GridView_Class.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称

        string DB_01 = ((TextBox)GridView_Class.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_02 = ((TextBox)GridView_Class.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_03 = ((TextBox)GridView_Class.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_04 = ((TextBox)GridView_Class.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_05 = ((TextBox)GridView_Class.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_06 = ((TextBox)GridView_Class.Rows[e.RowIndex].Cells[6].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_07 = ((TextBox)GridView_Class.Rows[e.RowIndex].Cells[7].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_08 = ((TextBox)GridView_Class.Rows[e.RowIndex].Cells[8].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_09 = ((TextBox)GridView_Class.Rows[e.RowIndex].Cells[9].Controls[0]).Text.ToString().Replace("'", "\"");

        if (!(DB_01.Length > 0))

        {

            MessageBox("", "课程名不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL = string.Empty;

        strSQL = "Update Dance_Class SET ClassName='" + DB_01 + "', ClassTeacher='" + DB_02 + "', ClassTimeStart='" + DB_03 + "', ClassTimeEnd='" + DB_04 + "', ClassWeek='" + DB_05 + "', MaxMen='" + DB_06 + "', Flag='" + DB_07 + "', PX='" + DB_08 + "', School='" + DB_09 + "', LTIME=GETDATE() WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "数据更新成功!");

        }

        else

        {

            MessageBox("", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        GridView_Class.SelectedIndex = -1;

        GridView_Class.EditIndex = -1;

        Load_GridView_Class();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Class_RowCommand(object sender, GridViewCommandEventArgs e)

    {

        if (e.CommandName == "GridView_Class_ADD")

        {

            this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#GridView_Class_ADD').modal('show')</script>");

        }

    }

    /// <summary>

    /// 模块数据保存

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Class_LinkButton1_Click(object sender, EventArgs e)

    {

        /// 课程名

        string DB_01 = this.GridView_Class_TextBox_ClassName.Text.Trim().Replace("'", "\"");

        /// 老师

        string DB_02 = this.GridView_Class_TextBox_ClassTeacher.Text.Trim().Replace("'", "\"");

        /// 开始时间

        string DB_03 = this.GridView_Class_TextBox_ClassTimeStart.Text.Trim().Replace("'", "\"");

        /// 结束时间

        string DB_04 = this.GridView_Class_TextBox_ClassTimeEnd.Text.Trim().Replace("'", "\"");

        /// 星期

        string DB_05 = this.GridView_Class_TextBox_ClassWeek.Text.Trim().Replace("'", "\"");

        /// 最多人数

        string DB_06 = this.GridView_Class_TextBox_MaxMen.Text.Trim().Replace("'", "\"");

        /// 状态

        string DB_07 = this.GridView_Class_TextBox_Flag.Text.Trim().Replace("'", "\"");

        /// 排序

        string DB_08 = this.GridView_Class_TextBox_PX.Text.Trim().Replace("'", "\"");

        /// 学校

        string DB_09 = this.GridView_Class_TextBox_School.Text.Trim().Replace("'", "\"");

        if (!(DB_01.Length > 0))

        {

            MessageBox("", "登录名称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL;

        strSQL = "Insert into Dance_Class ( ClassName, ClassTeacher, ClassTimeStart, ClassTimeEnd, ClassWeek, MaxMen, Flag, PX, School,CTIME,LTIME) VALUES ('" + DB_01 + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "','" + DB_06 + "','" + DB_07 + "','" + DB_08 + "','" + DB_09 + "',GETDATE(),GETDATE()) ";

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "课程管理信息添加成功!", Request.Url.LocalPath);

        }

        else

        {

            MessageBox("", "课程管理信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        Load_GridView_Class();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Class_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //如果是绑定数据行 

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

            {

                ((LinkButton)e.Row.Cells[10].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】吗?')");

            }

        }

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Class_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        string ID = GridView_Class.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from Dance_Class where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "指定数据删除成功^_^！");

            Load_GridView_Class();

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

    protected void GridView_Class_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_Class_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_Class_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_Class_Label1.Text.Length > 0)

        {

            this.GridView_Class_Label1.Text += "<b>并且</b><br />";

            this.GridView_Class_Label_tj.Text += " and ";

        }

        this.GridView_Class_Label1.Text += this.GridView_Class_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_Class_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_Class_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_Class_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_Class_Label_tj.Text += " " + this.GridView_Class_DropDownList1.SelectedValue + " " + this.GridView_Class_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_Class_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_Class_Label_tj.Text += " " + this.GridView_Class_DropDownList1.SelectedValue + " " + this.GridView_Class_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_Class_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_Class_TextBox_CXTJ.Text = string.Empty;

        this.GridView_Class_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Class_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_Class_TextBox_CXTJ.Text = string.Empty;

        this.GridView_Class_Label1.Text = string.Empty;

        this.GridView_Class_Label_tj.Text = string.Empty;

        this.GridView_Class_alerts_tj.Visible = false;

        Load_GridView_Class();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Class_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_Class();

    }

    protected void GridView_Class_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_Class.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_Class.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_Class.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_Class.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

        GridView_Class.Rows[e.NewSelectedIndex].Cells[4].BackColor = Color.FromName("#CAD3E4");

        GridView_Class.Rows[e.NewSelectedIndex].Cells[5].BackColor = Color.FromName("#CAD3E4");

        GridView_Class.Rows[e.NewSelectedIndex].Cells[6].BackColor = Color.FromName("#CAD3E4");

        GridView_Class.Rows[e.NewSelectedIndex].Cells[7].BackColor = Color.FromName("#CAD3E4");

        GridView_Class.Rows[e.NewSelectedIndex].Cells[8].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}