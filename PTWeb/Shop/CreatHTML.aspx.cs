using Microsoft.Office.Interop.Excel;
using Stimulsoft.Report.CrossTab.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;
using CheckBox = System.Web.UI.WebControls.CheckBox;

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
                    if (i + 1 == OP_Mode.Dtv.Count & !bSave)
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

        strSQL = "Select *,cast((Select COUNT(ID) from Shop_GoodsPrice where GoodsID=Shop_Goods.ID and StartTime='" + NDate + "') as bit) Selected,isnull((Select top 1 price from shop_goodsPrice where goodsid=Shop_Goods.ID order by Ctime desc),Price) NewPrice,(Select SetValue from Shop_SysSet where id=4) zz,(Select SetValue from Shop_SysSet where id=1) Gas from Shop_Goods ";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView_Goods.DataSource = OP_Mode.Dtv;
                GridView_Goods.DataBind();

                //OP_Mode.Dtv.RowFilter = "Flag=0";
                //Label1.Text = OP_Mode.Dtv.ToTable().Rows.Count.ToString();
                //for (int i = 0; i < OP_Mode.Dtv.ToTable().Rows.Count; i++)
                //{
                //    OPrice += Convert.ToDouble(OP_Mode.Dtv.ToTable().Rows[i]["Price"]);
                //    NPrice += Convert.ToDouble(OP_Mode.Dtv.ToTable().Rows[i]["NewPrice"]);
                //}
                //Label2.Text = OPrice.ToString();
                //Label3.Text = NPrice.ToString();
            }
        }
        //string strSQL = "Select count(a.NewPrice) CountID,sum(a.NewPrice) SumPrice,Max(LTime) MaxTime,(Select SetValue from Shop_SysSet where id=4) zz from (Select isnull((Select top 1 price from shop_goodsPrice where goodsid=Shop_Goods.ID order by Ctime desc),Price) NewPrice,isnull((Select top 1 Ctime from shop_goodsPrice where goodsid=Shop_Goods.ID order by Ctime desc),LTime) LTime from Shop_Goods where Flag=0) a";
        //if (OP_Mode.SQLRUN(strSQL))
        //{
        //    if (OP_Mode.Dtv.Count > 0)
        //    {
        //        Label1.Text = OP_Mode.Dtv[0]["CountID"].ToString();
        //        Label2.Text = Convert.ToDouble(OP_Mode.Dtv[0]["SumPrice"]).ToString("0");
        //        Label3.Text = (Convert.ToDouble(OP_Mode.Dtv[0]["SumPrice"]) * (1 + Convert.ToDouble(OP_Mode.Dtv[0]["zz"]))).ToString("0");
        //        Label4.Text = Convert.ToDateTime(OP_Mode.Dtv[0]["MaxTime"]).ToString("yyyy-MM-dd HH:mm");
        //    }
        //}
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        CreatHtml();
        // CreatGoodsToHtml();
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
        double strGas = 0;
        string strServer = TextBox_Server.Text;
        string strSQL = "Select *,isnull((Select top 1 price from shop_goodsPrice where goodsid=Shop_Goods.ID order by Ctime desc),Price) NewPrice,(Select SetValue from Shop_SysSet where id=4) zz,(Select SetValue from Shop_SysSet where id=1) Gas from Shop_Goods where Flag=0";
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
                strGas = Convert.ToDouble(OP_Mode.Dtv[i]["Gas"]);
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

                strHtml = CreatGoodsHtml.WriteFile(Convert.ToInt32(strID), strTitle, strBigImg, (Convert.ToDouble(strPrice) * strZZ).ToString("0.00"), strRemark, strImageInfo1, strDT.ToString("yyyy-MM-dd HH:mm"), strServer, strGas.ToString());
                strSQL += " Insert into Shop_GoodsPrice (GoodsID,HtmlID,StartTime,Price,Operator,Batch) values (" + strID + ",'" + strHtml + "','" + strDT + "'," + (Convert.ToDouble(strPrice) * strZZ).ToString() + ",'" + DefaultUser + "','" + strBatch + "')";
            }

            if (strSQL.Length > 0)
            {
                if (OP_Mode.SQLRUN(strSQL))
                {
                    MessageBox("<i class=\"icon-warning-sign green bigger-300\"><i/><br><h5>页面生成成功。<h5/>");
                    LoadData();
                }
            }
        }
    }

    private void CreatHtml()
    {
        string strGoodsID = string.Empty, strSQL = string.Empty;
        string strID, strTitle, strBigImg, strPrice, strRemark, strImageInfo, strImageInfo1 = string.Empty, strHtml = String.Empty;
        string[] arrImageInfo;
        double strZZ = 0;
        string strBatch = DateTime.Now.ToString("yyyyMMddHHmmss");// 操作批次号
        DateTime strDT = DateTime.Now;

        double strGas = 0;
        string strServer = TextBox_Server.Text;

        for (int i = 0; i < GridView_Goods.Rows.Count; i++)
        {
            CheckBox cBoxItem = (CheckBox)GridView_Goods.Rows[i].FindControl("CheckBox1");
            if (cBoxItem.Checked == true)
            {
                strImageInfo1 = String.Empty;//复位图片信息
                strID = GridView_Goods.DataKeys[i].Values[0].ToString();
                strTitle = GridView_Goods.DataKeys[i].Values[1].ToString();
                strBigImg = GridView_Goods.DataKeys[i].Values[2].ToString();
                strPrice = Convert.ToDouble(GridView_Goods.DataKeys[i].Values[3].ToString()).ToString("0.00");
                strRemark = GridView_Goods.DataKeys[i].Values[4].ToString();
                strImageInfo = GridView_Goods.DataKeys[i].Values[5].ToString();
                strZZ = 1 + Convert.ToDouble(GridView_Goods.DataKeys[i].Values[6].ToString());
                strGas = Convert.ToDouble(GridView_Goods.DataKeys[i].Values[7].ToString());
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

                strHtml = CreatGoodsHtml.WriteFile(Convert.ToInt32(strID), strTitle, strBigImg, (Convert.ToDouble(strPrice) * strZZ).ToString("0.00"), strRemark, strImageInfo1, strDT.ToString("yyyy-MM-dd HH:mm"), strServer, strGas.ToString());
                strSQL += " Insert into Shop_GoodsPrice (GoodsID,HtmlID,StartTime,Price,Operator,Batch) values (" + strID + ",'" + strHtml + "','" + strDT + "'," + (Convert.ToDouble(strPrice) * strZZ).ToString() + ",'" + DefaultUser + "','" + strBatch + "')";
                // strSQL += ";";
            }
        }

        if (strSQL.Length > 0)
        {
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("<i class=\"icon-warning-sign green bigger-300\"><i/><br><h5>页面生成成功。<h5/>");
                LoadData();
            }
            else
            {
                MessageBox("<i class=\"icon-warning-sign red bigger-300\"><i/><br><h5>页面生成失败。<h5/>");
            }
        }
    }
}