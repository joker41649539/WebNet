using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JYJG_Course : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefaultData();
            Load_GridView_KC();
        }
    }

    /// <summary>
    /// 读取默认机构
    /// </summary>
    private void LoadDefaultData()
    {
        string strSQL = "SELECT S_JG.ID,S_JG.JGJC FROM S_USERINFO LEFT JOIN S_JG ON SSDW=S_JG.ID WHERE S_USERINFO.ID=" + DefaultUser;

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                if (OP_Mode.Dtv[0][0].ToString().Length == 0 || OP_Mode.Dtv[0][1].ToString().Length == 0)
                {
                    MessageBox("", "您未设置默认机构，请设置默认机构后再添加课程。", "/Sys/MyUserInfo.aspx");
                }
                else
                {
                    Label_JGJC.Text = OP_Mode.Dtv[0][1].ToString();
                    Label_JGID.Text = OP_Mode.Dtv[0][0].ToString();
                }
            }
        }
    }

    /// <summary>
    /// 保存信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_JG_LinkButton1_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        string strKCMC = TextBox_KCMC.Text.Replace("'", "\"");
        string strLJKS = TextBox_LJKS.Text.Replace("'", "\"");
        string strKCJJ = TextBox_KCJJ.Text.Replace("'", "\"");

        int iJGID = Convert.ToInt32(Label_JGID.Text);

        if (strKCMC.Length == 0)
        {
            MessageBox("", "课程名称必须填写，请重新填写。");
            return;
        }

        if (strKCJJ.Length == 6)
        {
            MessageBox("", "课程简介必须填写，请重新填写。");
            return;
        }


        strSQL = " DECLARE @Count int ";
        strSQL += " Select @Count = Count(ID) from S_KC Where JGID=" + iJGID.ToString() + " And KCMC='" + strKCMC + "'";
        strSQL += " If @count = 0 ";
        strSQL += " Begin";
        strSQL += "     Insert into S_KC (JGID,KCMC,LJKS,KCJJ) values (" + iJGID.ToString() + ",'" + strKCMC + "'," + strLJKS + ",'" + strKCJJ + "') ";
        strSQL += "     Select * from S_KC Where JGID=" + iJGID.ToString() + " And KCMC='" + strKCMC + "'";
        strSQL += " End ";


        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                MessageBox("恭 喜", "课程添加成功，随后能可以去设置该课程的班了。");
                return;
            }
            else
            {
                MessageBox("错 误", "课程添加失败,该机构已经存在该名称的课程。<br/>请重试。");
                return;
            }
        }
        else
        {
            MessageBox("错 误", "课程添加失败。<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }
    }

    #region "GridView_KC 读取开设课程 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_KC()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_KC.Attributes["SortExpression"];

        string sortDirection = this.GridView_KC.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_KC_Label_tj.Text.Length > 0)

        {

            strSQL = "SELECT S_KC.ID,JGJC,KCMC,LJKS,0 BJ,S_JG.FLAG FROM S_KC,S_JG Where " + this.GridView_KC_Label_tj.Text.Trim() + " and JGID=S_JG.ID AND S_KC.DEL=0 ORDER BY ID";

        }

        else

        {

            strSQL = "SELECT S_KC.ID,JGJC,KCMC,LJKS,0 BJ,S_JG.FLAG FROM S_KC,S_JG WHERE JGID=S_JG.ID AND S_KC.DEL=0 ORDER BY S_KC.LTIME DESC";

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



            this.GridView_KC.DataSource = OP_Mode.Dtv;

            this.GridView_KC.DataBind();

            this.GridView_KC.BottomPagerRow.Visible = true;

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_KC_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_KC.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_KC.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_KC.Attributes["SortExpression"] = sortExpression;

        this.GridView_KC.Attributes["SortDirection"] = sortDirection;

        Load_GridView_KC();

    }

    protected void GridView_KC_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_KC();

    }

    protected void GridView_KC_RowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView_KC.EditIndex = e.NewEditIndex;

        //GridView_KC.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_KC();

    }

    protected void GridView_KC_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        GridView_KC.SelectedIndex = -1;

        GridView_KC.EditIndex = -1;

        Load_GridView_KC();

    }

    protected void GridView_KC_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

        //string ID = GridView_KC.DataKeys[e.RowIndex].Values[0].ToString();

        ///// 模块名称

        //string DB_01 = ((TextBox)GridView_KC.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Replace("'", "\"");

        //string DB_02 = ((TextBox)GridView_KC.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Replace("'", "\"");

        //string DB_03 = ((TextBox)GridView_KC.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Replace("'", "\"");

        //string DB_04 = ((TextBox)GridView_KC.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Replace("'", "\"");

        //string DB_05 = ((TextBox)GridView_KC.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Replace("'", "\"");

        //if (!(DB_01.Length > 0))

        //{

        //    MessageBox("", "机构名称不允许为空！<br/>请认真填写。");

        //    return;

        //}

        //string strSQL = string.Empty;

        //strSQL = "Update S_KC SET JGJC='" + DB_01 + "', KCMC='" + DB_02 + "', LJKS='" + DB_03 + "', BJ='" + DB_04 + "', FLAG='" + DB_05 + "', LTIME=GETDATE() WHERE ID=" + ID;

        //if (OP_Mode.SQLRUN(strSQL))

        //{

        //    MessageBox("", "数据更新成功!");

        //}

        //else

        //{

        //    MessageBox("", "数据更新失败！<br/>错误：" + OP_Mode.strErrMsg);

        //    return;

        //}

        //GridView_KC.SelectedIndex = -1;

        //GridView_KC.EditIndex = -1;

        //Load_GridView_KC();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_KC_RowDataBound(object sender, GridViewRowEventArgs e)

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

    protected void GridView_KC_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {

        string ID = GridView_KC.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Update S_KC set Del=1,LTime=getdate() where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))

        {

            MessageBox("", "指定数据删除成功^_^！");

            Load_GridView_KC();

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

    protected void GridView_KC_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_KC_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_KC_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_KC_Label1.Text.Length > 0)

        {

            this.GridView_KC_Label1.Text += "<b>并且</b><br />";

            this.GridView_KC_Label_tj.Text += " and ";

        }

        this.GridView_KC_Label1.Text += this.GridView_KC_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_KC_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_KC_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_KC_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_KC_Label_tj.Text += " " + this.GridView_KC_DropDownList1.SelectedValue + " " + this.GridView_KC_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_KC_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_KC_Label_tj.Text += " " + this.GridView_KC_DropDownList1.SelectedValue + " " + this.GridView_KC_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_KC_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_KC_TextBox_CXTJ.Text = string.Empty;

        this.GridView_KC_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_KC_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_KC_TextBox_CXTJ.Text = string.Empty;

        this.GridView_KC_Label1.Text = string.Empty;

        this.GridView_KC_Label_tj.Text = string.Empty;

        this.GridView_KC_alerts_tj.Visible = false;

        Load_GridView_KC();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_KC_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_KC();

    }

    protected void GridView_KC_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        GridView_KC.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_KC.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_KC.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_KC.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

        GridView_KC.Rows[e.NewSelectedIndex].Cells[4].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}