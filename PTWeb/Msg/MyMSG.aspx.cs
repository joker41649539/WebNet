using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Msg_MyMSG : PageBase
{
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_GridView_MSG();
            Load_GridView_FXX();
        }
    }

    /// <summary>
    /// 保存消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_JG_LinkButton1_Click(object sender, EventArgs e)
    {
        SaveMSG();
    }

    /// <summary>
    /// 保存信息
    /// </summary>
    private void SaveMSG()
    {
        string strSQL = string.Empty;
        string strTitle = TextBox_Title.Text.Replace("'", "\"");
        string strContent = TextBox_Content.Text.Replace("'", "\"");

        if (strTitle.Length == 0)
        {
            MessageBox("", "信息标题必须填写，请认真填写。");
            return;
        }
        if (strContent.Length == 0)
        {
            MessageBox("", "信息内容必须填写，请认真填写。");
            return;
        }

        if (CheckBox_AllMsg.Checked)
        {
            strSQL = " DECLARE @TNO int "; //
            strSQL += " Insert Into S_MSG (cTitle,cContent,iUserID) Values ('" + strTitle + "','" + strContent + "'," + DefaultUser + ") ";
            strSQL += " SET @TNO = @@IDENTITY  "; ///获得刚刚插入数据的ID号
            strSQL += " Insert Into S_MSG_YD (iMSGID,iSendID,iUserID,iYD) Select @TNO,ID," + DefaultUser + ",0 from S_USERINFO where FLAG=0 and id<>" + DefaultUser + ""; /// 循环插入所有用户的信息数据
        }
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "信息发送成功。", "/MSG/MyMSG.aspx");
        }
        else
        {
            MessageBox("", "信息发送失败。<br>错误：" + OP_Mode.strErrMsg);
        }

    }

    #region "GridView_MSG 读取消息 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_MSG()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_MSG.Attributes["SortExpression"];

        string sortDirection = this.GridView_MSG.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_MSG_Label_tj.Text.Length > 0)

        {

            strSQL = "SELECT S_MSG.ID,CTITLE,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=S_MSG.ID AND IYD=1) YYD,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=S_MSG.ID) ZYD, CNAME, S_MSG.CTime FROM S_MSG,S_MSG_YD,S_USERINFO WHERE S_MSG.ID = IMSGID AND S_MSG_YD.ISENDID =" + DefaultUser + " AND S_USERINFO.ID = S_MSG.IUSERID and " + this.GridView_MSG_Label_tj.Text.Trim() + " order by S_MSG.CTime";

        }

        else

        {

            strSQL = "SELECT S_MSG.ID,CTITLE,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=S_MSG.ID AND IYD=1) YYD,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=S_MSG.ID) ZYD, CNAME, S_MSG.CTime FROM S_MSG,S_MSG_YD,S_USERINFO WHERE S_MSG.ID = IMSGID AND S_MSG_YD.ISENDID =" + DefaultUser + " AND S_USERINFO.ID = S_MSG.IUSERID order by S_MSG.CTime";

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



            this.GridView_MSG.DataSource = OP_Mode.Dtv;

            this.GridView_MSG.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_MSG_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_MSG.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_MSG.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_MSG.Attributes["SortExpression"] = sortExpression;

        this.GridView_MSG.Attributes["SortDirection"] = sortDirection;

        Load_GridView_MSG();

    }

    protected void GridView_MSG_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_MSG();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_MSG_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_MSG_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_MSG_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_MSG_Label1.Text.Length > 0)

        {

            this.GridView_MSG_Label1.Text += "<b>并且</b><br />";

            this.GridView_MSG_Label_tj.Text += " and ";

        }

        this.GridView_MSG_Label1.Text += this.GridView_MSG_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_MSG_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_MSG_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_MSG_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_MSG_Label_tj.Text += " " + this.GridView_MSG_DropDownList1.SelectedValue + " " + this.GridView_MSG_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_MSG_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_MSG_Label_tj.Text += " " + this.GridView_MSG_DropDownList1.SelectedValue + " " + this.GridView_MSG_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_MSG_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_MSG_TextBox_CXTJ.Text = string.Empty;

        this.GridView_MSG_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_MSG_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_MSG_TextBox_CXTJ.Text = string.Empty;

        this.GridView_MSG_Label1.Text = string.Empty;

        this.GridView_MSG_Label_tj.Text = string.Empty;

        this.GridView_MSG_alerts_tj.Visible = false;

        Load_GridView_MSG();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_MSG_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_MSG();

    }

    protected void GridView_MSG_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_MSG.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_MSG.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_MSG.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");
        GridView_MSG.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion


    #region "GridView_FXX 读取已发出的消息 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_FXX()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_FXX.Attributes["SortExpression"];

        string sortDirection = this.GridView_FXX.Attributes["SortDirection"];

        string strSQL;

        if (this.GridView_FXX_Label_tj.Text.Length > 0)
        {
            strSQL = "SELECT distinct S_MSG.ID,CTITLE,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=S_MSG.ID AND IYD=1) YYD,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=S_MSG.ID) ZYD, CNAME, S_MSG.CTime FROM S_MSG,S_MSG_YD,S_USERINFO WHERE S_MSG.ID = IMSGID AND S_MSG_YD.IUSERID =" + DefaultUser + " AND S_USERINFO.ID = S_MSG.IUSERID and " + this.GridView_FXX_Label_tj.Text.Trim() + " order by S_MSG.CTime";
        }
        else

        {

            strSQL = "SELECT distinct S_MSG.ID,CTITLE,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=S_MSG.ID AND IYD=1) YYD,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=S_MSG.ID) ZYD, CNAME, S_MSG.CTime FROM S_MSG,S_MSG_YD,S_USERINFO WHERE S_MSG.ID = IMSGID AND S_MSG_YD.IUSERID =" + DefaultUser + " AND S_USERINFO.ID = S_MSG.IUSERID order by S_MSG.CTime";

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



            this.GridView_FXX.DataSource = OP_Mode.Dtv;

            this.GridView_FXX.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_FXX_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_FXX.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_FXX.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_FXX.Attributes["SortExpression"] = sortExpression;

        this.GridView_FXX.Attributes["SortDirection"] = sortDirection;

        Load_GridView_FXX();

    }

    protected void GridView_FXX_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_FXX();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_FXX_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_FXX_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_FXX_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_FXX_Label1.Text.Length > 0)

        {

            this.GridView_FXX_Label1.Text += "<b>并且</b><br />";

            this.GridView_FXX_Label_tj.Text += " and ";

        }

        this.GridView_FXX_Label1.Text += this.GridView_FXX_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_FXX_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_FXX_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_FXX_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_FXX_Label_tj.Text += " " + this.GridView_FXX_DropDownList1.SelectedValue + " " + this.GridView_FXX_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_FXX_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_FXX_Label_tj.Text += " " + this.GridView_FXX_DropDownList1.SelectedValue + " " + this.GridView_FXX_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_FXX_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_FXX_TextBox_CXTJ.Text = string.Empty;

        this.GridView_FXX_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_FXX_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_FXX_TextBox_CXTJ.Text = string.Empty;

        this.GridView_FXX_Label1.Text = string.Empty;

        this.GridView_FXX_Label_tj.Text = string.Empty;

        this.GridView_FXX_alerts_tj.Visible = false;

        Load_GridView_FXX();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_FXX_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_FXX();

    }

    protected void GridView_FXX_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_FXX.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_FXX.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_FXX.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_FXX.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}