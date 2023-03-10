using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bug_BugEdit : PageBase
{
    public string strSQL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                int IID = Convert.ToInt32(Request["ID"]);
                if (IID > 0)
                {
                    LoadDataByID(IID);
                }
            }
            catch
            {
                MessageBox("", "未查询到任何Bug信息。<br/>请重试。", "/Bug/");
                return;
            }
        }
    }

    /// <summary>
    /// 依据BUGID加载BUG信息
    /// </summary>
    /// <param name="iBugID"></param>
    private void LoadDataByID(int iBugID)
    {
        strSQL = "Select * from S_Bug where ID=" + iBugID.ToString();
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_ID.Text = OP_Mode.Dtv[0]["ID"].ToString();
                TextBox_Title.Text = OP_Mode.Dtv[0]["Title"].ToString();
                Label_CreatUserName.Text = OP_Mode.Dtv[0]["CreatUserName"].ToString();
                TextBox_Remark.Text = OP_Mode.Dtv[0]["Remark"].ToString();
                RadioButtonList1.SelectedValue = OP_Mode.Dtv[0]["Urgency"].ToString();

                int iFlag = Convert.ToInt32(OP_Mode.Dtv[0]["Flag"]);

                if (iFlag == 0)
                { // 待处理
                    LinkButton_Save.Visible = true;
                    LinkButton_Start.Visible = true;
                    LinkButton_Finsh.Visible = false;

                    TextBox_Title.Enabled = true;
                    TextBox_Remark.Enabled = true;

                    Label_Worker.Text = "待处理";
                }
                else if (iFlag == 1)
                {// 完成
                    LinkButton_Save.Visible = false;
                    LinkButton_Start.Visible = false;
                    LinkButton_Finsh.Visible = false;
                    TextBox_Title.Enabled = false;
                    TextBox_Remark.Enabled = false;
                    RadioButtonList1.Enabled = false;
                    Label_Worker.Text = OP_Mode.Dtv[0]["Worker"].ToString() + " 完成于 " + Convert.ToDateTime(OP_Mode.Dtv[0]["LTime"]).ToString("yyyy-MM-dd");
                }
                else if (iFlag == 2)
                {// 处理中
                    LinkButton_Save.Visible = false;
                    LinkButton_Start.Visible = false;
                    LinkButton_Finsh.Visible = true;
                    TextBox_Title.Enabled = false;
                    TextBox_Remark.Enabled = false;
                    RadioButtonList1.Enabled = false;
                    Label_Worker.Text = OP_Mode.Dtv[0]["Worker"].ToString() + " 于 " + Convert.ToDateTime(OP_Mode.Dtv[0]["WorkerDate"]).ToString("yyyy-MM-dd") + " 开始处理";
                }
            }
            else
            {
                MessageBox("", "未查询到任何Bug信息。<br/>请重试。", "/Bug/");
                return;
            }
        }
    }

    /// <summary>
    /// 仅保存BUG信息
    /// </summary>
    private void SaveBugData()
    {
        string strTitle = string.Empty;
        string strRemark = string.Empty;
        string strMSG = string.Empty;

        strTitle = TextBox_Title.Text.Replace("'", "\"");
        strRemark = TextBox_Remark.Text.Replace("'", "\"");

        if (strTitle.Length <= 0)
        {
            strMSG += "请输入标题信息。<br/>";
        }
        if (strRemark.Length <= 4)
        {
            strMSG += "请仔细输入问题描述信息，5字以上。<br/>";
        }
        if (strMSG.Length > 0)
        {
            MessageBox("", strMSG);
            return;
        }
        else
        {
            strSQL = "Update S_Bug set Title='" + strTitle + "',Remark='" + strRemark + "',Urgency=" + RadioButtonList1.SelectedValue + ",CreatDate=getdate() where id=" + Label_ID.Text;
            if (OP_Mode.SQLRUN(strSQL))
            {
                MessageBox("", "Bug信息修改成功。", "/Bug/");
            }
            else
            {
                MessageBox("", "Bug信息保存错误。<br/>错误：" + OP_Mode.strErrMsg);
                return;
            }
        }
    }

    /// <summary>
    /// 插入BUG数据
    /// </summary>
    /// <param name="strTitle"></param>
    /// <param name="strRemark"></param>
    /// <param name="iUrgency"></param>
    public void InsertBugData(string strTitle, string strRemark, int iUrgency)
    {
        string strSQL = "Insert into s_bug (Title,Remark,Urgency,CreatUserName) values ('" + strTitle + "','" + strRemark + "'," + iUrgency.ToString() + ",'" + UserNAME + "')";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "Bug提交成功。<br/>请等待技术人员处理。");
            return;
        }
        else
        {
            MessageBox("", "Bug提交失败。<br/>错误：" + OP_Mode.strErrMsg);
            return;
        }
    }

    /// <summary>
    /// 保存Bug信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_Bug_LinkButton1_Click(object sender, EventArgs e)
    {
        if (Label_CreatUserName.Text != UserNAME)
        {
            MessageBox("", "您不允许修改别人提交的Bug。");
        }
        else
        {
            SaveBugData();
        }
    }

    /// <summary>
    /// 开始处理Bug
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (SaveFlag(2))
        {
            MessageBox("", "Bug处理开始，请尽快完成。", "/BUG/");
        }
    }

    /// <summary>
    /// 处理完成
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_Finsh_Click(object sender, EventArgs e)
    {
        if (Label_CreatUserName.Text != UserNAME)
        {
            MessageBox("", "您不允许完成别人提交的Bug。");
        }
        else
        {
            if (SaveFlag(1))
            {
                MessageBox("", "恭喜您的Bug处理完成。", "/BUG/");
            }
        }
    }

    /// <summary>
    /// 保存标识位
    /// </summary>
    /// <param name="NewFlag"></param>
    /// <returns></returns>
    private bool SaveFlag(int NewFlag)
    {
        bool rValue = false;

        if (NewFlag == 1)
        {// 完成
            strSQL = "Update S_Bug set Flag=" + NewFlag.ToString() + ",LTime=getdate() where ID=" + Label_ID.Text;
        }
        else if (NewFlag == 2)
        {// 开始处理
            strSQL = "Update S_Bug set Flag=" + NewFlag.ToString() + ",Worker='" + UserNAME + "',WorkerDate=getdate() where ID=" + Label_ID.Text;
        }
        if (OP_Mode.SQLRUN(strSQL))
        {
            rValue = true;
        }

        return rValue;
    }
}