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

    private void LoadData(string strHTMLID)
    {
        string strSQL = "Select * from Shop_UserInfo where id=(Select Max(UserID) from Shop_UserGoods where GoodsPriceID=(Select ID from Shop_GoodsPrice where HtmlID='" + strHTMLID + "') and Flag=1)";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                if (OP_Mode.Dtv[0]["PayImg"].ToString().Length > 0)
                {
                    Image_WeChat.ImageUrl = "/Shop/img/" + OP_Mode.Dtv[0]["WeChatImg"].ToString();
                }
                if (OP_Mode.Dtv[0]["PayImg"].ToString().Length > 0)
                {
                    Image_Pay.ImageUrl = "/Shop/img/" + OP_Mode.Dtv[0]["PayImg"].ToString();
                }
                Label1.Text = OP_Mode.Dtv[0]["BankName"].ToString();
                Label2.Text = OP_Mode.Dtv[0]["BankStart"].ToString();
                Label3.Text = OP_Mode.Dtv[0]["BankID"].ToString();
            }
            else
            {
                MessageBox("无主商品，跳转到系统管理员收款账号。");
            }
        }
    }

}