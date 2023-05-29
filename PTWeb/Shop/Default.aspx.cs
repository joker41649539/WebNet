using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpaServer_Default : PageBaseShop
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            //Response.Redirect("/Shop/Html/Index.html", false);
            //return;
        }
    }

    private void LoadData()
    {
        string TempHtml = string.Empty;
        string sSTime = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 00:00:00";
        string sETime = System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 23:59:59";
        string strSQL = "Select StartTime from Shop_GoodsPrice where StartTime between '" + sSTime + "' and '" + sETime + "' group by StartTime";

        string RDate = Request["Date"];

        string NDate = string.Empty;

        bool bSave = false;

        if (OP_Mode.SQLRUN(strSQL))
        {
            TempHtml += "<ul class=\"pagination center\">";
            for (int i = 0; i < OP_Mode.Dtv.Count; i++)
            {
                if (RDate == Convert.ToDateTime(OP_Mode.Dtv[i]["StartTime"]).ToString("MM-dd HH:mm"))
                {
                    TempHtml = TempHtml.Replace("class=\"active\"", "") + "<li class=\"active\">";
                    NDate = Convert.ToDateTime(OP_Mode.Dtv[i]["StartTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    bSave = true;
                }
                else if (Convert.ToDateTime(OP_Mode.Dtv[i]["StartTime"]) > System.DateTime.Now)
                {
                    if (!bSave)
                    {
                        TempHtml = TempHtml.Replace("class=\"active\"", "") + "<li class=\"active\">";
                        NDate = Convert.ToDateTime(OP_Mode.Dtv[i]["StartTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                        bSave = true;
                    }
                    else
                    {
                        TempHtml += "<li>";
                    }
                }
                else
                {
                    if (i + 1 == OP_Mode.Dtv.Count)
                    {
                        TempHtml = TempHtml.Replace("class=\"active\"", "") + "<li class=\"active\">";
                        NDate = Convert.ToDateTime(OP_Mode.Dtv[i]["StartTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        TempHtml += "<li>";
                    }
                }
                TempHtml += " <a href=\"?Date=" + Convert.ToDateTime(OP_Mode.Dtv[i]["StartTime"]).ToString("MM-dd HH:mm") + "\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["StartTime"]).ToString("MM-dd HH:mm") + "</a>";
                TempHtml += "</li>";
            }
            TempHtml += "</ul>";
        }

        Div_Date.InnerHtml = TempHtml;

        string strGoodsGtml = string.Empty;
        string strShowTime = string.Empty;
        strSQL = "Select Title,HtmlID,GoodsID,Shop_GoodsPrice.Price,Shop_GoodsPrice.StartTime,BigImg from Shop_GoodsPrice,Shop_Goods where Shop_GoodsPrice.StartTime ='" + NDate + "' and Shop_GoodsPrice.GoodsID=Shop_Goods.ID ORDER BY NEWID()";
        if (OP_Mode.SQLRUN(strSQL))
        {
            for (int i = 0; i < OP_Mode.Dtv.Count; i++)
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
            }
            if (strGoodsGtml.Length > 0)
            {
                masonry.InnerHtml = strGoodsGtml;
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>" + strShowTime + "</script>");
            }
            else
            {
                masonry.InnerHtml = "<h1>暂没有任何藏品。</h1>";
            }
        }

    }
}