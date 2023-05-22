using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
{
    public int WebID = 2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(WebID, DefaultUser))
            {
                MessageBox("", "您无查看此页面的权限。", "/Shop/");
                return;
            }
            else
            {
                LoadData();
            }
        }
    }

    private void LoadData()
    {
        string strSQL = "Select count(a.NewPrice) CountID,sum(a.NewPrice) SumPrice,Max(LTime) MaxTime,(Select SetValue from Shop_SysSet where id=4) zz from (Select isnull((Select top 1 price from shop_goodsPrice where goodsid=Shop_Goods.ID order by Ctime desc),Price) NewPrice,isnull((Select top 1 Ctime from shop_goodsPrice where goodsid=Shop_Goods.ID order by Ctime desc),LTime) LTime from Shop_Goods where Flag=0) a";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label1.Text = OP_Mode.Dtv[0]["CountID"].ToString();
                Label2.Text = Convert.ToDouble(OP_Mode.Dtv[0]["SumPrice"]).ToString("0");
                Label3.Text = (Convert.ToDouble(OP_Mode.Dtv[0]["SumPrice"]) * (1 + Convert.ToDouble(OP_Mode.Dtv[0]["zz"]))).ToString("0");
                Label4.Text = Convert.ToDateTime(OP_Mode.Dtv[0]["MaxTime"]).ToString("yyyy-MM-dd HH:mm");
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        CreatGoodsToHtml();
        // CreatGoodsHtml.WriteFile(17, "传世古玉", "01.jpg", "1780", "CSS3网页滚动图片元素动画特效 - 站长素材CSS3网页滚动图片元素动画特效网页滚动图片元素动画特效 - 站长素材CSS3网页滚动图片元素动画特效 - 站长素材", "<img src=\"/img/01.jpg\" class=\"img-rounded\" width=\"100%\" /><img src=\"/img/02.jpg\" class=\"img-rounded\" width=\"100%\" /><img src=\"/img/03.jpg\" class=\"img-rounded\" width=\"100%\" /><img src=\"/img/04.jpg\" class=\"img-rounded\" width=\"100%\" /><img src=\"/img/05.jpg\" class=\"img-rounded\" width=\"100%\" />", "2023-05-19 11:30");
    }

    /// <summary>
    /// 循环生成商品页面。
    /// </summary>
    private void CreatGoodsToHtml()
    {
        string strID, strTitle, strBigImg, strPrice, strRemark, strImageInfo, strImageInfo1 = string.Empty, strHtml = String.Empty;
        string[] arrImageInfo;
        double strZZ = 0;
        string strBatch = DateTime.Now.ToString("yyyyMMddHHmmss");// 操作批次号
        DateTime strDT = DateTime.Now;
        int GoodsCount = 0;
        string strSQL = "Select *,isnull((Select top 1 price from shop_goodsPrice where goodsid=Shop_Goods.ID order by Ctime desc),Price) NewPrice,(Select SetValue from Shop_SysSet where id=4) zz from Shop_Goods where Flag=0";
        if (OP_Mode.SQLRUN(strSQL))
        {
            strSQL = String.Empty;
            GoodsCount = OP_Mode.Dtv.Count;
            for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            {
                strImageInfo1 = String.Empty;//复位图片信息
                strID = OP_Mode.Dtv[i]["ID"].ToString();
                strTitle = OP_Mode.Dtv[i]["Title"].ToString();
                strBigImg = OP_Mode.Dtv[i]["BigImg"].ToString();
                strPrice = Convert.ToDouble(OP_Mode.Dtv[i]["NewPrice"]).ToString("0.00");
                strRemark = OP_Mode.Dtv[i]["Remark"].ToString();
                strImageInfo = OP_Mode.Dtv[i]["InfoImg"].ToString();
                strZZ = 1 + Convert.ToDouble(OP_Mode.Dtv[i]["zz"]);
                arrImageInfo = strImageInfo.Split(';');

                for (int j = 0; j < arrImageInfo.Length; j++)
                {
                    if (arrImageInfo[j].Length > 1)
                    {
                        strImageInfo1 += "<img src=\"/Shop/img/" + arrImageInfo[j] + "\" class=\"img-rounded\" width=\"100%\" />";
                    }
                }

                strDT = Convert.ToDateTime(Convert.ToDateTime(TextBox_Stime.Text).ToString("yyyy-MM-dd HH:mm"));
                if (Convert.ToDateTime(strDT) < DateTime.Now)
                {
                    strDT = Convert.ToDateTime(Convert.ToDateTime(TextBox_Stime.Text).AddDays(1).ToString("yyyy-MM-dd HH:mm"));
                }

                strHtml = CreatGoodsHtml.WriteFile(Convert.ToInt32(strID), strTitle, strBigImg, (Convert.ToDouble(strPrice) * strZZ).ToString("0.00"), strRemark, strImageInfo1, strDT.ToString("yyyy-MM-dd HH:mm"));
                strSQL += " Insert into Shop_GoodsPrice (GoodsID,HtmlID,StartTime,Price,Operator,Batch) values (" + strID + ",'" + strHtml + "','" + strDT + "'," + (Convert.ToDouble(strPrice) * strZZ).ToString() + ",'" + DefaultUser + "','" + strBatch + "')";
            }
            strSQL += " Select shop_goodsPrice.Price,HtmlID,GoodsID,shop_goodsPrice.StartTime,Title,Remark,BigImg from shop_goodsPrice,Shop_Goods where Batch='" + strBatch + "' and GoodsID=Shop_Goods.ID and Flag=0";
            string strGoodsGtml = string.Empty, strShowTime = string.Empty;
            if (strSQL.Length > 0)
            {
                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count == GoodsCount)
                    {
                        for (int i = 0; i < GoodsCount; i++)
                        {
                            strGoodsGtml += "<div class=\"box\">";
                            strGoodsGtml += "  <div class=\"list-item\">";
                            strGoodsGtml += "  <div class=\"item-img\">";
                            strGoodsGtml += "  <a href=\"/Shop/Html/" + OP_Mode.Dtv[i]["HtmlID"].ToString() + "\">";//href
                            strGoodsGtml += "  <img src=\"/Shop/img/" + OP_Mode.Dtv[i]["BigImg"].ToString() + "\" alt=\"\"></a>";//img
                            strGoodsGtml += "  </div>";
                            strGoodsGtml += "  <div class=\"alert alert-danger\">";
                            strGoodsGtml += " <a href=\"/Shop/Html/" + OP_Mode.Dtv[i]["HtmlID"].ToString() + "\">";
                            strGoodsGtml += "<h5 id=\"show" + OP_Mode.Dtv[i]["GoodsID"].ToString() + "\" class=\"center\">";//ShowID
                            strGoodsGtml += "<span></span>小时<span></span>分<span></span>秒</h5></a></div>";
                            strGoodsGtml += " <div class=\"item-tt\"><a href=\"/Shop/Html/" + OP_Mode.Dtv[i]["HtmlID"].ToString() + "\">" + OP_Mode.Dtv[i]["Title"].ToString() + "</a></div>";//Remark
                            strGoodsGtml += "<div class=\"clearfix\"><div class=\"money\">￥<span>" + OP_Mode.Dtv[i]["Price"].ToString() + "</span></div></div>";//Price
                            strGoodsGtml += "<div class=\"pull-right\"><a href=\"/Shop/Html/" + OP_Mode.Dtv[i]["HtmlID"].ToString() + "\" class=\"btn btn-xs btn-success\">立即抢购</a></div>";//href
                            strGoodsGtml += "</div></div>";

                            strShowTime += "ShowTime(\"show" + OP_Mode.Dtv[i]["GoodsID"].ToString() + "\", \"" + OP_Mode.Dtv[i]["StartTime"].ToString() + "\");";

                            CreatGoodsHtml.WriteIndex(strGoodsGtml, strShowTime);
                        }

                        MessageBox("<i class=\"icon-warning-sign green bigger-300\"><i/><br><h5>页面生成成功。<h5/>");
                        LoadData();
                    }
                    else
                    {
                        MessageBox("", "<i class=\"icon-warning-sign red bigger-300\"><i/><br><h5>生成失败，请重试<h5/>");
                        return;
                    }
                }
            }
        }
    }
}