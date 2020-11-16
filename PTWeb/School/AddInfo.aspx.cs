using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class School_AddInfo : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_GridView_ZY();
            loadDefaultData();
        }
    }

    /// <summary>
    /// 加载默认数据
    /// </summary>
    private void loadDefaultData()
    {
        GridView_ZY_TextBox_TSTime.Text = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;


        string weekstr = DateTime.Now.DayOfWeek.ToString();
        switch (weekstr)
        {
            case "Monday": weekstr = "星期一"; break;
            case "Tuesday": weekstr = "星期二"; break;
            case "Wednesday": weekstr = "星期三"; break;
            case "Thursday": weekstr = "星期四"; break;
            case "Friday": weekstr = "星期五"; break;
            case "Saturday": weekstr = "星期六"; break;
            case "Sunday": weekstr = "星期日"; break;
        }

        if (weekstr == "星期五")
        {
            DateTime TTime;

            TTime = DateTime.Now.AddDays(2);

            GridView_ZY_TextBox_TETime.Text = TTime.Year + "-" + TTime.Month + "-" + TTime.Day;
        }


    }

    #region "GridView_ZY 读取信息添加 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_ZY()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_ZY.Attributes["SortExpression"];

        string sortDirection = this.GridView_ZY.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_ZY_Label_tj.Text.Length > 0)

        {

            strSQL = "SELECT School.*,NName FROM School,School_Class_User,School_Class where USERID=" + DefaultUser + " and CLASSID=School_Class.ID and School.IClass=School_Class.ID AND " + this.GridView_ZY_Label_tj.Text.Trim() + " ORDER BY School.ID desc";

        }

        else

        {

            strSQL = "SELECT School.*,NName FROM School,School_Class_User,School_Class where USERID=" + DefaultUser + " and CLASSID=School_Class.ID and School.IClass=School_Class.ID ORDER BY School.ID desc";

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



            this.GridView_ZY.DataSource = OP_Mode.Dtv;

            this.GridView_ZY.DataBind();

            this.GridView_ZY.BottomPagerRow.Visible = true;

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_ZY_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_ZY.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_ZY.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_ZY.Attributes["SortExpression"] = sortExpression;

        this.GridView_ZY.Attributes["SortDirection"] = sortDirection;

        Load_GridView_ZY();

    }

    protected void GridView_ZY_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_ZY();

    }

    protected void GridView_ZY_RowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView_ZY.EditIndex = e.NewEditIndex;

        //GridView_ZY.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_ZY();

    }

    protected void GridView_ZY_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        GridView_ZY.SelectedIndex = -1;

        GridView_ZY.EditIndex = -1;

        Load_GridView_ZY();

    }

    protected void GridView_ZY_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

        string ID = GridView_ZY.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称

        string DB_01 = ((TextBox)GridView_ZY.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_02 = ((TextBox)GridView_ZY.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_03 = ((TextBox)GridView_ZY.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_04 = ((TextBox)GridView_ZY.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_05 = ((TextBox)GridView_ZY.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Replace("'", "\"");

        if (!(DB_01.Length > 0))
        {

            MessageBox("", "信息类别不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL = string.Empty;

        strSQL = "Update School SET NContent='" + DB_02 + "', TSTime='" + DB_03 + "', TETime='" + DB_04 + "', IPX='" + DB_05 + "', LTIME=GETDATE() WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "数据更新成功!");

        }

        else

        {

            MessageBox("", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        GridView_ZY.SelectedIndex = -1;

        GridView_ZY.EditIndex = -1;

        Load_GridView_ZY();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_ZY_RowCommand(object sender, GridViewCommandEventArgs e)

    {

        if (e.CommandName == "GridView_ZY_ADD")

        {

            this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#GridView_ZY_ADD').modal('show')</script>");

        }

    }

    /// <summary>

    /// 模块数据保存

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_ZY_LinkButton1_Click(object sender, EventArgs e)

    {

        /// 信息类别

        string DB_01 = this.DropDownList1.SelectedValue.Trim().Replace("'", "\"");

        /// 信息内容

        string DB_02 = this.GridView_ZY_TextBox_NContent.Text.Trim().Replace("'", "\"");

        /// 开始时间

        string DB_03 = this.GridView_ZY_TextBox_TSTime.Text.Trim().Replace("'", "\"");

        /// 结束时间

        string DB_04 = this.GridView_ZY_TextBox_TETime.Text.Trim().Replace("'", "\"");

        /// 排序

        string DB_05 = this.GridView_ZY_TextBox_IPX.Text.Trim().Replace("'", "\"");

        if (!(DB_01.Length > 0))

        {

            MessageBox("", "登录名称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL;

        strSQL = "Insert into School ( IClass,IFlag, NContent, TSTime, TETime, IPX,CTIME,LTIME) VALUES ('" + DB_01 + "',1,'" + DB_02 + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "',GETDATE(),GETDATE()) ";

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "信息添加信息添加成功!", Request.Url.LocalPath);

        }

        else

        {

            MessageBox("", "信息添加信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        Load_GridView_ZY();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_ZY_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //如果是绑定数据行 

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

            {

                ((LinkButton)e.Row.Cells[6].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】吗?')");

            }

        }

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_ZY_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        string ID = GridView_ZY.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from School where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "指定数据删除成功^_^！");

            Load_GridView_ZY();

            //            File.Delete(@"D:\Test\Debug1\测试.txt");
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

    protected void GridView_ZY_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_ZY_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_ZY_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_ZY_Label1.Text.Length > 0)

        {

            this.GridView_ZY_Label1.Text += "<b>并且</b><br />";

            this.GridView_ZY_Label_tj.Text += " and ";

        }

        this.GridView_ZY_Label1.Text += this.GridView_ZY_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_ZY_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_ZY_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_ZY_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_ZY_Label_tj.Text += " " + this.GridView_ZY_DropDownList1.SelectedValue + " " + this.GridView_ZY_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_ZY_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_ZY_Label_tj.Text += " " + this.GridView_ZY_DropDownList1.SelectedValue + " " + this.GridView_ZY_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_ZY_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_ZY_TextBox_CXTJ.Text = string.Empty;

        this.GridView_ZY_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_ZY_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_ZY_TextBox_CXTJ.Text = string.Empty;

        this.GridView_ZY_Label1.Text = string.Empty;

        this.GridView_ZY_Label_tj.Text = string.Empty;

        this.GridView_ZY_alerts_tj.Visible = false;

        Load_GridView_ZY();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_ZY_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_ZY();

    }

    protected void GridView_ZY_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_ZY.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_ZY.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_ZY.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_ZY.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

        GridView_ZY.Rows[e.NewSelectedIndex].Cells[4].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}