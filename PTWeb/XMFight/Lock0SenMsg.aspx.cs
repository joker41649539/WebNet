using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Lock0SenMsg : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Key1 = string.Empty, Key2 = string.Empty, Key3 = string.Empty;
            Key1 = Request["Key1"];
            Key2 = Request["Key2"];
            Key3 = Request["Key3"];
            SendMSG(Key1, Key2, Key3);
        }
    }

    private void SendMSG(string Key1, string Key2, string Key3)
    {
        string Lock0OpenID = "ooUML6KVfVGSIkG1roRjyXdOrxig";
        string JokerOpenID = "ooUML6EsI6okXuBBhZ-_l4ur204Y";

        SendSKTXMsg(Lock0OpenID, "Lock0", Key1, Key2, Key3, "备注", "");
        SendSKTXMsg(JokerOpenID, "Lock0", Key1, Key2, Key3, "备注", "");
    }
}