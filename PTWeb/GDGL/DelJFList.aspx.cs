using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GDGL_DelJFList : PageBase
{
    public string strSQL = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        strSQL = "Select W_GCGD_FS_DelList.id,GCMC,AZWZ,SBMC,DelMan,W_GCGD_FS_DelList.FS,Operator,W_GCGD_FS_DelList.CTime from W_GCGD_FS_DelList,W_GCGD2,W_GCGD1 where GCMXID=W_GCGD2.ID and W_GCGD1.GCDH=W_GCGD2.GCDH order by W_GCGD_FS_DelList.CTime desc";
        
        if (OP_Mode.SQLRUN(strSQL))
        {
            if (OP_Mode.Dtv.Count > 0)
            {
                GridView1.DataSource = OP_Mode.Dtv;
                GridView1.DataBind();
            }
        }
    }
}