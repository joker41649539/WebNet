using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (DefaultUser != null)
            {
                LoadData(DefaultUser);
            }
            else
            {
                // MessageBox("", "您还未登录，无法查看该页面。", "/Shop/Login.aspx");
            }
        }
    }

    private void LoadData(string strPhoneNo)
    {
        string strSQL = "Select *,(Select Count(ID) From Shop_Address where UserNo=Shop_UserInfo.PhoneNo) AddressCount from Shop_UserInfo where PhoneNo='" + strPhoneNo + "' and Flag=0";
        string sIMGWeChat = string.Empty;
        string sIMGPay = string.Empty;
        string sBankName = string.Empty;
        string sBankStart = string.Empty;
        string sBankID = string.Empty;
        string strCNmae = string.Empty;

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                double GoldCount = 0;
                bool BankMSG = false;
                bool AddressMSG = false;
                int AddressCount = 0;
                sIMGWeChat = OP_Mode.Dtv[0]["WeChatImg"].ToString();
                sIMGPay = OP_Mode.Dtv[0]["PayImg"].ToString();
                sBankName = OP_Mode.Dtv[0]["BankName"].ToString();
                sBankStart = OP_Mode.Dtv[0]["BankStart"].ToString();
                sBankID = OP_Mode.Dtv[0]["BankID"].ToString();
                strCNmae = OP_Mode.Dtv[0]["CName"].ToString();
                AddressCount = Convert.ToInt32(OP_Mode.Dtv[0]["AddressCount"]);
                GoldCount = Convert.ToDouble(OP_Mode.Dtv[0]["GoldCount"]);

                if (sIMGWeChat.Length > 0 || sIMGPay.Length > 0 || (sBankID.Length + sBankName.Length + sBankID.Length + strCNmae.Length) > 0)
                {
                    BankMSG = true;
                }
                if (AddressCount > 0)
                {
                    AddressMSG = true;
                }

                /// 更新Cookie
                /// 
                ResponseCokie(strPhoneNo, BankMSG, AddressMSG, GoldCount);

                if (sIMGWeChat.Length > 0)
                {
                    Image_WeChat.ImageUrl = "/Shop/Img/" + sIMGWeChat;
                }
                if (sIMGPay.Length > 0)
                {
                    Image_Pay.ImageUrl = "/Shop/Img/" + sIMGPay;
                }
                TextBox1.Text = sBankName;
                TextBox2.Text = sBankStart;
                TextBox3.Text = sBankID;
                TextBox4.Text = strCNmae;
            }
        }
    }

    protected void LinkButton_Pay_Click(object sender, EventArgs e)
    {
        HttpPostedFile f = Request.Files[1];
        string strImg = UploadTPs(f, 0, "Pay");
        if (strImg.Length > 0 & DefaultUser != null)
        {
            string strSQL = "Update Shop_UserInfo Set PayImg='" + strImg + "',LTime=getdate() where PhoneNo='" + DefaultUser + "' and Flag=0";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("支付宝收款码更新成功。");
                LoadData(DefaultUser);
                return;
            }
        }
    }

    protected void LinkButton_WeChat_Click(object sender, EventArgs e)
    {
        HttpPostedFile f = Request.Files[0];
        string strImg = UploadTPs(f, 0, "WeChat");
        if (strImg.Length > 0 & DefaultUser != null)
        {
            string strSQL = "Update Shop_UserInfo Set WeChatImg='" + strImg + "',LTime=getdate() where PhoneNo='" + DefaultUser + "' and Flag=0";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("微信收款码更新成功。");
                LoadData(DefaultUser);
                return;
            }
        }
    }

    protected void LinkButton_Bank_Click(object sender, EventArgs e)
    {
        string sBankName = TextBox1.Text.Replace("'", "");
        string sBankStart = TextBox2.Text.Replace("'", "");
        string sBankID = TextBox3.Text.Replace("'", "");
        string sCName = TextBox4.Text.Replace("'", "");

        if (sBankName.Length > 0 && sBankStart.Length > 0 && sBankID.Length > 0 & sCName.Length > 0)
        {
            string strSQL = "Update Shop_UserInfo Set BankName='" + sBankName + "',CName='" + sCName + "',BankStart='" + sBankStart + "',BankID='" + sBankID + "',LTime=getdate() where PhoneNo='" + DefaultUser + "' and Flag=0";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("银行账号更新成功。");
                LoadData(DefaultUser);
                return;
            }
        }
    }



}