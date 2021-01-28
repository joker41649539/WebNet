using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sys_MyUserInfo : PageBase
{
    OpMode OP_Mode = new OpMode(DefaultConStr, 0);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUserInfo();
        }
    }

    /// <summary>
    /// 用户基本信息加载
    /// </summary>
    private void LoadUserInfo()
    {
        string strSql = "Select CNAME,ZMC,LTIME,CTIME,HEADURL,ZJHM,XB,SSDW,SSDZ,BankID from S_USERINFO left join (Select ZMC,USERID from S_QXZ,S_YH_QXZ where S_QXZ.ID=S_YH_QXZ.QXZID) a on ID=a.USERID Where ID=" + DefaultUser;

        if (OP_Mode.SQLRUN(strSql))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                this.Label_Name.Text = OP_Mode.Dtv[0]["CNAME"].ToString();
                this.TextBox_Name.Text = OP_Mode.Dtv[0]["CNAME"].ToString();
                this.Label_Ctime.Text = OP_Mode.Dtv[0]["CTIME"].ToString();
                this.Label_Ltime.Text = OP_Mode.Dtv[0]["LTIME"].ToString();
                TextBox_KH.Text = OP_Mode.Dtv[0]["BankID"].ToString();
                TextBox_ZJNo.Text = OP_Mode.Dtv[0]["ZJHM"].ToString();

                TextBox_LXDH.Text = OP_Mode.Dtv[0]["SSDZ"].ToString();

                string strTemp = OP_Mode.Dtv[0]["HEADURL"].ToString();

                if (OP_Mode.Dtv[0]["XB"].ToString() == "0")
                {
                    DropDownList_Sex.SelectedValue = "0";
                }
                else
                {
                    DropDownList_Sex.SelectedValue = "1";
                }

                //    DropDownList_JYJG.SelectedValue = OP_Mode.Dtv[0]["SSDW"].ToString();

                if (strTemp.Length > 0)
                {
                    this.Image_User.ImageUrl = strTemp;
                }
                else
                {
                    this.Image_User.ImageUrl = "/images/luLogo.jpg";
                }

                strTemp = string.Empty;

                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    if (i > 0)
                    {
                        strTemp += "，";
                    }
                    strTemp += OP_Mode.Dtv[i]["ZMC"].ToString();
                }

                this.Label_ZMC.Text = strTemp;
            }
            else
            {
                MessageBox("错 误", "错误的用户参数！<br/>请不要尝试非法操作。");
                return;
            }
        }
        else
        {
            MessageBox("错 误", "用户信息加载失败。<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }

    }

    /// <summary>
    /// 密码修改，弹出窗口
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_PassWord_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#PassWord_Edit').modal('show')</script>");
    }

    /// <summary>
    /// 密码修改保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_PassWordUpdate_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        string strOldPass = this.TextBox_Old.Text.Replace("'", "\"");
        string strNewPass = this.TextBox_New.Text.Replace("'", "\"");
        string strNewPass1 = this.TextBox_New1.Text.Replace("'", "\"");

        if (strOldPass.Length == 0)
        {
            MessageBox("", "原密码必须填写，请重新填写。");
            return;
        }

        if (strNewPass.Length < 6)
        {
            MessageBox("", "新密码至少需要6位，请重新填写。");
            return;
        }

        if (strNewPass != strNewPass1)
        {
            MessageBox("", "两次输入的新密码不一样，请重新填写。");
            return;
        }

        strSQL = " Update S_UserInfo set PASSWORD='" + strNewPass + "',LTime=Getdate() Where ID=" + DefaultUser + " And PassWord='" + strOldPass + "' ";
        strSQL += " Select * from S_UserInfo Where ID=" + DefaultUser + " And PassWord='" + strNewPass + "'";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                MessageBox("恭 喜", "密码修改成功。");
                return;
            }
            else
            {
                MessageBox("错 误", "原密码错误，密码修改失败。<br/>请重新填写。");
                return;
            }
        }
        else
        {
            MessageBox("错 误", "密码修改失败。<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }
    }

    /// <summary>
    /// 头像修改，弹出窗口
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_HeardUrl_Click(object sender, EventArgs e)
    {
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "sKey", "<script language=JavaScript>$('#HeadUrl').modal('show')</script>");
    }

    /// <summary>
    /// 头像数据保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_HeadUrl_Click(object sender, EventArgs e)
    {
        string strHeadUrl = this.TextBox_HeadUrl.Text.Replace("'", "\"");

        string strSQL = " Update S_UserInfo set HEADURL='" + strHeadUrl + "',LTime=getdate() Where ID=" + DefaultUser;

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "头像修改成功。");
            return;

        }
        else
        {
            MessageBox("错 误", "头像修改失败。<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }

    }

    /// <summary>
    /// 保存用户基本信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;
        string strSex = DropDownList_Sex.SelectedValue.ToString();
        string strZJNo = TextBox_ZJNo.Text.Replace("'", "\"");
        string strLXDH = TextBox_LXDH.Text.Replace("'", "\"");
        string strName = TextBox_Name.Text.Replace("'", "\"");
        string strBankID = TextBox_KH.Text.Replace("'", "\"");

        if (strZJNo.Length != 18)
        {
            MessageBox("", "身份证号码输入错误，请重新填写。");
            return;
        }

        if (strLXDH.Length != 11)
        {
            MessageBox("", "请输入11位移动电话号码，请重新填写。");
            return;
        }

        strSQL = " Update S_UserInfo Set XB=" + strSex + ",BankID='" + strBankID + "',CName='" + strName + "',ZJHM='" + strZJNo + "',SSDZ='" + strLXDH + "',LTime=getdate() Where ID=" + DefaultUser;
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "个人信息修改成功！");
        }
        else
        {
            MessageBox("", "修改错误：" + OP_Mode.strErrMsg);
        }

    }
}