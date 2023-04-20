using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TuanGou_Default2 : PageBaseXMFight
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    /// <summary>
    /// 加载基础数据
    /// </summary>
    private void LoadData()
    {
        try
        {
            string strSQL = "Select * from XMFight_Offer";

            if (OP_Mode.SQLRUN(strSQL))
            {
                if (OP_Mode.Dtv.Count > 0)
                {
                    GridView1.DataSource = OP_Mode.Dtv;
                    GridView1.DataBind();
                }
            }
        }
        catch
        {
            MessageBox("", "用户身份信息获取失败。", "/XMFight/");
        }
    }
}