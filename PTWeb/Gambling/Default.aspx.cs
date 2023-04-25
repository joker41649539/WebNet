using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Gambling_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        double Odds1 = 0, Odds2 = 0; double Odds3 = 0;
        if (TextBox_Odds1.Text.Length > 0)
        {
            Odds1 = Convert.ToDouble(TextBox_Odds1.Text);
        }
        if (TextBox_Odds2.Text.Length > 0)
        {
            Odds2 = Convert.ToDouble(TextBox_Odds2.Text);
        }
        if (TextBox_Odds3.Text.Length > 0)
        {
            Odds3 = Convert.ToDouble(TextBox_Odds3.Text);
        }
        OddsCount(Odds1, Odds2, Odds3);
    }

    private void OddsCount(double Odds1, double Odds2, double Odds3)
    {
        int DoubleCount = 100;
        double SumOdds = Odds1 + Odds2 + Odds3;

        double BetCount1 = 0, BetCount2 = 0, BetCount3 = 0, SumBetCount = 0;

        double WinCount1 = 0, WinCount2 = 0, WinCount3 = 0;

        if (Odds1 > 0)
        {
            BetCount1 = Math.Ceiling(SumOdds / Odds1 * DoubleCount);
        }
        if (Odds2 > 0)
        {
            BetCount2 = Math.Ceiling(SumOdds / Odds2 * DoubleCount);
        }
        if (Odds3 > 0)
        {
            BetCount3 = Math.Ceiling(SumOdds / Odds3 * DoubleCount);
        }

        SumBetCount = BetCount1 + BetCount2 + BetCount3;

        WinCount1 = Math.Ceiling(BetCount1 * Odds1);
        WinCount2 = Math.Ceiling(BetCount2 * Odds2);
        WinCount3 = Math.Ceiling(BetCount3 * Odds3);

        string TempMSG = string.Empty;
        double WinPercent = Math.Ceiling(((WinCount1 + WinCount2 + WinCount3) / 3 - SumBetCount) * 100 / SumBetCount);

        TempMSG += "Bet1:" + BetCount1.ToString() + " Win1:" + WinCount1.ToString() + " Win:" + (WinCount1 - SumBetCount).ToString() + "\r\n";
        TempMSG += "Bet2:" + BetCount2.ToString() + " Win2:" + WinCount2.ToString() + " Win:" + (WinCount2 - SumBetCount).ToString() + "\r\n";
        if (Odds3 > 0)
        {
            TempMSG += "Bet3:" + BetCount3.ToString() + " Win3:" + WinCount3.ToString() + " Win:" + (WinCount3 - SumBetCount).ToString() + "\r\n";
        }
        TempMSG += "SunBet:" + SumBetCount + " WinPercent:" + WinPercent.ToString() + " % \r\n";

        if (WinPercent > 0)
        {
            TempMSG += "可以推荐^_^ WinPercent:" + WinPercent.ToString() + " % \r\n";
        }
        else
        {
            TempMSG += "放弃。 WinPercent: " + WinPercent.ToString() + " % \r\n";
        }

        TextBox_Remark.Text = TempMSG;
    }
}