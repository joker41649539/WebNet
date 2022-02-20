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
            TextBox2.Text = "2021-09-01";
            TextBox3.Text = "2021-10-01";
        }
    }

    /// <summary>
    /// 模拟开始
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Test(Convert.ToInt32(TextBox1.Text), TextBox2.Text, TextBox3.Text);
    }
    double[] intZMLRZ = new double[] { 9.5, 37.5, 44.5, 67.5, 55 }; // 注码
    double[] intZMLRX = new double[] { 10, 40, 50, 80, 80 }; // 注码
    double[] intDM = new double[] { 10, 50, 170, 420, 920 }; // 打码量

    double lostLR = 920;//{ 10, 50, 110, 250, 500 }

    int strZMSN = 11;// 开始下注注码需要，等于为算。
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
                            if (BoolTrue(TempLu.Substring(iLu, 1)))
                            {/// 下中了，处理

                                if ((iZmSN - strZMSN) > -1)
                                {
                                    if (TempLu.Substring(iLu, 1) == "庄")
                                    {
                                        DWiner += intZMLRZ[(iZmSN - strZMSN)];
                                        DDML += intDM[(iZmSN - strZMSN)] * 0.95;
                                    }
                                    else
                                    {
                                        DWiner += intZMLRX[(iZmSN - strZMSN)];
                                        DDML += intDM[(iZmSN - strZMSN)];
                                    }

                                    if (DWiner > MaxWiner)
                                    {/// 记录最大值
                                        MaxWiner = DWiner;
                                        MaxDML = DDML;
                                    }
                                }
                                if (iZmSN > maxJTSN)
                                {/// 记录注码SN
                                    maxJTSN = iZmSN;
                                }
                                iZmSN = 0;
                            }
                            else
                            {/// 没下中处理
                                if (TempLu.Substring(iLu, 1) != "和")
                                {///
                                    iZmSN += 1;// 注码+1
                                    if ((iZmSN - strZMSN) >= intZMLRX.Length)
                                    {/// 炸了，扣除利润
                                        DWiner -= lostLR;
                                        iBao += 1;
                                        DDML += lostLR;
                                        iZmSN = 0;
                                    }
                                    if (DWiner < MinWiner)
                                    {// 记录最小值
                                        MinWiner = DWiner;
                                        MinDML = DDML;
                                    }
                                }
                            }

                            if (DWiner > 3000 || DWiner < -1500)
                            {
                                TextBox_Remark.Text = "累计利润：" + DWiner + "\r\n";
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
        TextBox_Remark.Text += "最高利润：" + MaxWiner + "\r\n";
        TextBox_Remark.Text += "最高打码：" + MaxDML + "\r\n";
        TextBox_Remark.Text += "最低利润：" + MinWiner + "\r\n";
        TextBox_Remark.Text += "最低打码：" + MinDML + "\r\n";
        TextBox_Remark.Text += "爆：" + iBao + "\r\n";
        TextBox_Remark.Text += "计算：" + TempCount + " 次\r\n";
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