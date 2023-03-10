using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SendMsg : PageBaseRem
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            senMsg();
        }
    }

    private void senMsg()
    {
        //http://yanwo.x76.com.cn/remember/sendmsg.aspx?OPID=ooUML6LgLHJdW17frsAoI9V0s-ws&Title=%E6%A0%87%E9%A2%98&Num=32.2&Info=%E4%BF%A1%E6%81%AF&Remark=%E8%AF%B4%E6%98%8E&URL=#
        string strOPenid = "ooUML6EsI6okXuBBhZ-_l4ur204Y";
        string strTilte = "标题";
        string strNum = "0.00";
        string strInfo = "商品信息";
        string strRemark = "备注说明";
        string strURL = "#";

        strOPenid = Request["OPID"];
        strTilte = Request["Title"];
        strNum = Request["Num"];
        strInfo = Request["Info"];
        strRemark = Request["Remark"];
        strURL = Request["URL"];

        SendWeiXinDDZFCG(strOPenid, strTilte, strNum, strInfo, strRemark, strURL);
    }
}