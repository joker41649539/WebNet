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

        string strSQL = "Select Shop_UserGoods.ID,HtmlID,Shop_GoodsPrice.Price,Title,BigImg from Shop_UserGoods,Shop_GoodsPrice,Shop_Goods where GoodsPriceID=Shop_GoodsPrice.HtmlID and Shop_Goods.ID=GoodsID and UserID='" + DefaultUser + "' and Shop_UserGoods.Flag=0";// 待付款

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strTempHtml = string.Empty;
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHtmlID = OP_Mode.Dtv[i]["HtmlID"].ToString();
                    strTempHtml += "<div class=\"well row\">";
                    strTempHtml += " <div class=\"col-xs-4\">";
                    strTempHtml += "  <span class=\"profile-picture\">";
                    strTempHtml += "   <img class=\"img-responsive img-rounded\" width=\"100%\" src=\"/Shop/Img/" + OP_Mode.Dtv[i]["BigImg"].ToString() + "\" />";
                    strTempHtml += "  </span>";
                    strTempHtml += " </div>";
                    strTempHtml += " <div class=\"col-xs-8\">";
                    strTempHtml += "  <h5>" + strHtmlID.Substring(0, strHtmlID.Length - 5) + "</h5>";
                    strTempHtml += "  <h5>" + OP_Mode.Dtv[i]["Title"].ToString() + "</h5>";
                    strTempHtml += "  <h3 class=\"red\">" + OP_Mode.Dtv[i]["Price"].ToString() + "</h3>";
                    strTempHtml += " <p class=\"btn-group pull-right\">";
                    // strTempHtml += "  <a href=\"#\" Class=\"btn btn-sm\"><i class=\"icon-ok\"></i>&nbsp;付款确认</a>";
                    strTempHtml += "  <a href=\"/Shop/BankCardByUser.aspx?id=" + strHtmlID + "\" Class=\"btn btn-sm btn-danger\"><i class=\"icon-credit-card\"></i>&nbsp;付款信息</a>";
                    strTempHtml += " </p>";
                    strTempHtml += " </div>";
                    strTempHtml += "</div>";
                }
                Well0.InnerHtml = strTempHtml;
            }
        }

        strSQL = "Select Shop_UserGoods.ID,HtmlID,Shop_GoodsPrice.Price,Title,BigImg from Shop_UserGoods,Shop_GoodsPrice,Shop_Goods where GoodsPriceID=Shop_GoodsPrice.HtmlID and Shop_Goods.ID=GoodsID and UserID='" + DefaultUser + "' and Shop_UserGoods.Flag=1";// 已完成

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strTempHtml = string.Empty;
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHtmlID = OP_Mode.Dtv[i]["HtmlID"].ToString();
                    strTempHtml += "<div class=\"well row\">";
                    strTempHtml += " <div class=\"col-xs-4\">";
                    strTempHtml += "  <span class=\"profile-picture\">";
                    strTempHtml += "   <img class=\"img-responsive img-rounded\" width=\"100%\" src=\"/Shop/Img/" + OP_Mode.Dtv[i]["BigImg"].ToString() + "\" />";
                    strTempHtml += "  </span>";
                    strTempHtml += " </div>";
                    strTempHtml += " <div class=\"col-xs-8\">";
                    strTempHtml += "  <h5>" + strHtmlID.Substring(0, strHtmlID.Length - 5) + "</h5>";
                    strTempHtml += "  <h5>" + OP_Mode.Dtv[i]["Title"].ToString() + "</h5>";
                    strTempHtml += "  <h3 class=\"red\">" + OP_Mode.Dtv[i]["Price"].ToString() + "</h3>";
                    strTempHtml += " </div>";
                    strTempHtml += "</div>";
                }
                Well1.InnerHtml = strTempHtml;
            }
        }

        strSQL = "Select Shop_UserGoods.ID,HtmlID,Shop_GoodsPrice.Price,Title,BigImg from Shop_UserGoods,Shop_GoodsPrice,Shop_Goods where GoodsPriceID=Shop_GoodsPrice.HtmlID and Shop_Goods.ID=GoodsID and UserID='" + DefaultUser + "' and Shop_UserGoods.Flag=2";// 待收款

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strTempHtml = string.Empty;
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHtmlID = OP_Mode.Dtv[i]["HtmlID"].ToString();
                    strTempHtml += "<div class=\"well row\">";
                    strTempHtml += " <div class=\"col-xs-4\">";
                    strTempHtml += "  <span class=\"profile-picture\">";
                    strTempHtml += "   <img class=\"img-responsive img-rounded\" width=\"100%\" src=\"/Shop/Img/" + OP_Mode.Dtv[i]["BigImg"].ToString() + "\" />";
                    strTempHtml += "  </span>";
                    strTempHtml += " </div>";
                    strTempHtml += " <div class=\"col-xs-8\">";
                    strTempHtml += " <h5>" + strHtmlID.Substring(0, strHtmlID.Length - 5) + "</h5>";
                    strTempHtml += " <h5>" + OP_Mode.Dtv[i]["Title"].ToString() + "</h5>";
                    strTempHtml += " <h3 class=\"red\">" + OP_Mode.Dtv[i]["Price"].ToString() + "</h3>";
                    strTempHtml += " <p class=\"btn-group pull-right\">";
                    // strTempHtml += "  <a href=\"#\" Class=\"btn btn-sm\"><i class=\"icon-ok\"></i>&nbsp;付款确认</a>";
                    strTempHtml += "  <a href=\"/Shop/BankCardByUser.aspx?id=" + strHtmlID + "\" Class=\"btn btn-sm btn-success\"><i class=\"icon-credit-card\"></i>&nbsp;付款信息</a>";
                    strTempHtml += " </p>";
                    strTempHtml += " </div>";
                    strTempHtml += "</div>";
                }
                Well2.InnerHtml = strTempHtml;
            }
        }

        strSQL = "Select Shop_UserGoods.ID,HtmlID,Shop_GoodsPrice.Price,Title,BigImg,Shop_UserGoods.Flag from Shop_UserGoods,Shop_GoodsPrice,Shop_Goods where GoodsPriceID=Shop_GoodsPrice.HtmlID and Shop_Goods.ID=GoodsID and HolderID='" + DefaultUser + "' order by Shop_UserGoods.Flag desc,Shop_UserGoods.Ltime desc";// 我卖出的

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                int iFlag = 0;
                strTempHtml = string.Empty;
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHtmlID = OP_Mode.Dtv[i]["HtmlID"].ToString();
                    iFlag = Convert.ToInt32(OP_Mode.Dtv[i]["Flag"].ToString());
                    strTempHtml += "<div class=\"well row\">";
                    strTempHtml += " <div class=\"col-xs-4\">";
                    strTempHtml += "  <span class=\"profile-picture\">";
                    strTempHtml += "   <img class=\"img-responsive img-rounded\" width=\"100%\" src=\"/Shop/Img/" + OP_Mode.Dtv[i]["BigImg"].ToString() + "\" />";
                    strTempHtml += "  </span>";
                    strTempHtml += " </div>";
                    strTempHtml += " <div class=\"col-xs-8\">";
                    if (iFlag == 0)
                    {
                        strTempHtml += "<h5><span class=\"label label-success\">等待买家付款</span></h5>";
                    }
                    else if (iFlag == 1)
                    {
                        strTempHtml += "<h5><span class=\"label label-purple\">完成</span></h5>";
                    }
                    else if (iFlag == 2)
                    {
                        strTempHtml += "<h5><span class=\"label label-danger\">等待您的确认</span></h5>";
                    }
                    strTempHtml += " <h5>" + strHtmlID.Substring(0, strHtmlID.Length - 5) + "</h5>";
                    strTempHtml += " <h5>" + OP_Mode.Dtv[i]["Title"].ToString() + "</h5>";
                    strTempHtml += " <h3 class=\"red\">" + OP_Mode.Dtv[i]["Price"].ToString() + "</h3>";
                    if (iFlag == 2)
                    {
                        strTempHtml += " <p class=\"btn-group pull-right\">";
                        strTempHtml += "  <a href=\"/Shop/BankCardShow.aspx?id=" + strHtmlID + "\" Class=\"btn btn-sm btn-success\"><i class=\"icon-credit-card\"></i>&nbsp;付款信息</a>";
                        strTempHtml += " </p>";
                    }
                    strTempHtml += " </div>";
                    strTempHtml += "</div>";
                }
                Div_My.InnerHtml = strTempHtml;
            }
        }

        strSQL = " Select GoldCount,(Select count(ID) from Shop_UserGoods where UserID=Shop_UserInfo.PhoneNo) OrderCount   from Shop_UserInfo where PhoneNo='" + DefaultUser + "'";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_Sum.Text = Convert.ToDecimal(OP_Mode.Dtv[0]["OrderCount"]).ToString("0.00");
                Label_GoldCount.Text = Convert.ToDecimal(OP_Mode.Dtv[0]["GoldCount"]).ToString("0.00");
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