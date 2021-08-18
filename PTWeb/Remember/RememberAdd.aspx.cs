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

                    int Tag = Convert.ToInt32(Request["tag"]);
                    if (Tag > 0 && iid > 0)
                    {
                        AddTag(iid, Tag);
                    }
                    LoadData(iid);
                    ReadMyAllTag(iid);
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
    /// 加载所有标签
    /// </summary>
    private void ReadMyAllTag(int iid)
    {
        string strTemp = string.Empty;
        if (iid > 0)
        {
            string strSQL = " Select * from Remember_Tag where UserID=" + DefaultUser + " order By LTime";
            if (OP_Mode.SQLRUN(strSQL))
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                { // 循环展示标签
                    strTemp += "<a href=\"?ID=" + iid + "&tag=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"label label-" + OP_Mode.Dtv[i]["TagColor"].ToString() + "\">" + OP_Mode.Dtv[i]["TagName"].ToString() + "</a>";
                }
            }
        }
        strTemp += "<a href=\"TagAdd.aspx\" class=\"label label-grey\"><i class=\"far fa-plus-square\"></i>&nbsp;添加新的标签</a>";
        MyTag.InnerHtml = strTemp;
    }

    /// <summary>
    /// 添加标签
    /// </summary>
    /// <param name="IID"></param>
    /// <param name="iTag"></param>
    private void AddTag(int IID, int iTag)
    {

        string strSQL = " DECLARE @Cont INT ";

        strSQL += " Select @Cont = count(*) from Remember_Tag,Remember_TagRemember where UserID=" + DefaultUser + " and Remember_Tag.ID=TagID and RememberID=" + IID + " and TagID=" + iTag + " ";

        strSQL += " if @Cont=0 ";
        strSQL += " BEGIN ";
        strSQL += "   Insert into Remember_TagRemember(RememberID, TagID) values(" + IID.ToString() + ", " + iTag.ToString() + ")";
        strSQL += " End";

        if (!OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "" + OP_Mode.strErrMsg);
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
        strSQL += " Update Remember set NextTime='" + System.DateTime.Now.AddDays(15).ToString("yyyy-MM-dd") + "',lTime=getdate(),ICount=ICount+1 where NextTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and ICount=4 and ID=" + IID + "  ";
        strSQL += " Update Remember set NextTime='" + System.DateTime.Now.AddDays(30).ToString("yyyy-MM-dd") + "',lTime=getdate(),ICount=ICount+1 where NextTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and ICount>4 and ID=" + IID + "  ";

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

                LoadTag(IID);
            }
            else
            {
                MessageBox("", "参数错误，请勿非法操作!", "/Remember/Remember.aspx");
                return;
            }
        }
    }

    /// <summary>
    /// 加载标签
    /// </summary>
    /// <param name="IID"></param>
    private void LoadTag(int IID)
    {
        string strSQL = "Select Remember_Tag.ID,TagName,TagColor from Remember_Tag,Remember_TagRemember where UserID=" + DefaultUser + " and Remember_Tag.ID=TagID and RememberID=" + IID;

        string strTemp = string.Empty;

        if (OP_Mode.SQLRUN(strSQL))
        {
            for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            {
                strTemp += "<div class=\"btn-group\">";
                strTemp += "  <button data-toggle=\"dropdown\" class=\"btn btn-" + OP_Mode.Dtv[i]["TagColor"].ToString() + " dropdown-toggle\">";
                strTemp += " " + OP_Mode.Dtv[i]["TagName"].ToString() + " <span class=\"icon-caret-down icon-on-right\"></span>";
                strTemp += "  </button>";
                strTemp += " <ul class=\"dropdown-menu dropdown-default\">";
                strTemp += "  <li>";
                strTemp += "    <a href=\"TagAdd.aspx?TagID=" + OP_Mode.Dtv[i]["ID"].ToString() + "&RememberID=" + IID + "\" >删除标签</a></li>";
                strTemp += " </ul>";
                strTemp += "</div>";
                //                strTemp += "<span class=\"label label-"+OP_Mode.Dtv[i]["TagColor"].ToString()+ "\">" + OP_Mode.Dtv[i]["TagName"].ToString() + "</span>";
            }
        }
        if (strTemp.Length > 0)
        {
            RememberTag.InnerHtml = strTemp;
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