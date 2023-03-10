using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dance_Default3 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AttendClass();
    }

    private void AttendClass()
    {
        try
        {
            int iid = Convert.ToInt32(Request["ID"]);
            int iUserID = Convert.ToInt32(Request.Cookies["Dance"]["USERID"]);
            //int iUserID = 2;
            if (iid > 0)
            {

                string strSQL = "insert into Dance_ClassList(Userid,ClassTime,ClassName,ClassTeacher,AdminUserID) ";
                strSQL += " Select dance_user.id,getdate(),ClassName,ClassTeacher," + iUserID + " from Dance_Arrange,Dance_Class,dance_user where classid=Dance_Class.ID and userid=dance_user.id and Dance_Arrange.ID=" + iid;
                strSQL += " Delete from Dance_Arrange where  ArrangeTime < DATEADD(dd,-1,getdate()) or ID=" + iid;  // 删除过期预约
                if (OP_Mode.SQLRUN(strSQL))
                {
                    MessageBox("", "消课成功。", "/Dance/Manage.aspx");
                    return;
                }
                else
                {
                    MessageBox("", "消课失败，参数错误。<br>请重试。错误：" + OP_Mode.strErrMsg);
                    return;
                }
            }
            else
            {
                MessageBox("", "消课失败，参数错误。<br>请重试。", "/Dance/Manage.aspx");
                return;
            }
        }
        catch
        {
            MessageBox("", "消课失败，参数错误。<br>请重试。", "/Dance/Manage.aspx");
            return;
        }
    }
}