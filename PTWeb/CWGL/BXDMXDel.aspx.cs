using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CWGL_BXDMXDel : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DelBXMXData(Request["ID"].ToString(), Convert.ToInt32(Request["MXID"]));
        }
    }

    /// <summary>
    /// 依据ID删除报销明细数据
    /// </summary>
    /// <param name="ID">w_bxd2 ID</param>

    private void DelBXMXData(string ID, int MXID)
    {
        // 删除语句需要判断是否是本人操作。
        string strSQL = string.Empty;
        strSQL += " DECLARE @Cont INT ";

        strSQL += " Select @Cont = count(W_BXD1.ID) from W_BXD1,W_BXD2 where W_BXD1.BXDH=W_BXD2.BXDH and W_BXD2.ID=" + MXID + " and UserName='" + UserNAME + "' ";

        strSQL += " if @Cont>0 ";
        strSQL += " BEGIN ";
        strSQL += "  Delete From W_BXD2 where ID=" + MXID;
        strSQL += " Select 0,ID from W_BXD1 where BXDH='" + ID + "'";
        strSQL += " End";
        strSQL += " Else";
        strSQL += " BEGIN ";
        strSQL += " Select 1,ID from W_BXD1 where BXDH='" + ID + "'";
        strSQL += " End";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv[0][0].ToString() == "0")
            {
                MessageBox("", "删除成功~", "/CWGL/ReimbursementAdd.ASPX?ID=" + OP_Mode.Dtv[0]["ID"].ToString());
            }
            else
            {
                MessageBox("", "删除失败，您不能删除别人的明细~", "/CWGL/ReimbursementAdd.ASPX?ID=" + OP_Mode.Dtv[0]["ID"].ToString());
            }
        }
    }
}