using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
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
        string strPhoneNo = DefaultUser;

        if (TextBox_PhoneNo.Text.Replace("'", "").Length == 11)
        {
            strPhoneNo = TextBox_PhoneNo.Text.Replace("'", "");
        }

        string strSQL = string.Empty;// "with AreaTree AS";
        strSQL += " SELECT * from Shop_UserInfo where Parent='" + strPhoneNo + "'";

        if (OP_Mode.SQLRUN(strSQL))
        {
            GridView1.DataSource = OP_Mode.Dtv;
            GridView1.DataBind();
        }
    }

    //-------------------------------------------------
    //--根据节点ID获取所有子节点
    //-------------------------------------------------
    //SELECT* FROM #Area;
    //WITH AreaTree AS
    //(
    //    SELECT* from #Area where id = 1--需要查找的节点
    //    UNION ALL
    //    SELECT #Area.* from AreaTree
    //    JOIN #Area on AreaTree.id = #Area.parent_id
    //)
    //SELECT* FROM AreaTree;
    //-------------------------------------------------
    //--根据节点ID获取所有父节点
    //-------------------------------------------------
    //SELECT* FROM #Area;
    //with AreaTree AS
    //(
    //    SELECT* from #Area where Id=6 --需要查找的节点
    //    UNION ALL
    //    SELECT #Area.* from AreaTree
    //    JOIN #Area on AreaTree.parent_id= #Area.Id
    //)
    //SELECT* from AreaTree;


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}