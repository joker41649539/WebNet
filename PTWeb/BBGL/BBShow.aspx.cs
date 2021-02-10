using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class BBGL_BBShow : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadBBInfo();
    }

    /// <summary>
    /// 加载报表信息
    /// </summary>
    private void LoadBBInfo()
    {
        if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
        {
            int ID;
            ID = Convert.ToInt32(Request.QueryString["ID"]);

            string strSQL = "SELECT S_REPORT.ID,CNAME,NCLASS,CFILENAME FROM S_QXZ,S_REPORT_QXZ,S_YH_QXZ,S_REPORT WHERE S_QXZ.ID=S_REPORT_QXZ.IQXZID AND S_YH_QXZ.QXZID=S_QXZ.ID and S_REPORT.ID=S_REPORT_QXZ.IREPORTID AND USERID=" + DefaultUser.ToString() + " AND S_REPORT.ID=" + ID.ToString() + " AND S_REPORT.ISHOW=0 GROUP BY S_REPORT.ID,CNAME,CFILENAME,NCLASS,S_REPORT.IPX,S_REPORT.ISHOW ORDER BY S_REPORT.IPX DESC";

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    StiReport report = new StiReport();

                    this.Title = OP_Mode.Dtv[0]["CNAME"].ToString();

                    /// 获得报表名称
                    report.Load(MapPath(OP_Mode.Dtv[0]["CFILENAME"].ToString().Trim()));

                    /// 默认加载用户ID信息
                    report.Dictionary.Variables.Add("UserID", DefaultUser);

                    strSQL = "Select * from S_REPORT_ZB where IREPORTID=" + ID.ToString() + " AND ISHOW=0 ORDER BY IPX DESC";

                    if (OP_Mode.SQLRUN(strSQL))
                    {
                        if (OP_Mode.Dtv.Count > 0)
                        {
                            for (int i = 1; i < OP_Mode.Dtv.Count + 1; i++)
                            {
                                ((Label)DIVSearch.FindControl("Label" + i.ToString())).Text = OP_Mode.Dtv[i - 1]["CNAME"].ToString().Trim();

                                if (OP_Mode.Dtv[i - 1]["CNAME"].ToString().Trim().Contains("时间")) /// 判断字段名称如果包含日期字样，则调用日期控件
                                {
                                    if (((TextBox)DIVSearch.FindControl("TextBox" + i.ToString())).Text.Length == 0)
                                    {
                                        string Temp = Convert.ToDateTime(System.DateTime.Now.Year.ToString() + '-' + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Day.ToString()).ToString("yyyy-MM-dd");

                                        ((TextBox)DIVSearch.FindControl("TextBox" + i.ToString())).Text = Temp;

                                        report.Dictionary.Variables.Add(OP_Mode.Dtv[i - 1]["CENAME"].ToString().Trim(), Temp);
                                    }
                                    else
                                    {
                                        string Ttime;//= Convert.ToDateTime(((TextBox)DIVSearch.FindControl("TextBox" + i.ToString())).Text).ToString("yyyy-MM-dd");

                                        if (OP_Mode.Dtv[i - 1]["CNAME"].ToString().Trim().Contains("截止"))
                                        {
                                            Ttime = Convert.ToDateTime(((TextBox)DIVSearch.FindControl("TextBox" + i.ToString())).Text).ToString("yyyy-MM-dd" + " 23:59:59");
                                        }
                                        else
                                        {
                                            Ttime = Convert.ToDateTime(((TextBox)DIVSearch.FindControl("TextBox" + i.ToString())).Text).ToString("yyyy-MM-dd" + " 00:00:00");
                                        }

                                        report.Dictionary.Variables.Add(OP_Mode.Dtv[i - 1]["CENAME"].ToString().Trim(), Ttime);
                                    }

                                    this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey" + i.ToString(), "<script type='text/javascript'>$(function () {$('#TextBox" + i.ToString() + "').datepicker();});</script>");

                                }
                                else
                                {
                                    if (((TextBox)DIVSearch.FindControl("TextBox1")).Text.Trim().Replace("'", "\"").Length == 0)
                                    {
                                        report.Dictionary.Variables.Add(OP_Mode.Dtv[i - 1]["CENAME"].ToString().Trim(), "0");
                                    }
                                    else
                                    {
                                        report.Dictionary.Variables.Add(OP_Mode.Dtv[i - 1]["CENAME"].ToString().Trim(), ((TextBox)DIVSearch.FindControl("TextBox" + i.ToString())).Text.Trim().Replace("'", "\""));
                                    }
                                }
                            }

                            for (int i = OP_Mode.Dtv.Count + 1; i < 6; i++)
                            {
                                DIVSearch.FindControl("DIV" + i.ToString()).Visible = false;
                            }
                        }
                        else
                        {
                            this.DIVSearch.Visible = false;
                        }

                        StiWebViewer1.Report = report;

                    }
                }
                else
                {
                    MessageBox("错误", "您无查看此报表的权限。<br/>或者是错误的参数！");
                    this.DIVSearch.Visible = false;
                    StiWebViewer1.Visible = false;
                }
            }
            else
            {
                this.DIVSearch.Visible = false;
                StiWebViewer1.Visible = false;
                MessageBox("错误", "错误：" + OP_Mode.strErrMsg);
                return;
            }
        }
        else
        {
            this.DIVSearch.Visible = false;
            StiWebViewer1.Visible = false;
            MessageBox("", "错误的参数！");
            return;
        }
    }

}