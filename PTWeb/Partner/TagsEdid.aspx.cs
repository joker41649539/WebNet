using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Partner_TagsEdid : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!QXBool(52, Convert.ToInt32(DefaultUser)))
        {
            MessageBox("", "您没有查看协同人员的权限。", Defaut_QX_URL);
            return;
        }
        else
        {
            if (!IsPostBack)
            {
                EditData();
            }
        }
    }

    /// <summary>
    /// 数据操作
    /// </summary>
    private void EditData()
    {
        int UserID = 0, TagID = 0;
        string Edits = string.Empty, strSQL = String.Empty, strRetunURL = String.Empty;
        try
        {
            UserID = Convert.ToInt32(Request["UserID"]);
            TagID = Convert.ToInt32(Request["TagID"]);
            Edits = Request["Edit"];
            strRetunURL = "/Partner/PartnerInfo.aspx?ID=" + UserID; // 消息提示后返回的页面
            switch (Edits)
            {
                case "Add":
                    // 添加用户标签
                    strSQL = "Insert into W_Tag_User (TagID,UserID,TagAddName) values (" + TagID + "," + UserID + ",'" + UserNAME + "')";
                    break;
                case "Del":
                    strSQL = "Delete from W_Tag_User where TagID=" + TagID + " and UserID=" + UserID;
                    break;
                case "DelTag":
                    strSQL = "Delete from W_Tags where ID=" + TagID;// 删除标签
                    strSQL += " Delete from W_Tag_User where TagID=" + TagID; // 同时删除所有用户的该标签
                    strRetunURL = "/Partner/Tags.aspx";
                    break;
            }
            if (strSQL.Length > 0)
            {
                if (OP_Mode.SQLRUN(strSQL))
                {

                    MessageBox("", "用户标签操作成功。", strRetunURL);
                }
            }
        }
        catch
        {

        }
    }
}