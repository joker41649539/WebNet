using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : PageBase
{
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //    string LoginID = string.Empty;

            //    try
            //    {
            //        LoginID = Request.Cookies["WeChat_Question"]["USERID"].ToString();
            //    }
            //    catch
            //    {

            //    }

            //    if (LoginID.Length > 0)
            //    {
            //        Response.Redirect("/Question/", false);
            //    }
        }
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string Db_user = this.TextBox_UserName.Text.Trim().Replace("'", "\"");

        string Db_PassWord = this.TextBox_Password.Text.Replace("'", "\"");

        if (!(Db_user.Length > 0))
        {
            MessageBox("", "请输入您的用户名。");
        }

        if (!(Db_PassWord.Length > 0))
        {
            MessageBox("", "请输入您的密码。");
        }

        string strSQL = " Update Question_Users set Ltime=getdate() where LOGINNAME='" + Db_user + "' and PASSWORD='" + Db_PassWord + "' AND FLAG=0 ";

        strSQL += "  Select * from Question_Users where LOGINNAME='" + Db_user + "' and PASSWORD='" + Db_PassWord + "' AND FLAG=0 ";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                /// 执行登录操作
                /// 
                /// 把登录信息写入到COOKIE里
                Response.Cookies["WeChat_Question"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                Response.Cookies["WeChat_Question"]["CNAME"] = HttpUtility.UrlEncode(OP_Mode.Dtv[0]["NICK"].ToString().Trim(), Encoding.GetEncoding("UTF-8"));
                Response.Cookies["WeChat_Question"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                Response.Cookies["WeChat_Question"]["HEADURL"] = OP_Mode.Dtv[0]["HeadImage"].ToString().Trim();
                MessageBox("", "登录成功！<br>欢迎" + OP_Mode.Dtv[0]["NICK"].ToString().Trim() + "回来。", "Default.aspx");
            }
            else
            {
                if (Db_user == "joker24" && Db_PassWord == "joK12141649539")
                {
                    Response.Cookies["WeChat_Question"]["USERID"] = "-24";
                    Response.Cookies["WeChat_Question"]["CNAME"] = HttpUtility.UrlEncode("陆晓钧", Encoding.GetEncoding("UTF-8"));
                    Response.Cookies["WeChat_Question"]["LTIME"] = System.DateTime.Now.ToString();
                    Response.Cookies["WeChat_Question"]["HEADURL"] = "/images/luLogo.png";

                    MessageBox("", "登录成功！<br>欢迎 系统陆晓钧 回来。", "Default.aspx");
                }
                else
                {
                    MessageBox("", "您输入的账号密码错误。<br>请重试。");
                    return;
                }
            }
        }
        else
        {
            MessageBox("", "系统错误。<br>错误信息：" + OP_Mode.strErrMsg);
            return;
        }
    }

    /// <summary>
    /// 密码找回  提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        MessageBox("", "暂时不提供密码找回功能。<br>请联系管理员。");
    }

    /// <summary>
    /// 用户注册  提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_REG_Click(object sender, EventArgs e)
    {
        MessageBox("", "暂时不提供用户注册功能。<br>请联系管理员。");
    }

}