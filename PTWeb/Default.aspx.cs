﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : PageBase
{
    public string strSQL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadQX();
           // LoadMyJF();
            LoadGCNum();
        }
    }

    /// <summary>
    /// 依据权限加载菜单
    /// </summary>
    private void LoadQX()
    {
        if (!QXBool(35, Convert.ToInt32(DefaultUser)))
        {/// 判断工程维系单权限
            DivGCWXD.Visible = false;
        }
        else
        {
            DivGCWXD.Visible = true;
        }

    }

    /// <summary>
    /// 加载工程数量
    /// </summary>
    private void LoadGCNum()
    {
        string strSQL = "Select (Select count(*) BXCOUNT from (SELECT isnull(count(GCDID), 0) temp FROM S_YH_QXZ, W_GCGD_USERS WHERE QXZID = 3 AND USERID = " + DefaultUser + " AND W_GCGD_USERS.USERS = USERID group by GCDID) a) BXCOUNT,(Select count(*) BXCOUNT from (SELECT isnull(count(GCDID), 0) temp FROM S_YH_QXZ, W_GCGD_USERS WHERE QXZID = 4 AND USERID = " + DefaultUser + " AND W_GCGD_USERS.USERS = USERID group by GCDID) a) AZCOUNT";
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                Label_MyBXNum.Text = OP_Mode.Dtv[0]["BXCOUNT"].ToString();
                Label_MyAZNum.Text = OP_Mode.Dtv[0]["AZCOUNT"].ToString();
            }
        }
    }
    private void LoadMyJF()
    {
        //string strSQL = "SELECT isnull(SUM(W_GCGD_FS.AZFS*W_GCGD2.AZFS/100),0)+isnull(SUM(W_GCGD_FS.FS*W_GCGD2.FS/100),0) SumFZ FROM W_GCGD_FS,W_GCGD2,W_GCGD1 WHERE GCMXID=W_GCGD2.ID AND USERID=" + DefaultUser + " AND W_GCGD1.GCDH=W_GCGD2.GCDH ";
        //strSQL += " AND W_GCGD_FS.LTIME>'" + System.DateTime.Now.ToString("yyyy-MM") + "-01'";
        //if (OP_Mode.SQLRUN(strSQL))
        //{
        //    if (OP_Mode.Dtv.Count > 0)
        //    {
        //        Label_MyJF.Text= OP_Mode.Dtv[0]["SumFZ"].ToString();
        //    }
        //}
    }

}