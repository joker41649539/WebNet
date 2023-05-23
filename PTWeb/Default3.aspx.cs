using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var client = new WebClient();
        string PhoneNo = "111";
        string GoodsID = "22";
        var serializer = new JavaScriptSerializer();
        client.Encoding = System.Text.Encoding.UTF8;//定义对象语言
        var url = string.Format("https://ptweb.x76.com.cn/Shop/ApiGoodsPrice.aspx?PhoneNo={0}&GoodsID={1}", PhoneNo, GoodsID);

        var getJson = client.DownloadString(url).Substring(1, client.DownloadString(url).Length - 2);

        Rootobject rt = JsonConvert.DeserializeObject<Rootobject>(getJson);

    }

    public class Rootobject
    {
        public string Msg { get; set; }
        public string errMsg { get; set; }
    }

}