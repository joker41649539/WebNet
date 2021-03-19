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
        int iID = 0;
        try
        {
            iID = Convert.ToInt32(Request["ID"]);
        }
        catch
        {
            MessageBox("", "错误的参数。", "/Dance/");
            return;
        }
        if (iID > 0)
        {
            LoadDefaultData(iID);
        }
        else
        {
            MessageBox("", "错误的参数。", "/Dance/");
            return;
        }
    }
    /// <summary>
    /// 加载基础数据
    /// </summary>
    private void LoadDefaultData(int IID)
    {
        string strWeek_Now = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(DateTime.Now.DayOfWeek);
        string strSQL = "Select ID,classname,ClassTeacher,CONVERT(varchar(100), ClassTimeStart, 24) STime,CONVERT(varchar(100), ClassTimeEnd, 24) ETime,ClassWeek,MaxMen,(Select Count(ID) from Dance_Arrange where classID=Dance_Class.ID) ArrAngeCount from Dance_Class where Flag=0 and ID=" + IID.ToString();

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string strWeek = OP_Mode.Dtv[0]["ClassWeek"].ToString();
                Label_DataTime.Text = Convert.ToDateTime(OP_Mode.Dtv[0]["STime"].ToString()).AddDays(CountWeek(strWeek_Now, strWeek)).ToString("yyyy-MM-dd") + " " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(Convert.ToDateTime(OP_Mode.Dtv[0]["STime"].ToString()).AddDays(CountWeek(strWeek_Now, strWeek)).DayOfWeek);
                Label_Time.Text = OP_Mode.Dtv[0]["STime"].ToString().Substring(0, 5) + " - " + OP_Mode.Dtv[0]["ETime"].ToString().Substring(0, 5);
                Label_Teacher.Text = OP_Mode.Dtv[0]["ClassTeacher"].ToString();
                Label_ClassName.Text = OP_Mode.Dtv[0]["classname"].ToString();
                Label_NowNo.Text = OP_Mode.Dtv[0]["ArrAngeCount"].ToString();
                Label_MaxNo.Text = OP_Mode.Dtv[0]["MaxMen"].ToString();
                LoadUserList(IID);
            }
        }
    }
    /// <summary>
    /// 加载预约列表
    /// </summary>
    private void LoadUserList(int iid)
    {
        DateTime Days = Convert.ToDateTime(Label_DataTime.Text);
        string strSQL = "Select Dance_Arrange.ID,Nick,HeadImage,Dance_Arrange.LTime from Dance_Arrange,Dance_User where classID = " + iid + " and ArrangeTime = '" + Days.ToString("yyyy-MM-dd") + "' and userid = Dance_User.id";
        if (OP_Mode.SQLRUN(strSQL))
        {
            this.GridView_List.DataSource = OP_Mode.Dtv;

            this.GridView_List.DataBind();
        }
        else
        {
            MessageBox("", "错误：" + OP_Mode.strErrMsg);
        }
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

    /// <summary>
    /// 确定预约
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Label_NowNo.Text) >= Convert.ToInt32(Label_MaxNo.Text))
        {
            MessageBox("", "课程已经预约满了。");
            return;
        }

        try
        {
            int iClassID = Convert.ToInt32(Request["ID"]);
            int iUserID = Convert.ToInt32(Response.Cookies["Dance"]["USERID"]);

            DateTime Days = Convert.ToDateTime(Label_DataTime.Text);

            string strSQL = "Select ID From Dance_Arrange where ClassID=" + iClassID + " and UserID=" + iUserID + " and ArrangeTime='" + Days + "'";

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count == 0)
                {
                    strSQL = "Insert into Dance_Arrange (ClassID,UserID,ArrangeTime) values (" + iClassID + "," + iUserID + ",'" + Days + "')";
                    if (OP_Mode.SQLRUN(strSQL))
                    {
                        MessageBox("", "恭喜，您已预约成功。<br/>请记得准时来上课哟。", "/Dance/");
                    }
                    else
                    {
                        MessageBox("", "预约失败，请重试。<br/>错误：" + OP_Mode.strErrMsg, "/Dance/");
                    }
                }
                else
                {
                    MessageBox("", "您已经预约过该课程了，请不要重复预约。", "/Dance/");
                    return;
                }
            }
        }
        catch
        {
            MessageBox("", "预约失败，请重试。<br/>错误：错误的参数信息。", "/Dance/");
        }
    }
}