using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Manage_AddStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string DB_01, DB_02, DB_03, DB_04;
        string strSQL = string.Empty;
        int iSex = 0;
        try
        {
            DB_01 = TextBox_Name.Text.Replace("'", "''");
            DB_02 = TextBox_Brithday.Text.Replace("'", "''");
            DB_03 = TextBox_OpID.Text.Replace("'", "''");
            DB_04 = TextBox_Remark.Text.Replace("'", "''");
            iSex = Convert.ToInt32(RadioButtonList1.SelectedValue);
            strSQL = "Insert into XMFight_Student (Name,BrithDay,OpenID,Sex,HeadImg,Remark) values('" + DB_01 + "','" + DB_02 + "','" + DB_03 + "','" + iSex + "','','" + DB_04 + "')";

        }
        catch
        {

        }
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }
}