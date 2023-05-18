using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
{
    public int WebID = 3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!QXBool(WebID, DefaultUser))
            {
                MessageBox("", "您无查看此页面的权限。", "/Shop/");
                return;
            }
            else
            {
                LoadSysSet();
            }
        }
    }

    private void LoadSysSet()
    {
        string strSQL = "Select * from Shop_SysSet where UserNo='" + DefaultUser + "'";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                TextBox1.Text = OP_Mode.Dtv[0][2].ToString();
                TextBox2.Text = OP_Mode.Dtv[1][2].ToString();
                TextBox3.Text = OP_Mode.Dtv[2][2].ToString();
                TextBox4.Text = OP_Mode.Dtv[3][2].ToString();
                TextBox5.Text = OP_Mode.Dtv[4][2].ToString();
            }
            else
            {
                MessageBox("", "您无查看此页面的权限。", "/Shop/");
                return;
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string DB_01 = TextBox1.Text.Replace("'", "");
        string DB_02 = TextBox2.Text.Replace("'", "");
        string DB_03 = TextBox3.Text.Replace("'", "");
        string DB_04 = TextBox4.Text.Replace("'", "");
        string DB_05 = TextBox5.Text.Replace("'", "");

        string strSQL = "Update Shop_SysSet set SetValue='" + DB_01 + "' where UserNo='" + DefaultUser + "' and ID=1";
        strSQL += " Update Shop_SysSet set SetValue='" + DB_02 + "' where UserNo='" + DefaultUser + "' and ID=2";
        strSQL += " Update Shop_SysSet set SetValue='" + DB_03 + "' where UserNo='" + DefaultUser + "' and ID=3";
        strSQL += " Update Shop_SysSet set SetValue='" + DB_04 + "' where UserNo='" + DefaultUser + "' and ID=4";
        strSQL += " Update Shop_SysSet set SetValue='" + DB_05 + "' where UserNo='" + DefaultUser + "' and ID=5";
        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "恭喜，系统设置成功。", "/Shop/SysSet.aspx");
            return;
        }
    }
}