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
        if (DefaultUser != null)
        {
            LoadData(DefaultUser);
        }
    }

    private void LoadData(string PhoneNo)
    {
        if (PhoneNo.Length == 11)
        {
            string strSQL = "Select * from Shop_Address where UserNo='" + PhoneNo + "' order by LTime desc";
            if (OP_Mode.SQLRUN(strSQL))
            {
                string strTempHtml = string.Empty;
                for (int i = 0; i < OP_Mode.Dtv.Count; i++)
                {
                    strTempHtml += "<div class=\"well\">";
                    strTempHtml += "    <h5>" + OP_Mode.Dtv[i]["Contacts"].ToString() + "<br />";
                    strTempHtml += "    " + OP_Mode.Dtv[i]["ContactsTel"].ToString() + "<br />";
                    strTempHtml += "    " + OP_Mode.Dtv[i]["AddressInfo"].ToString() + "</h5>";
                    strTempHtml += "    <p class=\"btn-group pull-right\">";
                    strTempHtml += "    <a href=\"/Shop/AddressNew.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm\" runat=\"server\"><i class=\"icon-edit\"></i>&nbsp;编辑</a>";
                    strTempHtml += "    <a href=\"/Shop/AddressNew.aspx?ID=" + OP_Mode.Dtv[i]["ID"].ToString() + "&Del=" + OP_Mode.Dtv[i]["ID"].ToString() + "\" class=\"btn btn-sm btn-danger\" runat=\"server\"><i class=\"icon-trash\"></i>&nbsp;删除</a>";
                    strTempHtml += "    </p>&nbsp;</div>";
                }
                if (strTempHtml.Length > 0)
                {
                    Div_Address.InnerHtml = strTempHtml;
                }
            }
        }
    }
}