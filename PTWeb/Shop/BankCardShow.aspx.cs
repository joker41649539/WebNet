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
            string strHtml = Request["id"];
            if (strHtml != null)
            {
                LoadData(strHtml);
            }
            else
            {
                MessageBox("", "参数错误。", "/Shop/html/");
            }
        }
    }

    private void LoadData(string strHTMLID)
    {
        string strSQL = "Select Shop_UserGoods.ID,BigImg,Title,Shop_GoodsPrice.Price,PhoneNo,CName,BankID,BankName,BankStart,WeChatImg,PayImg,GoldCount,Voucher from Shop_UserGoods,Shop_GoodsPrice,Shop_UserInfo,Shop_Goods where Shop_UserGoods.GoodsPriceID=Shop_GoodsPrice.HtmlID and HolderID=Shop_UserInfo.PhoneNo and GoodsID=Shop_Goods.ID and GoodsPriceID='" + strHTMLID + "' and HolderID='" + DefaultUser + "'";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_Title.Text = OP_Mode.Dtv[0]["Title"].ToString();
                Label_Price.Text = OP_Mode.Dtv[0]["Price"].ToString();
                HiddenField_ID.Value = OP_Mode.Dtv[0]["ID"].ToString();
                Image_BigImg.ImageUrl = "/Shop/img/" + OP_Mode.Dtv[0]["BigImg"].ToString();
                if (OP_Mode.Dtv[0]["Voucher"].ToString().Length > 0)
                {
                    Image1.ImageUrl = "/Shop/img/" + OP_Mode.Dtv[0]["Voucher"].ToString();
                }
            }
            else
            {
                MessageBox("", "未查询到付款信息，请重试。", "/Shop/html/");
            }
        }
    }

    protected void LinkButton_Up_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(HiddenField_ID.Value) > 0)
        {
            string strSQL = "Update Shop_UserGoods Set Flag=1,LTime=getdate() where ID=" + HiddenField_ID.Value + " and HolderID='" + DefaultUser + "'";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "您已确认收款。", "/Shop/Order.aspx");
                return;
            }
        }
        else
        {
            MessageBox("", "未查询到付款信息，请重试。", "/Shop/html/");
        }
    }
}