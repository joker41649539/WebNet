using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_MyClass : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudentsByOpID();
            LoadClassList();
        }
    }
    private void LoadStudentsByOpID()
    {
        string strOPID = string.Empty;
        string strTempDiv = string.Empty;
        try
        {
            strOPID = Request.Cookies["WeChat_XMFight"]["COPENID"];
           // MessageBox("", strOPID);
            string strSQL = "Select ID,Name,Sex from XMFight_Student where OpenID like ('%" + strOPID + "%')";
            if (OP_Mode.SQLRUN(strSQL))
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    if (Convert.ToInt32(OP_Mode.Dtv[i]["sex"]) == 1)
                    {/// 男孩蓝色标签
                        strTempDiv += " <a href=\"?SID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm btn-primary\">" + OP_Mode.Dtv[i]["Name"].ToString() + "</a>";
                    }
                    else
                    {// 女孩紫色标签
                        strTempDiv += " <a href=\"?SID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm btn-pink\">" + OP_Mode.Dtv[i]["Name"].ToString() + "</a>";
                    }
                }
            }
        }
        catch
        {

        }

        if (strTempDiv.Length > 0)
        {
            Div_Students.InnerHtml = strTempDiv;
            Div_Students.Visible = true;

        }
        else
        {
            Div_Students.Visible = false;
        }
    }

    /// <summary>
    /// 加载并绑定课程安排
    /// </summary>
    private void LoadClassList()
    {
        string strSQL = string.Empty;

        string strDiv = string.Empty;

        strSQL = "Select * from xmfight_classTime order by week,stime";

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
                        strDiv += "   <b>" + NumtoCHWeek(Convert.ToInt32(OP_Mode.Dtv[i]["Week"])).ToString() + "</b>";
                        strDiv += "  </span>";
                        strDiv += " </div>";

                        strDiv += " <div class=\"timeline-items\">";

                        /// 同日循环
                        strDiv += "  <div class=\"timeline-item clearfix\">";
                        //strDiv += "    <div class=\"timeline-info\">";
                        //if (Convert.ToInt32(Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH")) < 12)
                        //{
                        //    strDiv += "     <h5 class='red'>上&nbsp;午</h5>";
                        //}
                        //else
                        //{
                        //    strDiv += "     <h5 class='green'>下&nbsp;午</h5>";
                        //}
                        //strDiv += "    </div>";

                        strDiv += "    <div class=\"widget-box transparent\">";
                        strDiv += "     <div class=\"widget-header widget-header-small\">";
                        // strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                        strDiv += "      <B><span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " &nbsp;[" + OP_Mode.Dtv[i]["Teacher"].ToString() + "]</span></B>&nbsp;"; ///消费金额
                        strDiv += "     </div>";
                        // }
                        //strDiv += "     <div class=\"widget-body\">";
                        //strDiv += "      <div class=\"widget-main\">";
                        //strDiv += "      <img src=\"" + OP_Mode.Dtv[i]["HeadImg"].ToString() + "\" class=\"img-rounded\" style=\"max-width:90%\" />"; ///说明信息
                        //strDiv += "      </div>";
                        //strDiv += "     </div>";
                        strDiv += "    </div>";
                        //////////////
                    }

                    if (i > 0)
                    {
                        if (OP_Mode.Dtv[i - 1]["Week"].ToString() != OP_Mode.Dtv[i]["Week"].ToString())
                        {
                            strDiv += "    </div>"; /// 上个日期循环结束
                            strDiv += "<div class=\"timeline-container\">";
                            strDiv += " <div class=\"timeline-label\">";
                            strDiv += "  <span class=\"label label-primary arrowed-in-right label-lg\">";
                            strDiv += "   <b>" + NumtoCHWeek(Convert.ToInt32(OP_Mode.Dtv[i]["Week"])).ToString() + "</b>";
                            strDiv += "  </span>";
                            strDiv += " </div>";

                            strDiv += " <div class=\"timeline-items\">";

                            /// 同日循环
                            strDiv += "  <div class=\"timeline-item clearfix\">";
                            //strDiv += "    <div class=\"timeline-info\">";
                            //if (Convert.ToInt32(Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH")) < 12)
                            //{
                            //    strDiv += "     <h5 class='red'>上&nbsp;午</h5>";
                            //}
                            //else
                            //{
                            //    strDiv += "     <h5 class='green'>下&nbsp;午</h5>";
                            //}
                            //strDiv += "    </div>";
                            strDiv += "    <div class=\"widget-box transparent\">";
                            strDiv += "     <div class=\"widget-header widget-header-small\">";
                            // strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                            strDiv += "      <B><span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " &nbsp;[" + OP_Mode.Dtv[i]["Teacher"].ToString() + "]</span></B>&nbsp;";
                            strDiv += "     </div>";
                            //  }
                            //strDiv += "     <div class=\"widget-body\">";
                            //strDiv += "      <div class=\"widget-main\">";
                            //strDiv += "      <img src=\"" + OP_Mode.Dtv[i]["ImageName"].ToString() + "\" class=\"img-rounded\" style=\"max-width:90%\" />"; ///说明信息
                            //strDiv += "      </div>";
                            //strDiv += "     </div>";
                            strDiv += "    </div>";
                            //////////////
                        }
                        else
                        {
                            strDiv += "  <div class=\"timeline-item clearfix\">";
                            //strDiv += "    <div class=\"timeline-info\">";
                            //if (Convert.ToInt32(Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH")) < 12)
                            //{
                            //    strDiv += "     <h5 class='red'>上&nbsp;午</h5>";
                            //}
                            //else
                            //{
                            //    strDiv += "     <h5 class='green'>下&nbsp;午</h5>";
                            //}
                            //strDiv += "    </div>";
                            strDiv += "    <div class=\"widget-box transparent\">";
                            strDiv += "     <div class=\"widget-header widget-header-small\">";
                            // strDiv += "      <B><span class=\"green\">" + OP_Mode.Dtv[i]["Remark"].ToString() + "</span></B>&nbsp;[<a href=\"BanceAdd.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\">编辑</a>]"; ///消费金额
                            strDiv += "      <B><span class=\"green\">" + Convert.ToDateTime(OP_Mode.Dtv[i]["STime"]).ToString("HH:mm") + " - " + Convert.ToDateTime(OP_Mode.Dtv[i]["ETime"]).ToString("HH:mm") + " &nbsp;[" + OP_Mode.Dtv[i]["Teacher"].ToString() + "]</span></B>&nbsp;";
                            strDiv += "     </div>";
                            //}
                            //strDiv += "     <div class=\"widget-body\">";
                            //strDiv += "      <div class=\"widget-main\">";
                            //strDiv += "      <img src=\"" + OP_Mode.Dtv[i]["ImageName"].ToString() + "\" class=\"img-rounded\" style=\"max-width:90%\" />"; ///说明信息
                            //strDiv += "      </div>";
                            //strDiv += "     </div>";
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

    private string NumtoCHWeek(int Num)
    {
        string rValue = string.Empty;
        switch (Num)
        {
            case 1:
                rValue = "星期一";
                break;
            case 2:
                rValue = "星期二";
                break;
            case 3:
                rValue = "星期三";
                break;
            case 4:
                rValue = "星期四";
                break;
            case 5:
                rValue = "星期五";
                break;
            case 6:
                rValue = "星期六";
                break;
            case 7:
                rValue = "星期日";
                break;
        }
        return rValue;
    }
}