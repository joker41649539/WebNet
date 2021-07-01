using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RememberAdd : PageBaseRem
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LinkButton_Del.Visible = false;
                int iid = Convert.ToInt32(Request["id"]);
                if (iid > 0)
                {
                    LoadData(iid);
                    LinkButton_Del.Visible = true;

                    int iFlag = Convert.ToInt32(Request["flag"]);
                    if (iFlag == 1)
                    {/// 记忆完成
                        FinshRemember(iid);
                    }
                    else if (iFlag == -1)
                    {/// 非常熟了
                        OverRemember(iid);
                    }
                }
            }
            catch
            {
                MessageBox("", "参数错误，请勿非法操作!", "/Remember/Remember.aspx");
                return;
            }
        }
    }

    /// <summary>
    /// 完成记忆
    /// </summary>
    /// <param name="IID"></param>
    private void FinshRemember(int IID)
    {
        string strSQL = " Update Remember set NextTime='" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "',lTime=getdate(),ICount=ICount+1 where NextTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and ICount=0 and ID=" + IID + " ";
        strSQL += " Update Remember set NextTime='" + System.DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") + "',lTime=getdate(),ICount=ICount+1 where NextTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and ICount=1 and ID=" + IID + "  ";
        strSQL += " Update Remember set NextTime='" + System.DateTime.Now.AddDays(4).ToString("yyyy-MM-dd") + "',lTime=getdate(),ICount=ICount+1 where NextTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and ICount=2 and ID=" + IID + "  ";
        strSQL += " Update Remember set NextTime='" + System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd") + "',lTime=getdate(),ICount=ICount+1 where NextTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and ICount=3 and ID=" + IID + "  ";
        strSQL += " Update Remember set NextTime='" + System.DateTime.Now.AddDays(15).ToString("yyyy-MM-dd") + "',lTime=getdate(),ICount=ICount+1 where NextTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and ICount>=4 and ID=" + IID + "  ";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "操作完成!", "/Remember/Remember.aspx");
            return;
        }
        else
        {
            MessageBox("", "错误：" + OP_Mode.strErrMsg + "<br/>请重试。", "/Remember/Remember.aspx");
            return;
        }
    }
    /// <summary>
    /// 非常熟了
    /// </summary>
    /// <param name="IID"></param>
    private void OverRemember(int IID)
    {
        string strSQL = "";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "操作完成!", "/Remember/Remember.aspx");
            return;
        }
        else
        {
            MessageBox("", "错误：" + OP_Mode.strErrMsg + "<br/>请重试。", "/Remember/Remember.aspx");
            return;
        }
    }

    /// <summary>
    /// 依据ID 读取信息。
    /// </summary>
    /// <param name="IID"></param>
    private void LoadData(int IID)
    {
        string strSQL = " Select * from Remember Where iUserID=" + DefaultUser + " and ID=" + IID.ToString();

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView_Remember_TextBox_nContent.Text = OP_Mode.Dtv[0]["CContent"].ToString();
                GridView_Remember_TextBox_nRemark.Text = OP_Mode.Dtv[0]["CRemark"].ToString();
            }
            else
            {
                MessageBox("", "参数错误，请勿非法操作!", "/Remember/Remember.aspx");
                return;
            }
        }
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_Remember_LinkButton1_Click(object sender, EventArgs e)
    {

        /// 记忆内容

        string DB_02 = this.GridView_Remember_TextBox_nContent.Text.Trim().Replace("'", "\"");

        /// 备注信息

        string DB_03 = this.GridView_Remember_TextBox_nRemark.Text.Trim().Replace("'", "\"");

        if (!(DB_02.Length > 0))
        {

            MessageBox("", "记忆内容不允许为空！<br/>请认真填写。");

            return;

        }

        string strSQL;
        int iid = 0;
        try
        {
            iid = Convert.ToInt32(Request["ID"]);
        }
        catch
        { }

        if (iid > 0)
        {
            strSQL = "Update Remember set CContent='" + DB_02 + "', CRemark='" + DB_03 + "',LTime=getdate() where iUserID=" + DefaultUser + " and ID= " + iid;
        }
        else
        {
            strSQL = "Insert into Remember (CContent, CRemark, iUserID) VALUES ('" + DB_02 + "','" + DB_03 + "'," + DefaultUser + ") ";
        }
        if (OP_Mode.SQLRUN(strSQL))
        {

            MessageBox("", "记忆训练信息添加(修改)成功!", "/Remember/Remember.aspx");

        }

        else

        {

            MessageBox("", "记忆训练信息添加(修改)失败！<br/>错误：" + OP_Mode.strErrMsg);

            return;

        }
    }
    /// <summary>
    /// 删除记忆内容
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_Del_Click(object sender, EventArgs e)
    {
        string strSQL = "Delete from Remember where iuserid=" + DefaultUser + " and id=" + Request["ID"];
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "记忆训练信息删除成功!", "/Remember/Remember.aspx");
            return;
        }
        else
        {
            MessageBox("", "记忆训练信息删除失败！<br/>错误：" + OP_Mode.strErrMsg + "<br>请重试。");

            return;

        }
    }
}