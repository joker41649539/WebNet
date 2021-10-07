using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_GCBXDel : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string LoginID;
            LoginID = Request.Cookies["WeChat_Yanwo"]["USERID"].ToString();
        }
        catch
        {
            MessageBox("", "您还未登陆，无权查看该页！<br/>请先登陆！", "/Login.aspx");
            return;
        }


        if (!IsPostBack)
        {
            if (!QXBool(46, Convert.ToInt32(DefaultUser)))
            {
                MessageBox("", "您没有积分的权限。", Defaut_QX_URL);
                return;
            }
            else
            {
                try
                {
                    DelJF(Convert.ToInt32(Request["ID"]));
                }
                catch
                {
                    MessageBox("", "积分删除失败,请重试。", "/GDGL/");
                }
            }
        }

    }
    private void DelJF(int IID)
    {
        string strSQL = "Delete from W_GCGD_FS where id=" + IID;
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "积分删除成功。", "/GDGL/");
        }
        else
        {
            MessageBox("", "积分删除失败,请重试。", "/GDGL/");
        }
    }
}