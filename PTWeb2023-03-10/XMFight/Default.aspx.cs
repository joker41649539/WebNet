using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Default : PageBaseXMFight
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Server.Transfer("MyClass.aspx");
            //LoadPhoto();
        }
    }

    /// <summary>
    /// 加载并绑定盈利情况
    /// </summary>
    private void LoadPhoto()
    {
        string strSQL = string.Empty;

        string strDiv = string.Empty;

        strSQL = "Select top 100 * from XMFight_Image order by ITop desc,CTime desc";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strDiv = "<div class=\"col-xs-12 col-sm-10 col-sm-offset-1\">";

                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    if (i == 0)
                    {// 输出表头
                        strDiv += "<div class=\"timeline-container\">";
                        strDiv += " <div class=\"timeline-label\">";
                        strDiv += "  <span class=\"label label-primary arrowed-in-right label-lg\">";
                        strDiv += "   <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd dddd") + "</b>";
                        strDiv += "  </span>";
                        strDiv += " </div>";

                        strDiv += " <div class=\"timeline-items\">";

                        /// 同日循环
                        strDiv += "  <div class=\"timeline-item clearfix\">";
                        strDiv += "    <div class=\"timeline-info\">";
                        //if (OP_Mode.Dtv[i]["Remark"].ToString().Length > 0)
                        //{

                        strDiv += "     <i class=\"icon-credit-card bigger-230 green\"></i>";
                        strDiv += "    </div>";
                        strDiv += "    <div class=\"widget-box transparent\">";
                        strDiv += "     <div class=\"widget-header widget-header-small\">";
                       // strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                        strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;"; ///消费金额
                        strDiv += "     </div>";
                        // }
                        strDiv += "     <div class=\"widget-body\">";
                        strDiv += "      <div class=\"widget-main\">";
                        strDiv += "      <img src=\"" + OP_Mode.Dtv[i]["ImageName"].ToString() + "\" class=\"img-rounded\" style=\"max-width:90%\" />"; ///说明信息
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
                            strDiv += "   <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd dddd") + "</b>";
                            strDiv += "  </span>";
                            strDiv += " </div>";

                            strDiv += " <div class=\"timeline-items\">";

                            /// 同日循环
                            strDiv += "  <div class=\"timeline-item clearfix\">";
                            strDiv += "    <div class=\"timeline-info\">";
                            //if (OP_Mode.Dtv[i]["Remark"].ToString().Length > 0)
                            //{

                            strDiv += "     <i class=\"icon-credit-card bigger-230 green\"></i>";
                            strDiv += "    </div>";
                            strDiv += "    <div class=\"widget-box transparent\">";
                            strDiv += "     <div class=\"widget-header widget-header-small\">";
                            // strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                            strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;"; ///消费金额
                            strDiv += "     </div>";
                            //  }
                            strDiv += "     <div class=\"widget-body\">";
                            strDiv += "      <div class=\"widget-main\">";
                            strDiv += "      <img src=\"" + OP_Mode.Dtv[i]["ImageName"].ToString() + "\" class=\"img-rounded\" style=\"max-width:90%\" />"; ///说明信息
                            strDiv += "      </div>";
                            strDiv += "     </div>";
                            strDiv += "    </div>";
                            //////////////
                        }
                        else
                        {
                            strDiv += "  <div class=\"timeline-item clearfix\">";
                            strDiv += "    <div class=\"timeline-info\">";
                            //if (OP_Mode.Dtv[i]["Remark"].ToString().Length > 0)
                            //{

                            strDiv += "     <i class=\"icon-credit-card bigger-230 green\"></i>";
                            strDiv += "    </div>";
                            strDiv += "    <div class=\"widget-box transparent\">";
                            strDiv += "     <div class=\"widget-header widget-header-small\">";
                            // strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                            strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;"; ///消费金额
                            strDiv += "     </div>";
                            //}
                            strDiv += "     <div class=\"widget-body\">";
                            strDiv += "      <div class=\"widget-main\">";
                            strDiv += "      <img src=\"" + OP_Mode.Dtv[i]["ImageName"].ToString() + "\" class=\"img-rounded\" style=\"max-width:90%\" />"; ///说明信息
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
                    Div_PhotoList.InnerHtml = strDiv;
                    Div_PhotoList.Visible = true;
                }
                else
                {
                    Div_PhotoList.InnerHtml = String.Empty;
                    Div_PhotoList.Visible = false;
                }
            }
            else
            {
                Div_PhotoList.InnerHtml = String.Empty;
                Div_PhotoList.Visible = false;
            }
        }
        else
        {
            MessageBox("", OP_Mode.strErrMsg);
            return;
        }
    }

}