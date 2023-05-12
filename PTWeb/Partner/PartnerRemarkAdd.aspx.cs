using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partner_PartnerRemarkAdd : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!QXBool(52, Convert.ToInt32(DefaultUser)))
        {
            MessageBox("", "您没有查看协同人员的权限。", Defaut_QX_URL);
            return;
        }
        else
        {
            if (!IsPostBack)
            {
                DefaultData();
            }
        }
    }

    private void DefaultData()
    {
        string strTemp = string.Empty;
        try
        {
//            1、用工费用：
//2、日均积分能效比：
//3、能做什么：
//4、是否粗糙：
//5、是否斤斤计较：
//6、干活效率：
//7、其它说明：
            /// 首次填写 给出默认格式。
            strTemp = "1、用工费用：\r\n";
            strTemp += "2、日均积分能效比：\r\n";
            strTemp += "3、能做什么：\r\n";
            strTemp += "4、是否粗糙：\r\n";
            strTemp += "5、是否斤斤计较：\r\n";
            strTemp += "6、干活效率：\r\n";
            strTemp += "7、其它说明：\r\n";

            int ID = Convert.ToInt32(Request["ID"]);

            HiddenField_UserID.Value = ID.ToString();

            string strSQL = "Select CNAME,isnull((Select top 1 Remark from w_user_Remark where remarkuserid=S_USERINFO.ID),'') Remark from s_UserInfo where id=" + ID.ToString();

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    Label_Name.Text = OP_Mode.Dtv[0]["CName"].ToString();

                    if (OP_Mode.Dtv[0]["Remark"].ToString().Length > 0)
                    {/// 如果曾经有过说明记录，则不出现默认格式，否则出现默认格式。
                        strTemp = String.Empty;
                    }
                }
            }
            TextBox_Remark.Text = strTemp;
        }
        catch
        {
            MessageBox("", "错误的参数信息。", "/Partner/");
            return;
        }


    }

    /// <summary>
    /// 保存数据到数据库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;

        if (TextBox_Remark.Text.Length > 0)
        {
            strSQL = "Insert into w_user_Remark (UserID,RemarkUserID,Remark) values (" + DefaultUser + "," + Convert.ToInt32(HiddenField_UserID.Value) + ",'" + TextBox_Remark.Text.Replace("'", "") + "')";

            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "说明信息添加成功。", "/Partner/PartnerInfo.aspx?ID=" + HiddenField_UserID.Value);
            }
        }
    }
}