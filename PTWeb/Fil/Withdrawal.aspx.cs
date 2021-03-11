using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fil_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDayGrid();
        }
    }


    private void LoadDayGrid()
    {
        int iUserID = 0;
        try
        {
            iUserID = Convert.ToInt32(Request.Cookies["WeChat_Yanwo"]["USERID"]);
        }
        catch
        {

        }
        if (iUserID == 0)
        {
            return;
        }

        string strSQL = " declare @StartDate DATETIME = (Select min(EffectiveTime) from Fil_PowerComputer where UserID=" + iUserID + ")";
        strSQL += " declare @EndDate DATETIME = getdate()";// +System.DateTime.Now.add;
        //strSQL += " declare @EndDate DATETIME = '2021-08-16'";
        strSQL += " SELECT CONVERT(VARCHAR(100), dateadd(day, n.number, @StartDate), 23) AS every_time, a.*,(Select isnull(Sum(round(power/SumPower*Gift/180,4)),0) from vfil_gift where DATEDIFF(DAY, LTime,  CONVERT (VARCHAR (100),dateadd(day,n.number,@StartDate),23))<180 and UserID=" + iUserID + " and LTime<CONVERT (VARCHAR (100),dateadd(day,n.number,@StartDate),23))+isnull(a.DayRelease,0) Release FROM";
        strSQL += " master..spt_values n left join(Select gift, sumpower, ltime, sum(POWER) power, sum(Round(POWER / sumpower * Gift * 0.25, 4)) DayRelease, sum(Round(POWER / sumpower * Gift, 4)) SumRelease from vfil_gift where userid = " + iUserID.ToString() + " group by gift, sumpower, ltime) a on a.ltime = CONVERT(VARCHAR(100), dateadd(day, n.number, @StartDate), 23)";
        strSQL += " WHERE n.type = 'p' AND n.number <= DATEDIFF(day, @StartDate, @EndDate)";

        // OP_Mode.Dtv = new;
        if (OP_Mode.SQLRUN(strSQL))
        {
            double SumBalance = 0;
            double SumRelease = 0;
            for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            { // 计算合计信息
                if (OP_Mode.Dtv[i]["Release"].ToString().Length > 0)
                {
                    SumBalance += Convert.ToDouble(OP_Mode.Dtv[i]["Release"]);
                }
                if (OP_Mode.Dtv[i]["SumRelease"].ToString().Length > 0)
                {
                    SumRelease += Convert.ToDouble(OP_Mode.Dtv[i]["SumRelease"]);
                }
            }
            //if (OP_Mode.Dtv.Count > 0)
            //{
            //    DataRowView rowView = OP_Mode.Dtv.AddNew();
            //    rowView["every_time"] = SumRelease.ToString();
            //    rowView["Release"] = SumBalance.ToString();
            //    OP_Mode.Dtv.AddNew();
            //}
            Label_Release.Text = SumBalance.ToString();
            //Label_Lock.Text = (SumRelease - SumBalance).ToString();
            //Label_SumFil.Text = SumRelease.ToString();
            //for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            //{

            //}

            //for (DateTime dt = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day); dt >= new DateTime(startTime.Year, startTime.Month, startTime.Day); dt = dt.AddDays(-1))
            //{
            //    DataRowView rowView = OP_Mode.Dtv.AddNew();
            //    rowView["LTime"] = dt.ToString("yyyy-MM-dd");
            //    rowView["DayRelease"] = 0;
            //}
        }

    }
}