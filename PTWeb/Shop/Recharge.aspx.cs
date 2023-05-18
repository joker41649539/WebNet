using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
{
    int iWebID = 4;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(iWebID, DefaultUser))
            {
                MessageBox("", "您无查看此页面的权限。", "/Shop/");
                return;
            }
            else
            {
                //Label1.Text = GetIPToString();
                //  LoadSysSet();
            }
        }
    }

    /// <summary>
    /// 依据手机号查询数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strPhonNo = TextBox_PhoneNo.Text.Replace("'", "");
        HiddenField_PhoneNo.Value = "";
        if (strPhonNo.Length == 11)
        {
            string strSQL = "Select GoldCount,isnull((Select sum(Bance) from shop_Gold where UserNo=Shop_Userinfo.PhoneNo),0) Bance,isnull((Select sum(Bance) from shop_Gold where UserNo=Shop_Userinfo.PhoneNo and bance>0),0) BanceA,isnull((Select sum(Bance) from shop_Gold where UserNo=Shop_Userinfo.PhoneNo and bance<0),0) BanceD from Shop_Userinfo where PhoneNo='" + strPhonNo + "' and FLAG=0";
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    int iGolds = Convert.ToInt32(OP_Mode.Dtv[0]["GoldCount"]);
                    int iBance = Convert.ToInt32(OP_Mode.Dtv[0]["Bance"]);
                    int iBanceA = Convert.ToInt32(OP_Mode.Dtv[0]["BanceA"]);
                    int iBanceD = Convert.ToInt32(OP_Mode.Dtv[0]["BanceD"]);

                    if (iGolds != iBance)
                    {
                        Label1.Text = iGolds.ToString("0.00");
                        Label2.Text = iBanceA.ToString("0.00");
                        Label3.Text = iBanceD.ToString("0.00");
                        MessageBox("", "该账号数据异常，请联系管理员查看。");
                        HiddenField_PhoneNo.Value = "";
                        return;
                    }
                    else
                    {
                        Label1.Text = iBance.ToString("0.00");
                        Label2.Text = iBanceA.ToString("0.00");
                        Label3.Text = iBanceD.ToString("0.00");
                        HiddenField_PhoneNo.Value = strPhonNo;
                        strSQL = "Select * from shop_Gold where UserNo='" + strPhonNo + "' order by cTime desc";
                        if (OP_Mode.SQLRUN(strSQL))
                        {
                            if (OP_Mode.Dtv.Count > 0)
                            {
                                GridView1.DataSource = OP_Mode.Dtv;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
                else
                {
                    HiddenField_PhoneNo.Value = "";
                    MessageBox("", "未查询到任何数据，请检查手机号。");
                    return;
                }
            }
        }
    }

    /// <summary>
    /// 确认充值
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (!QXBool(iWebID, DefaultUser))
        {
            MessageBox("", "您无查看此页面的权限。", "/Shop/");
            return;
        }
        else
        {
            if (HiddenField_PhoneNo.Value.Length == 11)
            {
                string strOperatorIP = GetIPToString();

                string strSQL = " Insert into Shop_Gold (UserNo,Bance,Operator,OperatorIP,Event) values('" + HiddenField_PhoneNo.Value + "'," + TextBox_GoldCount.Text.Replace("'", "") + ",'" + DefaultUser + "','" + strOperatorIP + "','充值')";
                strSQL += " Update Shop_Userinfo set GoldCount=GoldCount+" + TextBox_GoldCount.Text.Replace("'", "") + " where PhoneNo='" + HiddenField_PhoneNo.Value + "' and FLAG=0";
                strSQL += " Select GoldCount,isnull((Select sum(Bance) from shop_Gold where UserNo=Shop_Userinfo.PhoneNo),0) Bance,isnull((Select sum(Bance) from shop_Gold where UserNo=Shop_Userinfo.PhoneNo and bance>0),0) BanceA,isnull((Select sum(Bance) from shop_Gold where UserNo=Shop_Userinfo.PhoneNo and bance<0),0) BanceD from Shop_Userinfo where PhoneNo='" + HiddenField_PhoneNo.Value + "' and FLAG=0";

                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        int iGolds = Convert.ToInt32(OP_Mode.Dtv[0]["GoldCount"]);
                        int iBance = Convert.ToInt32(OP_Mode.Dtv[0]["Bance"]);
                        int iBanceA = Convert.ToInt32(OP_Mode.Dtv[0]["BanceA"]);
                        int iBanceD = Convert.ToInt32(OP_Mode.Dtv[0]["BanceD"]);

                        if (iGolds != iBance)
                        {
                            Label1.Text = iGolds.ToString("0.00");
                            Label2.Text = iBanceA.ToString("0.00");
                            Label3.Text = iBanceD.ToString("0.00");
                            MessageBox("", "该账号数据异常，请联系管理员查看。");
                            HiddenField_PhoneNo.Value = "";
                            return;
                        }
                        else
                        {
                            Label1.Text = iBance.ToString("0.00");
                            Label2.Text = iBanceA.ToString("0.00");
                            Label3.Text = iBanceD.ToString("0.00");
                            HiddenField_PhoneNo.Value = "";
                            MessageBox("", "恭喜，账号充值成功。");
                            TextBox_GoldCount.Text = "";
                        }
                    }
                    else
                    {
                        HiddenField_PhoneNo.Value = "";
                        MessageBox("", "未查询到任何数据，请检查手机号。");
                        return;
                    }
                }
            }
            else
            {
                MessageBox("", "请先查询手机号信息，然后再充值。");
                return;
            }
        }
    }
}