using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Manage_Students : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudents();
        }
    }

    private void LoadStudents()
    {
        string strTempDiv = string.Empty;
        string strSQL;//= "Select ID,Name,Sex,Remark,Tel,BrithDay,datediff(year, BrithDay,getdate()) age,HeadImg from XMFight_Student order by Name";
        strSQL = " Select ID, Name, Sex, Remark, Tel, BrithDay, datediff(year, BrithDay, getdate()) age,HeadImg";
        strSQL += " ,sumClassCount,LastClassTime,";
        strSQL += " isnull((Select Count(ID) from XMFight_Class_Record where IFlag=2 and StudentID = a.ID),0) Leave,";
        strSQL += " isnull((Select Count(ID) from XMFight_Class_Record where IFlag=3 and StudentID = a.ID),0) Absenteeism,";
        strSQL += " isnull((Select sum(Bance) from XMFight_reserve where StudentID=a.ID),0) SumBance";
        strSQL += " from XMFight_Student a,";
        strSQL += " (Select sum(ICount) sumClassCount, MAX(CTime) LastClassTime, StudentID from XMFight_Class_Record group by StudentID) as b";
        strSQL += " where a.ID = b.StudentID";
        if (TextBox1.Text.Length > 0)
        {
            strSQL += " and a.name like '%" + TextBox1.Text.Replace("'", "''") + "%' ";
        }
        strSQL += " order by Name";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strTempDiv += "<div class=\"itemdiv dialogdiv\">";
                    strTempDiv += "<div class=\"user\">";
                    if (OP_Mode.Dtv[i]["HeadImg"].ToString().Length < 10)
                    {// 显示头像
                        strTempDiv += "   <img src=\"/images/XMFightLogo.jpg\"/>";
                    }
                    else
                    {
                        strTempDiv += "   <img src=\"" + OP_Mode.Dtv[i]["HeadImg"].ToString() + "\"/>";
                    }
                    strTempDiv += "</div>";

                    strTempDiv += "<div class=\"body\">";
                    strTempDiv += "     <div class=\"time\">";
                    strTempDiv += "         <i class=\"icon-time\"></i>";
                    strTempDiv += "         <span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["Brithday"]).ToString("yyyy-MM-dd") + "</span>";
                    strTempDiv += "     </div>";

                    strTempDiv += "     <div class=\"name\">";
                    if (Convert.ToInt32(OP_Mode.Dtv[i]["sex"]) == 1)
                    {/// 1 是男生
                        strTempDiv += "         <a href=\"tel:" + OP_Mode.Dtv[i]["Tel"].ToString() + "\"> " + OP_Mode.Dtv[i]["Name"].ToString() + " <span class=\"label label-info arrowed-in arrowed-in-right\"> " + OP_Mode.Dtv[i]["age"].ToString() + " 岁 </span> </a>";
                    }
                    else
                    {
                        strTempDiv += "         <a href=\"tel:" + OP_Mode.Dtv[i]["Tel"].ToString() + "\"> " + OP_Mode.Dtv[i]["Name"].ToString() + " <span class=\"label label-danger arrowed-in arrowed-in-right\"> " + OP_Mode.Dtv[i]["age"].ToString() + " 岁 </span> </a>";
                    }
                    strTempDiv += "     </div>";
                    strTempDiv += "    <div class=\"text\">";
                    if (ExecDateDiff(Convert.ToDateTime(OP_Mode.Dtv[i]["LastClassTime"]), System.DateTime.Now) > 7)
                    {/// 超过 7 天未上课的 红色显示
                        strTempDiv += "         <h5>上节课时间：<span class=\"label label-danger\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["LastClassTime"]).ToString("yyyy-MM-dd") + " </span></h5>";
                    }
                    else
                    {
                        strTempDiv += "        <h5>上节课时间：" + Convert.ToDateTime(OP_Mode.Dtv[i]["LastClassTime"]).ToString("yyyy-MM-dd") + " </h5>";
                    }
                    if (Convert.ToDouble(OP_Mode.Dtv[i]["sumClassCount"]) < 11)
                    {/// 小于 11 节课，高亮显示
                        strTempDiv += "        <h5>剩余课时：<span class=\"label label-danger\">" + OP_Mode.Dtv[i]["sumClassCount"].ToString() + "</span> 节</h5>";
                    }
                    else
                    {
                        strTempDiv += "         <h5>剩余课时：" + OP_Mode.Dtv[i]["sumClassCount"].ToString() + " 节</h5>";
                    }
                    if (Convert.ToDouble(OP_Mode.Dtv[i]["Leave"]) > 5)
                    {/// 请假超过 5 节课，高亮显示
                        strTempDiv += "         <h5>请假：<span class=\"label label-danger\">" + OP_Mode.Dtv[i]["Leave"].ToString() + "</span> 节</h5>";
                    }
                    else
                    {
                        strTempDiv += "         <h5>请假：" + OP_Mode.Dtv[i]["Leave"].ToString() + " 节</h5>";
                    }
                    if (Convert.ToDouble(OP_Mode.Dtv[i]["Absenteeism"]) > 2)
                    {/// 请假超过 2 节课，高亮显示

                        strTempDiv += "         <h5>旷课：<span class=\"label label-danger\">" + OP_Mode.Dtv[i]["Absenteeism"].ToString() + "</span> 节</h5>";
                    }
                    else
                    {
                        strTempDiv += "         <h5>旷课：" + OP_Mode.Dtv[i]["Absenteeism"].ToString() + " 节</h5>";
                    }
                    strTempDiv += "         <h5 class='pink'>储备金：" + OP_Mode.Dtv[i]["SumBance"].ToString() + " 元</h5>";
                    if (OP_Mode.Dtv[i]["Remark"].ToString().Length > 0)
                    {
                        strTempDiv += "<h5 class='red'>备注:" + OP_Mode.Dtv[i]["Remark"].ToString() + "</h5> ";
                    }
                    strTempDiv += "     </div>";

                    strTempDiv += "     <div class=\"tools\">";
                    strTempDiv += "         <a href=\"Operation.aspx?SID=" + OP_Mode.Dtv[i]["ID"].ToString() + "&CID=1\" class=\"btn btn-minier btn-success\">上课";
                    strTempDiv += "           </a>";
                    strTempDiv += "        <a href=\"Operation.aspx?SID=" + OP_Mode.Dtv[i]["ID"].ToString() + "&CID=2\" class=\"btn btn-minier btn-info\">请假";
                    strTempDiv += "          </a>";
                    strTempDiv += "         <a href=\"Operation.aspx?SID=" + OP_Mode.Dtv[i]["ID"].ToString() + "&CID=3\" class=\"btn btn-minier btn-danger\">旷课";
                    strTempDiv += "          </a>";
                    strTempDiv += "        <a href=\"Operation.aspx?SID=" + OP_Mode.Dtv[i]["ID"].ToString() + "&CID=0\" class=\"btn btn-minier btn-pink\">储备金";
                    strTempDiv += "          </a>";
                    strTempDiv += "     </div>";
                    strTempDiv += " </div>";
                    strTempDiv += " </div>";
                }
                if (strTempDiv.Length > 0)
                {
                    Div_StudentsList.InnerHtml = strTempDiv;
                }
            }
        }
    }
    /// <summary>
    /// 程序执行时间测试
    /// </summary>
    /// <param name="dateBegin">开始时间</param>
    /// <param name="dateEnd">结束时间</param>
    /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
    public static int ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
    {
        TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
        TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
        TimeSpan ts3 = ts1.Subtract(ts2).Duration();
        //你想转的格式
        return Convert.ToInt32(ts3.TotalDays);
    }

    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadStudents();
    }
}