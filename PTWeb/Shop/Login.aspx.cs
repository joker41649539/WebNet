using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : PageBaseShop
{
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


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
            return;
        }

        if (!(Db_PassWord.Length > 0))
        {
            MessageBox("", "请输入您的密码。");
            return;
        }

        string strSQL = " Update Shop_UserInfo set LTime=getdate() where PhoneNo='" + Db_user + "' and PassWordNo='" + Db_PassWord + "' AND FLAG=0 ";

        strSQL += "  Select *,(Select Count(ID) From Shop_Address where UserNo=Shop_UserInfo.PhoneNo) AddressCount from Shop_UserInfo where PhoneNo='" + Db_user + "' and PassWordNo='" + Db_PassWord + "' AND FLAG=0 ";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                string sIMGWeChat = string.Empty;
                string sIMGPay = string.Empty;
                string sBankName = string.Empty;
                string sBankStart = string.Empty;
                string sBankID = string.Empty;
                double GoldCount = 0;
                bool BankMSG = false;
                bool AddressMSG = false;
                int AddressCount = 0;

                sIMGWeChat = OP_Mode.Dtv[0]["WeChatImg"].ToString();
                sIMGPay = OP_Mode.Dtv[0]["PayImg"].ToString();
                sBankName = OP_Mode.Dtv[0]["BankName"].ToString();
                sBankStart = OP_Mode.Dtv[0]["BankStart"].ToString();
                sBankID = OP_Mode.Dtv[0]["BankID"].ToString();
                AddressCount = Convert.ToInt32(OP_Mode.Dtv[0]["AddressCount"]);
                GoldCount = Convert.ToDouble(OP_Mode.Dtv[0]["GoldCount"]);

                if (sIMGWeChat.Length > 0 || sIMGPay.Length > 0 || (sBankID.Length + sBankName.Length + sBankID.Length) > 0)
                {
                    BankMSG = true;
                }
                if (AddressCount > 0)
                {
                    AddressMSG = true;
                }

                /// 执行登录操作
                /// 
                /// 把登录信息写入到COOKIE里
                ResponseCokie(Db_user, BankMSG, AddressMSG, GoldCount);

                MessageBox("", "登录成功！<br>欢迎 [" + Db_user + "] 回来。", "/Shop/");
            }
            else
            {
                MessageBox("", "账号密码错误，请重试。");
                return;
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

    /// <summary>
    /// 发送验证码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_SendCode_Click(object sender, EventArgs e)
    {
        string strPhoneNo = TextBox_PhoneNo.Text;
        if (strPhoneNo.Length == 11)
        {
            Random rad = new Random();//实例化随机数产生器rad；

            int value = rad.Next(1000, 10000);
            TextBox_Code.Text = value.ToString();
            //  MessageBox("生成Code：" + value.ToString());
            // this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>$(\"#login-box\").modal('show');</script>");
            this.Page.ClientScript.RegisterStartupScript(typeof(string), "", "<script language=JavaScript>show_box('login-box')</script>");
            return;
        }
        else
        {
            MessageBox("手机号码输入错误，请检查。");
            return;
        }
    }
}