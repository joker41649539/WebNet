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
    }
}