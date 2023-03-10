using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Remember_Default3 : PageBaseRem
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllTag();

            try
            {
                int iID = Convert.ToInt32(Request["TagID"]);
                int iRemember = Convert.ToInt32(Request["RememberID"]);
                if (iID > 0 & iRemember > 0)
                {
                    DelTagForRememberID(iID, iRemember);
                }
                else
                {
                    int iDelID = Convert.ToInt32(Request["DelID"]);

                    if (iDelID > 0)
                    {
                        DelTagForID(iDelID);
                    }
                }
            }
            catch
            {

            }
        }
    }

    /// <summary>
    /// 保存标签
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;

        string DB_01 = Content.Text.Trim().Replace("'", "\"");
        string DB_02 = string.Empty;

        int iSelect = 0;
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                iSelect += 1;
                DB_02 = CheckBoxList1.Items[i].Value.ToString();
            }
        }

        if (iSelect > 1 || iSelect == 0)
        {

            MessageBox("", "颜色必须选择一个。");
            return;
        }

        strSQL = "Insert into Remember_Tag (TagName,TagColor,UserID) values ('" + DB_01 + "','" + DB_02 + "'," + DefaultUser + ")";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "标签添加成功。", "TagAdd.aspx");
        }
        else
        {
            MessageBox("", "标签添加失败，请重试。<br>错误：" + OP_Mode.strErrMsg);
        }

    }

    /// <summary>
    /// 加载所有标签
    /// </summary>
    private void LoadAllTag()
    {
        string strTemp = string.Empty;
        string strSQL = "Select * from Remember_Tag Where UserID=" + DefaultUser;
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
                strTemp += "    <a href=\"TagAdd.aspx?DelID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" >删除标签</a></li>";
                strTemp += " </ul>";
                strTemp += "</div>";
            }
        }

        if (strTemp.Length > 0)
        {
            PTag.InnerHtml = strTemp;
        }
    }

    private void DelTagForID(int IID)
    {

        string strSQL = " Delete Remember_TagRemember from Remember_TagRemember, Remember_Tag where Remember_Tag.ID = Remember_TagRemember.TagID  and UserID=" + DefaultUser + " and TagID=" + IID + " ";
        strSQL += " Delete from Remember_Tag Where UserID=" + DefaultUser + " and ID=" + IID.ToString();

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "标签删除成功。", "TagAdd.aspx");
        }
        else
        {
            MessageBox("", "标签删除失败，请重试。<br>错误：" + OP_Mode.strErrMsg);
        }

    }

    /// <summary>
    /// 依据记忆序号和标签号，删除标签
    /// </summary>
    private void DelTagForRememberID(int TagID, int RememberID)
    {
        string strSQL = "Delete Remember_TagRemember from  Remember_TagRemember,Remember_Tag where Remember_Tag.ID=Remember_TagRemember.TagID  and UserID=" + DefaultUser + " and TagID=" + TagID + " and RememberID=" + RememberID.ToString();

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "标签删除成功。", "RememberAdd.aspx?ID=" + RememberID);
        }

    }

}