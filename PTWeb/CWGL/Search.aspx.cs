using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CWGL_Search : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!QXBool(44, Convert.ToInt32(DefaultUser)))
        {
            MessageBox("", "您没有搜索报销单的权限。", Defaut_QX_URL);
            return;
        }

    }

    #region "GridView1 读取报销单查询 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView1()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_BX.Attributes["SortExpression"];

        string sortDirection = this.GridView_BX.Attributes["SortDirection"];

        string strSQL;
        strSQL = "Select w_bxd1.id,username,W_BXD1.bxdh,Occurrence,KZXM,W_BXD1.Remark SY,flag,FLAG,W_BXD2.BREAKFIRST,ZCBZ,WCBZ,ZSBZ,DRZS,TXR,MC,BECITY,ARRIVAL,BXJE,W_BXD2.REMARK,IMAGE from W_BXD1,W_BXD2 where w_bxd1.bxdh=w_bxd2.bxdh and flag>0 ";

        if (this.GridView1_Label_tj.Text.Length > 0)
        {
            strSQL += " And " + this.GridView1_Label_tj.Text.Trim();
        }

        string strCheckBox = GetChecked(CheckBoxList1);

        if (strCheckBox.Length > 0)
        {// 添加复选框条线
            strSQL += " and  KZXM in (" + strCheckBox + ") ";
        }

        /// 增加排序条件
        strSQL += " Order By username,Occurrence desc";

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



            this.GridView_BX.DataSource = OP_Mode.Dtv;

            this.GridView_BX.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_BX.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_BX.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_BX.Attributes["SortExpression"] = sortExpression;

        this.GridView_BX.Attributes["SortDirection"] = sortDirection;

        Load_GridView1();

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)

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

        Load_GridView1();

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        ////如果是绑定数据行 

        //if (e.Row.RowType == DataControlRowType.DataRow)

        //{

        //    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

        //    {

        //        ((LinkButton)e.Row.Cells[5].Controls[1]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】吗?')");

        //    }

        //}

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {


    }
    public static string GetChecked(CheckBoxList checklist)
    {
        string result = "";
        for (int i = 0; i < checklist.Items.Count; i++)
        {
            if (checklist.Items[i].Selected)
            {
                result += "'" + checklist.Items[i].Value.Trim() + "',";
            }
        }
        if (result.Length > 0)
        {
            result = result.Substring(0, result.Length - 1); // 去掉最后一个 ‘，’ 号
        }
        return result;
    }
    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_TJADD_Click(object sender, EventArgs e)

    {
        //MessageBox("", GetChecked(CheckBoxList1));
        //return;


        string strDiv = string.Empty;

        if (this.GridView1_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView1_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView1_Label1.Text.Length > 0)

        {

            this.GridView1_Label1.Text += "<b>并且</b><br />";

            this.GridView1_Label_tj.Text += " and ";

        }

        this.GridView1_Label1.Text += this.GridView1_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView1_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView1_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView1_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView1_Label_tj.Text += " " + this.GridView1_DropDownList1.SelectedValue + " " + this.GridView1_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView1_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView1_Label_tj.Text += " " + this.GridView1_DropDownList1.SelectedValue + " " + this.GridView1_DropDownList_SF.SelectedValue + " " + "'" + this.GridView1_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView1_TextBox_CXTJ.Text = string.Empty;

        this.GridView1_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView1_TextBox_CXTJ.Text = string.Empty;

        this.GridView1_Label1.Text = string.Empty;

        this.GridView1_Label_tj.Text = string.Empty;

        this.GridView1_alerts_tj.Visible = false;

        Load_GridView1();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView1_LinkButton4_Click(object sender, EventArgs e)

    {

        Load_GridView1();

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //MessageBox("", "[" + GridView1.DataKeys[e.NewSelectedIndex].Value.ToString() + "]");

        Response.Write("<script language='javascript'>window.location='/CWGL/ReimbursementAdd.aspx?ID=" + GridView_BX.DataKeys[e.NewSelectedIndex].Value.ToString() + "'</script>"); ;

        //GridView1.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        //GridView1.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        //GridView1.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

        //GridView1.Rows[e.NewSelectedIndex].Cells[3].BackColor = Color.FromName("#CAD3E4");

    }
    #endregion

    //Excel文件名称
    string ExcelName = System.DateTime.Now.ToString("yyMMdd") + "退款结算单.xlsx";


    private void ExportGridView(GridView GV)
    {
        /**
         * 如果打印全部数据，则加上注视的代码
         * */
        //GVExport.AllowPaging = false;
        //GVExport.AllowSorting = false;
        //GVExport.DataSource = null;
        //GVExport.DataBind();
        DateTime dt = DateTime.Now;
        Response.ClearContent();
        Response.Buffer = true;
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        string filename = "XX_" + dt.ToString("yyyyMMddHHmm") + ".xls";
        string[] browsers = { "Firefox", "AppleMAC-Safari", "Opera" }; //针对FF、Safari、Opera 设置编码
        string browser = Request.Browser.Browser;
        string attachment = string.Empty;
        if (Array.IndexOf<string>(browsers, browser) != -1)
        {
            attachment = "attachment; filename=" + filename;
        }
        else
        {
            attachment = "attachment; filename=" + Server.UrlEncode(filename);
        }
        Response.AddHeader("content-disposition", attachment);
        Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GV.RenderControl(htw);


        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void GridView1_DC_Click(object sender, EventArgs e)
    {
        Response.ClearContent(); Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        this.GridView_BX.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
        // ExportGridView(this.GridView1);
    }
}