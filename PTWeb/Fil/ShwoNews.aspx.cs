using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fil_Default3 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadNews();
        }
    }
    private void LoadNews()
    {
        string strSQL = "Select top 10 * from Fil_News order by Ltime desc";
        string strTemp = string.Empty;
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strTemp += "<div class=\"well counter\">";
                    if (OP_Mode.Dtv[i]["PicUrl"].ToString().Length > 10)
                    {
                        strTemp += "<img src=\"" + OP_Mode.Dtv[i]["PicUrl"].ToString() + "\" class=\"img-rounded\" width=\"100%\" />";
                        strTemp += "<hr />";
                    }
                    strTemp += "<a href=\""+ OP_Mode.Dtv[i]["Url"].ToString() + "\">" + OP_Mode.Dtv[i]["Title"].ToString() + "</a> " + OP_Mode.Dtv[i]["LTime"].ToString() + "";
                    strTemp += "<hr />";
                    strTemp += OP_Mode.Dtv[i]["Description"].ToString();
                    strTemp += "</div>";
                    strTemp += "<div class=\"hr hr12 dotted\"></div>";
                }
            }
        }

        NewsDiv.InnerHtml = strTemp;

    }
}