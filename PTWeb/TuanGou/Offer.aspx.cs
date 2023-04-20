using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Pay : PageBaseXMFight
{
    //  OpMode OP_Mode = new OpMode(DefaultConStr, 0);
    #region pageParameters
    public static string getNewDate;

    protected string wx_packageValue = "";
    protected string XSDValue = "";
    protected string OfferID = "";

    public string appId { get; set; }
    public string timeStamp { get; set; }

    public string nonceStr { get; set; }

    public string signature { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        // 微信JS签名
        this.appId = "wxf60778eb4d1003de"; /// 企业微信ID
        this.timeStamp = getTimestamp();
        this.nonceStr = getNoncestr();
        this.signature = GenSignature(this.nonceStr, this.timeStamp);
        this.DataBind();

        getNewDate = "2023-03-08";

        string strDDNo = "Offer" + System.DateTime.Now.ToString("yyyy") + System.DateTime.Now.ToString("MM") + System.DateTime.Now.ToString("dd") + System.DateTime.Now.ToString("HH") + System.DateTime.Now.ToString("mm") + System.DateTime.Now.ToString("fff");
        XSDValue = strDDNo;
        LoadFKXX(strDDNo);

    }
    /// <summary>
    /// 依据销售库
    /// </summary>
    /// <param name="IXSDID"></param>
    private void LoadFKXX(string strNo)
    {
        var weixinopenid = string.Empty;
        try
        {
            int iOfferID = Convert.ToInt32(Request["ID"]);
            string Images = string.Empty;
            string strSQL = "Select * from XMFight_Offer where ID=" + iOfferID;

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    OfferID = iOfferID.ToString();
                    getNewDate = OP_Mode.Dtv[0]["OfferETime"].ToString();
                    Label1.Text = OP_Mode.Dtv[0]["OfferPrice"].ToString();
                    Master.Page.Title = OP_Mode.Dtv[0]["OfferName"].ToString();
                    Images = OP_Mode.Dtv[0]["OfferImage"].ToString();

                    DateTime dt1 = DateTime.Now;

                    DateTime dt2 = Convert.ToDateTime(OP_Mode.Dtv[0]["OfferETime"].ToString());

                    TimeSpan ts = dt2 - dt1;

                    if (ts.Days > 5)
                    {// 有效期超过5天以上，不显示倒计时
                        show.Visible = false;
                        LastText.Visible = false;
                    }
                    else
                    {
                        show.Visible = true;
                        LastText.Visible = true;
                    }

                    //读取用户微信ID。
                    weixinopenid = Request.Cookies["WeChat_XMFight"]["COPENID"];//"ollQItx5i3C0IUC_sQRvEzzQfXE4";//
                                                                                // weixinopenid = "ooUML6EsI6okXuBBhZ-_l4ur204Y";
                    if (Convert.ToDateTime(OP_Mode.Dtv[0]["OfferETime"]) > System.DateTime.Now)
                    {///有效期内才执行
                        string _Pay_Package = LoadPayID(weixinopenid, strNo, Convert.ToDecimal(OP_Mode.Dtv[0]["OfferPrice"]), OP_Mode.Dtv[0]["OfferName"].ToString());
                        //微信jspai支付
                        if (_Pay_Package.Length > 0)
                        {
                            wx_packageValue = _Pay_Package;
                        }
                    }
                }
                else
                {
                    MessageBox("", "没有已生效的团购信息。", "/XMFight/Contact.aspx");
                }
            }
        }
        catch
        {

        }
    }

}
