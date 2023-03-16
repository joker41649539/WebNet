using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RetunUrl : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        var strURL = Request["URL"];// = "/CWGL/ReimbursementAdd.aspx;ID=10947";
        var RUrl = string.Empty;

        if (strURL.IndexOf(";") > -1)
        {
            strURL = strURL.Replace(";", "?");
            RUrl = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=wwcb109f513aaa59b1&redirect_uri=http%3a%2f%2fwww.putian.ink/{0}&Wechat%3d0&response_type=code&scope=snsapi_base&state=%23wechat_redirect", strURL);
        }
        else
        {
            RUrl = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid=wwcb109f513aaa59b1&redirect_uri=http%3a%2f%2fwww.putian.ink/{0}%3fWechat%3d0&response_type=code&scope=snsapi_base&state=%23wechat_redirect", strURL);
        }

        Response.Redirect(RUrl, false);
    }

}