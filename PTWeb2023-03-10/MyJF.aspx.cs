using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyJF : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //try
            //{
            //    LoginID = Request.Cookies["WeChat_Yanwo"]["USERID"].ToString();
            //}
            //catch
            //{
            //    MessageBox("", "您还未登陆，无权查看该页！<br/>请先登陆！", "/Login.aspx");
            //    return;
            //}

            Load_Data();
        }
    }

    protected void GridView_WZLLD_TJADD_Click(object sender, EventArgs e)

    {

        string strDiv = string.Empty;

        if (this.GridView_WZLLD_TextBox_CXTJ.Text.Length == 0)

        {

            this.GridView_WZLLD_TextBox_CXTJ.Text = "空";

        }

        if (this.GridView_WZLLD_Label1.Text.Length > 0)

        {

            this.GridView_WZLLD_Label1.Text += "<b>并且</b><br />";

            this.GridView_WZLLD_Label_tj.Text += " and ";

        }

        this.GridView_WZLLD_Label1.Text += this.GridView_WZLLD_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_WZLLD_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_WZLLD_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_WZLLD_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_WZLLD_Label_tj.Text += " " + this.GridView_WZLLD_DropDownList1.SelectedValue + " " + this.GridView_WZLLD_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_WZLLD_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_WZLLD_Label_tj.Text += " " + this.GridView_WZLLD_DropDownList1.SelectedValue + " " + this.GridView_WZLLD_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_WZLLD_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_WZLLD_TextBox_CXTJ.Text = string.Empty;

        this.GridView_WZLLD_alerts_tj.Visible = true;

    }

    /// <summary>

    /// 清除查询条件

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_WZLLD_LinkButton3_Click(object sender, EventArgs e)

    {

        this.GridView_WZLLD_TextBox_CXTJ.Text = string.Empty;

        this.GridView_WZLLD_Label1.Text = string.Empty;

        this.GridView_WZLLD_Label_tj.Text = string.Empty;

        this.GridView_WZLLD_alerts_tj.Visible = false;

        Load_Data();

    }

    /// <summary>

    /// 查询

    /// </summary>

    /// <param name="sender"></param>

    /// <param name="e"></param>

    protected void GridView_WZLLD_LinkButton4_Click(object sender, EventArgs e)
    {
        Load_Data();
    }
    /// <summary>
    /// 加载积分数据
    /// </summary>
    private void Load_Data()
    {
        string strSQL = string.Empty;

        if (this.GridView_WZLLD_Label_tj.Text.Length > 0)
        {
            strSQL += "SELECT GCMC,SUM(W_GCGD_FS.AZFS*W_GCGD2.AZFS/100) AZFZ,SUM(W_GCGD_FS.FS*W_GCGD2.FS/100) BXFZ FROM W_GCGD_FS,W_GCGD2,W_GCGD1 WHERE GCMXID=W_GCGD2.ID AND USERID=" + DefaultUser + " AND W_GCGD1.GCDH=W_GCGD2.GCDH ";

            strSQL += " AND W_GCGD_FS.LTIME>'" + System.DateTime.Now.ToString("yyyy-MM") + "-01' AND " + this.GridView_WZLLD_Label_tj.Text.Trim() + "";

            strSQL += " GROUP BY GCMC order by gcmc";
        }
        else
        {
            strSQL += "SELECT GCMC,SUM(W_GCGD_FS.AZFS*W_GCGD2.AZFS/100) AZFZ,SUM(W_GCGD_FS.FS*W_GCGD2.FS/100) BXFZ FROM W_GCGD_FS,W_GCGD2,W_GCGD1 WHERE GCMXID=W_GCGD2.ID AND USERID=" + DefaultUser + " AND W_GCGD1.GCDH=W_GCGD2.GCDH ";
            strSQL += " AND W_GCGD_FS.LTIME>'" + System.DateTime.Now.ToString("yyyy-MM") + "-01'";
            strSQL += " GROUP BY GCMC order by gcmc";
        }
        string strHTML = string.Empty;

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {

                    Label_MyJF.Text = (Convert.ToInt32(Label_MyJF.Text) + Convert.ToInt32(OP_Mode.Dtv[i]["BXFZ"]) + Convert.ToInt32(OP_Mode.Dtv[i]["AZFZ"])).ToString();

                    strHTML += " <div class='infobox infobox-green'> ";
                    strHTML += "<div class='infobox-content'> ";
                    // strHTML += "  <span class='icon-legal'>&nbsp;<a href = '\\GDGL\\MyGDBXWZ.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' >" + OP_Mode.Dtv[i]["GCMC"].ToString() + "</a></span> ";
                    strHTML += "  <span class='icon-legal'>&nbsp;" + OP_Mode.Dtv[i]["GCMC"].ToString() + "</span> ";
                    strHTML += " <div class='infobox-content'> ";
                    // strHTML += "    <a href = '\\GDGL\\MyGDBXWZ.ASPX?ID=" + OP_Mode.Dtv[i]["IID"].ToString() + "' > 累计：" + OP_Mode.Dtv[i]["MXCOUNT"].ToString() + " 安装项</a>";
                    strHTML += "     布线：" + OP_Mode.Dtv[i]["BXFZ"].ToString() + " 分；安装：" + OP_Mode.Dtv[i]["AZFZ"].ToString() + "</a>";
                    strHTML += " </div> ";
                    strHTML += "</div> ";
                    strHTML += "</div> ";
                }
            }
            else
            {
                Label_MyJF.Text = "0";
            }
        }

        Dtv_HTML.InnerHtml = strHTML;

    }
}