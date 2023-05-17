using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpaServer_Default2 : PageBaseShop
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MessageBox("", "您已经确认付款款。<br>我们已经通知用户查收。");
        return;
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        MessageBox("", "您已经确认收款。<br>商品归属已经移给您。");
        return;
    }
}