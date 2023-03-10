using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Manage_Operation : PageBaseXMFight
{
    public string Openids = string.Empty;// = new Openids[] { 1, 2, 3, 4, 5, 6 };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(DefaultUser) != 6)
        {
            MessageBox("", "您没有操作权限。", "/XMFight/");
            return;
        }
        else
        {
            if (!IsPostBack)
            {
                try
                {
                    int StudentID = Convert.ToInt32(Request["SID"]);
                    LoadUserInfo(StudentID);
                    int iClassID = Convert.ToInt32(Request["CID"]);
                    Operation(iClassID);
                }
                catch
                {
                    MessageBox("", "您没有操作权限。", "/XMFight/");
                    return;
                }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="iClass"></param>
    private void Operation(int iClass)
    {
        switch (iClass)
        {
            case 0:
                // 添加储备金 界面
                Div_Reserve.Visible = true;
                break;
            case 1:
                // 正常消课
                SaveClassData(1);
                break;
            case 2:
                // 请假，不扣课时
                SaveClassData(2);
                break;
            case 3:
                // 旷课，旷课正常扣除课时
                SaveClassData(3);
                break;
                //default:
                //    // 添加储备金 界面
                //    Div_Reserve.Visible = false;
                //    break;
        }
    }

    private void LoadUserInfo(int iID)
    {
        if (iID > 0)
        {
            string strSQL = "Select * from XMFight_Student Where id=" + iID;
            {
                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        Label_Name.Text = OP_Mode.Dtv[0]["Name"].ToString();
                        //  Openids = OP_Mode.Dtv[0]["OpenID"].ToString();
                    }
                    else
                    {
                        MessageBox("", "未找到任何会员信息。请重试。", "/XMFight/");
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 依据类别保存数据，1、正常上课 2、请假 3、旷课
    /// </summary>
    /// <param name="iFlag"></param>
    private void SaveClassData(int iFlag)
    {
        try
        {
            if (Convert.ToInt32(DefaultUser) <= 0)
            {
                return;
            }
            int StudentID = Convert.ToInt32(Request["SID"]);
            int iClassID = Convert.ToInt32(Request["CID"]);
            string strSQL = string.Empty;
            switch (iFlag)
            {
                case 1:
                    strSQL = "Insert into XMFight_Class_Record (StudentID,iFlag,iCount,UserID,Remark) values (" + StudentID + ",1,-1," + DefaultUser + ",'" + TextBox_Remark.Text.Replace("'", "''") + "')";
                    break;
                case 2:
                    strSQL = "Insert into XMFight_Class_Record (StudentID,iFlag,iCount,UserID,Remark) values (" + StudentID + ",2,0," + DefaultUser + ",'" + TextBox_Remark.Text.Replace("'", "''") + "')";
                    break;
                case 3:
                    strSQL = "Insert into XMFight_Class_Record (StudentID,iFlag,iCount,UserID,Remark) values (" + StudentID + ",3,-1," + DefaultUser + ",'" + TextBox_Remark.Text.Replace("'", "''") + "')";
                    break;
            }
            //switch (iFlag)
            //{
            //    case 1:
            //        strSQL = "Insert into XMFight_Class_Record (StudentID,iFlag,iCount,UserID,Remark) values (" + StudentID + ",1,-1,6,'" + TextBox_Remark.Text.Replace("'", "''") + "')";
            //        break;
            //    case 2:
            //        strSQL = "Insert into XMFight_Class_Record (StudentID,iFlag,iCount,UserID,Remark) values (" + StudentID + ",2,0,6,'" + TextBox_Remark.Text.Replace("'", "''") + "')";
            //        break;
            //    case 3:
            //        strSQL = "Insert into XMFight_Class_Record (StudentID,iFlag,iCount,UserID,Remark) values (" + StudentID + ",3,-1,6,'" + TextBox_Remark.Text.Replace("'", "''") + "')";
            //        break;
            //}
            strSQL += " Select ID, Name, Sex, Remark, Tel, BrithDay, datediff(year, BrithDay, getdate()) age,HeadImg,OpenID";
            strSQL += " ,sumClassCount,LastClassTime,";
            strSQL += " isnull((Select Count(ID) from XMFight_Class_Record where IFlag=2 and StudentID = a.ID),0) Leave,";
            strSQL += " isnull((Select Count(ID) from XMFight_Class_Record where IFlag=3 and StudentID = a.ID),0) Absenteeism,";
            strSQL += " isnull((Select sum(Bance) from XMFight_reserve where StudentID=a.ID),0) SumBance";
            strSQL += " from XMFight_Student a,";
            strSQL += " (Select sum(ICount) sumClassCount, MAX(CTime) LastClassTime, StudentID from XMFight_Class_Record group by StudentID) as b";
            strSQL += " where a.ID = b.StudentID and a.id=" + StudentID;
            strSQL += " order by Name";
            string strMSG = string.Empty;
            if (OP_Mode.SQLRUN(strSQL, "WeChatMsg"))
            {
                if (OP_Mode.Dtv1.Count > 0)
                {
                    Openids = OP_Mode.Dtv1[0]["OpenID"].ToString();
                    if (Openids.Length > 5)
                    {
                        string[] strArray = Openids.Split(';');
                        if (iFlag == 1)
                        {/// 正常上课
                            for (int i = 0; i < strArray.Length; i++)
                            {/// 循环给用户发送信息
                                strMSG += SendXKMsg(strArray[i], OP_Mode.Dtv1[0]["Name"].ToString() + " 同学家长您好，您的孩子已经正常签到。", "自由搏击", OP_Mode.Dtv1[0]["sumClassCount"].ToString(), System.DateTime.Now.ToString("yyyy-MM-dd dddd HH:mm"), "-1 课时", "谢谢您对旭铭搏击的支持，坚持不懈是一种非常好的习惯。", "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf60778eb4d1003de&redirect_uri=http%3A%2F%2Fptweb.x76.com.cn%2FXMFight&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
                            }
                        }
                        else if (iFlag == 2)
                        {/// 请假
                            for (int i = 0; i < strArray.Length; i++)
                            {/// 循环给用户发送信息
                                strMSG += SendXKMsg(strArray[i], OP_Mode.Dtv1[0]["Name"].ToString() + " 同学家长您好，您的孩子由于请假未正常上课。", "自由搏击", OP_Mode.Dtv1[0]["sumClassCount"].ToString(), System.DateTime.Now.ToString("yyyy-MM-dd dddd HH:mm"), "0 课时", "坚持不懈才是对孩子的负责，请勿让孩子养成半途而废的习惯。", "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf60778eb4d1003de&redirect_uri=http%3A%2F%2Fptweb.x76.com.cn%2FXMFight&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
                            }
                        }
                        else if (iFlag == 3)
                        {/// 旷课
                            for (int i = 0; i < strArray.Length; i++)
                            {/// 循环给用户发送信息
                                strMSG += SendXKMsg(strArray[i], OP_Mode.Dtv1[0]["Name"].ToString() + " 同学家长您好，您的孩子已经旷课。请和工作人员联系说明情况。", "自由搏击", OP_Mode.Dtv1[0]["sumClassCount"].ToString(), System.DateTime.Now.ToString("yyyy-MM-dd dddd HH:mm"), "-1 课时", "旷课会正常扣除课时，如有特殊情况请及时联系工作人员。坚持不懈才是对孩子的负责，请勿让孩子养成半途而废的习惯。", "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf60778eb4d1003de&redirect_uri=http%3A%2F%2Fptweb.x76.com.cn%2FXMFight&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
                            }
                        }
                    }
                    //if (strMSG.Length > 0)
                    //{
                    //    MessageBox("", strMSG);
                    //}
                    //else
                    //{
                    MessageBox("", "操作成功。", "/XMFight/Manage/Class.aspx");
                    //}
                    return;
                }
            }
            else
            {
                MessageBox("", "操作失败。<br/>错误：" + OP_Mode.strErrMsg, "/XMFight/Manage/Students.aspx");
                return;
            }
        }
        catch (Exception ex)
        {
            MessageBox("", "您没有操作权限。" + ex, "/XMFight/");
            return;
        }
    }

    /// <summary>
    /// 保存储备金数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            int StudentID = Convert.ToInt32(Request["SID"]);
            string strSQL = "Insert into XMFight_Reserve (StudentID,Bance,iFlag,Remark,UserID) values (" + StudentID + "," + Convert.ToInt32(TextBox_Bance.Text) + "," + Convert.ToInt32(RadioButtonList1.SelectedValue) + ",'" + TextBox_Remark.Text.Replace("'", "''") + "'," + DefaultUser + ")";
            //string strSQL = "Insert into XMFight_Reserve (StudentID,Bance,iFlag,Remark,UserID) values (" + StudentID + "," + Convert.ToInt32(TextBox_Bance.Text) + "," + Convert.ToInt32(RadioButtonList1.SelectedValue) + ",'" + TextBox_Remark.Text.Replace("'", "''") + "',6)";
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "储备金添加成功。", "/XMFight/Manage/Students.aspx");
                return;
            }
        }
        catch
        {
            MessageBox("", "您没有操作权限。", "/XMFight/");
            return;
        }

    }
}