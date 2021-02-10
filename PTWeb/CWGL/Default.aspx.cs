using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CWGL_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(43, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有查看报销单的权限。", Defaut_QX_URL);
                return;
            }
            else
            {
                Load_GridView_BXD();
            }
        }
    }

    #region "GridView_BXD 读取报销单 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_BXD()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_BXD.Attributes["SortExpression"];

        string sortDirection = this.GridView_BXD.Attributes["SortDirection"];

        string strSQL;

        string strFlag = Request["flag"];

        if (strFlag != null)
        {
            if (this.GridView_BXD_Label_tj.Text.Length > 0)
            {
                strSQL = "Select W_BXD1.ID,UserName,(Select sum(BXJE) from W_BXD2 where BXDH=W_BXD1.BXDH) ZJE ,FLAG,W_BXD1.LTIME,w_bxd1.BXDH,w_bxd1.remark from w_bxd1,W_BXD2,(SELECT QXID FROM S_QXZZB,S_YH_QXZ WHERE S_YH_QXZ.QXZID=S_QXZZB.QXZID AND USERID=" + DefaultUser + " group by QXID) a WHERE W_BXD1.BXDH=W_BXD2.BXDH and flag=" + Request["flag"] + " and " + this.GridView_BXD_Label_tj.Text.Trim() + " and (a.QXID in(39,40,41,42) or UserName='" + UserNAME + "') GROUP BY  W_BXD1.ID,W_BXD1.BXDH,UserName,FLAG,W_BXD1.LTIME,w_bxd1.remark ORDER BY LTIME DESC";
            }
            else
            {
                strSQL = "Select W_BXD1.ID,UserName,(Select sum(BXJE) from W_BXD2 where BXDH=W_BXD1.BXDH) ZJE,FLAG,W_BXD1.LTIME,w_bxd1.BXDH,w_bxd1.remark from w_bxd1,W_BXD2,(SELECT QXID FROM S_QXZZB,S_YH_QXZ WHERE S_YH_QXZ.QXZID=S_QXZZB.QXZID AND USERID=" + DefaultUser + " group by QXID) a WHERE W_BXD1.BXDH=W_BXD2.BXDH and flag=" + Request["flag"] + " and (a.QXID in(39,40,41,42) or UserName='" + UserNAME + "')  GROUP BY  W_BXD1.ID,W_BXD1.BXDH,UserName,FLAG,W_BXD1.LTIME,w_bxd1.remark ORDER BY LTIME DESC";
            }
        }
        else
        {
            if (this.GridView_BXD_Label_tj.Text.Length > 0)
            {
                strSQL = "Select W_BXD1.ID,UserName,(Select sum(BXJE) from W_BXD2 where BXDH=W_BXD1.BXDH) ZJE,FLAG,W_BXD1.LTIME,w_bxd1.BXDH,w_bxd1.remark from w_bxd1,W_BXD2,(SELECT QXID FROM S_QXZZB,S_YH_QXZ WHERE S_YH_QXZ.QXZID=S_QXZZB.QXZID AND USERID=" + DefaultUser + " group by QXID) a WHERE W_BXD1.BXDH=W_BXD2.BXDH and " + this.GridView_BXD_Label_tj.Text.Trim() + " and flag>0 and (a.QXID in(39,40,41,42) or UserName='" + UserNAME + "')  GROUP BY  W_BXD1.ID,W_BXD1.BXDH,UserName,FLAG,W_BXD1.LTIME,w_bxd1.remark ORDER BY LTIME DESC";
            }
            else
            {
                strSQL = "Select W_BXD1.ID,UserName,(Select sum(BXJE) from W_BXD2 where BXDH=W_BXD1.BXDH) ZJE,FLAG,W_BXD1.LTIME,w_bxd1.BXDH,w_bxd1.remark from w_bxd1,W_BXD2,(SELECT QXID FROM S_QXZZB,S_YH_QXZ WHERE S_YH_QXZ.QXZID=S_QXZZB.QXZID AND USERID=" + DefaultUser + " group by QXID) a WHERE W_BXD1.BXDH=W_BXD2.BXDH and (a.QXID in(39,40,41,42) or UserName='" + UserNAME + "') and flag>0 GROUP BY  W_BXD1.ID,W_BXD1.BXDH,UserName,FLAG,W_BXD1.LTIME,w_bxd1.remark ORDER BY LTIME DESC";
            }
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



            this.GridView_BXD.DataSource = OP_Mode.Dtv;

            this.GridView_BXD.DataBind();

            this.GridView_BXD.BottomPagerRow.Visible = true;

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_BXD_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_BXD.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_BXD.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_BXD.Attributes["SortExpression"] = sortExpression;

        this.GridView_BXD.Attributes["SortDirection"] = sortDirection;

        Load_GridView_BXD();

    }

    protected void GridView_BXD_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView_BXD();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_BXD_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GridView_BXD_ADD")
        {
            Response.Write("<script language='javascript'>window.location='/CWGL/ReimbursementAdd.aspx'</script>");
        }
    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_BXD_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_BXD_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_BXD_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_BXD_Label1.Text.Length > 0)

        {

            this.GridView_BXD_Label1.Text += "<b>并且</b><br />";

            this.GridView_BXD_Label_tj.Text += " and ";

        }

        this.GridView_BXD_Label1.Text += this.GridView_BXD_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_BXD_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_BXD_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_BXD_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_BXD_Label_tj.Text += " " + this.GridView_BXD_DropDownList1.SelectedValue + " " + this.GridView_BXD_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_BXD_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_BXD_Label_tj.Text += " " + this.GridView_BXD_DropDownList1.SelectedValue + " " + this.GridView_BXD_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_BXD_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_BXD_TextBox_CXTJ.Text = string.Empty;

        this.GridView_BXD_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_BXD_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_BXD_TextBox_CXTJ.Text = string.Empty;

        this.GridView_BXD_Label1.Text = string.Empty;

        this.GridView_BXD_Label_tj.Text = string.Empty;

        this.GridView_BXD_alerts_tj.Visible = false;

        Load_GridView_BXD();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_BXD_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView_BXD();

    }

    protected void GridView_BXD_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {
        Response.Write("<script language='javascript'>window.location='/CWGL/ReimbursementAdd.aspx?ID=" + GridView_BXD.DataKeys[e.NewSelectedIndex].Values[0].ToString() + "'</script>");
    }

    #endregion
}