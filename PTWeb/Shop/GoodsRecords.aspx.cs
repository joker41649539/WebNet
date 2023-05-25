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
        string strSQL = "Select HolderID,UserID,Title,BigImg,shop_goodsPrice.Price,Shop_Goods.ID,Shop_UserGoods.Flag,Shop_UserGoods.CTime from Shop_UserGoods,shop_goodsPrice,Shop_Goods where HtmlID=GoodsPriceID and GoodsID=Shop_Goods.ID and Shop_Goods.ID=" + Request["id"] + " order by Shop_UserGoods.CTime";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_Title.Text = OP_Mode.Dtv[0]["Title"].ToString();
                Image1.ImageUrl = "/Shop/img/" + OP_Mode.Dtv[0]["BigImg"].ToString();
                //double OPrice = 0, NPrice = 0;
                GridView_Goods.DataSource = OP_Mode.Dtv;
                GridView_Goods.DataBind();
            }
            else
            {
                MessageBox("", "未查询到任何商品数据。", "/Shop/");
                return;
            }
        }
    }
}