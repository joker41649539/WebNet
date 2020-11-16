using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Msg_Default : PageBase
{
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (!QXBool(Constant.QX_S_QJGG, Convert.ToInt32(DefaultUser)))
            //{
            //    MessageBox("", "您没有查看的权限。", Defaut_QX_URL);
            //    return;
            //}

        }
    }

}