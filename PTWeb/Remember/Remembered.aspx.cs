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

    /// <summary>
    /// 完成学习
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {//1\2\4\7\15
        string strSQL = " Update Remember set tRememberTime='" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "',lTime=getdate(),iRememberCount=iRememberCount+1 where tRememberTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and iRememberCount=1 ";
        strSQL += " Update Remember set tRememberTime='" + System.DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") + "',lTime=getdate(),iRememberCount=iRememberCount+1 where tRememberTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and iRememberCount=2 ";
        strSQL += " Update Remember set tRememberTime='" + System.DateTime.Now.AddDays(4).ToString("yyyy-MM-dd") + "',lTime=getdate(),iRememberCount=iRememberCount+1 where tRememberTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and iRememberCount=3 ";
        strSQL += " Update Remember set tRememberTime='" + System.DateTime.Now.AddDays(7).ToString("yyyy-MM-dd") + "',lTime=getdate(),iRememberCount=iRememberCount+1 where tRememberTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and iRememberCount=4 ";
        strSQL += " Update Remember set tRememberTime='" + System.DateTime.Now.AddDays(15).ToString("yyyy-MM-dd") + "',lTime=getdate(),iRememberCount=iRememberCount+1 where tRememberTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and iRememberCount>=5 ";
        /// 最后一次记忆结束，则赋值到最大日期
        // strSQL += " Update Remember set tRememberTime='2079-06-06 00:00:00',lTime=getdate() where tRememberTime<'" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + "' And iUserID=" + DefaultUser + " and iRememberCount=6 ";
        //this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script src=\"/assets/js/jquery-2.0.3.min.js\"></script> <script language=JavaScript>dialog = jqueryAlert({ 'title': '提示', 'content': '您确定要关闭吗？', 'modal': true, 'buttons': { '确定': function () {dialog.destroy();dialog.close(); },'取消': function () {dialog.destroy();dialog.close(); } })</script>");

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "恭喜，您已经完成今日的学习,<br>期待您明天的学习。", "Remember.aspx");
        }
        else
        {
            MessageBox("", "数据保存错误，请重试。");
        }
    }
}