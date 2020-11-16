using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_MyAZGD : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    private void LoadData()
    {
        string strHTML = string.Empty;
        string strSQL = string.Empty;

        // 布线工程
        strSQL = "SELECT GCMC,MAX(W_GCGD1.ID) IID,COUNT(W_GCGD1.ID) MXCOUNT FROM W_GCGD_USERS,W_GCGD1,W_GCGD2,S_YH_QXZ WHERE USERS=" + DefaultUser + " AND FLAG=1 AND W_GCGD1.GCDH=W_GCGD2.GCDH AND W_GCGD1.ID=GCDID and W_GCGD_USERS.USERS=USERID and QXZID=4 GROUP BY GCMC ORDER BY GCMC";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHTML += " <div class='infobox infobox-green'> ";
                    strHTML += "<div class='infobox-content'> ";
                    strHTML += "  <span class='icon-legal'>&nbsp;<a href = '\\GDGL\\MyGDAZWZ.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' >" + OP_Mode.Dtv[i]["GCMC"].ToString() + "</a></span> ";
                    strHTML += " <div class='infobox-content'> ";
                    strHTML += "    <a href = '\\GDGL\\MyGDAZWZ.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' > 累计：" + OP_Mode.Dtv[i]["MXCOUNT"].ToString() + " 安装项</a>";
                    strHTML += " </div> ";
                    strHTML += "</div> ";
                    strHTML += "</div> ";
                }
            }
        }

        Dtv_HTML.InnerHtml = strHTML;

    }
}