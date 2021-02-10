using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fil_Default2 : PageBase
{
    public string strSQL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUserInfo();
        }
    }
    private void LoadUserInfo()
    {
        try
        {
            int iUserID = Convert.ToInt32(Request.Cookies["WeChat_Yanwo"]["USERID"]);
            int iSumPower = 0;
            string strTempDiv = string.Empty;
            strSQL = "Select * from Fil_PowerComputer Where UserID=" + iUserID.ToString();

            if (OP_Mode.SQLRUN(strSQL))
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    iSumPower += Convert.ToInt32(OP_Mode.Dtv[i]["Power"]);
                    strTempDiv += " <div class=\"well\">";
                    strTempDiv += " <div class=\"widget-main\">";
                    strTempDiv += "    <div class=\"clearfix\">";
                    strTempDiv += "       <div class=\"grid2\">";
                    strTempDiv += "           <span class=\"grey\">";
                    strTempDiv += "              <i class=\"icon-facebook-sign icon-2x blue\"></i>";
                    strTempDiv += "               &nbsp; 算力值（T）";
                    strTempDiv += "           </span>";
                    strTempDiv += "           <br>";
                    strTempDiv += "           <h3 class=\"bigger pull-right\">" + OP_Mode.Dtv[i]["Power"].ToString() + "</h3>";
                    strTempDiv += "      </div>";
                    strTempDiv += "      <div class=\"grid2\">";
                    strTempDiv += "          <span class=\"grey\">";
                    strTempDiv += "             <i class=\"icon-heart icon-2x red\"></i>";
                    strTempDiv += "           &nbsp; 总产出（FIL）";
                    strTempDiv += "      </span>";
                    strTempDiv += "       <br>";
                    strTempDiv += "       <h3 class=\"bigger pull-right\">" + OP_Mode.Dtv[i]["SumFil"].ToString() + "</h3>";
                    strTempDiv += "   </div>";
                    strTempDiv += "  <div class=\"grid2\">";
                    strTempDiv += "      <span class=\"grey\">";
                    strTempDiv += "          <i class=\"icon-lock icon-2x red\"></i>";
                    strTempDiv += "         &nbsp; 锁仓中（FIL）";
                    strTempDiv += "     </span>";
                    strTempDiv += "     <br>";
                    strTempDiv += "      <h3 class=\"bigger pull-right\">" + OP_Mode.Dtv[i]["LockFil"].ToString() + "</h3>";
                    strTempDiv += "  </div>";
                    strTempDiv += "  <div class=\"grid2\">";
                    strTempDiv += "      <span class=\"grey\">";
                    strTempDiv += "          <i class=\"icon-credit-card icon-2x red\"></i>";
                    strTempDiv += "          &nbsp; 已释放（FIL）";
                    strTempDiv += "      </span>";
                    strTempDiv += "      <br>";
                    strTempDiv += "      <h3 class=\"bigger pull-right\">" + OP_Mode.Dtv[i]["ReleaseFil"].ToString() + "</h3>";
                    strTempDiv += "  </div>";
                    strTempDiv += "  <div class=\"grid2\">";
                    strTempDiv += "      <span class=\"grey\">";
                    strTempDiv += "          <i class=\"icon-calendar icon-2x green\"></i>";
                    strTempDiv += "          &nbsp; 生效日期";
                    strTempDiv += "     </span>";
                    strTempDiv += "     <br>";
                    strTempDiv += "      <h3 class=\"bigger pull-right\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["EffectiveTime"]).ToString("yyyy-MM-dd") + "</h3>";
                    strTempDiv += "  </div>";
                    strTempDiv += "  <div class=\"grid2\">";
                    strTempDiv += "     <span class=\"grey\">";
                    strTempDiv += "         <i class=\"icon-calendar icon-2x green\"></i>";
                    strTempDiv += "         &nbsp; 截止日期";
                    strTempDiv += "     </span>";
                    strTempDiv += "     <br>";
                    if (Convert.ToDateTime(OP_Mode.Dtv[i]["EndTime"]).ToString("yyyy-MM-dd") == "2099-01-01")
                    {
                        strTempDiv += "     <h3 class=\"bigger pull-right\">永久生效</h3>";
                    }
                    else
                    {
                        strTempDiv += "     <h3 class=\"bigger pull-right\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["EndTime"]).ToString("yyyy-MM-dd") + "</h3>";
                    }
                    strTempDiv += "  </div>";
                    strTempDiv += "  </div>";
                    strTempDiv += "  </div>";
                    strTempDiv += "  </div>";
                    strTempDiv += "  <hr />";
                }
                Label_ComputerCount.Text = OP_Mode.Dtv.Count.ToString();
                Label_SumPower.Text = iSumPower.ToString();

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