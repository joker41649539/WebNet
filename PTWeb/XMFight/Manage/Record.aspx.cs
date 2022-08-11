using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Manage_Record : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_GridView1();
        }
    }

    #region "GridView1 读取今日消课 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView1()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView1.Attributes["SortExpression"];

        string sortDirection = this.GridView1.Attributes["SortDirection"];

        string strSQL;

        strSQL = "Select XMFight_Class_Record.ID,Name,ICount,XMFight_Class_Record.LTime,XMFight_Class_Record.iFlag from XMFight_Class_Record,XMFight_Student where XMFight_Class_Record.LTime >CONVERT(varchar(100), GETDATE(), 23) and XMFight_Class_Record.StudentID=XMFight_Student.ID order by XMFight_Class_Record.LTime";

        if (OP_Mode.SQLRUN(strSQL))

        {

            this.GridView1.DataSource = OP_Mode.Dtv;

            this.GridView1.DataBind();

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

        if (sortExpression == this.GridView1.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView1.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView1.Attributes["SortExpression"] = sortExpression;

        this.GridView1.Attributes["SortDirection"] = sortDirection;

        Load_GridView1();

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        if (Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value) > 0)
        {
            DeleteRecord(Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value));
        }

        //GridView1.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        //GridView1.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        //GridView1.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

    }

    /// <summary>
    ///  删除指定记录
    /// </summary>
    /// <param name="iID"></param>
    private void DeleteRecord(int iID)
    {
        string strSQL = "Delete from XMFight_Class_Record where ID=" + iID;
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "上课记录删除成功。", "/XMFight/Manage/Record.aspx");
        }
    }


    #endregion
}