using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partner_Default : PageBase
{
    public string strSQL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!QXBool(52, Convert.ToInt32(DefaultUser)))
        {
            MessageBox("", "您没有查看协同人员的权限。", Defaut_QX_URL);
            return;
        }
        else
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
    }

    private void LoadData()
    {// flag=2 待审核  3 审核过 停用 ， 4 启用

        // 获取GridView排序数据列及排序方向

        string sortExpression2 = this.GridView_Partner2.Attributes["SortExpression"];

        string sortDirection2 = this.GridView_Partner2.Attributes["SortDirection"];
        string sortExpression3 = this.GridView_Partner3.Attributes["SortExpression"];

        string sortDirection3 = this.GridView_Partner3.Attributes["SortDirection"];
        string sortExpression4 = this.GridView_Partner4.Attributes["SortExpression"];

        string sortDirection4 = this.GridView_Partner4.Attributes["SortDirection"];
        string strTempSQL = "(Select tagname+'; '+stytle+'; ' from w_tag_user,w_tags where tagid=w_tags.id and userid=S_USERINFO.ID FOR XML PATH('')) Tags";

        strSQL = "Select *," + strTempSQL + " from s_UserInfo where flag=2 order by SSDW";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {//加载待审核
                /// 设置排序
                if ((!string.IsNullOrEmpty(sortExpression2)) && (!string.IsNullOrEmpty(sortDirection2)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression2, sortDirection2);
                }
                GridView_Partner2.DataSource = OP_Mode.Dtv;
                GridView_Partner2.DataBind();
            }
        }

        strSQL = "Select *," + strTempSQL + " from s_UserInfo where flag=3 order by SSDW";
        if (OP_Mode.SQLRUN(strSQL))
        {//加载审核完成
            if (OP_Mode.Dtv.Count > 0)
            {
                if ((!string.IsNullOrEmpty(sortExpression3)) && (!string.IsNullOrEmpty(sortDirection3)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression3, sortDirection3);
                }
                GridView_Partner3.DataSource = OP_Mode.Dtv;
                GridView_Partner3.DataBind();
            }
        }
        strSQL = "Select *," + strTempSQL + " from s_UserInfo where flag=4 order by SSDW";
        if (OP_Mode.SQLRUN(strSQL))
        {//加载审核完成
            if (OP_Mode.Dtv.Count > 0)
            {
                if ((!string.IsNullOrEmpty(sortExpression4)) && (!string.IsNullOrEmpty(sortDirection4)))
                {
                    OP_Mode.Dtv.Sort = string.Format("{0} {1}", sortExpression4, sortDirection4);
                }
                GridView_Partner4.DataSource = OP_Mode.Dtv;
                GridView_Partner4.DataBind();
            }
        }
    }

    protected void GridView_Partner3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridView_Partner2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID = GridView_Partner2.DataKeys[e.RowIndex].Values[0].ToString();

        string strSQL = "Delete from S_Userinfo where ID=" + ID;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "指定人员数据删除成功^_^！", "/Partner/");
        }
        else
        {
            MessageBox("", "指定数据删除错误。<br/>" + OP_Mode.strErrMsg);
        }
    }


    protected void GridView_Partner3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //((LinkButton)e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：【\"" + e.Row.Cells[1].Text + "\" 】吗?')");
    }

    protected void GridView_Partner3_DataBinding(object sender, EventArgs e)
    {

    }
    public string ToHtml(string str)
    {
        //不能用; Danger; 马虎; Danger; 仔细; Success;
        string[] sTemp = str.Split(';');
        string rVlaue = string.Empty;

        for (int i = 0; i < sTemp.Length - 2; i = i + 2)
        {
            rVlaue += "<span class=\"label label-" + sTemp[i + 1].Trim() + "\">" + sTemp[i].Trim() + "</span>&nbsp;";
        }
        return rVlaue;
    }


    protected void GridView_Partner4_Sorting(object sender, GridViewSortEventArgs e)
    {
        // 从事件参数获取排序数据列

        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_Partner4.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_Partner4.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_Partner4.Attributes["SortExpression"] = sortExpression;

        this.GridView_Partner4.Attributes["SortDirection"] = sortDirection;

        LoadData();
    }

    protected void GridView_Partner2_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_Partner2.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_Partner2.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_Partner2.Attributes["SortExpression"] = sortExpression;

        this.GridView_Partner2.Attributes["SortDirection"] = sortDirection;

        LoadData();
    }

    protected void GridView_Partner3_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression.ToString();

        // 假定为排序方向为“顺序”

        string sortDirection = "ASC";

        // “ASC”与事件参数获取到的排序方向进行比较，进行GridView排序方向参数的修改

        if (sortExpression == this.GridView_Partner3.Attributes["SortExpression"])

        {

            //获得下一次的排序状态

            sortDirection = (this.GridView_Partner3.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");

        }

        // 重新设定GridView排序数据列及排序方向

        this.GridView_Partner3.Attributes["SortExpression"] = sortExpression;

        this.GridView_Partner3.Attributes["SortDirection"] = sortDirection;

        LoadData();
    }
}