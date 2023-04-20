using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partner_Tags : PageBase
{
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
                LoadAllTags();
            }
        }
    }

    /// <summary>
    /// 读取所有标签并显示
    /// </summary>
    private void LoadAllTags()
    {
        int UserID = 0;

        try
        {
            UserID = Convert.ToInt32(Request["id"]);

            string strSQL = "Select * from W_Tags order by SN desc";
            string strTemp = string.Empty;
            if (OP_Mode.SQLRUN(strSQL))
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strTemp += "<a onclick=\"javascript:return confirm('您确定要删除[" + OP_Mode.Dtv[i]["TagName"].ToString() + "]标签吗？')\" href=\"TagsEdid.aspx?UserID=" + UserID + "&Edit=DelTag&TagID=" + OP_Mode.Dtv[i]["ID"].ToString().Trim() + "\" class=\"label label-" + OP_Mode.Dtv[i]["Stytle"].ToString().Trim() + "\">" + OP_Mode.Dtv[i]["TagName"].ToString() + "[" + OP_Mode.Dtv[i]["SN"].ToString() + "]" + "</a>&nbsp;";
                }
            }
            if (strTemp.Length > 0)
            {
                Div_Tags.InnerHtml = strTemp;
            }
        }
        catch
        {

        }
    }

    /// <summary>
    /// 保存标签按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        InsertTagData();
    }
    /// <summary>
    /// 插入标签数据
    /// </summary>
    private void InsertTagData()
    {
        string strTagName = string.Empty, strStytle = string.Empty;
        int strSN = 100;

        strTagName = TextBox_TagName.Text.Trim().Replace("'", "");
        strStytle = RadioButtonList1.SelectedValue;
        try
        {
            strSN = Convert.ToInt32(TextBox_PX.Text.Trim().Replace("'", ""));
        }
        catch
        {

        }

        string strSQL = "Insert into W_Tags (TagName,Stytle,SN) values ('" + strTagName + "','" + strStytle + "'," + strSN + ")";
        if (OP_Mode.SQLRUN(strSQL))
        {
            TextBox_TagName.Text = "";//清空文本框
            MessageBox("", "新标签添加成功。");
            LoadAllTags();
        }
    }
}