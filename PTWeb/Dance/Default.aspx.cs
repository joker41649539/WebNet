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
            //MessageBox("", "[" + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(Convert.ToDateTime("2021-03-21").DayOfWeek) + "]");
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
        string strSQL = "Select classname,ClassTeacher,CONVERT(varchar(100), ClassTimeStart, 24) STime,ClassWeek,MaxMen from Dance_Class order by PX,ClassTimeStart";
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
                    if (OP_Mode.Dtv[i]["ClassWeek"].ToString() == System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DateTime.Now.DayOfWeek))
                    {
                        strTemp += " <div class=\"widget-header red\">";
                    }
                    else
                    {
                        strTemp += " <div class=\"widget-header green\">";
                    }
                    strTemp += "     <h4 class=\"lighter smaller\">";
                    strTemp += "         <i class=\"icon-calendar\"></i>";
                    strTemp += " 星期" + OP_Mode.Dtv[i]["ClassWeek"].ToString();
                    //   strTemp += System.DateTime.Now.ToString("yyyy-MM-dd") + " " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
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
                strTemp += "                      <span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"].ToString()).AddDays(1) + "</span>";
                strTemp += "                  </div>";
                strTemp += "                  <div class=\"name\">";
                strTemp += "                     <a href=\"#\"> " + OP_Mode.Dtv[i]["ClassTeacher"].ToString() + " </a>";
                strTemp += "                  </div>";
                strTemp += "                <div class=\"text\">" + OP_Mode.Dtv[i]["classname"].ToString() + " (5/10)</div>";
                strTemp += "                 <div class=\"tools\">";
                strTemp += "                      <a href =\"/Dance/Reserve.aspx\" class=\"btn btn-minier btn-info\">";
                strTemp += "                          <i class=\"icon-calendar\"></i>我要预约";
                strTemp += "                      </a>";
                strTemp += "                   </div>";
                strTemp += "               </div>";
                strTemp += "           </div>";

                if (i == OP_Mode.Dtv.Count)
                {
                    strTemp += "   </div>";
                }
            }
        }
        if (strTemp.Length > 0)
        {
            ClassList.InnerHtml = strTemp;
        }
    }
}