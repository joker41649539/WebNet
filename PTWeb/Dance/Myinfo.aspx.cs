using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dance_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadArrange();
            LoadAttend();
        }
    }

    private void LoadArrange()
    {
        int iUserID;
        try
        {
            iUserID = Convert.ToInt32(Request.Cookies["Dance"]["USERID"]);

            //iUserID = 2;

            if (iUserID <= 0)
            {
                MessageBox("", "用户信息获取失败，请重试。", "/Dance/");
                return;
            }
        }
        catch
        {
            MessageBox("", "用户信息获取失败，请重试。", "/Dance/");
            return;
        }
        string strTemp = string.Empty;

        string strSQL = "Select Dance_Arrange.ID,ArrangeTime,ClassName,ClassTeacher,CONVERT(varchar(100), ClassTimeStart, 24) STime,CONVERT(varchar(100), ClassTimeEnd, 24) ETime,ClassWeek from Dance_Arrange,Dance_Class where classid=Dance_Class.ID and UserID=" + iUserID + " order by ArrangeTime,ClassTimeStart";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strTemp += "  <div class=\"dialogs\">";
                    strTemp += "            <div class=\"itemdiv dialogdiv\">";
                    strTemp += "               <div class=\"user\">";
                    strTemp += "                   <img src =\"/images/DanceLogo.jpg\" />";
                    strTemp += "               </div >";
                    strTemp += "               <div class=\"body\">";
                    strTemp += "                 <div class=\"time\">";
                    strTemp += "                     <i class=\"icon-time\"></i>";
                    strTemp += "                      <span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["ArrangeTime"]).ToString("yyyy-MM-dd") + " " + OP_Mode.Dtv[i]["STime"].ToString().Substring(0, 5) + " - " + OP_Mode.Dtv[i]["ETime"].ToString().Substring(0, 5) + "</span>";
                    strTemp += "                  </div>";
                    strTemp += "                  <div class=\"name\">";
                    strTemp += "                     <a href=\"#\"> " + OP_Mode.Dtv[i]["ClassTeacher"].ToString() + " </a>";
                    strTemp += "                  </div>";
                    strTemp += "                <div class=\"text\">" + OP_Mode.Dtv[i]["classname"].ToString() + " </div>";
                    strTemp += "                 <div class=\"name\">";
                    strTemp += "                      <a href =\"/Dance/DelReserve.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-minier btn-info\">";
                    strTemp += "                          <i class=\"icon-calendar\"></i>取消预约";
                    strTemp += "                      </a>";
                    strTemp += "                   </div>";
                    strTemp += "               </div>";
                    strTemp += "           </div>";
                    strTemp += "           </div>";
                }
            }
            if (strTemp.Length > 0)
            {
                ArrangeList.InnerHtml = strTemp;
            }
        }
    }
    private void LoadAttend()
    {
        int iUserID;
        try
        {
            iUserID = Convert.ToInt32(Request.Cookies["Dance"]["USERID"]);

            // iUserID = 2;

            if (iUserID <= 0)
            {
                MessageBox("", "用户信息获取失败，请重试。", "/Dance/");
                return;
            }
        }
        catch
        {
            MessageBox("", "用户信息获取失败，请重试。", "/Dance/");
            return;
        }
        string strTemp = string.Empty;

        string strSQL = "Select * from Dance_ClassList where Userid=" + iUserID + " order by ClassTime";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strTemp += "  <div class=\"dialogs\">";
                    strTemp += "            <div class=\"itemdiv dialogdiv\">";
                    strTemp += "               <div class=\"user\">";
                    strTemp += "                   <img src =\"/images/DanceLogo.jpg\" />";
                    strTemp += "               </div >";
                    strTemp += "               <div class=\"body\">";
                    strTemp += "                 <div class=\"time\">";
                    strTemp += "                     <i class=\"icon-time\"></i>";
                    strTemp += "                      <span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["ClassTime"]).ToString() + "</ span > ";
                    strTemp += "                  </div>";
                    strTemp += "                  <div class=\"name\">";
                    strTemp += "                     <a href=\"#\"> " + OP_Mode.Dtv[i]["ClassTeacher"].ToString() + " </a>";
                    strTemp += "                  </div>";
                    strTemp += "                <div class=\"text\">" + OP_Mode.Dtv[i]["classname"].ToString() + " </div>";
                    strTemp += "               </div>";
                    strTemp += "           </div>";
                    strTemp += "           </div>";
                }
            }
            if (strTemp.Length > 0)
            {
                AttendList.InnerHtml = strTemp;
            }
        }
    }
}