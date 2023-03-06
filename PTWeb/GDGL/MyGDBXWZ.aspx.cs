using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_MyGDBXWZ : PageBase
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
            LoadData();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void LoadData()
    {
        int iid = 0;

        try
        {
            iid = Convert.ToInt32(Request["ID"]);
        }
        catch
        {

        }
        if (iid > 0)
        {
            string strHTML = string.Empty;
            string strSQL = "SELECT distinct mAX(GCMC) gcmc,AZWZ,(Select CNAME+';' from W_GCGD_USERS,W_GCGD1,S_USERINFO where GCDID=W_GCGD1.ID and USERS=S_USERINFO.ID and W_GCGD_USERS.Flag=0 and W_GCGD1.ID=" + iid + " for xml path('')) BXRS,MAX(W_GCGD2.ID) IID,COUNT(W_GCGD2.ID) MXCOUNT,(Select CNAME+' '+cast(fs as nvarchar)+'%'+';' from W_GCGD_FS,S_USERINFO where USERID=S_USERINFO.ID and gcmxid =Max(W_GCGD2.ID) and fs>0 for xml path('')) BXRY FROM W_GCGD_USERS,W_GCGD1,W_GCGD2,S_YH_QXZ WHERE USERS=" + DefaultUser + " AND W_GCGD1.ID=" + iid + " AND W_GCGD1.GCDH=W_GCGD2.GCDH AND W_GCGD1.ID=GCDID and W_GCGD_USERS.USERS=USERID and QXZID=3 and flag=0 GROUP BY AZWZ order by IID";
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                    {

                        strHTML += " <div class='infobox infobox-green'> ";
                        //strHTML += "  <div class='infobox-icon'> ";
                        //strHTML += "      <i class='icon-legal'></i> ";
                        //strHTML += " </div> ";
                        strHTML += "<div class='infobox-content'> ";
                        strHTML += "  <span class='icon-legal'>&nbsp;<a href = '\\GDGL\\GCBXListPH.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' >" + OP_Mode.Dtv[i]["AZWZ"].ToString() + " ";

                        if (OP_Mode.Dtv[i]["BXRY"].ToString().Length > 0)
                        {
                            strHTML += " [" + OP_Mode.Dtv[i]["BXRY"].ToString() + "]";
                        }

                        strHTML += " </a></span> ";
                        strHTML += " <div class='infobox-content'> ";
                        strHTML += "    <a href = '\\GDGL\\GCBXListPH.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' > 累计：" + OP_Mode.Dtv[i]["MXCOUNT"].ToString() + " 安装项</a>";
                        strHTML += " </div> ";
                        strHTML += "</div> ";
                        strHTML += "</div> ";

                    }
                }
            }
            if (strHTML.Length > 0)
            {
                Label_GCMC.Text = OP_Mode.Dtv[0]["GCMC"].ToString();
                Label_BXRY.Text = OP_Mode.Dtv[0]["BXRS"].ToString();
                Dtv_HTML.InnerHtml = strHTML;
            }
        }
    }
}