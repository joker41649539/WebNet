using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JYJG_Class : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadKC();
            HtmlGrid.InnerHtml = LoadHtmlGrid();
        }
    }

    /// <summary>
    /// 加载并绑定课程信息
    /// </summary>
    private void LoadKC()
    {
        string strSQL = "SELECT S_KC.ID,KCMC FROM S_KC,S_USERINFO WHERE S_USERINFO.SSDW=S_KC.JGID AND S_KC.DEL=0 AND S_KC.FLAG=0 AND S_USERINFO.ID=" + DefaultUser;
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                DropDownList1.DataSource = OP_Mode.Dtv;
                DropDownList1.DataTextField = "KCMC";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();
            }
            else
            {
                MessageBox("", "您所属的机构还没有开设任何课程，请先添加课程信息。", "./");
            }
        }
    }

    /// <summary>
    /// 保存课程信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_JG_LinkButton1_Click(object sender, EventArgs e)
    {
        string strMSG = string.Empty;
        int iT = 0;

        if (TextBox_Name.Text.Length == 0)
        {
            iT += 1;
            strMSG += iT + "、班级名称不允许为空。<br>";
        }

        string strKCRQ = string.Empty;

        if (CData1.Text == "on")
        {
            strKCRQ += "1-" + Convert.ToDateTime(textboxTime1.Text).ToString("HH:mm") + "-" + Convert.ToDateTime(textboxTime2.Text).ToString("HH:mm") + ";";
        }
        if (CData2.Text == "on")
        {
            strKCRQ += "2-" + Convert.ToDateTime(textboxTime3.Text).ToString("HH:mm") + "-" + Convert.ToDateTime(textboxTime4.Text).ToString("HH:mm") + ";";
        }
        if (CData3.Text == "on")
        {
            strKCRQ += "3-" + Convert.ToDateTime(textboxTime5.Text).ToString("HH:mm") + "-" + Convert.ToDateTime(textboxTime6.Text).ToString("HH:mm") + ";";
        }
        if (CData4.Text == "on")
        {
            strKCRQ += "4-" + Convert.ToDateTime(textboxTime7.Text).ToString("HH:mm") + "-" + Convert.ToDateTime(textboxTime8.Text).ToString("HH:mm") + ";";
        }
        if (CData5.Text == "on")
        {
            strKCRQ += "5-" + Convert.ToDateTime(textboxTime9.Text).ToString("HH:mm") + "-" + Convert.ToDateTime(textboxTime10.Text).ToString("HH:mm") + ";";
        }
        if (CData6.Text == "on")
        {
            strKCRQ += "6-" + Convert.ToDateTime(textboxTime11.Text).ToString("HH:mm") + "-" + Convert.ToDateTime(textboxTime12.Text).ToString("HH:mm") + ";";
        }
        if (CData7.Text == "on")
        {
            strKCRQ += "7-" + Convert.ToDateTime(textboxTime13.Text).ToString("HH:mm") + "-" + Convert.ToDateTime(textboxTime14.Text).ToString("HH:mm") + ";";
        }

        if (strKCRQ.Length == 0)
        {
            iT += 1;
            strMSG += iT + "、请选择上课时间。<br>";
        }

        if (TextBox21.Text.Length == 0)
        {
            iT += 1;
            strMSG += iT + "、开课日期不允许为空。<br>";
        }

        if (TextBox22.Text.Length == 0)
        {
            iT += 1;
            strMSG += iT + "、截课日期不允许为空。<br>";
        }

        if (strMSG.Length > 0)
        {
            MessageBox("", strMSG);
            return;
        }

        string strBJMC = TextBox_Name.Text.Replace("'", "\"");

        string strSQL = string.Empty;

        strSQL = " DECLARE @Count int ";
        strSQL += " Select @Count = Count(ID) from S_BJ Where KCID=" + DropDownList1.SelectedValue.ToString() + " And BJMC='" + strBJMC + "'";
        strSQL += " If @count = 0 ";
        strSQL += " Begin";
        strSQL += "     Insert into S_BJ (KCID,BJMC,SKSJWeek,YXQSTime,YXQETime) values (" + DropDownList1.SelectedValue.ToString() + ",'" + strBJMC + "','" + strKCRQ + "','" + Convert.ToDateTime(TextBox21.Text).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox22.Text).ToString("yyyy-MM-dd") + "') ";
        strSQL += "     Select * from S_BJ Where KCID=" + DropDownList1.SelectedValue.ToString() + " And BJMC='" + strBJMC + "'";
        strSQL += " End ";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                MessageBox("恭 喜", "班级添加成功，随后能可以去添加班级学生以及任课老师了。");
                return;
            }
            else
            {
                MessageBox("错 误", "班级添加失败,该班级名称已经存在。<br/>请重试。");
                return;
            }
        }
        else
        {
            MessageBox("错 误", "班级添加失败。<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }
    }

    /// <summary>
    /// 输出HTML列表样式
    /// </summary>
    private string LoadHtmlGrid()
    {
        string rValue = string.Empty;

        string strSQL = string.Empty;

        strSQL = "SELECT S_BJ.ID,KCMC+BJMC BJMC FROM S_BJ,S_KC WHERE KCID=S_KC.ID AND S_BJ.FLAG=0 AND S_BJ.DEL=0";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    rValue += " <div class=\"infobox infobox-green\">";
                    rValue += "     <div class=\"infobox-icon\">";
                    rValue += "      <i class=\"icon-group\"></i>";
                    rValue += "     </div>";
                    rValue += "     <div class=\"infobox-data\">";
                    rValue += "         <span class=\"infobox-data-number\">" + OP_Mode.Dtv[i]["BJMC"].ToString().Substring(OP_Mode.Dtv[i]["BJMC"].ToString().Length - 6) + "</span>";
                    rValue += "         <div class=\"infobox-content\">";
                    rValue += "             <a href=\"/JYJG/Student.aspx?ClassID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">55 人</a>&nbsp;&nbsp;&nbsp;&nbsp;陈老师&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"/JYJG/ClassEdit.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\"><i class=\"icon-edit\"></i></a>";
                    rValue += "      </div>";
                    rValue += "     </div>";
                    rValue += " </div>";
                }
            }
        }
        return rValue;
    }

}