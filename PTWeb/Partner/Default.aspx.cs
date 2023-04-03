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
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {// flag=2 待审核  3 审核过 停用 ， 4 启用

        strSQL = "Select * from s_UserInfo where flag=2";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {//加载待审核
                GridView_Partner2.DataSource = OP_Mode.Dtv;
                GridView_Partner2.DataBind();
            }
        }

        strSQL = "Select * from s_UserInfo where flag=3";
        if (OP_Mode.SQLRUN(strSQL))
        {//加载审核完成
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView_Partner3.DataSource = OP_Mode.Dtv;
                GridView_Partner3.DataBind();
            }
        }
        strSQL = "Select * from s_UserInfo where flag=4";
        if (OP_Mode.SQLRUN(strSQL))
        {//加载审核完成
            if (OP_Mode.Dtv.Count > 0)
            {
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
}