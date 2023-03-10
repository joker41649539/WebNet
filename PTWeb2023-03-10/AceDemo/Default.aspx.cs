using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //string strSQL = " insert into w_wzkck (ckid,wzbh,shdh,nian,yue) values(1,'qwe','2121',2016,4) ";
        ////strSQL += " insert into w_wzkck (ckid,wzbh,shdh) values(1,'qwe','2121') ";
        //if (OP_Mode.SQLRUN(strSQL))
        //{

        //}
        //else
        //{
        //    MessageBox("", OP_Mode.strErrMsg);
        //}
    }
}