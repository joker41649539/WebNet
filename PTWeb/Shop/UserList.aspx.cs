using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Default2 : PageBaseShop
{
    public int WebID = 1;// 页面ID
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
                LoadData();
            }
        }
    }

    private void LoadData()
    {
        string strSQL = "Select row_number() over(order by LTime) as row_number,* from Shop_UserInfo where PhoneNo like '%" + TextBox_PhoneNo.Text.Replace("'", "").Trim() + "%' order by LTime desc";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView_Users.DataSource = OP_Mode.Dtv;
                GridView_Users.DataBind();
            }
        }
    }

    protected void GridView_Users_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int iID = Convert.ToInt32(GridView_Users.DataKeys[e.NewEditIndex].Values[0]);
        int iFlag = Convert.ToInt32(GridView_Users.DataKeys[e.NewEditIndex].Values[1]);
        if (iFlag == 0)
        {
            iFlag = 1;
        }
        else
        {
            iFlag = 0;
        }
        string strSQL = "Update Shop_UserInfo set Flag=" + iFlag + ",LTime=getdate() where ID=" + iID.ToString();
        if (OP_Mode.SQLRUN(strSQL))
        {
            e.NewEditIndex = -1;
            if (iFlag == 0)
            {
                MessageBox("用户启用成功。");
            }
            else
            {
                MessageBox("用户停用成功。");
            }
            LoadData();
        }
        else
        {
            MessageBox("用户状态更新失败。");
            return;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}