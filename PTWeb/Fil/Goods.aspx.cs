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
            LoadUserInfo();
        }
    }
    private void LoadUserInfo()
    {
        string strSQL;
        try
        {
            int iSumPower = 0;
            string strTempDiv = string.Empty;
            strSQL = "Select * from Fil_Goods Where Flag = 0";

            if (OP_Mode.SQLRUN(strSQL))
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strTempDiv += " <div class=\"well\">";
                    strTempDiv += " <div class=\"widget-main\">";
                    strTempDiv += "    <div class=\"clearfix\">";
                    strTempDiv += "       <div class=\"grid2\">";
                    strTempDiv += "           <span class=\"grey\">";
                    strTempDiv += "              <img src=\"/images/Fil.png\" width=\"25px\" />";
                    strTempDiv += "               &nbsp; 产品名称：";
                    strTempDiv += "           </span>";
                    strTempDiv += "           <br>";
                    strTempDiv += "           <h3 class=\"bigger pull-right\">" + OP_Mode.Dtv[i]["CName"].ToString() + "</h3>";
                    strTempDiv += "      </div>";
                    strTempDiv += "      <div class=\"grid2\">";
                    strTempDiv += "          <span class=\"grey\">";
                    strTempDiv += "             <i class=\"icon-heart icon-2x red\"></i>";
                    strTempDiv += "           &nbsp; 有效算力(T)：";
                    strTempDiv += "      </span>";
                    strTempDiv += "       <br>";
                    strTempDiv += "       <h3 class=\"bigger pull-right\">" + OP_Mode.Dtv[i]["Power"].ToString() + "</h3>";
                    strTempDiv += "   </div>";
                    strTempDiv += "  <div class=\"grid2\">";
                    strTempDiv += "      <span class=\"grey\">";
                    strTempDiv += "          <i class=\"icon-credit-card icon-2x red\"></i>";
                    strTempDiv += "         &nbsp; 销售价(元)：";
                    strTempDiv += "     </span>";
                    strTempDiv += "     <br>";
                    strTempDiv += "      <h3 class=\"bigger pull-right red\">" + OP_Mode.Dtv[i]["Price"].ToString() + "</h3>";
                    strTempDiv += "  </div>";
                    strTempDiv += "  <div class=\"grid2\">";
                    strTempDiv += "      <span class=\"grey\">";
                    strTempDiv += "          <i class=\"icon-calendar icon-2x red\"></i>";
                    strTempDiv += "          &nbsp; 有效期(年)：";
                    strTempDiv += "      </span>";
                    strTempDiv += "      <br>";
                    if (Convert.ToInt32(OP_Mode.Dtv[i]["Years"]) == 0)
                    {
                        strTempDiv += "      <h3 class=\"bigger pull-right red\" >永久生效</h3>";
                    }
                    else
                    {
                        strTempDiv += "      <h3 class=\"bigger pull-right\">" + OP_Mode.Dtv[i]["Years"].ToString() + "</h3>";
                    }
                    strTempDiv += "  </div>";
                    strTempDiv += "   <p>";

                    strTempDiv += "   <span class=\"label label-primary\">头矿红利</span>";
                    strTempDiv += "   <span class=\"label label-success\">极速挖矿</span>";
                    strTempDiv += "   <span class=\"label label-danger\">极速收益</span>";
                    strTempDiv += "   <span class=\"label label-purple\">无质押</span>";
                    strTempDiv += "   </p>";

                    strTempDiv += "  </div>";
                    strTempDiv += "  </div>";
                    strTempDiv += "  </div>";
                    strTempDiv += "  <hr />";
                }
                if (strTempDiv.Length > 0)
                {
                    Div_ComputerInfo.InnerHtml = strTempDiv;
                }
            }
        }
        catch
        {
            MessageBox("错误", "用户信息获取失败。", "/Fil/Info.aspx");
        }
    }
}