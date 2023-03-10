using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BCTL_GameData : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!QXBool(18, Convert.ToInt32(DefaultUser)))
        {
            MessageBox("", "您没有查看的权限。", Defaut_QX_URL);
            return;
        }
        Load_GridView_Game();
    }
    #region "GridView_Game 读取游戏数据 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_Game()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_Game.Attributes["SortExpression"];

        string sortDirection = this.GridView_Game.Attributes["SortDirection"];

        string strSQL;

        string strName = HttpUtility.UrlDecode(Request.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CNAME], Encoding.GetEncoding("UTF-8"));

        if (strName == "joker")
        {
            strSQL = "Select * from BBGameData where id in (SELECT max(ID) FROM BBGameData group by JQName) and ys>0 order by jqname";
        }
        else
        {
            strSQL = "Select * from BBGameData where id in (SELECT max(ID) FROM BBGameData where JQNAME LIKE '" + strName + "%' group by JQName) and ys>0 order by jqname";
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



            this.GridView_Game.DataSource = OP_Mode.Dtv;

            this.GridView_Game.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_Game_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_Game.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_Game.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_Game.Attributes["SortExpression"] = sortExpression;

        this.GridView_Game.Attributes["SortDirection"] = sortDirection;

        Load_GridView_Game();

    }

    protected void GridView_Game_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_Game();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Game_TJADD_Click(object sender, EventArgs e)

    {

        //string strDiv = string.Empty;

        //if (this.GridView_Game_TextBox_CXTJ.Text.Length == 0)

        //{

        //    this.GridView_Game_TextBox_CXTJ.Text = "空";

        //}

        //if (this.GridView_Game_Label1.Text.Length > 0)

        //{

        //    this.GridView_Game_Label1.Text += "<b>并且</b><br />";

        //    this.GridView_Game_Label_tj.Text += " and ";

        //}

        //this.GridView_Game_Label1.Text += this.GridView_Game_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_Game_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_Game_TextBox_CXTJ.Text + "&nbsp;";

        //if (this.GridView_Game_DropDownList_SF.SelectedValue == "LIKE")

        //{

        //    this.GridView_Game_Label_tj.Text += " " + this.GridView_Game_DropDownList1.SelectedValue + " " + this.GridView_Game_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_Game_TextBox_CXTJ.Text.Trim() + "%'";

        //}

        //else

        //{

        //    this.GridView_Game_Label_tj.Text += " " + this.GridView_Game_DropDownList1.SelectedValue + " " + this.GridView_Game_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_Game_TextBox_CXTJ.Text.Trim() + "'";

        //}

        //this.GridView_Game_TextBox_CXTJ.Text = string.Empty;

        //this.GridView_Game_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Game_LinkButton3_Click(object sender, EventArgs e)

    {

        //this.GridView_Game_TextBox_CXTJ.Text = string.Empty;

        //this.GridView_Game_Label1.Text = string.Empty;

        //this.GridView_Game_Label_tj.Text = string.Empty;

        //this.GridView_Game_alerts_tj.Visible = false;

        //Load_GridView_Game();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_Game_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_Game();

    }

    protected void GridView_Game_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_Game.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_Game.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        GridView_Game.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        GridView_Game.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

        GridView_Game.Rows[e.NewSelectedIndex].Cells[4].BackColor = Color.FromName("#CAD3E4");

        GridView_Game.Rows[e.NewSelectedIndex].Cells[5].BackColor = Color.FromName("#CAD3E4");

        GridView_Game.Rows[e.NewSelectedIndex].Cells[6].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}