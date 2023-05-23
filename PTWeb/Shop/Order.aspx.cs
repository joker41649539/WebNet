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
        }
    }

    /// <summary>
    /// 读取数据
    /// </summary>
    private void LoadData()
    {
        string strTempHtml = string.Empty;
        string strHtmlID = string.Empty;
        string strSQL = "Select Shop_UserGoods.ID,HtmlID,Shop_GoodsPrice.Price,Title,BigImg from Shop_UserGoods,Shop_UserInfo,Shop_GoodsPrice,Shop_Goods where UserID=Shop_UserInfo.ID and PhoneNo='" + DefaultUser + "' and Shop_GoodsPrice.ID=Shop_UserGoods.GoodsPriceID and GoodsID=Shop_Goods.ID and Shop_UserGoods.FLAG=0";// 待付款

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strTempHtml = string.Empty;
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHtmlID = OP_Mode.Dtv[i]["HtmlID"].ToString();
                    strTempHtml += "<div class=\"well\">";
                    strTempHtml += " <h5>" + strHtmlID.Substring(0, strHtmlID.Length - 5) + "</h5>";
                    strTempHtml += " <h5>" + OP_Mode.Dtv[i]["Title"].ToString() + "</h5>";
                    strTempHtml += " <h3 class=\"red\">" + OP_Mode.Dtv[i]["Price"].ToString() + "</h3>";
                    strTempHtml += "";
                    strTempHtml += "</div>";
                }
                Well0.InnerHtml = strTempHtml;
            }
        }

        strSQL = "Select Shop_UserGoods.ID,HtmlID,Shop_GoodsPrice.Price,Title,BigImg from Shop_UserGoods,Shop_UserInfo,Shop_GoodsPrice,Shop_Goods where UserID=Shop_UserInfo.ID and PhoneNo='" + DefaultUser + "' and Shop_GoodsPrice.ID=Shop_UserGoods.GoodsPriceID and GoodsID=Shop_Goods.ID and Shop_UserGoods.FLAG=1";// 已完成

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strTempHtml = string.Empty;
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHtmlID = OP_Mode.Dtv[i]["HtmlID"].ToString();
                    strTempHtml += "<div class=\"well\">";
                    strTempHtml += " <h5>" + strHtmlID.Substring(0, strHtmlID.Length - 5) + "</h5>";
                    strTempHtml += " <h5>" + OP_Mode.Dtv[i]["Title"].ToString() + "</h5>";
                    strTempHtml += " <h3 class=\"red\">" + OP_Mode.Dtv[i]["Price"].ToString() + "</h3>";
                    strTempHtml += "";
                    strTempHtml += "</div>";
                }
                Well1.InnerHtml = strTempHtml;
            }
        }

        strSQL = "Select Shop_UserGoods.ID,HtmlID,Shop_GoodsPrice.Price,Title,BigImg from Shop_UserGoods,Shop_UserInfo,Shop_GoodsPrice,Shop_Goods where UserID=Shop_UserInfo.ID and PhoneNo='" + DefaultUser + "' and Shop_GoodsPrice.ID=Shop_UserGoods.GoodsPriceID and GoodsID=Shop_Goods.ID and Shop_UserGoods.FLAG=2";// 待收款

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strTempHtml = string.Empty;
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHtmlID = OP_Mode.Dtv[i]["HtmlID"].ToString();
                    strTempHtml += "<div class=\"well\">";
                    strTempHtml += " <h5>" + strHtmlID.Substring(0, strHtmlID.Length - 5) + "</h5>";
                    strTempHtml += " <h5>" + OP_Mode.Dtv[i]["Title"].ToString() + "</h5>";
                    strTempHtml += " <h3 class=\"red\">" + OP_Mode.Dtv[i]["Price"].ToString() + "</h3>";
                    strTempHtml += "";
                    strTempHtml += "</div>";
                }
                Well2.InnerHtml = strTempHtml;
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {// 付款确认 状态 2
        MessageBox("", "您已经确认付款款。<br>我们已经通知用户查收。");
        return;
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {// 状态切换成 1完成
        MessageBox("", "您已经确认收款。<br>商品归属已经移给您。");
        return;
    }
}