using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BBGL_Default : PageBase
{
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

            strSQL = "SELECT * FROM S_REPORT where " + this.GridView_Report_Label_tj.Text.Trim() + " ORDER BY ID";

        }

        else
        {

            strSQL = "SELECT * FROM S_REPORT ORDER BY ID";

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

    protected void GridView_Report_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView_Report.EditIndex = e.NewEditIndex;

        //GridView_Report.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_Report();

    }

    protected void GridView_Report_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView_Report.SelectedIndex = -1;

        GridView_Report.EditIndex = -1;

        Load_GridView_Report();

    }

    protected void GridView_Report_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string ID = GridView_Report.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称

        string DB_01 = ((TextBox)GridView_Report.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_02 = ((TextBox)GridView_Report.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_03 = ((TextBox)GridView_Report.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_04 = ((TextBox)GridView_Report.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_05 = ((TextBox)GridView_Report.Rows[e.RowIndex].Cells[6].Controls[0]).Text.ToString().Replace("'", "\"");

        if (!(DB_01.Length > 0))
        {

            MessageBox(GridView_Report_UpdatePanel1, "", "报表名称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL = string.Empty;

        strSQL = "Update S_REPORT SET CNAME='" + DB_01 + "', CFILENAME='" + DB_02 + "', NCLASS='" + DB_03 + "', ISHOW='" + DB_04 + "', IPX='" + DB_05 + "', LTIME=GETDATE() WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox(GridView_Report_UpdatePanel1, "", "数据更新成功!");

        }

        else
        {

            MessageBox(GridView_Report_UpdatePanel1, "", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        GridView_Report.SelectedIndex = -1;

        GridView_Report.EditIndex = -1;

        Load_GridView_Report();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "GridView_Report_ADD")
        {

            ScriptManager.RegisterStartupScript(GridView_Report_UpdatePanel1, this.GetType(), "sKey", "$('#GridView_Report_ADD').modal('show');", true);

        }

    }

    /// <summary>

    /// 模块数据保存

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_LinkButton1_Click(object sender, EventArgs e)
    {

        /// 报表名称

        string DB_01 = this.GridView_Report_TextBox_CNAME.Text.Trim().Replace("'", "\"");

        /// 报表文件名

        string DB_02 = this.GridView_Report_TextBox_CFILENAME.Text.Trim().Replace("'", "\"");

        /// 报表类型

        string DB_03 = this.GridView_Report_TextBox_NCLASS.Text.Trim().Replace("'", "\"");

        /// 显示否

        string DB_04 = this.GridView_Report_TextBox_ISHOW.Text.Trim().Replace("'", "\"");

        /// 排序

        string DB_05 = this.GridView_Report_TextBox_IPX.Text.Trim().Replace("'", "\"");

        if (!(DB_01.Length > 0))
        {

            MessageBox("", "报表名称不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL;

        strSQL = "Insert into S_REPORT ( CNAME, CFILENAME, NCLASS, ISHOW, IPX,CTIME,LTIME) VALUES ('" + DB_01 + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "','" + DB_05 + "',GETDATE(),GETDATE()) ";

        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox(GridView_Report_UpdatePanel1, "", "报表列表信息添加成功!", Request.Url.LocalPath);

        }

        else
        {

            MessageBox(GridView_Report_UpdatePanel1, "", "报表列表信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        Load_GridView_Report();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //如果是绑定数据行 

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {

                ((LinkButton)e.Row.Cells[7].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[2].Text + "\" 】吗?')");

            }

        }

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string ID = GridView_Report.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from S_REPORT where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox(GridView_Report_UpdatePanel1, "", "指定数据删除成功^_^！");

            Load_GridView_Report();

        }

        else
        {

            MessageBox(GridView_Report_UpdatePanel1, "", "指定数据删除错误。<br/>" + OP_Mode.strErrMsg);

        }

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

    protected void GridView_Report_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView_Report.SelectedRow.Cells[0].BackColor = Color.FromName("#CAD3E4");
        GridView_Report.SelectedRow.Cells[1].BackColor = Color.FromName("#CAD3E4");
        GridView_Report.SelectedRow.Cells[2].BackColor = Color.FromName("#CAD3E4");
        GridView_Report.SelectedRow.Cells[3].BackColor = Color.FromName("#CAD3E4");
        GridView_Report.SelectedRow.Cells[4].BackColor = Color.FromName("#CAD3E4");
        GridView_Report.SelectedRow.Cells[5].BackColor = Color.FromName("#CAD3E4");

        Load_GridView_Report_ZB();
        LoadQXZ();
    }

    #endregion

    #region "GridView1 权限组表 相关代码"

    private void LoadQXZ()
    {
        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_Report_ZB.Attributes["SortExpression"];

        string sortDirection = this.GridView_Report_ZB.Attributes["SortDirection"];

        string strSQL;

        string strID = "-1";

        if (GridView_Report.SelectedIndex > -1)
        {
            strID = GridView_Report.SelectedDataKey[0].ToString();
        }

        strSQL = "SELECT ID,ZMC,CAST((SELECT COUNT(IQXZID) FROM S_REPORT_QXZ WHERE IQXZID=S_QXZ.ID AND IREPORTID=" + strID + ") AS BIT ) AS ICHECK FROM S_QXZ ORDER BY ID";


        if (OP_Mode.SQLRUN(strSQL))
        {

            /// 设置排序

            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
            {

                OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

            }

            GridView1.PageSize = OP_Mode.Dtv.Count;

            this.GridView1.DataSource = OP_Mode.Dtv;

            this.GridView1.DataBind();


            this.GridView1.BottomPagerRow.Visible = true;
        }

        else
        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GridView1_Save")
        {
            string strSQL;

            if (GridView_Report.SelectedIndex > -1)
            {
                strSQL = " Delete from S_REPORT_QXZ where IREPORTID=" + GridView_Report.SelectedDataKey[0].ToString() + " ";

                string stemp = string.Empty;

                for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
                {
                    CheckBox chkbox = (CheckBox)this.GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;

                    if (chkbox.Checked)
                    {
                        strSQL += " INSERT INTO S_REPORT_QXZ (IREPORTID,IQXZID) VALUES (" + this.GridView_Report.DataKeys[GridView_Report.SelectedIndex].Value.ToString().Replace("'", "\"") + "," + this.GridView1.DataKeys[i].Value.ToString().Replace("'", "\"") + ") ";
                    }
                }

                if (!OP_Mode.SQLRUN(strSQL))
                {
                    MessageBox(UpdatePanel1, "", "保存错误。<br/>错误：" + OP_Mode.strErrMsg);
                }
                else
                {
                    MessageBox(UpdatePanel1, "", "权限组分配成功！");
                }
            }
        }
    }


    #endregion

    #region "GridView_Report_ZB 读取报表条件 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_Report_ZB()
    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_Report_ZB.Attributes["SortExpression"];

        string sortDirection = this.GridView_Report_ZB.Attributes["SortDirection"];

        string strSQL;

        string strID = "-1";

        if (GridView_Report.SelectedIndex > -1)
        {
            strID = GridView_Report.SelectedDataKey[0].ToString();
        }

        strSQL = "SELECT * FROM S_Report_ZB where IREPORTID = " + strID + " ORDER BY IPX";


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

            this.GridView_Report_ZB.DataSource = OP_Mode.Dtv;

            this.GridView_Report_ZB.DataBind();

            this.GridView_Report_ZB.BottomPagerRow.Visible = true;

        }

        else
        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_Report_ZB_Sorting(object sender, GridViewSortEventArgs e)
    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_Report_ZB.Attributes["SortExpression"])
        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_Report_ZB.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_Report_ZB.Attributes["SortExpression"] = sortExpression;

        this.GridView_Report_ZB.Attributes["SortDirection"] = sortDirection;

        Load_GridView_Report_ZB();

    }

    protected void GridView_Report_ZB_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        Load_GridView_Report_ZB();

    }

    protected void GridView_Report_ZB_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GridView_Report_ZB.EditIndex = e.NewEditIndex;

        //GridView_Report_ZB.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_Report_ZB();

    }

    protected void GridView_Report_ZB_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        GridView_Report_ZB.SelectedIndex = -1;

        GridView_Report_ZB.EditIndex = -1;

        Load_GridView_Report_ZB();

    }

    protected void GridView_Report_ZB_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string ID = GridView_Report_ZB.DataKeys[e.RowIndex].Values[0].ToString();

        /// 模块名称

        string DB_01 = ((TextBox)GridView_Report_ZB.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_02 = ((TextBox)GridView_Report_ZB.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_03 = ((TextBox)GridView_Report_ZB.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");

        string DB_04 = ((TextBox)GridView_Report_ZB.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Replace("'", "\"");

        if (!(DB_01.Length > 0))
        {

            MessageBox(GridView_Report_ZB_UpdatePanel1, "", "中文名不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL = string.Empty;

        strSQL = "Update S_Report_ZB SET CNAME='" + DB_01 + "', CENAME='" + DB_02 + "', ISHOW='" + DB_03 + "', IPX='" + DB_04 + "', LTIME=GETDATE() WHERE ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox(GridView_Report_ZB_UpdatePanel1, "", "数据更新成功!");

        }

        else
        {

            MessageBox(GridView_Report_ZB_UpdatePanel1, "", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        GridView_Report_ZB.SelectedIndex = -1;

        GridView_Report_ZB.EditIndex = -1;

        Load_GridView_Report_ZB();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_ZB_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "GridView_Report_ZB_ADD")
        {
            if (this.GridView_Report_ZB.Rows.Count > 4)
            {
                MessageBox(GridView_Report_ZB_UpdatePanel1, "", "报表条件暂时最多只能添加5个！<br/>如有特别需要请联系系统管理员。");

                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(GridView_Report_ZB_UpdatePanel1, this.GetType(), "sKey", "$('#GridView_Report_ZB_ADD').modal('show');", true);
            }
        }

    }

    /// <summary>

    /// 模块数据保存

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_ZB_LinkButton1_Click(object sender, EventArgs e)
    {

        /// 中文名

        string DB_01 = this.GridView_Report_ZB_TextBox_CNAME.Text.Trim().Replace("'", "\"");

        /// 英文名

        string DB_02 = this.GridView_Report_ZB_TextBox_CENAME.Text.Trim().Replace("'", "\"");

        /// 显示否

        string DB_03 = this.GridView_Report_ZB_TextBox_ISHOW.Text.Trim().Replace("'", "\"");

        /// 排序

        string DB_04 = this.GridView_Report_ZB_TextBox_IPX.Text.Trim().Replace("'", "\"");

        if (this.GridView_Report_ZB.Rows.Count > 4)
        {
            MessageBox("", "报表条件暂时最多只能添加5个！<br/>如有特别需要请联系系统管理员。");

            return;
        }

        if (!(DB_01.Length > 0))
        {

            MessageBox("", "中文名称不允许为空！<br/>请认真填写。");

            return;

        }

        if (!(DB_02.Length > 0))
        {

            MessageBox("", "英文名称不允许为空！<br/>请认真填写。");

            return;

        }

        string strID = "-1";

        if (GridView_Report.SelectedIndex > -1)
        {
            strID = GridView_Report.SelectedDataKey[0].ToString();
        }

        if (Convert.ToInt32(strID) < 0)
        {
            MessageBox("", "请先选择主表！<br/>请认真填写。");

            return;
        }

        string strSQL;

        strSQL = "Insert into S_Report_ZB ( IREPORTID,CNAME, CENAME, ISHOW, IPX,CTIME,LTIME) VALUES (" + strID + ",'" + DB_01 + "','" + DB_02 + "','" + DB_03 + "','" + DB_04 + "',GETDATE(),GETDATE()) ";

        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox(GridView_Report_ZB_UpdatePanel1, "", "报表条件信息添加成功!", Request.Url.LocalPath);

        }

        else
        {

            MessageBox(GridView_Report_ZB_UpdatePanel1, "", "报表条件信息添加失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }

        Load_GridView_Report_ZB();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Report_ZB_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void GridView_Report_ZB_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string ID = GridView_Report_ZB.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from S_Report_ZB where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox(GridView_Report_ZB_UpdatePanel1, "", "指定数据删除成功^_^！");

            Load_GridView_Report_ZB();

        }

        else
        {

            MessageBox(GridView_Report_ZB_UpdatePanel1, "", "指定数据删除错误。<br/>" + OP_Mode.strErrMsg);

        }

    }

    protected void GridView_Report_ZB_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        GridView_Report_ZB.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_Report_ZB.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_Report_ZB.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

        GridView_Report_ZB.Rows[e.NewSelectedIndex].Cells[4].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion

}