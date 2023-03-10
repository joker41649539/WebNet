using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Manage_BanceAdd : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    private void LoadData()
    {
        string strSQL = string.Empty;

        string strID = "0";
        try
        {
            strID = Request["ID"];
            if (Convert.ToInt32(strID) > 0)
            {
                strSQL = "Select * from XMFight_Bance where ID=" + strID;
                if (OP_Mode.SQLRUN(strSQL))
                {
                    if (OP_Mode.Dtv.Count > 0)
                    {
                        double Amount = Convert.ToDouble(OP_Mode.Dtv[0]["Amount"]);
                        if (Amount >= 0)
                        {
                            DropDownList1.SelectedValue = "收入";
                        }
                        else
                        {
                            DropDownList1.SelectedValue = "支出";
                            Amount = Amount * Convert.ToDouble(-1);
                        }
                        TextBox_XFJE.Text = Amount.ToString();
                        TextBox_Remark.Text = OP_Mode.Dtv[0]["Remark"].ToString();
                    }
                }
            }
        }
        catch
        {
        }

    }

    /// <summary>
    /// 数据保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;

        string strID = "0";
        try
        {
            strID = Request["ID"];
        }
        catch
        {
        }

        UpdateData(Convert.ToInt32(strID));

    }

    private void UpdateData(int strID)
    {
        string Db01 = DropDownList1.SelectedValue;
        double DB02 = 0;
        string Db03 = TextBox_Remark.Text.Replace("'", "''");
        int userID = 1;
        try
        {
            userID = Convert.ToInt32(DefaultUser);
            DB02 = Convert.ToDouble(TextBox_XFJE.Text);
            if (Db01 == "支出")
            {
                DB02 = DB02 * -1;
            }
        }
        catch
        {
            MessageBox("", "消费金额必须是数字。");
            return;
        }
        string strSQL = string.Empty;

        if (strID > 0)
        {
            strSQL = "Update XMFight_Bance set Amount='" + DB02 + "',Remark='" + Db03 + "',UserID=" + userID + ",LTime=getdate() where id=" + strID;
        }
        else
        {
            strSQL = "Insert into XMFight_Bance (Amount,Remark,UserID) values (" + DB02 + ",'" + Db03 + "'," + userID + ")";
        }

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (strID > 0)
            {
                MessageBox("", "消费数据更新成功。", "/XMFight/Manage/Bance.aspx");
            }
            else
            {
                MessageBox("", "消费数据添加成功。", "/XMFight/Manage/Bance.aspx");
            }
        }
    }

    /// <summary>
    /// 数据删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string strID = "0";
        try
        {
            strID = Request["ID"];
            if (Convert.ToInt32(strID) > 0)
            {
                string strSQL = "Delete from XMFight_Bance where ID=" + strID;
                if (OP_Mode.SQLRUN(strSQL))
                {
                    MessageBox("", "消费数据删除成功。", "/XMFight/Manage/Bance.aspx");
                }
                else
                {
                    MessageBox("", "消费数据删除失败，请重试。", "/XMFight/Manage/Bance.aspx");
                }
            }
        }
        catch
        {

        }
    }
}