using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Remember_Remembered : PageBaseRem
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefaultData();
        }
    }

    /// <summary>
    /// 加载基础数据
    /// </summary>
    private void LoadDefaultData()
    {
        string strSQL = "Select * from Remember Where ltime>'" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' and NextTime >='" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " order by ICount";
        string strTemp = string.Empty;
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strTemp += "<div class=\"well\">";
                    strTemp += "   <h6 class=\"blue\"> 序号：" + (OP_Mode.Dtv.Count - i).ToString() + " [" + Convert.ToDateTime(OP_Mode.Dtv[i]["LTime"]).ToString("yyyy-MM-dd hh:mm") + "]</h6>";
                    strTemp += "   <h3 class=\"red lighter\">" + OP_Mode.Dtv[i]["CContent"].ToString().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</h3>";
                    strTemp += "   <h4 class=\"green\">" + OP_Mode.Dtv[i]["CRemark"].ToString().Replace("\r\n", "<br/>").Replace("\n", "<br/>") + "</h4>";
                    strTemp += "   <h6>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + " 第 1 次背诵，已背诵 " + OP_Mode.Dtv[i]["ICount"].ToString() + " 次。</h6>";
                    strTemp += "   <div class=\"btn-group\">";
                    strTemp += "     <a href=\"RememberAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm btn-info\"><i class=\"icon-edit\"></i>编辑</a>";
                    strTemp += "   </div>";
                    strTemp += "</div>";
                }
                if (strTemp.Length > 0)
                {
                    accordion.InnerHtml = strTemp;
                }
            }
        }
    }

}