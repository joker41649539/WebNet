using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Manage_SendMsg : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            int Classid = Convert.ToInt32(Request["CID"]);
            if (Classid > 0)
            {
                SendMSGByClassID(Classid);
            }
            else
            {
                MessageBox("", "群发班级ID获取错误，群发失败。", "/XMFight/Manage/Class.aspx");
                return;
            }
        }
        catch
        {
            MessageBox("", "群发班级ID获取错误，群发失败。", "/XMFight/Manage/Class.aspx");
            return;
        }

    }

    private void SendMSGByClassID(int ClassID)
    {
        string Openids = string.Empty;
        string strSQL = "Select OpenID,Name,STime,ETime,Week from XMFight_Class_Student,XMFight_Student,XMFight_ClassTime where ClassID=" + ClassID + " and StudentID=XMFight_Student.ID and ClassID=XMFight_ClassTime.ID and len(OpenID)>0";
        if (OP_Mode.SQLRUN(strSQL,"Msg"))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int ii = 0; ii < OP_Mode.Dtv1.Count; ii++)
                {
                    Openids = OP_Mode.Dtv1[ii]["OpenID"].ToString();
                    string strSKSC = "1.5 小时";// 上课时长
                    if (Openids.Length > 5)
                    {
                        string strSKSJ = SKSJ(Convert.ToInt32(OP_Mode.Dtv1[ii]["Week"]), Convert.ToDateTime(OP_Mode.Dtv1[ii]["STime"]).ToString("HH:mm"), Convert.ToDateTime(OP_Mode.Dtv1[ii]["ETime"]).ToString("HH:mm"));//上课时间
                        string[] strArray = Openids.Split(';');
                        for (int i = 0; i < strArray.Length; i++)
                        {/// 循环给用户发送信息
                            SendSKTXMsg(strArray[i], OP_Mode.Dtv1[ii]["Name"].ToString(), "自由搏击", strSKSJ, strSKSC, "谢谢您对旭铭搏击的支持，坚持不懈是一种非常好的习惯。", "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf60778eb4d1003de&redirect_uri=http%3A%2F%2Fptweb.x76.com.cn%2FXMFight&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
                        }
                    }
                }
                MessageBox("", "班级群发成功。", "/XMFight/Manage/Class.aspx");
                return;
            }
        }
    }

    private string SKSJ(int iWeek, string STime, string ETime)
    {
        string rValue = string.Empty;
        int TodayWeek = 0;
        string dt;
        dt = DateTime.Today.DayOfWeek.ToString();
        switch (dt)
        {
            case "Monday":
                TodayWeek = 1;
                break;
            case "Tuesday":
                TodayWeek = 2;
                break;
            case "Wednesday":
                TodayWeek = 3;
                break;
            case "Thursday":
                TodayWeek = 4;
                break;
            case "Friday":
                TodayWeek = 5;
                break;
            case "Saturday":
                TodayWeek = 6;
                break;
            case "Sunday":
                TodayWeek = 7;
                break;
        }

        if (TodayWeek == iWeek)
        {
            rValue = System.DateTime.Now.ToString("MM-dd dddd") + " 今天";
        }
        else
        {
            rValue = System.DateTime.Now.AddDays(1).ToString("MM-dd dddd") + " 明天";
        }

        rValue += " " + STime + " - " + ETime;

        return rValue;

    }
}