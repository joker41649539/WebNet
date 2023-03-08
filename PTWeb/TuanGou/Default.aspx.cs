using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TuanGou_Default : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDataByOpenID();
        }
    }

    /// <summary>
    /// 加载基础数据
    /// </summary>
    private void LoadDataByOpenID()
    {
        try
        {
            string weixinopenid = Request.Cookies["WeChat_XMFight"]["COPENID"];//"ollQItx5i3C0IUC_sQRvEzzQfXE4";//
            string strSQL = "Select offerddno,OfferName,offerid,ctime,payflag,ID,offerprice from XMFight_Offer_List where openid='" + weixinopenid + "'";

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    GridView1.DataSource = OP_Mode.Dtv;
                    GridView1.DataBind();
                }
            }
        }
        catch
        {
            MessageBox("", "用户身份信息获取失败。", "/XMFight/");
        }
    }
}