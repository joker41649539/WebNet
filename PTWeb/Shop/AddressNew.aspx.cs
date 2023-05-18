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
                try
                {
                    int DelID = Convert.ToInt32(Request["Del"]);
                    int iID = Convert.ToInt32(Request["ID"]);

                    if (DelID == iID)
                    {
                        /// 执行删除操作
                        DelAddress(DelID);
                    }
                    else if (iID > 0)
                    { /// 修改操作
                        LoadData(iID);
                    }
                }
                catch
                {
                }
            }
        }
    }

    /// <summary>
    /// 删除指定的地址信息
    /// </summary>
    /// <param name="AddressID"></param>
    private void DelAddress(int AddressID)
    {
        if (AddressID > 0)
        {
            string strSQL = "Delete from Shop_Address where UserNo='" + DefaultUser + "' and ID=" + AddressID.ToString();
            strSQL += " Select *,(Select Count(ID) From Shop_Address where UserNo=Shop_UserInfo.PhoneNo) AddressCount from Shop_UserInfo where PhoneNo='" + DefaultUser + "' and Flag=0";
            if (OP_Mode.SQLRUN(strSQL))
            {
                string sIMGWeChat = string.Empty;
                string sIMGPay = string.Empty;
                string sBankName = string.Empty;
                string sBankStart = string.Empty;
                string sBankID = string.Empty;

                double GoldCount = 0;
                bool BankMSG = false;
                bool AddressMSG = false;
                int AddressCount = 0;
                sIMGWeChat = OP_Mode.Dtv[0]["WeChatImg"].ToString();
                sIMGPay = OP_Mode.Dtv[0]["PayImg"].ToString();
                sBankName = OP_Mode.Dtv[0]["BankName"].ToString();
                sBankStart = OP_Mode.Dtv[0]["BankStart"].ToString();
                sBankID = OP_Mode.Dtv[0]["BankID"].ToString();
                AddressCount = Convert.ToInt32(OP_Mode.Dtv[0]["AddressCount"]);
                GoldCount = Convert.ToDouble(OP_Mode.Dtv[0]["GoldCount"]);

                if (sIMGWeChat.Length > 0 || sIMGPay.Length > 0 || (sBankID.Length + sBankName.Length + sBankID.Length) > 0)
                {
                    BankMSG = true;
                }
                if (AddressCount > 0)
                {
                    AddressMSG = true;
                }

                /// 更新Cookie
                /// 
                ResponseCokie(DefaultUser, BankMSG, AddressMSG, GoldCount);

                MessageBox("", "您指定的收货地址删除成功。", "/Shop/Address.aspx");
                return;
            }
        }
    }

    private void LoadData(int AddressID)
    {
        if (AddressID > 0)
        {
            string strSQL = "Select * from Shop_Address where UserNo='" + DefaultUser + "' and ID=" + AddressID.ToString();
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    TextBox1.Text = OP_Mode.Dtv[0]["Contacts"].ToString();
                    TextBox2.Text = OP_Mode.Dtv[0]["ContactsTel"].ToString();
                    TextBox3.Text = OP_Mode.Dtv[0]["AddressInfo"].ToString();
                    HiddenField_AddressID.Value = AddressID.ToString();
                }
                else
                {
                    MessageBox("", "用户地址信息获取错误。", "/Shop/Address.aspx");
                }
            }
        }
    }

    /// <summary>
    /// 添加新地址
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string Contacts = TextBox1.Text.Replace("'", "");
        string PhoneNo = TextBox2.Text.Replace("'", "");
        string Address = TextBox3.Text.Replace("'", "");
        if (DefaultUser.Length == 11)
        {
            string strSQL = String.Empty;
            if (HiddenField_AddressID.Value.Length <= 0)
            {
                strSQL = "Insert into Shop_Address (UserNo,AddressInfo,Contacts,ContactsTel) values ('" + DefaultUser + "','" + Address + "','" + Contacts + "','" + PhoneNo + "')";
            }
            else
            {
                strSQL = "Update Shop_Address set AddressInfo='" + Address + "',Contacts='" + Contacts + "',ContactsTel='" + PhoneNo + "',LTime=getdate() where UserNo='" + DefaultUser + "' and ID=" + HiddenField_AddressID.Value;
            }
            strSQL += " Select *,(Select Count(ID) From Shop_Address where UserNo=Shop_UserInfo.PhoneNo) AddressCount from Shop_UserInfo where PhoneNo='" + DefaultUser + "' and Flag=0";
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    string sIMGWeChat = string.Empty;
                    string sIMGPay = string.Empty;
                    string sBankName = string.Empty;
                    string sBankStart = string.Empty;
                    string sBankID = string.Empty;
                    double GoldCount = 0;
                    bool BankMSG = false;
                    bool AddressMSG = false;
                    int AddressCount = 0;
                    sIMGWeChat = OP_Mode.Dtv[0]["WeChatImg"].ToString();
                    sIMGPay = OP_Mode.Dtv[0]["PayImg"].ToString();
                    sBankName = OP_Mode.Dtv[0]["BankName"].ToString();
                    sBankStart = OP_Mode.Dtv[0]["BankStart"].ToString();
                    sBankID = OP_Mode.Dtv[0]["BankID"].ToString();
                    AddressCount = Convert.ToInt32(OP_Mode.Dtv[0]["AddressCount"]);
                    GoldCount = Convert.ToDouble(OP_Mode.Dtv[0]["GoldCount"]);

                    if (sIMGWeChat.Length > 0 || sIMGPay.Length > 0 || (sBankID.Length + sBankName.Length + sBankID.Length) > 0)
                    {
                        BankMSG = true;
                    }
                    if (AddressCount > 0)
                    {
                        AddressMSG = true;
                    }

                    /// 更新Cookie
                    /// 
                    ResponseCokie(DefaultUser, BankMSG, AddressMSG, GoldCount);
                    if (HiddenField_AddressID.Value.Length <= 0)
                    {
                        MessageBox("", "地址信息添加成功。", "/Shop/Address.aspx");
                    }
                    else
                    {
                        MessageBox("", "地址信息修改成功。", "/Shop/Address.aspx");
                    }
                }
            }
        }
    }
}