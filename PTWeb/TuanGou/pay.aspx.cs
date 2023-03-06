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
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    protected string wx_packageValue = "";
    protected string XSDValue = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Request.QueryString["No"] != null && Request.QueryString["No"] != "")
        //    {
        //        string strNo = Request.QueryString["No"];
        //        try
        //        {
        string strDDNo = "TestDD" + System.DateTime.Now.ToString("yyyy") + System.DateTime.Now.ToString("MM") + System.DateTime.Now.ToString("dd") + System.DateTime.Now.ToString("HH") + System.DateTime.Now.ToString("mm") + System.DateTime.Now.ToString("fff");
        LoadFKXX(strDDNo);
        //        }
        //        catch
        //        {

        //        }
        //    }

    }

    /// <summary>
    /// 依据销售库
    /// </summary>
    /// <param name="IXSDID"></param>
    private void LoadFKXX(string strNo)
    {
        //string strSQL = "Select * from W_Buy1 Where DDNo='" + strNo + "'";

        //if (OP_Mode.SQLRUN(strSQL))
        //{

        this.Label_DDH.Text = strNo;
        this.Label_LXR.Text = "联系人";
        this.Label_LXDH.Text = "电话";
        //this.Label_SHDZ.Text = OP_Mode.Dtv[0]["SHDZ"].ToString().Trim();
        this.Label_ZFJE.Text = "0.01";
        //this.Label_Remark.Text = OP_Mode.Dtv[0]["Remark"].ToString().Trim();

        var weixinopenid = string.Empty;
        //try
        //{
        // 读取用户微信ID。
        //weixinopenid = Request.Cookies["WeChat_Yanwo"]["COPENID"];//"ollQItx5i3C0IUC_sQRvEzzQfXE4";//
        weixinopenid = "ooUML6EsI6okXuBBhZ-_l4ur204Y";
        string _Pay_Package = LoadPayID(weixinopenid, strNo, Convert.ToDecimal(Label_ZFJE.Text), "旭铭搏击");
        //微信jspai支付
        if (_Pay_Package.Length > 0)
        {
            wx_packageValue = _Pay_Package;
        }
        //}
        //catch
        //{

        //}
        //}

    }
}

//}