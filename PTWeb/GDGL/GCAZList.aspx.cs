using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_GCAZList : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string LoginID;
            LoginID = Request.Cookies["WeChat_Yanwo"]["USERID"].ToString();
        }
        catch
        {
            MessageBox("", "您还未登陆，无权查看该页！<br/>请先登陆！", "/Login.aspx");
            return;
        }


        if (!IsPostBack)
        {
            Load_GridView_List();
        }
    }

    #region "GridView_List 读取工程工单 相关代码"
    /// <summary>

    /// 模块列表读取

    /// </summary>

    private void Load_GridView_List()

    {

        // 获取GridView排序数据列及排序方向

        string sortExpression = this.GridView_List.Attributes["SortExpression"];

        string sortDirection = this.GridView_List.Attributes["SortDirection"];

        string strSQL;
        int iid = 0;
        try
        {
            iid = Convert.ToInt32(Request["ID"]);
        }
        catch
        {
            MessageBox("", "参数错误。", "./");
            return;
        }
        strSQL = "Select distinct W_GCGD2.ID ID,GCMC,AZWZ,SBBH,W_GCGD1.ID IID,AZFS,(SELECT ISNULL(SUM(AZFS),0) YAZ FROM W_GCGD_FS WHERE GCMXID=W_GCGD2.ID) YAZ from W_GCGD1,W_GCGD2,W_GCGD_USERS where azwz =(Select AZWZ from W_GCGD2 where W_GCGD2.ID=" + iid + ") and W_GCGD1.GCDH = (Select GCDH from W_GCGD2 where W_GCGD2.ID=" + iid + ") and W_GCGD2.GCDH=W_GCGD1.GCDH and W_GCGD1.ID=GCDID and USERS=" + DefaultUser + " order by SBBH";

        if (OP_Mode.SQLRUN(strSQL))

        {

            /// 设置排序

            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))

            {

                OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression, sortDirection);

            }
            /// 设置翻页层始终显示
            if (OP_Mode.Dtv.Count > 0)

            {

                Label_GCMC.Text = OP_Mode.Dtv[0]["GCMC"].ToString();
                Label_GCMC.NavigateUrl = "/GDGL/MyGDAZWZ.aspx?ID=" + OP_Mode.Dtv[0]["IID"].ToString();
                Label_AZWZ.Text = OP_Mode.Dtv[0]["AZWZ"].ToString();

            }



            this.GridView_List.DataSource = OP_Mode.Dtv;

            this.GridView_List.DataBind();

        }

        else

        {

            MessageBox("", strSQL + "<br/>" + OP_Mode.strErrMsg);

            return;

        }

    }

    protected void GridView_List_Sorting(object sender, GridViewSortEventArgs e)

    {

        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_List.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_List.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_List.Attributes["SortExpression"] = sortExpression;

        this.GridView_List.Attributes["SortDirection"] = sortDirection;

        Load_GridView_List();

    }

    protected void GridView_List_RowEditing(object sender, GridViewEditEventArgs e)

    {

        GridView_List.EditIndex = e.NewEditIndex;

        //GridView_List.EditRowStyle.BackColor = Color.FromName("#CAD3E4");

        Load_GridView_List();

    }

    protected void GridView_List_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

    {

        GridView_List.SelectedIndex = -1;

        GridView_List.EditIndex = -1;

        Load_GridView_List();

    }

    protected void GridView_List_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {

    }

    /// <summary>

    /// 

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_List_RowDataBound(object sender, GridViewRowEventArgs e)

    {

        //如果是绑定数据行 

        //if (e.Row.RowType == DataControlRowType.DataRow)

        //{

        //    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)

        //    {

        //        ((LinkButton)e.Row.Cells[4].Controls[3]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[0].Text + "\" 】吗?')");

        //    }

        //}

    }

    /// <summary>

    /// 模块删除

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_List_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {


    }

    protected void GridView_List_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {
        string strURL = "/GDGL/GCAZ.ASPX?ID=" + GridView_List.DataKeys[e.NewSelectedIndex].Value.ToString();
        Response.Redirect(strURL);
        //GridView_List.Rows[e.NewSelectedIndex].Cells[0].BackColor = Color.FromName("#CAD3E4");

        //GridView_List.Rows[e.NewSelectedIndex].Cells[1].BackColor = Color.FromName("#CAD3E4");

        //GridView_List.Rows[e.NewSelectedIndex].Cells[2].BackColor = Color.FromName("#CAD3E4");

    }

    #endregion
}