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
                TextBox_Data.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                LoadData();
            }
        }
    }
    private void LoadData()
    {
        string sDate = Convert.ToDateTime(TextBox_Data.Text).ToString("yyyy-MM-dd") + " 00:00:00";
        string EDate = Convert.ToDateTime(TextBox_Data.Text).ToString("yyyy-MM-dd") + " 23:59:59";
        string Title = TextBox_Title.Text.Replace("'", "");
        string strSQL = string.Empty;

        if (Title.Length > 0)
        {
            strSQL = "Select HolderID,UserID,Title,BigImg,shop_goodsPrice.Price,Shop_Goods.ID,Shop_UserGoods.Flag,Shop_UserGoods.CTime from Shop_UserGoods,shop_goodsPrice,Shop_Goods where HtmlID=GoodsPriceID and GoodsID=Shop_Goods.ID and Shop_UserGoods.CTime between '" + sDate + "' and  '" + EDate + "' and Title like '%" + Title + "%' order by Shop_UserGoods.CTime";
        }
        else
        {
            strSQL = "Select HolderID,UserID,Title,BigImg,shop_goodsPrice.Price,Shop_Goods.ID,Shop_UserGoods.Flag,Shop_UserGoods.CTime from Shop_UserGoods,shop_goodsPrice,Shop_Goods where HtmlID=GoodsPriceID and GoodsID=Shop_Goods.ID and Shop_UserGoods.CTime between '" + sDate + "' and  '" + EDate + "' order by Shop_UserGoods.CTime";
        }
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView_Goods.DataSource = OP_Mode.Dtv;
                GridView_Goods.DataBind();
            }
            else
            {
                GridView_Goods.DataSource = null;
                GridView_Goods.DataBind();
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}