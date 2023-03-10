using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JYJG_Student : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGrid.InnerHtml = LoadStudent();
        }
    }

    private string LoadStudent()
    {
        string rValue = string.Empty;

        string strSQL = string.Empty;

        if (Request.QueryString["ClassID"] != null && Request.QueryString["ClassID"] != "")
        {
            strSQL = "SELECT S_XS.CNAME,S_XS.XB,S_XS.ID,S_BJ.BJMC FROM S_XS,S_BJ WHERE S_XS.CLASSID = S_BJ.ID AND S_XS.DEL = 0 AND S_XS.CLASSID = " + Request.QueryString["ClassID"] + " ORDER BY S_XS.CNAME";

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    Label1.Text = OP_Mode.Dtv[0]["BJMC"].ToString();

                    for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                    {
                        if (OP_Mode.Dtv[i]["XB"].ToString() == "0")
                        {// 0 表示男生，蓝色
                            rValue += " <div class=\"infobox infobox-blue\">";
                        }
                        else
                        {// 非0 则表示女生，红色
                            rValue += " <div class=\"infobox infobox-red\">";
                        }

                        rValue += "     <div class=\"infobox-icon\">";
                        rValue += "      <i class=\"icon-group\"></i>";
                        rValue += "     </div>";
                        rValue += "     <div class=\"infobox-data\">";
                        rValue += "         <span class=\"infobox-data-number\">" + OP_Mode.Dtv[i]["CNAME"].ToString() + "（10/18）</span>";
                        rValue += "         <div class=\"infobox-content\">";
                        rValue += "             <div class=\"infobox-content\"><a href=\"#\"><i class=\"icon-calendar\"></i>&nbsp;签到</a><a href=\"#\">&nbsp;&nbsp;<i class=\"icon-camera\"></i>&nbsp;点评</a><a href=\"#\">&nbsp;&nbsp;<i class=\"icon-edit\"></i>&nbsp;编辑</a></div>";
                        rValue += "      </div>";
                        rValue += "     </div>";
                        rValue += " </div>";
                    }
                }
                else
                {
                    rValue += " <div class=\"infobox infobox-red\">";
                    rValue += "     <div class=\"infobox-icon\">";
                    rValue += "      <i class=\"icon-bolt\"></i>";
                    rValue += "     </div>";
                    rValue += "     <div class=\"infobox-data\">";
                    rValue += "         <span class=\"infobox-data-number\">还没有学生</span>";
                    //rValue += "         <div class=\"infobox-content\">";
                    //rValue += "             <a href=\"/JYJG/Student.aspx?ClassID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">55 人</a>&nbsp;&nbsp;&nbsp;&nbsp;陈老师&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"/JYJG/ClassEdit.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\"><i class=\"icon-edit\"></i></a>";
                    //rValue += "      </div>";
                    rValue += "     </div>";
                    rValue += " </div>";
                }
            }
            else
            {
                MessageBox("", "参数错误。", "/JYJG/Class.ASPX");
            }

        }
        else
        {
            MessageBox("", "参数错误。", "/JYJG/Class.ASPX");
        }

        return rValue;
    }

    /// <summary>
    /// 保存学生信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_JG_LinkButton1_Click(object sender, EventArgs e)
    {

    }
}