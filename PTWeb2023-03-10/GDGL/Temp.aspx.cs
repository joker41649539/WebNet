using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_Temp :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LinkButton_Save_Click(object sender, EventArgs e)
    {
        MessageBox("", "提示：" + Request.Form["ck1"]);
    }
}