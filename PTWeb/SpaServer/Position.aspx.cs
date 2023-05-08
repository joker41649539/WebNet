using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpaServer_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //name=东升花园(站前东路)&latng=31.879457,117.345861&addr=安徽省合肥市瑶海区临泉东路与当涂路交叉口&city=合肥市&module=locationPicker
        MessageBox("", "地址=" + Request["name"] + "<br/>坐标=" + Request["latng"] + "<br/>详细地址=" + Request["addr"], "/SpaServer/");
        // https://3gimg.qq.com/lightmap/components/locationPicker2/back.html?name=%E4%B8%9C%E5%8D%87%E8%8A%B1%E5%9B%AD(%E7%AB%99%E5%89%8D%E4%B8%9C%E8%B7%AF)&latng=31.879457,117.345861&addr=%E5%AE%89%E5%BE%BD%E7%9C%81%E5%90%88%E8%82%A5%E5%B8%82%E7%91%B6%E6%B5%B7%E5%8C%BA%E4%B8%B4%E6%B3%89%E4%B8%9C%E8%B7%AF%E4%B8%8E%E5%BD%93%E6%B6%82%E8%B7%AF%E4%BA%A4%E5%8F%89%E5%8F%A3&city=%E5%90%88%E8%82%A5%E5%B8%82&module=locationPicker
    }
}