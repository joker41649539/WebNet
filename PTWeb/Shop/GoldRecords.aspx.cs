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
                TextBox_DataS.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                TextBox_DataE.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                LoadData();
            }
        }
    }
    private void LoadData()
    {
        string sDate = Convert.ToDateTime(TextBox_DataS.Text).ToString("yyyy-MM-dd") + " 00:00:00";
        string EDate = Convert.ToDateTime(TextBox_DataE.Text).ToString("yyyy-MM-dd") + " 23:59:59";
        string strSQL = string.Empty;
        int DSum = 0;
        strSQL = "Select * from Shop_Gold where CTime between '" + sDate + "' and '" + EDate + "' order by CTime";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView_Goods.DataSource = OP_Mode.Dtv;
                GridView_Goods.DataBind();
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    DSum += Convert.ToInt32(OP_Mode.Dtv[i]["Bance"].ToString());
                }
                Label_Sum.Text = DSum.ToString();
            }
            else
            {
                GridView_Goods.DataSource = null;
                GridView_Goods.DataBind();
                Label_Sum.Text = "0.00";
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}