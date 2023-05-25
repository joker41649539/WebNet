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
        string strSQL = "Select *,isnull((Select top 1 price from shop_goodsPrice where goodsid=Shop_Goods.ID order by Ctime desc),Price) NewPrice,(Select SetValue from Shop_SysSet where id=4) zz,(Select SetValue from Shop_SysSet where id=1) Gas from Shop_Goods ";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                double OPrice = 0, NPrice = 0;
                GridView_Goods.DataSource = OP_Mode.Dtv;
                GridView_Goods.DataBind();

                OP_Mode.Dtv.RowFilter = "Flag=0";
                Label1.Text = OP_Mode.Dtv.ToTable().Rows.Count.ToString();
                for (int i = 0; i < OP_Mode.Dtv.ToTable().Rows.Count; i++)
                {
                    OPrice += Convert.ToDouble(OP_Mode.Dtv.ToTable().Rows[i]["Price"]);
                    NPrice += Convert.ToDouble(OP_Mode.Dtv.ToTable().Rows[i]["NewPrice"]);
                }
                Label2.Text = OPrice.ToString();
                Label3.Text = NPrice.ToString();
            }
        }
    }

    protected void GridView_Goods_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int iID = Convert.ToInt32(GridView_Goods.DataKeys[e.NewEditIndex].Values[0]);
        int iFlag = Convert.ToInt32(GridView_Goods.DataKeys[e.NewEditIndex].Values[1]);
        if (iFlag == 0)
        {
            iFlag = 1;
        }
        else
        {
            iFlag = 0;
        }
        string strSQL = "Update Shop_Goods set Flag=" + iFlag + ",LTime=getdate() where ID=" + iID.ToString();
        if (OP_Mode.SQLRUN(strSQL))
        {
            e.NewEditIndex = -1;
            if (iFlag == 0)
            {
                MessageBox("藏品启用成功。");
            }
            else
            {
                MessageBox("藏品停用成功。");
            }
            LoadData();
        }
        else
        {
            MessageBox("藏品状态更新失败。");
            return;
        }
    }
}