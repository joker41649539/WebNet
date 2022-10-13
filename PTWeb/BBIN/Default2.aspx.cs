using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BBIN_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox2.Text = "2021-08-01";
            TextBox3.Text = "2021-09-01";
        }
    }

    /// <summary>
    /// 模拟开始
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Test(Convert.ToInt32(TextBox1.Text), TextBox2.Text, TextBox3.Text);
        TextBox_Remark.Text = DateTimeByWeekAndDay(1).ToString("yyyy-MM-dd");
    }

    public static DateTime DateTimeByWeekAndDay(int day)
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

    public static int WeekOfMonth()
    {
        DateTime dtSel = System.DateTime.Now;
        //如果要判断的日期为1号，则肯定是第一周了
        if (dtSel.Day == 1)
            return 1;
        else
        {
            //得到本月第一天
            DateTime dtStart = new DateTime(dtSel.Year, dtSel.Month, 1);
            //得到本月第一天是周几
            int dayofweek = (int)dtStart.DayOfWeek;

            ////如果不是以周日开始，需要重新计算一下dayofweek，详细风DayOfWeek枚举的定义
            //if (!sundayStart)
            //{
            //    dayofweek = dayofweek - 1;

            //    if (dayofweek < 0)
            //        dayofweek = 7;
            //}

            //得到本月的第一周一共有几天
            int startWeekDays = 7 - dayofweek;

            //如果要判断的日期在第一周范围内，返回1
            if (dtSel.Day <= startWeekDays)
                return 1;
            else
            {
                int aday = dtSel.Day + 7 - startWeekDays;
                return aday / 7 + (aday % 7 > 0 ? 1 : 0);
            }
        }
    }


    double[] intZM = new double[] { 10, 50, 110, 250, 500 }; // 打码量

    double lostLR = 920;//{ 10, 50, 110, 250, 500 }

    int strZMSN = 15;// 开始下注注码需要，等于为算。
    int iBao = 0;// 炸次数
    int maxJTSN = 0;// 最大解套序号
    double DWiner = 0; ///累计利润
    double DDML = 0; ///累计打码量
    double MaxWiner = 0; /// 最高利润
    double MaxDML = 0;
    double MinWiner = 0; /// 最低利润
    double MinDML = 0;

    int TempCount = 0; ///计数
                       /// <summary>
                       /// 套路
                       /// </summary>
                       /// <param name="iCount">每个套路循环次数</param>
                       /// <param name="sTime">开始日期</param>
                       /// <param name="eTime">截止日期</param>
    private void Test(int iCount, string sTime, string eTime)
    {
        int iZmSN = 0;
        string TempLu = string.Empty;
        for (int j = 0; j < iCount; j++)
        { /// 但套路循环
            string strSQL = "Select * from NewHundredLu where CTIME between '" + sTime + "' and '" + eTime + "'";
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                    {/// 按路子循环
                        TempLu = OP_Mode.Dtv[i]["LU"].ToString();
                        for (int iLu = 0; iLu < TempLu.Length; iLu++)
                        {
                            string TempPlay = string.Empty;

                            TempPlay = AllPlay();// 下注全闲

                            if (TempPlay != "无")
                            {/// 下注操作

                                if (CheckBox1.Checked)
                                {// 反下
                                    /// 下注操作，扣除利润
                                    if ((iZmSN - strZMSN) > -1)
                                    {
                                        /// 扣除利润
                                        DWiner = DWiner - intZM[(iZmSN - strZMSN)];
                                        /// 增加打码量
                                        DDML = DDML + intZM[(iZmSN - strZMSN)];

                                        if (DWiner < MinWiner)
                                        {// 记录最小值
                                            MinWiner = DWiner;
                                            MinDML = DDML;
                                        }
                                    }

                                    /// 判断输赢
                                    if (TempLu.Substring(iLu, 1) == "庄")
                                    {
                                        if (TempPlay == "庄")
                                        { /// 下中了
                                            if ((iZmSN - strZMSN) > -1)
                                            {// 获得庄的利润
                                                DWiner = DWiner + intZM[(iZmSN - strZMSN)] * 1.95;
                                                ///中庄扣除5%的打码量
                                                DDML = DDML - intZM[(iZmSN - strZMSN)] * 0.05;
                                            }
                                            if (DWiner > MaxWiner)
                                            {// 记录最大值
                                                MaxWiner = DWiner;
                                                MaxDML = DDML;
                                            }
                                            if (iZmSN > maxJTSN)
                                            {/// 记录注码SN
                                                maxJTSN = iZmSN;
                                            }
                                            iZmSN++;// 增加

                                            if ((iZmSN - strZMSN) >= intZM.Length)
                                            { // 炸了
                                                if (iZmSN > maxJTSN)
                                                {/// 记录注码SN
                                                    maxJTSN = iZmSN;
                                                }
                                                iBao += 1;
                                                iZmSN = 0;
                                            }
                                        }
                                        else
                                        { // 没下中
                                            iZmSN = 0; // 增加注码序号
                                        }
                                    }
                                    else if (TempLu.Substring(iLu, 1) == "闲")
                                    {
                                        if (TempPlay == "闲")
                                        { /// 下中了
                                            if ((iZmSN - strZMSN) > -1)
                                            {// 获得庄的利润
                                                DWiner = DWiner + intZM[(iZmSN - strZMSN)] * 2;
                                            }
                                            if (DWiner > MaxWiner)
                                            {// 记录最大值
                                                MaxWiner = DWiner;
                                                MaxDML = DDML;
                                            }
                                            if (iZmSN > maxJTSN)
                                            {/// 记录注码SN
                                                maxJTSN = iZmSN;
                                            }
                                            iZmSN++;// 复位下注注码
                                            if ((iZmSN - strZMSN) >= intZM.Length)
                                            { // 炸了
                                                if (iZmSN > maxJTSN)
                                                {/// 记录注码SN
                                                    maxJTSN = iZmSN;
                                                }
                                                iBao += 1;
                                                iZmSN = 0;
                                            }
                                        }
                                        else
                                        { // 没下中
                                            iZmSN = 0; // 增加注码序号
                                        }
                                    }
                                    else if (TempLu.Substring(iLu, 1) == "和")
                                    {
                                        if ((iZmSN - strZMSN) > -1)
                                        {// 增加利润
                                            DWiner = DWiner + intZM[(iZmSN - strZMSN)];
                                            ///扣除打码
                                            DDML = DDML - intZM[(iZmSN - strZMSN)];
                                        }
                                    }
                                }
                                else
                                {// 正下

                                    /// 下注操作，扣除利润
                                    if ((iZmSN - strZMSN) > -1)
                                    {
                                        /// 扣除利润
                                        DWiner = DWiner - intZM[(iZmSN - strZMSN)];
                                        /// 增加打码量
                                        DDML = DDML + intZM[(iZmSN - strZMSN)];

                                        if (DWiner < MinWiner)
                                        {// 记录最小值
                                            MinWiner = DWiner;
                                            MinDML = DDML;
                                        }
                                    }

                                    /// 判断输赢
                                    if (TempLu.Substring(iLu, 1) == "庄")
                                    {
                                        if (TempPlay == "庄")
                                        { /// 下中了
                                            if ((iZmSN - strZMSN) > -1)
                                            {// 获得庄的利润
                                                DWiner = DWiner + intZM[(iZmSN - strZMSN)] * 1.95;
                                                ///中庄扣除5%的打码量
                                                DDML = DDML - intZM[(iZmSN - strZMSN)] * 0.05;
                                            }
                                            if (DWiner > MaxWiner)
                                            {// 记录最大值
                                                MaxWiner = DWiner;
                                                MaxDML = DDML;
                                            }
                                            if (iZmSN > maxJTSN)
                                            {/// 记录注码SN
                                                maxJTSN = iZmSN;
                                            }
                                            iZmSN = 0;// 复位下注注码
                                        }
                                        else
                                        { // 没下中
                                            iZmSN++; // 增加注码序号
                                            if ((iZmSN - strZMSN) >= intZM.Length)
                                            { // 炸了
                                                if (iZmSN > maxJTSN)
                                                {/// 记录注码SN
                                                    maxJTSN = iZmSN;
                                                }
                                                iBao += 1;
                                                iZmSN = 0;
                                            }
                                        }
                                    }
                                    else if (TempLu.Substring(iLu, 1) == "闲")
                                    {
                                        if (TempPlay == "闲")
                                        { /// 下中了
                                            if ((iZmSN - strZMSN) > -1)
                                            {// 获得庄的利润
                                                DWiner = DWiner + intZM[(iZmSN - strZMSN)] * 2;
                                            }
                                            if (DWiner > MaxWiner)
                                            {// 记录最大值
                                                MaxWiner = DWiner;
                                                MaxDML = DDML;
                                            }
                                            if (iZmSN > maxJTSN)
                                            {/// 记录注码SN
                                                maxJTSN = iZmSN;
                                            }
                                            iZmSN = 0;// 复位下注注码
                                        }
                                        else
                                        { // 没下中
                                            iZmSN++; // 增加注码序号
                                            if ((iZmSN - strZMSN) >= intZM.Length)
                                            { // 炸了
                                                if (iZmSN > maxJTSN)
                                                {/// 记录注码SN
                                                    maxJTSN = iZmSN;
                                                }
                                                iBao += 1;
                                                iZmSN = 0;
                                            }
                                        }
                                    }
                                    else if (TempLu.Substring(iLu, 1) == "和")
                                    {
                                        if ((iZmSN - strZMSN) > -1)
                                        {// 增加利润
                                            DWiner = DWiner + intZM[(iZmSN - strZMSN)];
                                            ///扣除打码
                                            DDML = DDML - intZM[(iZmSN - strZMSN)];
                                        }
                                    }
                                }

                            }
                            if (DWiner > 3000 || DWiner < -1500)
                            {
                                TextBox_Remark.Text = "累计利润：" + DWiner + "\r\n";
                                TextBox_Remark.Text += "累计打码：" + DDML + "\r\n";
                                TextBox_Remark.Text += "最高利润：" + MaxWiner + "\r\n";
                                TextBox_Remark.Text += "最高打码：" + MaxDML + "\r\n";
                                TextBox_Remark.Text += "最低利润：" + MinWiner + "\r\n";
                                TextBox_Remark.Text += "最低打码：" + MinDML + "\r\n";
                                TextBox_Remark.Text += "爆：" + iBao + "\r\n";
                                TextBox_Remark.Text += "最大注码：" + maxJTSN + "\r\n";
                                TextBox_Remark.Text += "计算：" + TempCount + " 次\r\n";
                                return;
                            }
                        }
                    }
                }
            }
        }

        TextBox_Remark.Text = "累计利润：" + DWiner + "\r\n";
        TextBox_Remark.Text += "累计打码：" + DDML + "\r\n";
        TextBox_Remark.Text += "最高利润：" + MaxWiner + "\r\n";
        TextBox_Remark.Text += "最高打码：" + MaxDML + "\r\n";
        TextBox_Remark.Text += "最低利润：" + MinWiner + "\r\n";
        TextBox_Remark.Text += "最低打码：" + MinDML + "\r\n";
        TextBox_Remark.Text += "最大注码：" + maxJTSN + "\r\n";
        TextBox_Remark.Text += "爆：" + iBao + "\r\n";
        TextBox_Remark.Text += "计算：" + TempCount + " 次\r\n";
    }

    /// <summary>
    /// 光下P
    /// </summary>
    /// <returns></returns>
    private string AllPlay()
    {
        string rValue = "无";
        Random rd = new Random();
        int RanI = rd.Next(0, 100);// (生成0~100之间的随机数，不包括100)

        if (RanI > 52)
        { //
            rValue = "无";
        }
        else
        {
            TempCount += 1;
            rValue = "闲";
        }
        return rValue;
    }

    private bool BoolTrue(string Zhuang)
    {
        bool rValue = false;
        Random rd = new Random();
        int RanI = rd.Next(0, 100);// (生成0~100之间的随机数，不包括100)

        if (RanI > 52)
        { //
            if (Zhuang == "庄")
            {
                rValue = true;
            }
        }
        else
        {
            if (Zhuang == "闲")
            {
                rValue = true;
            }
        }
        TempCount += 1;
        return rValue;
    }
}