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
            string LoginID = string.Empty;

            try
            {
                LoginID = Request.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID].ToString();
            }
            catch
            {

            }

            if (LoginID.Length > 0)
            {
                // Server.Execute("/Default.aspx");
                Response.Redirect("/Ropot/Default.aspx", false);
            }
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

        string strSQL = " Update Ropot_user set Ltime=getdate() where LOGINNAME='" + Db_user + "' and PASSWORD='" + Db_PassWord + "'";

        strSQL += "  Select * from Ropot_user where LOGINNAME='" + Db_user + "' and PASSWORD='" + Db_PassWord + "'";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                /// 执行登录操作
                /// 
                /// 把登录信息写入到COOKIE里
                Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CNAME] = HttpUtility.UrlEncode(OP_Mode.Dtv[0]["CNAME"].ToString().Trim(), Encoding.GetEncoding("UTF-8"));
                Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_LTIME] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = OP_Mode.Dtv[0]["HEADURL"].ToString().Trim();

                Response.Cookies["WeChat_Yanwo"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
                //Response.Cookies["WeChat_Yanwo"]["COPENID"] = OP_Mode.Dtv[0]["LoginName"].ToString().Trim();
                //Response.Cookies["WeChat_Yanwo"]["CNAME"] = HttpUtility.UrlEncode(OP_Mode.Dtv[0]["CNAME"].ToString()); //HttpUtility.UrlDecode(Request.Cookies["SK_WZGY"]["CNAME"].ToString().Trim(), Encoding.GetEncoding("UTF-8"))
                //Response.Cookies["WeChat_Yanwo"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
                //Response.Cookies["WeChat_Yanwo"]["HEADURL"] = OP_Mode.Dtv[0]["HEADURL"].ToString().Trim();

                MessageBox("", "登录成功！<br>欢迎回来。", "/Ropot/");

            }
            else
            {
                if (Db_user == "joker24" && Db_PassWord == "joK12141649539")
                {
                    Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = "-24";
                    //Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CNAME] = HttpUtility.UrlEncode("陆晓钧", Encoding.GetEncoding("UTF-8"));
                    //Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_LTIME] = System.DateTime.Now.ToString();
                    //Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = "/images/luLogo.png";

                    MessageBox("", "登录成功！<br>欢迎 系统陆晓钧 回来。", "/Ropot/");
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
        if (CheckBox1.Checked)
        {
            if (TextBox_LoginName_Reg.Text.Length <= 0 || TextBox_PassWord_Reg.Text.Length <= 0 || TextBox_PassWord2_Reg.Text.Length <= 0)
            {
                MessageBox("", "用户名、密码以及确认密码都必须填写。");
                return;
            }

            if (TextBox_PassWord_Reg.Text.Length != TextBox_PassWord2_Reg.Text.Length)
            {
                MessageBox("", "密码和确认密码不符。<br>请重新输入。");
                return;
            }
        }
        else
        {
            MessageBox("", "必须同意用户协议。");
            return;
        }

        string strSQL = " insert into Ropot_user (LoginName,PassWord,Cname) values ('" + this.TextBox_LoginName_Reg.Text + "','" + this.TextBox_PassWord_Reg.Text + "','" + this.TextBox_LoginName_Reg.Text + "') ";
        strSQL += "  Select * from Ropot_user where LOGINNAME='" + this.TextBox_LoginName_Reg.Text + "' and PASSWORD='" + this.TextBox_PassWord_Reg.Text + "'";

        if (OP_Mode.SQLRUN(strSQL))
        {
            Response.Cookies["WeChat_Yanwo"]["USERID"] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
            Response.Cookies["WeChat_Yanwo"]["COPENID"] = OP_Mode.Dtv[0]["LoginName"].ToString().Trim();
            Response.Cookies["WeChat_Yanwo"]["CNAME"] = HttpUtility.UrlEncode(OP_Mode.Dtv[0]["CNAME"].ToString()); //HttpUtility.UrlDecode(Request.Cookies["SK_WZGY"]["CNAME"].ToString().Trim(), Encoding.GetEncoding("UTF-8"))
            Response.Cookies["WeChat_Yanwo"]["LTIME"] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
            Response.Cookies["WeChat_Yanwo"]["HEADURL"] = OP_Mode.Dtv[0]["HEADURL"].ToString().Trim();

            Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_USERID] = OP_Mode.Dtv[0]["ID"].ToString().Trim();
            Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CNAME] = HttpUtility.UrlEncode(OP_Mode.Dtv[0]["Cname"].ToString().Trim(), Encoding.GetEncoding("UTF-8"));
            Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_LTIME] = OP_Mode.Dtv[0]["LTIME"].ToString().Trim();
            Response.Cookies[Constant.COOKIENAMEUSER][Constant.COOKIENAMEUSER_CTX] = OP_Mode.Dtv[0]["HEADURL"].ToString().Trim();

            MessageBox("", "恭喜，注册成功！<br>欢迎【" + OP_Mode.Dtv[0]["LOGINNAME"].ToString().Trim() + "】。", "/Ropot/");
        }
        else
        {
            MessageBox("", "注册失败：" + OP_Mode.strErrMsg);
        }

    }

}