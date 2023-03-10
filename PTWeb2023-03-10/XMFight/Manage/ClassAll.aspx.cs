using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Default3 : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudents();
        }
    }


    /// <summary>
    /// 加载学生信息
    /// </summary>
    private void LoadStudents()
    {
        string strTempDiv = string.Empty;
        string strSQL;//= "Select ID,Name,Sex,Remark,Tel,BrithDay,datediff(year, BrithDay,getdate()) age,HeadImg from XMFight_Student order by Name";
        string strWeek = string.Empty;
        string dt;
        int iNumber = 0; // 记录序号
        dt = DateTime.Today.DayOfWeek.ToString();
        switch (dt)
        {
            case "Monday":
                strWeek = "1,2";
                break;
            case "Tuesday":
                strWeek = "2,3";
                break;
            case "Wednesday":
                strWeek = "3,4";
                break;
            case "Thursday":
                strWeek = "4,5,6";
                break;
            case "Friday":
                strWeek = "5,6";
                break;
            case "Saturday":
                strWeek = "6,7";
                break;
            case "Sunday":
                strWeek = "7,1";
                break;
        }

        strWeek = "1,2,3,4,5,6,7";

        strSQL = " Select XMFight_Student.ID,Week,STime,ETime, datediff(year, BrithDay, getdate()) age";
        strSQL += " ,sumClassCount,LastClassTime,*";
        strSQL += " ,isnull((Select Count(ID) from XMFight_Class_Record where IFlag=2 and StudentID = XMFight_Student.ID),0) Leave,";
        strSQL += " isnull((Select Count(ID) from XMFight_Class_Record where IFlag=3 and StudentID = XMFight_Student.ID),0) Absenteeism,";
        strSQL += " isnull((Select sum(Bance) from XMFight_reserve where StudentID=XMFight_Student.ID),0) SumBance";
        strSQL += "  from XMFight_Class_Student,XMFight_Student,XMFight_ClassTime,";
        strSQL += " (Select sum(ICount) sumClassCount, MAX(CTime) LastClassTime, StudentID from XMFight_Class_Record group by StudentID) as b";
        strSQL += " where ClassID=XMFight_ClassTime.ID and XMFight_ClassTime.Flag=0 and XMFight_Class_Student.StudentID=XMFight_Student.ID and b.StudentID=XMFight_Student.ID and Week in (" + strWeek + ")";

        strSQL += " order by classid ,name";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {

                    if (i == 0)
                    {// 输出表头
                     //if (strWeek.Substring(0, 1) == OP_Mode.Dtv[i]["Week"].ToString())
                     //{
                     // strTempDiv += "<h5>&nbsp;" + System.DateTime.Now.ToString("yyyy-MM-dd dddd") + " " + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " </h5>";
                        strTempDiv += "<h5>&nbsp;" + GetWeekUpForData(Convert.ToInt32(OP_Mode.Dtv[i]["Week"])).ToString("yyyy-MM-dd dddd") + " " + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " </h5>";
                        //}
                        //else
                        //{
                        //    strTempDiv += "<h5>&nbsp;" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd dddd") + " " + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " </h5>";
                        //}
                        strTempDiv += "         <a href=\"SendMsg.aspx?CID=" + OP_Mode.Dtv[i]["ClassID"].ToString() + "\" class=\"btn btn-minier btn-success\">群发上课提醒";
                        strTempDiv += "           </a>";
                        strTempDiv += "<div class=\"widget-main no-padding\">";
                        strTempDiv += "<div class=\"dialogs\">";
                    }
                    if (i > 0)
                    {
                        if (OP_Mode.Dtv[i - 1]["ClassID"].ToString() != OP_Mode.Dtv[i]["ClassID"].ToString())
                        {
                            iNumber = 0;
                            strTempDiv += "</div>";
                            strTempDiv += "</div>";
                            strTempDiv += "<h5>&nbsp;" + GetWeekUpForData(Convert.ToInt32(OP_Mode.Dtv[i]["Week"])).ToString("yyyy-MM-dd dddd") + " " + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " </h5>";
                            strTempDiv += "         <a href=\"SendMsg.aspx?CID=" + OP_Mode.Dtv[i]["ClassID"].ToString() + "\" class=\"btn btn-minier btn-success\">群发上课提醒";
                            strTempDiv += "           </a>";
                            strTempDiv += "<div class=\"widget-main no-padding\">";
                            strTempDiv += "<div class=\"dialogs\">";
                        }
                    }
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
                    iNumber++;
                    if (Convert.ToInt32(OP_Mode.Dtv[i]["sex"]) == 1)
                    {/// 1 是男生
                        strTempDiv += "         <a href=\"tel:" + OP_Mode.Dtv[i]["Tel"].ToString() + "\"> " + iNumber + "、" + OP_Mode.Dtv[i]["Name"].ToString() + " <span class=\"label label-info arrowed-in arrowed-in-right\"> " + OP_Mode.Dtv[i]["age"].ToString() + " 岁 </span> </a>";
                    }
                    else
                    {
                        strTempDiv += "         <a href=\"tel:" + OP_Mode.Dtv[i]["Tel"].ToString() + "\"> " + iNumber + "、" + OP_Mode.Dtv[i]["Name"].ToString() + " <span class=\"label label-danger arrowed-in arrowed-in-right\"> " + OP_Mode.Dtv[i]["age"].ToString() + " 岁 </span> </a>";
                    }
                    strTempDiv += "     </div>";
                    strTempDiv += "    <div class=\"text\">";

                    if (ExecDateDiff(Convert.ToDateTime(Convert.ToDateTime(OP_Mode.Dtv[i]["BrithDay"]).ToString("MM-dd")), System.DateTime.Now) < 7)
                    {/// 最近一周内要过生日。
                        strTempDiv += "<h3 class=\"red\">生日:" + Convert.ToDateTime(System.DateTime.Now.Year + " " + Convert.ToDateTime(OP_Mode.Dtv[i]["BrithDay"]).ToString("MM-dd")).ToString("MM月dd日 dddd") + "</h3>";
                    }
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
                    strTempDiv += "         <a href=\"/XMFight/MyClass.aspx?SID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-minier btn-primary\">详情";
                    strTempDiv += "           </a>";
                    strTempDiv += "     </div>";
                    strTempDiv += " </div>";
                    strTempDiv += " </div>";
                }
                /// 结束了，添加三个收尾

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
    /// 依据星期显示具体日期
    /// </summary>
    /// <param name="day"></param>
    /// <returns></returns>
    public DateTime GetWeekUpForData(int day)
    {
        DateTime someTime = System.DateTime.Now;

        int i = (int)someTime.DayOfWeek;

        if (day > i)
        {
            someTime = someTime.AddDays(day - i);
        }
        else if (day < i)
        {
            someTime = someTime.AddDays(day + 7 - i);
        }

        return someTime;
    }
}