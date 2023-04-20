using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        WriteCookie(TextBox1.Text, TextBox2.Text);

        string strKey = GetCookie(TextBox1.Text);
        string strValue = GetCookie(TextBox2.Text);

        MessageBox("", "Cookie:" + strKey + "|" + strValue);
    }
}