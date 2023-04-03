using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_MyGDAZWZ : PageBase
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
            string strSQL = "SELECT mAX(GCMC) gcmc,isnull((SELECT CNAME + ' 布线：'+cast(SUM(W_GCGD_FS.FS*W_GCGD2.FS/100) as nvarchar)+'; 安装：'+cast(SUM(W_GCGD_FS.AZFS*W_GCGD2.AZFS/100) as nvarchar)+';' FROM W_GCGD1,W_GCGD2,W_GCGD_FS,S_USERINFO WHERE W_GCGD1.GCDH=W_GCGD2.GCDH AND GCMXID=W_GCGD2.ID AND W_GCGD1.ID=" + iid + " AND S_USERINFO.ID=USERID GROUP BY CNAME for xml path('')),'') fsmx,AZWZ,MAX(W_GCGD2.ID) IID,COUNT(W_GCGD2.ID) MXCOUNT,(Select CNAME+';' from W_GCGD_USERS,W_GCGD1,S_USERINFO where GCDID=W_GCGD1.ID and USERS=S_USERINFO.ID and W_GCGD_USERS.Flag=1 and W_GCGD1.ID=" + iid + " for xml path('')) BXRS ,case (Select count(c.ID) from W_GCGD2 c,W_GCGD1 d where c.GCDH=d.GCDH and d.ID=" + iid + " and AZWZ=W_GCGD2.AZWZ and c.AZFS>0) when 0 then '0%' else cast(isnull((Select sum(AZFS)/(Select count(d.ID) from W_GCGD2 c,W_GCGD1 d where c.GCDH=d.GCDH and d.ID=" + iid + " and AZWZ=W_GCGD2.AZWZ and c.AZFS>0)  from W_GCGD_FS where GCMXID in (Select a.ID from W_GCGD1 b,W_GCGD2 a where a.GCDH=b.GCDH and b.ID=" + iid + " and AZWZ=W_GCGD2.AZWZ) and AZFS>0),0) as nvarchar)+'%' end AZRY FROM W_GCGD_USERS,W_GCGD1,W_GCGD2 WHERE USERS=" + DefaultUser + " AND W_GCGD1.ID=" + iid + " AND W_GCGD1.GCDH=W_GCGD2.GCDH AND W_GCGD1.ID=GCDID and flag=1 GROUP BY AZWZ order by IID";
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
                        strHTML += "  <span class='icon-legal'>&nbsp;<a href = '\\GDGL\\GCAZListph.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' >" + OP_Mode.Dtv[i]["AZWZ"].ToString();

                        if (OP_Mode.Dtv[i]["AZRY"].ToString().Length > 0)
                        {
                            strHTML += " [" + OP_Mode.Dtv[i]["AZRY"].ToString() + "]";
                        }

                        strHTML += " </a></span> ";
                        strHTML += " <div class='infobox-content'> ";
                        strHTML += "    <a href = '\\GDGL\\GCAZListph.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' > 累计：" + OP_Mode.Dtv[i]["MXCOUNT"].ToString() + " 安装项</a>";
                        strHTML += " </div> ";
                        strHTML += "</div> ";
                        strHTML += "</div> ";

                    }
                }
            }
            if (strHTML.Length > 0)
            {
                Label_GCMC.Text = OP_Mode.Dtv[0]["GCMC"].ToString();
                Label_AZRY.Text = "[" + OP_Mode.Dtv[0]["BXRS"].ToString() + "] [" + OP_Mode.Dtv[0]["fsmx"].ToString() + "]";
                Dtv_HTML.InnerHtml = strHTML;
            }
        }
    }
}