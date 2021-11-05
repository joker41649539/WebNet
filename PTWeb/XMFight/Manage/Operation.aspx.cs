using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Manage_Operation : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(DefaultUser) != 6)
        //{
        //    MessageBox("", "您没有操作权限。", "/XMFight/");
        //    return;
        //}
        //else
        //{
        //    if (!IsPostBack)
        //    { 
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
        //    }
        //}


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
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "操作成功。", "/XMFight/Manage/Students.aspx");
                return;
            }
            else
            {
                MessageBox("", "操作失败。<br/>错误：" + OP_Mode.strErrMsg, "/XMFight/Manage/Students.aspx");
                return;
            }
        }
        catch
        {
            MessageBox("", "您没有操作权限。", "/XMFight/");
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