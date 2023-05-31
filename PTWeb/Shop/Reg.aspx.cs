using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Reg : PageBaseShop
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox_Parent.Text = Request["Parent"];
        }
    }

    protected void Button_SendCode_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        string strPhoneNo = TextBox_PhoneNo.Text;
        if (strPhoneNo.Length == 11)
        {
            // 1、检测手机号码是否注册过，注册过给出提示。并检测验证码发送时间间隔，验证码间隔2分钟才允许再次发送

            strSQL = "Select top 1 *,isnull((Select Top 1 ID from Shop_UserInfo where PhoneNo=a.PhoneNo order by Ctime desc),0) UserID from Shop_PhoneCode a Where PhoneNo='" + strPhoneNo + "' order by CTime desc";

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    if (Convert.ToInt32(OP_Mode.Dtv[0]["UserID"]) > 0)
                    {
                        MessageBox("", "'" + strPhoneNo + "' 已经注册过了。");
                        return;
                    }
                    else if (Convert.ToDateTime(OP_Mode.Dtv[0]["CTime"]).AddMinutes(2) > System.DateTime.Now)
                    {
                        MessageBox("", "'" + strPhoneNo + "' 刚刚发送过验证码，请查阅。<br>如未收到请等2分钟后再试。");
                        return;
                    }
                }
            }

            Random rad = new Random();//实例化随机数产生器rad；

            int value = rad.Next(1000, 10000);
            TextBox_Code.Text = value.ToString();

            // 2、生成验证码，发送验证码信息，发送成功后执行下面数据库操作。MSGNo 为发送的ID号 成功iFlag=0

            string TempCodeNo = string.Empty;// 获取到返回的验证码ID
            strSQL = "Insert into Shop_PhoneCode (PhoneNo,CodeNo,MSGNo,iFlag) values ('" + strPhoneNo + "','" + value + "','" + TempCodeNo + "',0)";

            if (OP_Mode.SQLRUN(strSQL))
            {
                HiddenField_CodeNo.Value = TempCodeNo;
                Button_SendCode.Enabled = false;
                return;
            }
        }
        else
        {
            MessageBox("手机号码输入错误，请检查。");
            return;
        }
    }

    protected void LinkButton_REG_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;

        string strPhoneNo = TextBox_PhoneNo.Text.Replace("'", "");
        string strCode = TextBox_Code.Text.Replace("'", "");
        string strPass = TextBox_Password.Text.Replace("'", "");
        string strCodeNo = HiddenField_CodeNo.Value;

        strSQL = "DECLARE @ICOUNT INT";

        strSQL += " SELECT @ICOUNT = COUNT(ID) FROM Shop_UserInfo WHERE PhoneNo ='" + strPhoneNo + "'";

        strSQL += " IF @ICOUNT<= 0"; // 未注册，可以注册
        strSQL += " BEGIN";

        strSQL += "   SELECT @ICOUNT = COUNT(ID) FROM Shop_PhoneCode WHERE PhoneNo ='" + strPhoneNo + "' and CodeNo='" + strCode + "' and MSGNo='" + strCodeNo + "'";
        strSQL += "     IF @ICOUNT> 0"; // 验证码正确
        strSQL += "     BEGIN";

        strSQL += "     Insert into Shop_UserInfo (PhoneNo,NickName,PassWordNo,Parent) values ('" + strPhoneNo + "','" + strPhoneNo + "','" + strPass + "','" + TextBox_Parent.Text + "')";
        strSQL += "     Select '恭喜，注册成功。' MSG, 'true' T";
        strSQL += "     END";
        strSQL += "     ELSE";
        strSQL += "     BEGIN";
        strSQL += "         Select '1' MSG, 'false' T";
        strSQL += "     END";
        strSQL += " END";
        strSQL += " ELSE";
        strSQL += " BEGIN";
        strSQL += "   Select '2' MSG, 'false' T";
        strSQL += " END";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                if (OP_Mode.Dtv[0]["T"].ToString() == "true")
                {
                    /// 注册成功，需要写入Cooke
                    Response.Cookies["Shop"]["PhoneNo"] = strPhoneNo;

                    MessageBox("", "恭喜，注册成功。", "/Shop/");
                    return;
                }
                else
                {
                    string strMSG = string.Empty;
                    if (OP_Mode.Dtv[0]["MSG"].ToString() == "1")
                    {
                        strMSG = "验证码错误，请仔细查阅。";
                    }
                    else if (OP_Mode.Dtv[0]["MSG"].ToString() == "2")
                    {
                        strMSG = "此号码已经注册过了，不能再注册了。";
                    }
                    MessageBox("", strMSG);
                    return;
                }
            }
        }
    }
}