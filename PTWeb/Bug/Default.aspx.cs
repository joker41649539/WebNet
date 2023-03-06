using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bug_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadBugData();
        }
    }

    /// <summary>
    /// 加载列表资料
    /// </summary>
    private void LoadBugData()
    {
        /// 加载待处理
        string strSQL = "Select * from s_Bug where flag=0 order by Urgency desc,CreatDate";
        if (OP_Mode.SQLRUN(strSQL))
        {
            GridView_Bug0.DataSource = OP_Mode.Dtv;
            GridView_Bug0.DataBind();
        }
        ///加载处理完成
        strSQL = "Select Top 100 * from s_Bug where flag=1 order by Urgency desc,CreatDate";
        if (OP_Mode.SQLRUN(strSQL))
        {
            GridView_Bug1.DataSource = OP_Mode.Dtv;
            GridView_Bug1.DataBind();
        }
        ///加载处理中
        strSQL = "Select * from s_Bug where flag=2 order by Urgency desc,CreatDate";
        if (OP_Mode.SQLRUN(strSQL))
        {
            GridView_Bug2.DataSource = OP_Mode.Dtv;
            GridView_Bug2.DataBind();
        }
    }

    /// <summary>
    /// Bug提交按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_Bug_LinkButton1_Click(object sender, EventArgs e)
    {
        string strTitle = string.Empty;
        string strRemark = string.Empty;
        string strMSG = string.Empty;

        strTitle = TextBox_Title.Text.Replace("'", "\"");
        strRemark = TextBox_Remark.Text.Replace("'", "\"");

        if (strTitle.Length <= 0)
        {
            strMSG += "请输入标题信息。<br/>";
        }
        if (strRemark.Length <= 4)
        {
            strMSG += "请仔细输入问题描述信息，5字以上。<br/>";
        }
        if (strMSG.Length > 0)
        {
            MessageBox("", strMSG);
            return;
        }
        else
        {
            InsertBugData(strTitle, strRemark, Convert.ToInt32(RadioButtonList1.SelectedValue));
        }
    }

    /// <summary>
    /// 插入BUG数据
    /// </summary>
    /// <param name="strTitle"></param>
    /// <param name="strRemark"></param>
    /// <param name="iUrgency"></param>
    public void InsertBugData(string strTitle, string strRemark, int iUrgency)
    {
        string strSQL = "Insert into s_bug (Title,Remark,Urgency,CreatUserName) values ('" + strTitle + "','" + strRemark + "'," + iUrgency.ToString() + ",'" + UserNAME + "')";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "Bug提交成功。<br/>请等待技术人员处理。");
            return;
        }
        else
        {
            MessageBox("", "Bug提交失败。<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }
    }

    protected void GridView_Bug0_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string strURL = "/Bug/BugEdit.ASPX?ID=" + GridView_Bug0.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            Response.Redirect(strURL);
        }
    }
    protected void GridView_Bug1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string strURL = "/Bug/BugEdit.ASPX?ID=" + GridView_Bug1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            Response.Redirect(strURL);
        }
    }
    protected void GridView_Bug2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string strURL = "/Bug/BugEdit.ASPX?ID=" + GridView_Bug2.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            Response.Redirect(strURL);
        }
    }
}