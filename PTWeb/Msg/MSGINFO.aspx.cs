using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Msg_MSGINFO : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMSGINFO();
        }
    }

    private void LoadMSGINFO()
    {
        try
        {
            if (Convert.ToInt32(Request["ID"]) > 0)
            {
                int TID = Convert.ToInt32(Request["ID"]);
                string strSQL = string.Empty;

                strSQL = " update S_MSG_YD set iyd=1,LTime=getdate() where imsgid=" + TID + " and isendid=" + DefaultUser + " ";
                strSQL += "SELECT top 1 IYD,CTITLE,CCONTENT,S_MSG.CTIME,CNAME,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=1 AND IYD=1) YYD,(SELECT COUNT(ID) FROM S_MSG_YD WHERE IMSGID=1) ZYD FROM S_MSG,S_MSG_YD,S_USERINFO WHERE S_MSG.ID=" + TID + " AND S_MSG.ID=S_MSG_YD.IMSGID AND S_MSG_YD.ISENDID=" + DefaultUser + " AND S_MSG.IUSERID=S_USERINFO.ID ";


                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        Label_Title.Text = OP_Mode.Dtv[0]["CTITLE"].ToString();
                        DivContent.InnerHtml = OP_Mode.Dtv[0]["CCONTENT"].ToString();
                        Label1.Text = "&nbsp;&nbsp; <a href='/MSG/MSGYD.ASPX?ID=" + TID + "'>" + OP_Mode.Dtv[0]["YYD"].ToString() + "/" + OP_Mode.Dtv[0]["ZYD"].ToString() + "</a> " + OP_Mode.Dtv[0]["CNAME"].ToString() + "( " + Convert.ToDateTime(OP_Mode.Dtv[0]["CTIME"]).ToString("yyyy-MM-dd") + " )";
                    }
                }
            }
            else
            {
                MessageBox("", "非法操作！请重试。", "./");
            }
        }
        catch
        {
            MessageBox("", "非法操作！请重试。<br> 错误：" + OP_Mode.strErrMsg, "./");
        }
    }
}