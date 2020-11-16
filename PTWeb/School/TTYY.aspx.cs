using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class School_TTYY : PageBase
{
    public string strSql = string.Empty;
    public string strHtml = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDetault();
            LoadZYInfo();
        }
    }

    /// <summary>
    /// 加载原始数据
    /// </summary>
    private void LoadDetault()
    {
        //2、加载标题日期
        string weekstr = DateTime.Now.DayOfWeek.ToString();
        switch (weekstr)
        {
            case "Monday": weekstr = "星期一"; break;
            case "Tuesday": weekstr = "星期二"; break;
            case "Wednesday": weekstr = "星期三"; break;
            case "Thursday": weekstr = "星期四"; break;
            case "Friday": weekstr = "星期五"; break;
            case "Saturday": weekstr = "星期六"; break;
            case "Sunday": weekstr = "星期日"; break;
        }

        Label_Data.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日 " + weekstr;
        //2、加载默认时间
        this.TextBox_Time.Text = System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString("00") + "-" + System.DateTime.Now.Day.ToString("00");
    }

    /// <summary>
    /// 加载作业信息
    /// </summary>
    private void LoadZYInfo()
    {
        string ClassID = string.Empty;

        try
        {
            ClassID = Request["C"].ToString();
        }
        catch
        {

        }

        if (ClassID.Length < 1)
        {
            return;
        }

        strSql = "SELECT * FROM SCHOOL,School_Class WHERE IClass=School_Class.ID AND IFLAG=1 AND ICLASS=" + ClassID + " AND '" + TextBox_Time.Text + "' BETWEEN TSTIME AND TETIME ORDER BY ICLASS, SCHOOL.IPX DESC";

        strHtml = string.Empty;

        if (OP_Mode.SQLRUN(strSql))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strHtml += "<div class=\"widget-body\">";
                strHtml += "  <div class=\"widget-main no-padding\">";
                strHtml += "    <div class=\"dialogs\">";

                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    int iClass = Convert.ToInt32(OP_Mode.Dtv[i]["ICLASS"].ToString());

                    strHtml += "      <div class=\"itemdiv dialogdiv\">";
                    strHtml += "        <div class=\"user\">";
                    strHtml += "          <img alt=\"Alexa's Avatar\" src=\"/images/" + OP_Mode.Dtv[i]["NIMG"].ToString() + "\" />";
                    strHtml += "        </div>";
                    strHtml += "        <div class=\"body\">";
                    strHtml += "          <div class=\"time\">";
                    strHtml += "            <i class=\"icon-time\"></i>";
                    strHtml += "            <span class=\"grey\">" + OP_Mode.Dtv[i]["LTime"].ToString() + "</span>";
                    strHtml += "          </div>";
                    strHtml += "          <div class=\"name\">";
                    strHtml += "            <span class=\"label label-info arrowed arrowed-in-right\">" + OP_Mode.Dtv[i]["NName"].ToString() + "</span>";
                    strHtml += "          </div>";
                    strHtml += "          <div class=\"text\">";

                    if (OP_Mode.Dtv[i]["NUrl"].ToString().Length > 0 && OP_Mode.Dtv[i]["NUrl"].ToString() != "#")
                    {
                        if (OP_Mode.Dtv[i]["NUrl"].ToString().IndexOf("http") < 0)
                        {
                            /// 图片形式
                            strHtml += "<a href=\"" + OP_Mode.Dtv[i]["NUrl"].ToString() + "\"><img width=\"200\" class=\"img-rounded\" src=\"" + OP_Mode.Dtv[i]["NUrl"].ToString() + "\" /></a><br>";
                            strHtml += OP_Mode.Dtv[i]["NContent"].ToString();
                        }
                        else
                        {
                            /// URL链接形式
                            strHtml += "<a href=\"" + OP_Mode.Dtv[i]["NUrl"].ToString() + "\">" + OP_Mode.Dtv[i]["NContent"].ToString() + " 【点击进入】</a>";
                        }
                    }
                    else
                    {
                        string TTT = OP_Mode.Dtv[i]["NContent"].ToString();
                        strHtml += TTT.Replace("\r\n", "<br>");
                    }
                    strHtml += "          </div>";
                    strHtml += "        </div>";
                    strHtml += "      </div>";
                }
                strHtml += "    </div>";
                strHtml += "  </div>";
                strHtml += " </div>";

                ZuoYeInfo.InnerHtml = strHtml;
                ZuoYeInfo.Visible = true;
            }
            else
            {
                ZuoYeInfo.Visible = false;
            }
        }
        else
        {
            ZuoYeInfo.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadZYInfo();
    }
}