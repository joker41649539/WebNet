using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (DefaultUser.Length != 11)
        { /// 未登录，跳转到登录页面

        }
        else
        {
            MessageBox("", "恭喜，抢购成功。<br>系统已经自动扣除您总金额5%的金豆。<br/>请在一小时内付款。", "/Shop/BankCardByUser.aspx?ID=1&GoodsID=1");///提示成功后需要跳转到用户信息页面
        }
    }
}