using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
{
    /// <summary>
    ///  依据当前用户ID，商品ID，商品所有人ID，判断是否有数据，有数据则显示用户的收款信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
    public int Tempi = 0;

    private void LoadData(string strHTMLID)
    {
        if (Tempi > 1)
        {
            MessageBox("", "未查询到付款信息，请重试。", "/Shop/");
            return;
        }
        string strSQL = "Select Shop_UserGoods.ID,BigImg,Title,Shop_GoodsPrice.Price,PhoneNo,CName,BankID,BankName,BankStart,WeChatImg,PayImg,GoldCount,Voucher from Shop_UserGoods,Shop_GoodsPrice,Shop_UserInfo,Shop_Goods where Shop_UserGoods.GoodsPriceID=Shop_GoodsPrice.HtmlID and HolderID=Shop_UserInfo.PhoneNo and GoodsID=Shop_Goods.ID and GoodsPriceID='" + strHTMLID + "' and UserID='" + DefaultUser + "'";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                if (OP_Mode.Dtv[0]["WeChatImg"].ToString().Length > 0)
                {
                    Image_WeChat.ImageUrl = "/Shop/img/" + OP_Mode.Dtv[0]["WeChatImg"].ToString();
                }
                if (OP_Mode.Dtv[0]["PayImg"].ToString().Length > 0)
                {
                    Image_Pay.ImageUrl = "/Shop/img/" + OP_Mode.Dtv[0]["PayImg"].ToString();
                }
                Label1.Text = "银行：" + OP_Mode.Dtv[0]["BankName"].ToString();
                Label2.Text = "开户行：" + OP_Mode.Dtv[0]["BankStart"].ToString();
                Label3.Text = "账号：" + OP_Mode.Dtv[0]["BankID"].ToString();
                Label4.Text = "姓名：" + OP_Mode.Dtv[0]["CName"].ToString();
                HyperLink_Tel.Text = OP_Mode.Dtv[0]["PhoneNo"].ToString();
                HyperLink_Tel.NavigateUrl = "tel:" + OP_Mode.Dtv[0]["PhoneNo"].ToString();
                Label_Title.Text = OP_Mode.Dtv[0]["Title"].ToString();
                Label_Price.Text = OP_Mode.Dtv[0]["Price"].ToString();
                Image_BigImg.ImageUrl = "/Shop/img/" + OP_Mode.Dtv[0]["BigImg"].ToString();
                HiddenField_ID.Value = OP_Mode.Dtv[0]["ID"].ToString();
                if (OP_Mode.Dtv[0]["Voucher"].ToString().Length > 0)
                {
                    Image1.ImageUrl = "/Shop/img/" + OP_Mode.Dtv[0]["Voucher"].ToString();
                }
            }
            else
            {// 更新付款信息

                strSQL = "Select SetValue from Shop_SysSet where id=3";
                if (OP_Mode.SQLRUN(strSQL))
                {
                    string[] arrUsers = OP_Mode.Dtv[0][0].ToString().Split(';');
                    if (arrUsers.Length <= 0)
                    {
                        MessageBox("未设置抢购人员，请先设置。");
                        return;
                    }
                    Random ran = new Random();
                    int n = ran.Next(arrUsers.Length);
                    strSQL = " Update Shop_UserGoods set HolderID='" + arrUsers[n] + "' where GoodsPriceID='" + strHTMLID + "' and  UserID='" + DefaultUser + "'";
                    if (OP_Mode.SQLRUN(strSQL))
                    {
                        Tempi++;
                        LoadData(strHTMLID);
                        return;
                    }
                }
                else
                {
                    MessageBox("", "未查询到付款信息，请重试。", "/Shop/");
                }
            }
        }
    }


    protected void LinkButton_Up_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(HiddenField_ID.Value) > 0)
        {
            HttpPostedFile f = Request.Files[0];

            string strImg = UploadTPs(f, 0, "Voucher");
            if (strImg.Length > 0 & DefaultUser != null)
            {
                string strSQL = "Update Shop_UserGoods Set Voucher='" + strImg + "',Flag=2,VoucherTime=getdate(),LTime=getdate() where ID=" + HiddenField_ID.Value + "";
                if (OP_Mode.SQLRUN(strSQL))
                {
                    MessageBox("付款截图上传成功，并且状态更新为待确认。<br/>请等待卖家发货。");
                    string strHtml = Request["id"];
                    if (strHtml != null)
                    {
                        LoadData(strHtml);
                    }
                    else
                    {
                        MessageBox("", "参数错误。", "/Shop/html/");
                    }
                    return;
                }
            }
        }
        else
        {
            MessageBox("", "未查询到付款信息，请重试。", "/Shop/html/");
        }
    }
}