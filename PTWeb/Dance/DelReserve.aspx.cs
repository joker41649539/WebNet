using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dance_Default3 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DelArrage();
    }
    private void DelArrage()
    {
        int iid = Convert.ToInt32(Request["ID"]);
        if (iid > 0)
        {
            string strSQL = "Delete from Dance_Arrange where ID=" + iid;
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "预约信息删除成功。", "/Dance/MyInfo.aspx");
                return;
            }
        }
        else
        {
            MessageBox("", "预约信息删除失败，请重试。", "/Dance/MyInfo.aspx");
        }
    }
}