using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XMFight_agreement_New : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefaultData();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void LoadDefaultData()
    {
        ///赋值当天日期
        TextBoxSTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
    }
}