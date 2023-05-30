using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
{
    public int WebID = 5;

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
        string strSQL = string.Empty;
        strSQL = "Select Shop_GoodsPrice.ID,(Select SetValue from Shop_SysSet where id=3) DefaultPhone,BigImg,Title,isnull(Shop_GoodsPrice.Price,Shop_Goods.Price) NewPrice from  Shop_GoodsPrice,Shop_Goods where HtmlID not in (Select GoodsPriceID from Shop_UserGoods) and GoodsID=Shop_Goods.ID order by ID";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView_Goods.DataSource = OP_Mode.Dtv;
                GridView_Goods.DataBind();
                TextBox1.Text = OP_Mode.Dtv[0]["DefaultPhone"].ToString();
            }
            Label1.Text = OP_Mode.Dtv.Count.ToString();
        }
    }

    // Select HtmlID,'USERID',0 flag,(Select isnull((Select UserID from Shop_UserGoods where GoodsPriceID = (Select top 1 HtmlID from Shop_GoodsPrice where GoodsID=a.GoodsID and HtmlID!=a.HtmlID order by Ctime desc) and Flag = 1),0) from Shop_GoodsPrice a where HtmlID=aa.HtmlID)  holder
    //from Shop_GoodsPrice aa where HtmlID not in (Select GoodsPriceID from Shop_UserGoods)


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string[] arrUsers = TextBox1.Text.Split(';');
        if (arrUsers.Length <= 0)
        {
            MessageBox("未设置抢购人员，请先设置。");
            return;
        }
        Random ran = new Random();
        int n = ran.Next(arrUsers.Length);

        string strSQL = "insert into Shop_UserGoods(GoodsPriceID, UserID, HolderID) ";
        strSQL += " Select HtmlID,'" + arrUsers[n] + "',(Select isnull((Select UserID from Shop_UserGoods where GoodsPriceID = (Select top 1 HtmlID from Shop_GoodsPrice where GoodsID=a.GoodsID and HtmlID!=a.HtmlID order by Ctime desc) and Flag = 1),0) from Shop_GoodsPrice a where HtmlID=aa.HtmlID) from Shop_GoodsPrice aa where HtmlID not in (Select GoodsPriceID from Shop_UserGoods)";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("批量抢购成功！");
            LoadData();
        }
    }
}