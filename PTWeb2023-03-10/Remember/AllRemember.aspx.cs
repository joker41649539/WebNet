using System;
using System.Collections.Generic;
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
            LoadDefaultData();
        }
    }

    /// <summary>
    /// 加载基础数据
    /// </summary>
    private void LoadDefaultData()
    {
        string strSQL = "Select * from Remember where iUserID=" + DefaultUser + " order by ICount desc";
        string strTemp = string.Empty;

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strTemp += "<div class=\"well\">";
                    strTemp += "   <h6 class=\"blue\"> 序号：" + (OP_Mode.Dtv.Count - i).ToString() + "</h6>";
                    strTemp += "   <h3 class=\"red lighter\">" + OP_Mode.Dtv[i]["CContent"].ToString().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</h3>";
                    strTemp += "   <h4 class=\"green\">" + OP_Mode.Dtv[i]["CRemark"].ToString().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "<h4>";
                    strTemp += "   <h6>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + " 第 1 次背诵，已背诵 " + OP_Mode.Dtv[i]["ICount"].ToString() + " 次。</h6>";

                    strTemp += ReadMyTag(Convert.ToInt32(OP_Mode.Dtv[i]["ID"])); // 加载标签数据

                    strTemp += "   <div class=\"btn-group\">";
                    //strTemp += "     <a href=\"RememberAdd.aspx?flag=1&ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm btn-success\"><i class=\"icon-ok\"></i>完成</a>";
                    //if (Convert.ToInt32(OP_Mode.Dtv[i]["ICount"]) > 5)
                    //{ // 如果超过5次记忆，才允许非常熟了。
                    //    strTemp += "     <a href=\"RememberAdd.aspx?flag=-1&ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm btn-danger\"><i class=\"icon-eye-close\"></i>很熟</a>";
                    //}

                    strTemp += "     <a href=\"RememberAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm btn-info\"><i class=\"icon-edit\"></i>编辑</a>";
                    strTemp += "   </div>";
                    strTemp += "</div>";
                }
            }
        }
        if (strTemp.Length > 0)
        {
            accordion.InnerHtml = strTemp;
        }
    }


    /// <summary>
    /// 依据记忆内容加载标签
    /// </summary>
    /// <param name="RememberID"></param>
    /// <returns></returns>
    private string ReadMyTag(int RememberID)
    {
        string rValue = string.Empty;

        string strSQL = "Select TagColor,TagName from Remember_TagRemember,Remember_Tag where Remember_Tag.ID=Remember_TagRemember.TagID  and UserID=" + DefaultUser + " and RememberID=" + RememberID;

        if (OP_Mode.SQLRUN(strSQL, "Tag"))
        {
            if (OP_Mode.Dtv1.Count > 0)
            {
                rValue = "<p>";
            }
            for (int i = 0; i < OP_Mode.Dtv1.Count; i++)
            {
                rValue += "<span class=\"label label-" + OP_Mode.Dtv1[i]["TagColor"].ToString() + "\">" + OP_Mode.Dtv1[i]["TagName"].ToString() + "</span>";
            }
            if (rValue.Length > 0)
            {
                rValue += "</p>";
            }
        }

        return rValue;
    }

    /// <summary>
    /// 清空记忆数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_Clear_Click(object sender, EventArgs e)
    {
        string strSQL = "Delete from Remember where iUserID=" + DefaultUser;
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "数据清空成功。<br />","Default.aspx");
        }
        else
        {
            MessageBox("", "数据清空失败。<br />" + OP_Mode.strErrMsg);
        }
    }
}