using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : PageBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadIcoShow();
        }
    }


    private void LoadIcoShow()
    {
        /// 所有颜色数组
        string[] RandColor = new string[17];

        RandColor[0] = "infobox infobox-purple";
        RandColor[1] = "infobox infobox-purple2";
        RandColor[2] = "infobox infobox-pink";
        RandColor[3] = "infobox infobox-blue";
        RandColor[4] = "infobox infobox-blue2";
        RandColor[5] = "infobox infobox-blue3";
        RandColor[6] = "infobox infobox-red";
        RandColor[7] = "infobox infobox-brown";
        RandColor[8] = "infobox infobox-wood";
        RandColor[9] = "infobox infobox-light-brown";
        RandColor[10] = "infobox infobox-orange";
        RandColor[11] = "infobox infobox-orange2";
        RandColor[12] = "infobox infobox-green";
        RandColor[13] = "infobox infobox-green2";
        RandColor[14] = "infobox infobox-grey";
        RandColor[15] = "infobox infobox-black";
        RandColor[16] = "infobox infobox-dark";

        Random ran = new Random();

        int RandKey = ran.Next(0, 16); /// 获取随 0-16 的随机数。

        string STRSQL = "SELECT ICONAME FROM A_TEMP ORDER BY ICONAME";

        string strDTV = string.Empty;

        if (OP_Mode.SQLRUN(STRSQL))
        {
            for (int num = 0; num < OP_Mode.Dtv.Count; num++)
            {
                RandKey = ran.Next(0, 16);
                strDTV += "<div class=\"" + RandColor[RandKey] + " \">";
                strDTV += "  <div class=\"infobox-icon\">";
                strDTV += "    <i class=\"" + OP_Mode.Dtv[num][0].ToString().Trim() + "\"></i>";
                strDTV += "  </div>";
                strDTV += "  <div class=\"infobox-data\">";
                strDTV += "    <div class=\"infobox-content\">" + RandColor[RandKey].Substring(16) + "</div>";
                strDTV += "    <div class=\"infobox-content\">" + OP_Mode.Dtv[num][0].ToString().Trim() + "</div>";
                strDTV += "  </div>";
                strDTV += "</div>";
            }
        }

        this.ICOSHOW.InnerHtml = strDTV;

    }






}