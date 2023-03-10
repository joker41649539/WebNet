using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dance_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadClass();
        }
    }
    /// <summary>
    /// 加载课程列表
    /// </summary>
    private void LoadClass()
    {
        string strTemp = string.Empty;
        string strWeek = string.Empty;
        string strWeek2 = string.Empty;
        // 当前星期几
        string strWeek_Now = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DateTime.Now.DayOfWeek);

        int iSchool = 0;
        try
        {
            iSchool = Convert.ToInt32(Request["school"]);
        }
        catch
        {
        }

        string strSQL = " Delete from Dance_Arrange where  ArrangeTime < DATEADD(dd,-1,getdate()) ";  // 删除过期预约

        strSQL += "Select ID,classname,ClassTeacher,CONVERT(varchar(100), ClassTimeStart, 24) STime,CONVERT(varchar(100), ClassTimeEnd, 24) ETime,ClassWeek,MaxMen,(Select Count(ID) from Dance_Arrange where classID=Dance_Class.ID) ArrAngeCount from Dance_Class where Flag=0 and school=" + iSchool + " order by PX,ClassTimeStart";

        if (OP_Mode.SQLRUN(strSQL))
        {
            for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            {
                strWeek = OP_Mode.Dtv[i]["ClassWeek"].ToString();
                if (i > 0)
                {
                    strWeek2 = OP_Mode.Dtv[i - 1]["ClassWeek"].ToString();
                }
                if (strWeek != strWeek2)
                {
                    if (strWeek2.Length > 0)
                    {//尾部输出
                        strTemp += "      </div>";
                        strTemp += "      </div>";
                        strTemp += "     </div>";
                    }
                    strTemp += "<div class=\"widget-box\">";
                    if (strWeek == strWeek_Now)
                    {
                        strTemp += " <div class=\"widget-header red\">";
                    }
                    else
                    {
                        strTemp += " <div class=\"widget-header green\">";
                    }
                    strTemp += "     <h4 class=\"lighter smaller\">";
                    strTemp += "         <i class=\"icon-calendar\"></i>";
                    // strTemp += " 星期" + OP_Mode.Dtv[i]["ClassWeek"].ToString();
                    strTemp += Convert.ToDateTime(OP_Mode.Dtv[i]["STime"].ToString()).AddDays(CountWeek(strWeek_Now, strWeek)).ToString("yyyy-MM-dd") + " " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(Convert.ToDateTime(OP_Mode.Dtv[i]["STime"].ToString()).AddDays(CountWeek(strWeek_Now, strWeek)).DayOfWeek);

                    if (iSchool == 0)
                    {
                        strTemp += " (美生店)";
                    }
                    else if (iSchool == 1)
                    {
                        strTemp += " (金中环店)";
                    }

                    strTemp += "     </h4>";
                    strTemp += "  </div>";
                    strTemp += " <div class=\"widget-body\">";
                    strTemp += "     <div class=\"widget-main no-padding\">";
                    strTemp += "        <div class=\"dialogs\">";
                }
                strTemp += "            <div class=\"itemdiv dialogdiv\">";
                strTemp += "               <div class=\"user\">";
                strTemp += "                   <img src =\"/images/DanceLogo.jpg\" />";
                strTemp += "               </div >";
                strTemp += "               <div class=\"body\">";
                strTemp += "                 <div class=\"time\">";
                strTemp += "                     <i class=\"icon-time\"></i>";

                strTemp += "                      <span class=\"green\">" + OP_Mode.Dtv[i]["STime"].ToString().Substring(0, 5) + " - " + OP_Mode.Dtv[i]["ETime"].ToString().Substring(0, 5) + "</span>";

                strTemp += "                  </div>";
                strTemp += "                  <div class=\"name\">";
                strTemp += "                     <a href=\"#\"> " + OP_Mode.Dtv[i]["ClassTeacher"].ToString() + " </a>";
                strTemp += "                  </div>";
                strTemp += "                <div class=\"text\">" + OP_Mode.Dtv[i]["classname"].ToString() + " (" + OP_Mode.Dtv[i]["ArrAngeCount"].ToString() + "/" + OP_Mode.Dtv[i]["MaxMen"].ToString() + ")</div>";
                if (Convert.ToDateTime(OP_Mode.Dtv[i]["STime"].ToString()).AddDays(CountWeek(strWeek_Now, strWeek)).AddHours(-2) > System.DateTime.Now && Convert.ToDateTime(OP_Mode.Dtv[i]["STime"].ToString()).AddDays(CountWeek(strWeek_Now, strWeek)) < System.DateTime.Now.AddDays(3))
                {
                    strTemp += "                 <div class=\"name\">";
                    strTemp += "                      <a href =\"/Dance/Reserve.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-minier btn-info\">";
                    strTemp += "                          <i class=\"icon-calendar\"></i>我要预约";
                    strTemp += "                      </a>";
                    strTemp += "                   </div>";
                }
                strTemp += "               </div>";
                strTemp += "           </div>";

                if (i == OP_Mode.Dtv.Count)
                {
                    strTemp += "   </div>";
                }
            }
        }
        //if (strTemp.Length > 0)
        //{
            ClassList.InnerHtml = strTemp;
        //}
    }

    /// <summary>
    /// 计算星期差值
    /// </summary>
    /// <param name="sWeek">开始星期</param>
    /// <param name="eWeek">截止星期</param>
    /// <returns></returns>
    private int CountWeek(string sWeek, string eWeek)
    {
        int rValue = 0;
        int iSWeek = 0, iEWeek = 0;

        if (sWeek == "一")
        {
            iSWeek = 1;
        }
        else if (sWeek == "二")
        {
            iSWeek = 2;
        }
        else if (sWeek == "三")
        {
            iSWeek = 3;
        }
        else if (sWeek == "四")
        {
            iSWeek = 4;
        }
        else if (sWeek == "五")
        {
            iSWeek = 5;
        }
        else if (sWeek == "六")
        {
            iSWeek = 6;
        }
        else if (sWeek == "日")
        {
            iSWeek = 7;
        }

        if (eWeek == "一")
        {
            iEWeek = 1;
        }
        else if (eWeek == "二")
        {
            iEWeek = 2;
        }
        else if (eWeek == "三")
        {
            iEWeek = 3;
        }
        else if (eWeek == "四")
        {
            iEWeek = 4;
        }
        else if (eWeek == "五")
        {
            iEWeek = 5;
        }
        else if (eWeek == "六")
        {
            iEWeek = 6;
        }
        else if (eWeek == "日")
        {
            iEWeek = 7;
        }

        if (iSWeek == iEWeek)
        {
            rValue = 0;
        }
        else if (iEWeek > iSWeek)
        {
            rValue = iEWeek - iSWeek;
        }
        else
        {
            rValue = iEWeek + 7 - iSWeek;
        }

        return rValue;
    }
}