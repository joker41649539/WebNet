using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Msg_MSGYD : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_GridView_YD();
            Load_GridView_YYD();
        }
    }

    #region "GridView_YD 读取未阅读 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_YD()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_YD.Attributes["SortExpression"];

        string sortDirection = this.GridView_YD.Attributes["SortDirection"];

        try
        {
            if (Convert.ToInt32(Request["ID"]) > 0)
            {
                int TID = Convert.ToInt32(Request["ID"]);
                string strSQL = string.Empty;

                strSQL = "SELECT S_MSG_YD.ID,CNAME,S_MSG_YD.LTime FROM S_MSG_YD,S_USERINFO WHERE IMSGID=" + TID + " AND IYD=0 and S_USERINFO.ID=iSendID ORDER BY S_MSG_YD.LTime";
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



                    this.GridView_YD.DataSource = OP_Mode.Dtv;

                    this.GridView_YD.DataBind();

                }

                else

                {

                    MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

                    return;

                }
            }
        }
        catch
        {

        }
    }

    protected void GridView_YD_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_YD.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_YD.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_YD.Attributes["SortExpression"] = sortExpression;

        this.GridView_YD.Attributes["SortDirection"] = sortDirection;

        Load_GridView_YD();

    }

    protected void GridView_YD_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_YD.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_YD.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion

    #region "GridView_YD 读取未阅读 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_YYD()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_YD.Attributes["SortExpression"];

        string sortDirection = this.GridView_YD.Attributes["SortDirection"];

        try
        {
            if (Convert.ToInt32(Request["ID"]) > 0)
            {
                int TID = Convert.ToInt32(Request["ID"]);
                string strSQL = string.Empty;

                strSQL = "SELECT S_MSG_YD.ID,CNAME,S_MSG_YD.LTime FROM S_MSG_YD,S_USERINFO WHERE IMSGID=" + TID + " AND IYD=1 and S_USERINFO.ID=iSendID ORDER BY S_MSG_YD.LTime";
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



                    this.GridView_YYD.DataSource = OP_Mode.Dtv;

                    this.GridView_YYD.DataBind();

                }

                else

                {

                    MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

                    return;

                }
            }
        }
        catch
        {

        }
    }

    protected void GridView_YYD_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_YD.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_YD.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_YD.Attributes["SortExpression"] = sortExpression;

        this.GridView_YD.Attributes["SortDirection"] = sortDirection;

        Load_GridView_YYD();

    }

    protected void GridView_YYD_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        GridView_YD.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        GridView_YD.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion

}