using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BGGL_XJDAdd : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefaultData();
        }

    }
    private void LoadDefaultData()
    {
        Label_ServerTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
        Label_WBName.Text = UserNAME;
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    private bool SaveData()
    {
        bool bSave = false;
        int iFlag = 0;
        string strDJBH = string.Empty, strDWMC = string.Empty, strKHMC = string.Empty, strRemark = string.Empty;
        string DB_01 = string.Empty, DB_02 = string.Empty, DB_03 = string.Empty, DB_04 = string.Empty, DB_05 = string.Empty, DB_06 = string.Empty, DB_07 = string.Empty, DB_08 = string.Empty, DB_09 = string.Empty, DB_10 = string.Empty, DB_11 = string.Empty, DB_12 = string.Empty, DB_13 = string.Empty, DB_14 = string.Empty, DB_15 = string.Empty, DB_16 = string.Empty;

        strDJBH = Label_dh.Text;
        strDWMC = Label_DW.Text;
        strKHMC = TextBox_KHDW.Text.Replace("'", "");
        strRemark = TextBox_Remark.Text.Replace("'", "");

        return bSave;
    }
}