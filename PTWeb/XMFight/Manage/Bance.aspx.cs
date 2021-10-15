using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_Manage_Bance : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefaultData();
            LoadAmount();
        }
    }
    /// <summary>
    /// 加载默认数据
    /// </summary>
    private void LoadDefaultData()
    {
        TextBox1.Text = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.ToString("yyyy-MM-dd");
        TextBox2.Text = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1).ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// 加载并绑定盈利情况
    /// </summary>
    private void LoadAmount()
    {
        string strSQL = string.Empty;

        string DLtimeStart = Convert.ToDateTime(TextBox1.Text).ToString("yyyy-MM-dd");
        string DLtimeEnd = Convert.ToDateTime(TextBox2.Text).ToString("yyyy-MM-dd");

        strSQL = "Select (Select sum(amount) SR from xmfight_bance where ltime between '" + DLtimeStart + "' and '" + DLtimeEnd + "' and amount > 0) SR,";
        strSQL += "(Select sum(amount) ZC from xmfight_bance where ltime between '" + DLtimeStart + "' and '" + DLtimeEnd + "' and amount<0) ZC,";
        strSQL += " * from xmfight_bance where ltime between '" + DLtimeStart + "' and '" + DLtimeEnd + "' order by Ltime desc";

        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_LJSR.Text = OP_Mode.Dtv[0]["SR"].ToString();
                Label_LJZC.Text = OP_Mode.Dtv[0]["ZC"].ToString();
                Label_LJLR.Text = (Convert.ToDouble(OP_Mode.Dtv[0]["SR"]) + Convert.ToDouble(OP_Mode.Dtv[0]["ZC"])).ToString();
            }
            else
            {
                Label_LJSR.Text = "0";
                Label_LJZC.Text = "0";
                Label_LJLR.Text = "0";
            }
        }
        else
        {
            MessageBox("", OP_Mode.strErrMsg);
            return;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadAmount();
    }
}