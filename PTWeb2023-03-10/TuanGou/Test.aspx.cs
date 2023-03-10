using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TuanGou_Default3 : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }



    /// <summary>
    /// 生成获得二维码的值
    /// </summary>
    public string Ecod(int strID)
    {
        string sValue = string.Empty;
        var url = string.Format(" https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", GetaccessToken());

        var data = "{\"action_name\": \"QR_LIMIT_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": " + strID + "}}}";

        var serializer = new JavaScriptSerializer();
        var obj = serializer.Deserialize<Dictionary<string, string>>(PostWeixinPage(url, data));
        if (!obj.TryGetValue("ticket", out sValue))
        {

        }
        // var imageurl = string.Format("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}", sValue);
        return sValue;
    }
}