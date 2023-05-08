using Stimulsoft.Report.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CWGL_SearchQD : PageBase
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
        int strBxdID = 0;
        string sUserName = string.Empty;
        try
        {
            // 获取报销单ID
            strBxdID = Convert.ToInt32(Request["BXDID"]);

        }
        catch
        {

        }
        sUserName = Request["UserName"];

        if (sUserName != null)
        {
            TextBox_Name.Enabled = false;
        }

        TextBox_STime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
        TextBox_ETime.Text = System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

        string strSQL = string.Empty;

        if (strBxdID > 0)
        {
            strSQL = "Select Max(TXR),max(W_BXD1.UserName),max(Occurrence) from W_BXD1,W_BXD2 where W_BXD1.BXDH=W_BXD2.BXDH and W_BXD1.id=" + strBxdID;
            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    TextBox_Name.Text = OP_Mode.Dtv[0][1].ToString() + ";" + OP_Mode.Dtv[0][0].ToString();

                    TextBox_STime.Text = Convert.ToDateTime(OP_Mode.Dtv[0][2]).ToString("yyyy-MM-dd");
                    TextBox_ETime.Text = Convert.ToDateTime(OP_Mode.Dtv[0][2]).AddDays(1).ToString("yyyy-MM-dd");
                }
            }
        }
        TextBox_Name.Text = (sUserName + TextBox_Name.Text).Replace(" ", ";");
        TextBox_Name.Text = (TextBox_Name.Text).Replace("、", ";");
        TextBox_Name.Text = (TextBox_Name.Text).Replace(",", ";");
        TextBox_Name.Text = (TextBox_Name.Text).Replace("，", ";");
        TextBox_Name.Text = (TextBox_Name.Text).Replace("；", ";");
        LoadQDList();
    }


    private void LoadQDList()
    {
        string strTemp = string.Empty;
        string strSQL = string.Empty;

        string strTJ = string.Empty;

        string[] Names = TextBox_Name.Text.Replace("'", "").Split(';');
        if (Names.Length <= 1)
        {
            Names = TextBox_Name.Text.Replace("'", "").Split('；');
        }
        if (Names.Length <= 1)
        {
            Names = TextBox_Name.Text.Replace("'", "").Split(',');
        }
        //MessageBox("", "数量：" + Names.Length + " [" + Names[0] + "]");
        //return;
        for (int i = 0; i < Names.Length; i++)
        {
            if (Names[i].Length > 0)
            {
                strTJ += "'" + Names[i] + "',";
            }
        }

        if (strTJ.Length > 0)
        {
            strTJ = " and cname in (" + strTJ.Substring(0, strTJ.Length - 1) + ") ";
        }
        string[] strImages;

        strSQL = "Select w_kq.*,CName,HeadUrl,DefaultScreen from w_kq,S_USERINFO where UserID=S_USERINFO.ID " + strTJ + " and W_KQ.Ctime between '" + TextBox_STime.Text.Replace("'", "") + "' and '" + TextBox_ETime.Text.Replace("'", "") + "' order by cname, w_kq.ctime";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    if (i == 0)
                    {
                        strTemp += " <div class='timeline'>";
                        strTemp += "  <span class='label label-primary arrowed-in-right label-lg'>";
                        strTemp += OP_Mode.Dtv[i]["CName"].ToString();
                        strTemp += "    <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + "</b>";
                        strTemp += "  </span>";
                        strTemp += " </div>";
                    }
                    else
                    {
                        if (Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") != Convert.ToDateTime(OP_Mode.Dtv[i - 1]["CTime"]).ToString("yyyy-MM-dd") || OP_Mode.Dtv[i]["CName"].ToString() != OP_Mode.Dtv[i - 1]["CName"].ToString())
                        {
                            strTemp += " <div class='timeline'>";
                            strTemp += "  <span class='label label-primary arrowed-in-right label-lg'>";
                            strTemp += OP_Mode.Dtv[i]["CName"].ToString();
                            strTemp += "    <b>" + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("yyyy-MM-dd") + "</b>";
                            strTemp += "  </span>";
                            strTemp += " </div>";
                        }
                    }

                    strTemp += "<div class='timeline-item'>";
                    strTemp += "  <div class='timeline-info'>";
                    if (OP_Mode.Dtv[i]["HeadUrl"].ToString().Length > 0)
                    {
                        strTemp += "<img whidth='100%' src='" + OP_Mode.Dtv[i]["HeadUrl"].ToString() + "' />";
                    }

                    string StrQDFlag = OP_Mode.Dtv[i]["QDFlag"].ToString();

                    if (StrQDFlag == "维修开始")
                    {
                        strTemp += "      <span class='label label-danger label-sm'>维修开始</span>";
                    }
                    else if (StrQDFlag == "维修结束")
                    {
                        strTemp += "      <span class='label label-danger label-sm'>维修结束</span>";
                    }
                    else if (StrQDFlag == "出差")
                    {
                        strTemp += "      <span class='label label-success label-sm'>出差</span>";
                    }
                    else if (StrQDFlag == "到达")
                    {
                        strTemp += "      <span class='label label-success label-sm'>到达</span>";
                    }
                    else if (StrQDFlag == "施工")
                    {
                        strTemp += "      <span class='label label-warning label-sm'>施工</span>";
                    }
                    else if (StrQDFlag == "离场")
                    {
                        strTemp += "      <span class='label label-warning label-sm'>离场</span>";
                    }
                    else if (StrQDFlag == "上班")
                    {
                        strTemp += "      <span class='label label-info label-sm'>上班</span>";
                    }
                    else if (StrQDFlag == "下班")
                    {
                        strTemp += "      <span class='label label-info label-sm'>下班</span>";
                    }

                    strTemp += "      <span class='label label-info label-sm'> " + Convert.ToDateTime(OP_Mode.Dtv[i]["CTime"]).ToString("HH:mm") + "</span>";
                    strTemp += "  </div>";
                    strTemp += "  <div class='widget-box transparent'>";
                    strTemp += "      <div class='widget-header widget-header-small'>";
                    strTemp += " <h5 class='smaller'>";

                    if (OP_Mode.Dtv[i]["DefaultScreen"].ToString() != OP_Mode.Dtv[i]["Screen"].ToString())
                    {/// 判断设备是否异常
                        strTemp += " <span class='label label-warning label-sm'>设备异常</span>";
                    }

                    strTemp += "  <a target='_blank' href='/CWGL/MapTencent.aspx?iJD=" + OP_Mode.Dtv[i]["ZB_WD"] + "&iWD=" + OP_Mode.Dtv[i]["ZB_JD"] + "'><span class='grey'>" + OP_Mode.Dtv[i]["ZB_Name"] + "<br/>" + OP_Mode.Dtv[i]["ZB_WZ"] + "</span></a>";

                    strTemp += " </h5>";
                    strTemp += "          <span class='widget-toolbar'>";
                    strTemp += "              <a href='#' data-action='collapse'>";
                    strTemp += "                 <i class='icon-chevron-up'></i>";
                    strTemp += "             </a>";
                    strTemp += "         </span>";
                    strTemp += "     </div>";
                    strTemp += "     <div class='widget-body'>";
                    strTemp += "         <div class='widget-main'>";

                    if (i > 0)
                    {
                        if (OP_Mode.Dtv[i]["ZB_WZ"].ToString() != OP_Mode.Dtv[i - 1]["ZB_WZ"].ToString())
                        {
                            strTemp += "<input id=\"Button1\" class=\"btn btn-minier\" type=\"button\" onclick=\"init(" + OP_Mode.Dtv[i]["ZB_WD"] + "," + OP_Mode.Dtv[i]["ZB_JD"] + "," + OP_Mode.Dtv[i - 1]["ZB_WD"] + "," + OP_Mode.Dtv[i - 1]["ZB_JD"] + ")\" value=\"距上次签到距离\" />  ";
                        }
                    }

                    strTemp += OP_Mode.Dtv[i]["Remark"];

                    if (OP_Mode.Dtv[i]["GCSGBH"].ToString().Length > 0)
                    {
                        strTemp += ";" + OP_Mode.Dtv[i]["GCSGBH"];
                    }
                    if (OP_Mode.Dtv[i]["GCMC"].ToString().Length > 0)
                    {
                        strTemp += ";" + OP_Mode.Dtv[i]["GCMC"];
                    }

                    strImages = OP_Mode.Dtv[i]["Image1"].ToString().Split(';');
                    for (int j = 0; j < strImages.Length; j++)
                    {
                        if (strImages[j].Length > 0)
                        {
                            strTemp += "             <br/><a href='/KQImage/" + strImages[j] + "'><img class=\"img-rounded\" width=\"150\" src='/KQImage/" + strImages[j] + "' /></a>";
                        }
                    }

                    strTemp += "       </div>";
                    strTemp += "     </div>";
                    strTemp += "   </div>";
                    strTemp += " </div>";
                }
                if (strTemp.Length > 0)
                {
                    QDList.InnerHtml = strTemp;
                }
            }
        }
        else
        {
            MessageBox("", "错误：" + OP_Mode.strErrMsg);
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadQDList();
    }
}