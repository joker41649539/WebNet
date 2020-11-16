using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class School_Default : PageBase
{
    public string strSql = string.Empty;
    public string strHtml = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDetault();
            LoadGGInfo();
            //     LoadTPInfo();
            LoadZYInfo();
        }
    }

    #region 学校信息 微信相关
    /// <summary>
    /// 微信打开，则自助注册登录
    /// </summary>
    public void LoadWeiXinUserinfo()
    {
        string accessToken = string.Empty;

        string AppId = WebConfigurationManager.AppSettings["CorpId"];//与微信公众账号后台的AppId设置保持一致，区分大小写。
        string AppSecret = WebConfigurationManager.AppSettings["WeixinAppSecret"];

        var code = string.Empty;

        try
        {
            code = Request.QueryString["code"];
        }
        catch
        {

        }
        try
        {
            Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_COPENID] = Request.QueryString["openid"];
        }
        catch
        {

        }

        string DeBugMsg = string.Empty;

        var opentid = string.Empty;

        if (string.IsNullOrEmpty(code))
        {
            //opentid = Request.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_COPENID];
        }
        else
        {
            string strWeixin_OpenID = string.Empty;

            string STRUSERID = string.Empty;

            if (strWeixin_OpenID == string.Empty || STRUSERID == string.Empty)
            {
                DeBugMsg += "<br> 没有所需的OPENID！";

                // this.Label1.Text = "没有所需的OPENID";
                var client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", AppId, AppSecret, code);
                var data = client.DownloadString(url);

                var serializer = new JavaScriptSerializer();
                var obj = serializer.Deserialize<Dictionary<string, string>>(data);

                //this.Label1.Text += url;

                if (!obj.TryGetValue("access_token", out accessToken))
                {
                    DeBugMsg += "<br> Token获取错误！";
                    return;
                }

                opentid = obj["openid"];

                string strSQL;
                strSQL = "Select * from OD_USERINFO where COPENID='" + opentid + "'";

                //this.Label1.Text += strSQL;

                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        /// 如果数据库有ID，则直接登录。
                        // MessageBox("A", "用户名已存在，请更换用户名。");
                        Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                        Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_COPENID] = OP_Mode.Dtv[0]["COPENID"].ToString().Trim();
                        Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_CNAME] = OP_Mode.Dtv[0]["CNC"].ToString().Trim();
                        Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_LTIME] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                        Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_CTX] = OP_Mode.Dtv[0]["CTX"].ToString().Trim();

                        Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_LGOIN] = "true";

                        ///设置COOKIE最长时间
                        Response.Cookies[Constant.COOKIENAMEOPENDOOR].Expires = DateTime.MaxValue;

                        // this.Label1.Text = "难道加载这里了？";
                        return;
                    }
                    else
                    {
                        url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", accessToken, opentid);
                        data = client.DownloadString(url);
                        var userInfo = serializer.Deserialize<Dictionary<string, object>>(data);

                        int vsex = 2;

                        var vcity = "中国";

                        if (userInfo["sex"].ToString() == "1")
                        {
                            vsex = 0;
                        }

                        vcity = userInfo["country"].ToString() + userInfo["province"].ToString() + userInfo["city"].ToString();

                        strSQL = " INSERT INTO OD_USERINFO (COPENID,CNC,IXB,CCITY,CTX) VALUES ('" + opentid + "','" + userInfo["nickname"] + "'," + vsex + ",'" + vcity + "','" + userInfo["headimgurl"] + "')";

                        strSQL += " Select * from OD_USERINFO where COPENID='" + opentid + "'";

                        if (OP_Mode.SQLRUN(strSQL))
                        {
                            Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                            Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_COPENID] = OP_Mode.Dtv[0]["COPENID"].ToString().Trim();
                            Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_CNAME] = OP_Mode.Dtv[0]["CNC"].ToString().Trim();
                            Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_LTIME] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                            Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_CTX] = OP_Mode.Dtv[0]["CTX"].ToString().Trim();

                            Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_LGOIN] = "true";
                            //Response.Cookies[Constant.COOKIENAMEOPENDOOR][Constant.COOKIENAMEOPENDOOR_LGOIN] = "true";
                            ///设置COOKIE最长时间  不设置时间，窗口关闭则丢失
                            Response.Cookies[Constant.COOKIENAMEOPENDOOR].Expires = DateTime.MaxValue;

                            string MSG = string.Format("<img class=\"img-rounded\" src=\"{1}\" width=\"60PX\" />欢迎 {0} 注册成功。<br/>祝您生活愉快。", OP_Mode.Dtv[0]["CNC"].ToString(), OP_Mode.Dtv[0]["CTX"].ToString());

                            MessageBox("", MSG);

                            return;
                        }
                        else
                        {
                            //  MessageBox("A", "错误2.");
                        }
                    }
                }
                else
                {

                }

            }
        }

    }

    #endregion


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
    /// 加载公告信息
    /// </summary>
    private void LoadGGInfo()
    {
        strSql = "SELECT * FROM SCHOOL WHERE IFLAG=1 AND ICLASS=9 AND '" + TextBox_Time.Text + "' BETWEEN TSTIME AND TETIME ORDER BY IPX DESC";

        if (OP_Mode.SQLRUN(strSql))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strHtml = "<div class=\"col-xs-12\">";
                strHtml += "<div class=\"widget-box transparent\">";
                strHtml += "  <div class=\"widget-header widget-header-flat\">";
                strHtml += "    <h4 class=\"lighter\"><i class=\"icon-bullhorn\"></i>通知公告</h4>";
                strHtml += "    <div class=\"widget-toolbar\"><a href=\"#\" data-action=\"collapse\"><i class=\"icon-chevron-up\"></i></a></div>";
                strHtml += "  </div>";
                strHtml += "</div>";
                strHtml += "<div class=\"widget-body\">";
                strHtml += "  <div class=\"widget-main no-padding\">";
                strHtml += "    <div class=\"dialogs\">";
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHtml += "      <div class=\"itemdiv dialogdiv\">";
                    strHtml += "        <div class=\"user\">";
                    strHtml += "          <img alt=\"Alexa's Avatar\" src=\"/images/ant2.png\" />";
                    strHtml += "        </div>";
                    strHtml += "        <div class=\"body\">";
                    strHtml += "          <div class=\"time\">";
                    strHtml += "            <i class=\"icon-time\"></i>";
                    strHtml += "            <span class=\"grey\">" + OP_Mode.Dtv[i]["LTime"].ToString() + "</span>";
                    strHtml += "          </div>";
                    strHtml += "          <div class=\"name\">";
                    strHtml += "            <span class=\"label label-info arrowed arrowed-in-right\">通知公告</span>";
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
                strHtml += "</div>";

                TPinfo.InnerHtml = strHtml;
                TPinfo.Visible = true;
            }
            else
            {
                TPinfo.Visible = false;
            }
        }
        else
        {
            TPinfo.Visible = false;
        }
    }

    /// <summary>
    /// 加载图片信息
    /// </summary>
    private void LoadTPInfo()
    {
        strSql = "SELECT * FROM SCHOOL WHERE IFLAG=1 AND ICLASS=9 AND '" + TextBox_Time.Text + "' BETWEEN TSTIME AND TETIME ORDER BY IPX DESC";

        if (OP_Mode.SQLRUN(strSql))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                strHtml = "<div class=\"col-xs-12\">";
                strHtml += "<div class=\"widget-box transparent\">";
                strHtml += "  <div class=\"widget-header widget-header-flat\">";
                strHtml += "    <h4 class=\"lighter\"><i class=\"icon-bullhorn\"></i>图片信息</h4>";
                strHtml += "    <div class=\"widget-toolbar\"><a href=\"#\" data-action=\"collapse\"><i class=\"icon-chevron-up\"></i></a></div>";
                strHtml += "  </div>";
                strHtml += "</div>";
                strHtml += "<div class=\"widget-body\">";
                strHtml += "  <div class=\"widget-main no-padding\">";
                strHtml += "    <div class=\"dialogs\">";
                strHtml += "      <div class=\"itemdiv dialogdiv\">";
                strHtml += "        <div class=\"user\">";
                strHtml += "          <img alt=\"Alexa's Avatar\" src=\"/images/ant2.png\" />";
                strHtml += "        </div>";
                strHtml += "        <div class=\"body\">";
                strHtml += "          <div class=\"time\">";
                strHtml += "            <i class=\"icon-time\"></i>";
                strHtml += "          </div>";
                strHtml += "          <div class=\"name\">";
                strHtml += "            <span class=\"label label-info arrowed arrowed-in-right\">图片信息</span>";
                strHtml += "          </div>";
                strHtml += "          <div class=\"text\">";

                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strHtml += "<a href=\"" + OP_Mode.Dtv[i]["NContent"].ToString() + "\"><img width=\"200\" class=\"img-rounded\" src=\"" + OP_Mode.Dtv[i]["NContent"].ToString() + "\" /></a>";
                }

                strHtml += "          </div>";
                strHtml += "        </div>";
                strHtml += "      </div>";
                strHtml += "    </div>";
                strHtml += "  </div>";
                strHtml += " </div>";
                strHtml += "</div>";

                GGInfo.InnerHtml = strHtml;
                GGInfo.Visible = true;
            }
            else
            {
                GGInfo.Visible = false;
            }
        }
        else
        {
            GGInfo.Visible = false;
        }
    }

    /// <summary>
    /// 加载作业信息
    /// </summary>
    private void LoadZYInfo()
    {
        strSql = "SELECT * FROM SCHOOL WHERE IFLAG=1 AND ICLASS<>0 AND ICLASS<5 AND '" + TextBox_Time.Text + "' BETWEEN TSTIME AND TETIME ORDER BY ICLASS, IPX DESC";

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
                    if (iClass == -1)
                    {
                        strHtml += "          <img alt=\"Alexa's Avatar\" src=\"/images/ant2.png\" />";
                    }
                    else if (iClass == 1)
                    {
                        strHtml += "          <img alt=\"Alexa's Avatar\" src=\"/images/yuwen.png\" />";
                    }
                    else if (iClass == 2)
                    {
                        strHtml += "          <img alt=\"Alexa's Avatar\" src=\"/images/shuxue.png\" />";
                    }
                    else if (iClass == 3)
                    {
                        strHtml += "          <img alt=\"Alexa's Avatar\" src=\"/images/yingyu.png\" />";
                    }
                    else if (iClass == 4)
                    {
                        strHtml += "          <img alt=\"Alexa's Avatar\" src=\"/images/qita.png\" />";
                    }
                    strHtml += "        </div>";
                    strHtml += "        <div class=\"body\">";
                    strHtml += "          <div class=\"time\">";
                    strHtml += "            <i class=\"icon-time\"></i>";
                    strHtml += "            <span class=\"grey\">" + OP_Mode.Dtv[i]["LTime"].ToString() + "</span>";
                    strHtml += "          </div>";
                    strHtml += "          <div class=\"name\">";

                    if (iClass == -1)
                    {
                        strHtml += "            <span class=\"label label-info arrowed arrowed-in-right\">图片信息</span>";
                    }
                    else if (iClass == 1)
                    {
                        strHtml += "            <span class=\"label label-info arrowed arrowed-in-right\">语文作业</span>";
                    }
                    else if (iClass == 2)
                    {
                        strHtml += "            <span class=\"label label-info arrowed arrowed-in-right\">数学作业</span>";
                    }
                    else if (iClass == 3)
                    {
                        strHtml += "            <span class=\"label label-info arrowed arrowed-in-right\">英语作业</span>";
                    }
                    else if (iClass == 4)
                    {
                        strHtml += "            <span class=\"label label-info arrowed arrowed-in-right\">其它作业</span>";
                    }

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
                        strHtml += OP_Mode.Dtv[i]["NContent"].ToString();
                    }
                    strHtml += "          </div>";
                    strHtml += "        </div>";
                    strHtml += "      </div>";
                }
                strHtml += "    </div>";
                strHtml += "  </div>";
                strHtml += " </div>";
                // strHtml += "</div>";

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

    /// <summary>
    /// 查询作业
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadGGInfo();
        //     LoadTPInfo();
        LoadZYInfo();

    }
}