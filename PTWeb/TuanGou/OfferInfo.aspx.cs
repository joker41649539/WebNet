using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TuanGou_OfferInfo : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }

    }

    private void LoadData()
    {
        try
        {
            string weixinopenid = Request.Cookies["WeChat_XMFight"]["COPENID"];//"ollQItx5i3C0IUC_sQRvEzzQfXE4";//
            int iOfferListID = Convert.ToInt32(Request["id"]);
            string strSQL = "Select * from XMFight_Offer_List where openid='" + weixinopenid + "' and ID=" + iOfferListID;

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    Label_DDNo.Text = OP_Mode.Dtv[0]["offerddno"].ToString();
                    Label_OfferName.Text = OP_Mode.Dtv[0]["OfferName"].ToString();
                    TextBox_Name.Text = OP_Mode.Dtv[0]["ChildName"].ToString();
                    TextBox_Tel.Text = OP_Mode.Dtv[0]["Tel"].ToString();
                    TextBox_Remark.Text = OP_Mode.Dtv[0]["Remark"].ToString();
                }
            }
        }
        catch
        {
            MessageBox("", "用户身份信息获取失败。", "/XMFight/");
        }
    }

    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        try
        {
            string weixinopenid = Request.Cookies["WeChat_XMFight"]["COPENID"];//"ollQItx5i3C0IUC_sQRvEzzQfXE4";//

            int iID = Convert.ToInt32(Request["ID"]);

            strSQL = "Update XMFight_Offer_List set ChildName='" + TextBox_Name.Text.Replace("'", "") + "',Tel='" + TextBox_Tel.Text.Replace("'", "") + "',Remark='" + TextBox_Remark.Text.Replace("'", "") + "' where Openid='" + weixinopenid + "' and ID=" + iID;
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    Label_OfferName.Text = OP_Mode.Dtv[0]["Offername"].ToString();
                }

                MessageBox("", "资料信息更新成功。");
            }
        }
        catch
        {

        }
    }
}