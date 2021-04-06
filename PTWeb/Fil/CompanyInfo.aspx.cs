using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fil_Default3 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }

    }

    private void LoadData()
    {
        int iTest = 1;// 1为正式，否则为测试用户

        string strSQL = " declare @StartDate DATETIME = (Select min(EffectiveTime) from Fil_PowerComputer Where Test=" + iTest + ")";
        strSQL += " declare @EndDate DATETIME = getdate()";
        strSQL += " SELECT CONVERT(VARCHAR(100), dateadd(day, n.number, @StartDate), 23) AS every_time, a.*,(Select isnull(Sum(round(power/SumPower*Gift/180,4)),0) from vfil_gift where Test=" + iTest + " And DATEDIFF(DAY, LTime,  CONVERT (VARCHAR (100),dateadd(day,n.number,@StartDate),23))<180 and LTime<CONVERT (VARCHAR (100),dateadd(day,n.number,@StartDate),23))+isnull(a.DayRelease,0) Release FROM";
        strSQL += " master..spt_values n left join(Select gift, sumpower, ltime, sum(POWER) power, sum(Round(POWER / sumpower * Gift * 0.25 * 0.8, 4)) DayRelease, sum(Round(POWER / sumpower * Gift * 0.8, 4)) SumRelease from vfil_gift Where Test=" + iTest + " group by gift, sumpower, ltime) a on a.ltime = CONVERT(VARCHAR(100), dateadd(day, n.number, @StartDate), 23)";
        strSQL += " WHERE n.type = 'p' AND n.number <= DATEDIFF(day, @StartDate, @EndDate)";
        //NULL 
        // declare @StartDate DATETIME = (Select min(EffectiveTime) from Fil_PowerComputer where Test = 0) declare @EndDate DATETIME = getdate() SELECT CONVERT(VARCHAR(100), dateadd(day, n.number, @StartDate), 23) AS every_time, a.*,(Select isnull(Sum(round(power / SumPower * Gift / 180, 4)), 0) from vfil_gift where DATEDIFF(DAY, LTime, CONVERT(VARCHAR(100), dateadd(day, n.number, @StartDate), 23)) < 180 and LTime<CONVERT (VARCHAR (100),dateadd(day, n.number, @StartDate),23) and Test = 0)+isnull(a.DayRelease, 0) Release FROM master..spt_values n left join(Select gift, sumpower, ltime, sum(POWER) power, sum(Round(POWER / sumpower * Gift * 0.25 * 0.8, 4)) DayRelease, sum(Round(POWER / sumpower * Gift * 0.8, 4)) SumRelease from vfil_gift where Test = 0 group by gift, sumpower, ltime) a on a.ltime = CONVERT(VARCHAR(100), dateadd(day, n.number, @StartDate), 23) WHERE n.type = 'p' AND n.number <= DATEDIFF(day, @StartDate, @EndDate)


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
            if (OP_Mode.Dtv.Count > 0)
            {// 最新公司总算力
             //Label_SumPower.Text = OP_Mode.Dtv[OP_Mode.Dtv.Count - 1]["SumPower"].ToString();
             //// 公司总算力 - 已经生效的算力 = 公司掌握的实际算力。
             // Label_Release.Text = Convert.ToInt16(OP_Mode.Dtv[OP_Mode.Dtv.Count - 1]["Power"])).ToString();
             //// 公司矿工账户余额
             //Label2.Text = "0";
            }
            //售出可提现
            Label_Lock.Text = SumBalance.ToString();
            // 售出锁仓
            Label1.Text = (SumRelease - SumBalance).ToString();
        }

        strSQL = " Select ";
        strSQL += " (Select SUm(Power) from Fil_PowerComputer where Test=1 and EndTime>getdate()) as SumPower,";
        strSQL += " (Select top 1 SumPower from Fil_Summary order by id desc) as SumPowerAll,";
        strSQL += " (Select SUm(Power) from Fil_PowerComputer where Test=1 and EffectiveTime>getdate() and EndTime>getdate()) as EffectivePower,";
        strSQL += " (Select top 1 filye from Fil_Summary order by id desc) as Filye,";
        strSQL += " (Select top 1 Lock from Fil_Summary order by id desc) as Lock,";
        strSQL += " (Select sum(Power) from Fil_PowerComputer where EffectiveTime<getdate() and EndTime>getdate() and test=1) as Power";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label3.Text = OP_Mode.Dtv[0]["SumPower"].ToString();
                Label4.Text = OP_Mode.Dtv[0]["EffectivePower"].ToString();
                Label2.Text = OP_Mode.Dtv[0]["Filye"].ToString();
                Label_Withdraw.Text = OP_Mode.Dtv[0]["Lock"].ToString();
                Label_SumPower.Text = OP_Mode.Dtv[0]["SumPowerAll"].ToString();
                //// 公司总算力 - 已经生效的算力 = 公司掌握的实际算力。
                Label_Release.Text = (Convert.ToDecimal(OP_Mode.Dtv[0]["SumPowerAll"]) - Convert.ToDecimal(OP_Mode.Dtv[0]["Power"])).ToString();
            }
        }
    }
}