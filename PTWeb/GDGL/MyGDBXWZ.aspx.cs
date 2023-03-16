﻿using System;
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
            string strSQL = "SELECT distinct mAX(GCMC) gcmc,(Select top 1 USERS from W_GCGD_USERS where GCDID=" + iid + " and Charge=1 and Flag=0) ZID,AZWZ,(Select isnull(sum(ipercent),0) from W_GCGD_USERS where GCDID=" + iid + " and Flag=0) SumPercent,(Select case Charge when 1 then '(主)'+ CNAME+' '+cast(ipercent as varchar)+'%; ' else CNAME+' '+cast(ipercent as varchar)+'%; ' end from W_GCGD_USERS,W_GCGD1,S_USERINFO where GCDID=W_GCGD1.ID and USERS=S_USERINFO.ID and W_GCGD_USERS.Flag=0 and W_GCGD1.ID=" + iid + " order by charge desc,CNAME for xml path('')) BXRS,MAX(W_GCGD2.ID) IID,COUNT(W_GCGD2.ID) MXCOUNT,(Select CNAME+' '+cast(fs as nvarchar)+'%'+';' from W_GCGD_FS,S_USERINFO where USERID=S_USERINFO.ID and gcmxid =Max(W_GCGD2.ID) and fs>0 order by CNAME for xml path('')) BXRY FROM W_GCGD_USERS,W_GCGD1,W_GCGD2,S_YH_QXZ WHERE USERS=" + DefaultUser + " AND W_GCGD1.ID=" + iid + " AND W_GCGD1.GCDH=W_GCGD2.GCDH AND W_GCGD1.ID=GCDID and W_GCGD_USERS.USERS=USERID and QXZID=3 and flag=0 GROUP BY AZWZ order by IID";
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                    {
                        HiddenField_ZID.Value = OP_Mode.Dtv[0]["ZID"].ToString();
                        strHTML += " <div class='infobox infobox-green'> ";
                        //strHTML += "  <div class='infobox-icon'> ";
                        //strHTML += "      <i class='icon-legal'></i> ";
                        //strHTML += " </div> ";
                        strHTML += "<div class='infobox-content'> ";
                        strHTML += "  <span class='icon-legal'>&nbsp;<a ";
                        if (Convert.ToInt32(OP_Mode.Dtv[i]["SumPercent"]) != 100)
                        {
                            strHTML += " onclick=\"return myFunction()\"";
                        }

                        if (HiddenField_ZID.Value == DefaultUser)
                        {// 如果是主负责才允许修改人员占比
                            strHTML += " href = '\\GDGL\\GCBXListPH.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' >" + OP_Mode.Dtv[i]["AZWZ"].ToString() + " ";
                        }
                        else
                        {
                            strHTML += " href='#'>" + OP_Mode.Dtv[i]["AZWZ"].ToString() + " ";
                        }

                        if (OP_Mode.Dtv[i]["BXRY"].ToString().Length > 0)
                        {
                            strHTML += " <br/>[" + OP_Mode.Dtv[i]["BXRY"].ToString() + "]";
                        }

                        strHTML += " </a></span> ";
                        strHTML += " <div class='infobox-content'> ";
                        if (HiddenField_ZID.Value == DefaultUser)
                        {// 如果是主负责才允许修改人员占比

                            strHTML += "    <a href = '\\GDGL\\GCBXListPH.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' > 累计：" + OP_Mode.Dtv[i]["MXCOUNT"].ToString() + " 安装项</a>";
                        }
                        else
                        {
                            strHTML += " <a href='#'>累计：" + OP_Mode.Dtv[i]["MXCOUNT"].ToString() + " 安装项</a> ";
                        }
                        strHTML += " </div> ";
                        strHTML += "</div> ";
                        strHTML += "</div> ";

                    }
                }
            }
            if (strHTML.Length > 0)
            {
                if (HiddenField_ZID.Value == DefaultUser)
                {// 如果是主负责才允许修改人员占比
                    Label_BXRY.NavigateUrl = "/GDGL/BXPercent.aspx?ID=" + iid;
                }
                Label_GCMC.Text = OP_Mode.Dtv[0]["GCMC"].ToString();
                Label_BXRY.Text = OP_Mode.Dtv[0]["BXRS"].ToString();
                Dtv_HTML.InnerHtml = strHTML;
            }
        }
    }
}