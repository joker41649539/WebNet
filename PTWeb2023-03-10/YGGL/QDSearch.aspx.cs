using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YGGL_QDGL : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 加载考勤信息
    /// </summary>
    private void LoadQDList()
    {
        string strTemp = string.Empty;
        string strSQL = string.Empty;

        //   strSQL = "Select * from w_kq where userid=" + DefaultUser + " and ctime between '" + System.DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00' and '" + System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00' order by ctime desc";

        if (GridView_MSG_Label_tj.Text.Length > 0)
        {
            strSQL = "Select w_kq.*,CName,HeadUrl from w_kq,S_USERINFO where UserID=S_USERINFO.ID and " + GridView_MSG_Label_tj.Text + " order by CName,w_kq.ctime desc";

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                    {
                        if (i == 0)
                        {
                            strTemp += " <div class='timeline-label'>";
                            strTemp += "  <span class='label label-primary arrowed-in-right label-lg'>";
                            strTemp += OP_Mode.Dtv[i]["CName"].ToString();
                            strTemp += "    <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + "</b>";
                            strTemp += "  </span>";
                            strTemp += " </div>";
                        }
                        else
                        {
                            if (Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") != Convert.ToDateTime(OP_Mode.Dtv[i - 1]["CTime"]).ToString("yyyy-MM-dd"))
                            {
                                strTemp += " <div class='timeline-label'>";
                                strTemp += "  <span class='label label-primary arrowed-in-right label-lg'>";
                                strTemp += OP_Mode.Dtv[i]["CName"].ToString();
                                strTemp += "    <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + "</b>";
                                strTemp += "  </span>";
                                strTemp += " </div>";
                            }
                        }

                        strTemp += "<div class='timeline-item clearfix'>";
                        strTemp += "  <div class='timeline-info'>";
                        if (OP_Mode.Dtv[i]["HeadUrl"].ToString().Length > 0)
                        {
                            strTemp += "<img src='" + OP_Mode.Dtv[i]["HeadUrl"].ToString() + "' />";
                        }
                        strTemp += "      <span class='label label-info label-sm'>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("HH:mm") + "</span>";
                        strTemp += "  </div>";
                        strTemp += "  <div class='widget-box transparent'>";
                        strTemp += "      <div class='widget-header widget-header-small'>";
                        strTemp += " <h5 class='smaller'>";
                        strTemp += "  <span class='grey'><a href='#'>" + OP_Mode.Dtv[i]["ZB_WZ"] + "</a></span>";
                        strTemp += " </h5>";
                        strTemp += "          <span class='widget-toolbar'>";
                        strTemp += "              <a href='#' data-action='collapse'>";
                        strTemp += "                 <i class='icon-chevron-up'></i>";
                        strTemp += "             </a>";
                        strTemp += "         </span>";
                        strTemp += "     </div>";
                        strTemp += "     <div class='widget-body'>";
                        strTemp += "         <div class='widget-main'>";
                        if (OP_Mode.Dtv[i]["Image1"].ToString().Length > 0)
                        {
                            strTemp += "             <a href='/KQImage/" + OP_Mode.Dtv[i]["Image1"].ToString() + "'><img src='/KQImage/" + OP_Mode.Dtv[i]["Image1"].ToString() + "' /></a>";
                        }
                        if (OP_Mode.Dtv[i]["Image2"].ToString().Length > 0)
                        {
                            strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image2"].ToString() + "' />";
                        }
                        if (OP_Mode.Dtv[i]["Image3"].ToString().Length > 0)
                        {
                            strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image3"].ToString() + "' />";
                        }
                        if (OP_Mode.Dtv[i]["Image4"].ToString().Length > 0)
                        {
                            strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image4"].ToString() + "' />";
                        }
                        if (OP_Mode.Dtv[i]["Image5"].ToString().Length > 0)
                        {
                            strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image5"].ToString() + "' />";
                        }
                        if (OP_Mode.Dtv[i]["Image6"].ToString().Length > 0)
                        {
                            strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image6"].ToString() + "' />";
                        }
                        if (OP_Mode.Dtv[i]["Image7"].ToString().Length > 0)
                        {
                            strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image7"].ToString() + "' />";
                        }
                        if (OP_Mode.Dtv[i]["Image8"].ToString().Length > 0)
                        {
                            strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image8"].ToString() + "' />";
                        }
                        if (OP_Mode.Dtv[i]["Image9"].ToString().Length > 0)
                        {
                            strTemp += "             <img src='/KQImage/" + OP_Mode.Dtv[i]["Image9"].ToString() + "' />";
                        }
                        strTemp += OP_Mode.Dtv[i]["Remark"];
                        strTemp += "       </div>";
                        strTemp += "     </div>";
                        strTemp += "   </div>";
                        strTemp += " </div>";
                    }
                    if (strTemp.Length > 0)
                    {
                        QDList.Visible = true;
                        QDList.InnerHtml = strTemp;
                    }
                }

            }
            else
            {
                MessageBox("", "错误：" + OP_Mode.strErrMsg);
            }
        }
        else
        {
            QDList.Visible = false;
        }
    }
    /// <summary>
    /// 清除查询条件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_FXX_LinkButton3_Click(object sender, EventArgs e)
    {

        this.GridView_MSG_TextBox_CXTJ.Text = string.Empty;

        this.GridView_MSG_Label1.Text = string.Empty;

        this.GridView_MSG_Label_tj.Text = string.Empty;

        this.GridView_FXX_alerts_tj.Visible = false;

        LoadQDList();
    }
    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_FXX_LinkButton4_Click(object sender, EventArgs e)
    {
        LoadQDList();
    }
    /// <summary>
    /// 查询条件添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_MSG_TJADD_Click(object sender, EventArgs e)
    {

        string strDiv = string.Empty;

        if (this.GridView_MSG_TextBox_CXTJ.Text.Length == 0)

        {
            this.GridView_MSG_TextBox_CXTJ.Text = string.Empty;
            this.GridView_FXX_alerts_tj.Visible = false;

        }

        if (this.GridView_MSG_Label1.Text.Length > 0)

        {

            this.GridView_MSG_Label1.Text += "<b>并且</b><br />";

            this.GridView_MSG_Label_tj.Text += " and ";

        }

        this.GridView_MSG_Label1.Text += this.GridView_MSG_DropDownList1.SelectedItem.Text + "&nbsp;" + this.GridView_MSG_DropDownList_SF.SelectedItem.Text + "&nbsp;" + this.GridView_MSG_TextBox_CXTJ.Text + "&nbsp;";

        if (this.GridView_MSG_DropDownList_SF.SelectedValue == "LIKE")

        {

            this.GridView_MSG_Label_tj.Text += " " + this.GridView_MSG_DropDownList1.SelectedValue + " " + this.GridView_MSG_DropDownList_SF.SelectedValue + " " + "'%" + this.GridView_MSG_TextBox_CXTJ.Text.Trim() + "%'";

        }

        else

        {

            this.GridView_MSG_Label_tj.Text += " " + this.GridView_MSG_DropDownList1.SelectedValue + " " + this.GridView_MSG_DropDownList_SF.SelectedValue + " " + "'" + this.GridView_MSG_TextBox_CXTJ.Text.Trim() + "'";

        }

        this.GridView_MSG_TextBox_CXTJ.Text = string.Empty;

        this.GridView_FXX_alerts_tj.Visible = true;

    }
}