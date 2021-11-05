using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Manage_Bance : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefaultData();
            LoadAmount();
        }
    }
    /// <summary>
    /// 加载默认数据
    /// </summary>
    private void LoadDefaultData()
    {
        TextBox1.Text = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.ToString("yyyy-MM-dd");
        TextBox2.Text = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// 加载并绑定盈利情况
    /// </summary>
    private void LoadAmount()
    {
        string strSQL = string.Empty;

        string DLtimeStart = Convert.ToDateTime(TextBox1.Text).ToString("yyyy-MM-dd");
        string DLtimeEnd = Convert.ToDateTime(TextBox2.Text).ToString("yyyy-MM-dd");
        string strDiv = string.Empty;
        strSQL = "Select ISNULL((Select sum(amount) SR from xmfight_bance where ltime between '" + DLtimeStart + "' and '" + DLtimeEnd + "' and amount > 0),0) SR,";
        strSQL += "ISNULL((Select sum(amount) ZC from xmfight_bance where ltime between '" + DLtimeStart + "' and '" + DLtimeEnd + "' and amount<0),0) ZC,";
        strSQL += " * from xmfight_bance where ltime between '" + DLtimeStart + "' and '" + DLtimeEnd + "' order by Ltime desc";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_LJSR.Text = OP_Mode.Dtv[0]["SR"].ToString();
                Label_LJZC.Text = OP_Mode.Dtv[0]["ZC"].ToString();
                Label_LJLR.Text = (Convert.ToDouble(OP_Mode.Dtv[0]["SR"]) + Convert.ToDouble(OP_Mode.Dtv[0]["ZC"])).ToString();
                strDiv = "<div class=\"col-xs-12 col-sm-10 col-sm-offset-1\">";

                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    if (i == 0)
                    {// 输出表头
                        strDiv += "<div class=\"timeline-container\">";
                        strDiv += " <div class=\"timeline-label\">";
                        strDiv += "  <span class=\"label label-primary arrowed-in-right label-lg\">";
                        strDiv += "   <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["LTime"]).ToString("yyyy-MM-dd dddd") + "</b>";
                        strDiv += "  </span>";
                        strDiv += " </div>";

                        strDiv += " <div class=\"timeline-items\">";

                        /// 同日循环
                        strDiv += "  <div class=\"timeline-item clearfix\">";
                        strDiv += "    <div class=\"timeline-info\">";
                        if (Convert.ToDouble(OP_Mode.Dtv[i]["Amount"]) > 0)
                        {
                            strDiv += "     <i class=\"icon-credit-card bigger-230 red\"></i>";
                            strDiv += "    </div>";
                            strDiv += "    <div class=\"widget-box transparent\">";
                            strDiv += "     <div class=\"widget-header widget-header-small\">";
                            strDiv += "      <B><span class=\"red\">" + OP_Mode.Dtv[i]["Amount"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                            strDiv += "     </div>";
                        }
                        else
                        {
                            strDiv += "     <i class=\"icon-credit-card bigger-230 green\"></i>";
                            strDiv += "    </div>";
                            strDiv += "    <div class=\"widget-box transparent\">";
                            strDiv += "     <div class=\"widget-header widget-header-small\">";
                            strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Amount"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                            strDiv += "     </div>";
                        }
                        strDiv += "     <div class=\"widget-body\">";
                        strDiv += "      <div class=\"widget-main\">";
                        strDiv += "      " + OP_Mode.Dtv[i]["Remark"].ToString(); ///说明信息
                        strDiv += "      </div>";
                        strDiv += "     </div>";
                        strDiv += "    </div>";
                        //////////////
                    }

                    if (i > 0)
                    {
                        if (Convert.ToDateTime(OP_Mode.Dtv[i - 1]["LTime"]).ToString("yyyy-MM-dd") != Convert.ToDateTime(OP_Mode.Dtv[i]["LTime"]).ToString("yyyy-MM-dd"))
                        {
                            strDiv += "    </div>"; /// 上个日期循环结束
                            strDiv += "<div class=\"timeline-container\">";
                            strDiv += " <div class=\"timeline-label\">";
                            strDiv += "  <span class=\"label label-primary arrowed-in-right label-lg\">";
                            strDiv += "   <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["LTime"]).ToString("yyyy-MM-dd dddd") + "</b>";
                            strDiv += "  </span>";
                            strDiv += " </div>";

                            strDiv += " <div class=\"timeline-items\">";

                            /// 同日循环
                            strDiv += "  <div class=\"timeline-item clearfix\">";
                            strDiv += "    <div class=\"timeline-info\">";
                            if (Convert.ToDouble(OP_Mode.Dtv[i]["Amount"]) > 0)
                            {
                                strDiv += "     <i class=\"icon-credit-card bigger-230 red\"></i>";
                                strDiv += "    </div>";
                                strDiv += "    <div class=\"widget-box transparent\">";
                                strDiv += "     <div class=\"widget-header widget-header-small\">";
                                strDiv += "      <B><span class=\"red\">" + OP_Mode.Dtv[i]["Amount"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                                strDiv += "     </div>";
                            }
                            else
                            {
                                strDiv += "     <i class=\"icon-credit-card bigger-230 green\"></i>";
                                strDiv += "    </div>";
                                strDiv += "    <div class=\"widget-box transparent\">";
                                strDiv += "     <div class=\"widget-header widget-header-small\">";
                                strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Amount"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                                strDiv += "     </div>";
                            }
                            strDiv += "     <div class=\"widget-body\">";
                            strDiv += "      <div class=\"widget-main\">";
                            strDiv += "      " + OP_Mode.Dtv[i]["Remark"].ToString(); ///说明信息
                            strDiv += "      </div>";
                            strDiv += "     </div>";
                            strDiv += "    </div>";
                            //////////////
                        }
                        else
                        {
                            strDiv += "  <div class=\"timeline-item clearfix\">";
                            strDiv += "    <div class=\"timeline-info\">";
                            if (Convert.ToDouble(OP_Mode.Dtv[i]["Amount"]) > 0)
                            {
                                strDiv += "     <i class=\"icon-credit-card bigger-230 red\"></i>";
                                strDiv += "    </div>";
                                strDiv += "    <div class=\"widget-box transparent\">";
                                strDiv += "     <div class=\"widget-header widget-header-small\">";
                                strDiv += "      <B><span class=\"red\">" + OP_Mode.Dtv[i]["Amount"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                                strDiv += "     </div>";
                            }
                            else
                            {
                                strDiv += "     <i class=\"icon-credit-card bigger-230 green\"></i>";
                                strDiv += "    </div>";
                                strDiv += "    <div class=\"widget-box transparent\">";
                                strDiv += "     <div class=\"widget-header widget-header-small\">";
                                strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Amount"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                                strDiv += "     </div>";
                            }
                            strDiv += "     <div class=\"widget-body\">";
                            strDiv += "      <div class=\"widget-main\">";
                            strDiv += "      " + OP_Mode.Dtv[i]["Remark"].ToString(); ///说明信息
                            strDiv += "      </div>";
                            strDiv += "     </div>";
                            strDiv += "    </div>";
                        }
                    }

                    if (i == OP_Mode.Dtv.Count - 1)
                    { // 最后一条信息，输出结尾
                        strDiv += "   </div>";
                    }
                }
                if (strDiv.Length > 0)
                {
                    Div_BanceList.InnerHtml = strDiv;
                    Div_BanceList.Visible = true;
                }
                else
                {
                    Div_BanceList.InnerHtml = String.Empty;
                    Div_BanceList.Visible = false;
                }
            }
            else
            {
                Div_BanceList.InnerHtml = String.Empty;
                Div_BanceList.Visible = false;

                Label_LJSR.Text = "0";
                Label_LJZC.Text = "0";
                Label_LJLR.Text = "0";
            }
        }
        else
        {
            MessageBox("", OP_Mode.strErrMsg);
            return;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadAmount();
    }


    private void DivTimes()
    {

    }
}