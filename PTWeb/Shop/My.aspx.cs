using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpaServer_Default2 : PageBaseShop
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (DefaultUser != null)
            {
                LoadData();
            }
            LoadAppBtn();
        }
    }

    private void LoadAppBtn()
    {
        string strTempHtml = string.Empty;


        strTempHtml += "<a href=\"/Shop/BankCard.aspx\" class=\"btn btn-app btn-warning\">";
        strTempHtml += "    <i class=\"icon-credit-card bigger-230\"></i>收款账号</a>";
        strTempHtml += "<a href=\"/Shop/Address.aspx\" class=\"btn btn-app btn-success\">";
        strTempHtml += "    <i class=\"icon-globe bigger-230\"></i>收货地址</a>";
        strTempHtml += "<a href=\"#\" class=\"btn btn-app btn-pink\">";
        strTempHtml += "    <i class=\"icon-facetime-video bigger-230\"></i>新人教程</a>";
        strTempHtml += "<a href=\"/Shop/Friends.aspx\" class=\"btn btn-app btn-info\">";
        strTempHtml += "    <i class=\"icon-comments bigger-230\"></i>邀请好友</a>";
        strTempHtml += "<a href=\"/Shop/Service.aspx\" class=\"btn btn-app btn-purple\">";
        strTempHtml += "    <i class=\"icon-headphones bigger-230\"></i>联系客服</a>";

        string strSQL = "Select cast( ModuleID as nvarchar)+';' from Shop_Module,Shop_UserInfo where Shop_Module.PhoneNo='" + DefaultUser + "' and Shop_Module.PhoneNo=Shop_UserInfo.PhoneNo and FLAG=0 for xml PATH('')";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string[] arrModul = OP_Mode.Dtv[0][0].ToString().Split(';');

                if (arrModul.Length > 0)
                {

                    int id = Array.IndexOf(arrModul, "2");

                    if (id != -1)
                    {
                        strTempHtml += "<a href=\"/Shop/GoodsAdd.aspx\" class=\"btn btn-app btn-inverse\">";
                        strTempHtml += "    <i class=\"icon-gift bigger-230\"></i>藏品添加</a>";
                    }

                    id = Array.IndexOf(arrModul, "4");

                    if (id != -1)
                    {
                        strTempHtml += "<a href=\"/Shop/Recharge.aspx\" class=\"btn btn-app btn-inverse\">";
                        strTempHtml += "    <i class=\"icon-briefcase bigger-230\"></i>金豆充值</a>";
                    }

                    id = Array.IndexOf(arrModul, "1");

                    if (id != -1)
                    {
                        strTempHtml += "<a href=\"/Shop/UserList.aspx\" class=\"btn btn-app btn-inverse\">";
                        strTempHtml += "    <i class=\"icon-group bigger-230\"></i>会员管理</a>";
                    }


                    id = Array.IndexOf(arrModul, "3");

                    if (id != -1)
                    {
                        strTempHtml += "<a href=\"/Shop/SysSet.aspx\" class=\"btn btn-app btn-inverse\">";
                        strTempHtml += "    <i class=\"icon-cogs bigger-230\"></i>系统设置</a>";
                    }

                }
            }
        }

        strTempHtml += "<div class=\"hr hr8 hr-double\"></div>";
        if (strTempHtml.Length > 0)
        {
            Div_AppBtn.InnerHtml = strTempHtml;
        }
    }

    private void LoadData()
    {
        string strSQL = "Select *,(Select Count(ID) From Shop_Address where UserNo=Shop_UserInfo.PhoneNo) AddressCount,isnull((Select sum(Bance) from shop_Gold where UserNo=Shop_Userinfo.PhoneNo),0) Bance,isnull((Select sum(Bance) from shop_Gold where UserNo=Shop_Userinfo.PhoneNo and bance>0),0) BanceA,isnull((Select sum(Bance) from shop_Gold where UserNo=Shop_Userinfo.PhoneNo and bance<0),0) BanceD from Shop_Userinfo where PhoneNo='" + DefaultUser + "' and FLAG=0";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                double GoldCount = 0;
                bool BankMSG = false;
                bool AddressMSG = false;
                int AddressCount = 0;
                string sIMGWeChat = string.Empty;
                string sIMGPay = string.Empty;
                string sBankName = string.Empty;
                string sBankStart = string.Empty;
                string sBankID = string.Empty;
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

                int iGolds = Convert.ToInt32(OP_Mode.Dtv[0]["GoldCount"]);
                int iBance = Convert.ToInt32(OP_Mode.Dtv[0]["Bance"]);
                int iBanceA = Convert.ToInt32(OP_Mode.Dtv[0]["BanceA"]);
                int iBanceD = Convert.ToInt32(OP_Mode.Dtv[0]["BanceD"]);

                if (iGolds != iBance)
                {
                    MessageBox("", "该账号数据异常，请联系管理员查看。");
                    return;
                }
                else
                {
                    ResponseCokie(DefaultUser, BankMSG, AddressMSG, GoldCount);

                    Label2.Text = iGolds.ToString("0.000");

                }
            }
            //else
            //{
            //    MessageBox("", "登录信息有误，请重新登录。","/Shop/Login.aspx");
            //    return;
            //}
        }
    }
}