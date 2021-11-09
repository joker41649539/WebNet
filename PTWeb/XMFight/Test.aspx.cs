using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Test : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MessageBox("", DateTime.Today.DayOfWeek.ToString());
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // SendSKTXMsg();
        string msg = SendXKMsg("ooUML6EsI6okXuBBhZ-_l4ur204Y", "测试", "自由搏击", "10", System.DateTime.Now.ToString("yyyy-MM-dd dddd HH:mm"), "-1 课时", "谢谢您对旭铭搏击的支持，坚持不懈是一种非常好的习惯。", "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf60778eb4d1003de&redirect_uri=http%3A%2F%2Fptweb.x76.com.cn%2FXMFight&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
        if (msg.Length > 0)
        {
            MessageBox("", msg);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string msg = SendSKTXMsg("ooUML6EsI6okXuBBhZ-_l4ur204Y", "自由搏击", "10", System.DateTime.Now.ToString("yyyy-MM-dd dddd HH:mm"), "-1 课时", "谢谢您对旭铭搏击的支持，坚持不懈是一种非常好的习惯。", "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf60778eb4d1003de&redirect_uri=http%3A%2F%2Fptweb.x76.com.cn%2FXMFight&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
        if (msg.Length > 0)
        {
            MessageBox("", msg);
        }
    }
}