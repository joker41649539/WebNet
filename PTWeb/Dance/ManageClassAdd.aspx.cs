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

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_Next_Click(object sender, EventArgs e)
    {
        string strSQL = string.Empty;

        double db_School, Db_PX;
        string db_KCMC, db_RKLS, db_sksj, db_xksj, db_Week = string.Empty;
        db_School = Convert.ToInt32(TextBox_School.Text.Replace("'", ""));
        Db_PX = Convert.ToInt32(TextBox2.Text.Replace("'", ""));
        db_KCMC = TextBox3.Text.Replace("'", "");
        db_RKLS = TextBox4.Text.Replace("'", "");
        db_sksj = TextBox5.Text.Replace("'", "");
        db_xksj = TextBox6.Text.Replace("'", "");

        if (Db_PX == 1)
        {
            db_Week = "一";
        }
        else if (Db_PX == 2)
        {
            db_Week = "二";
        }
        if (Db_PX == 3)
        {
            db_Week = "三";
        }
        if (Db_PX == 4)
        {
            db_Week = "四";
        }
        if (Db_PX == 5)
        {
            db_Week = "五";
        }
        if (Db_PX == 6)
        {
            db_Week = "六";
        }
        if (Db_PX == 7)
        {
            db_Week = "日";
        }

        if (db_KCMC.Length <= 0 || db_RKLS.Length <= 0 || db_sksj.Length <= 0 || db_xksj.Length <= 0)
        {
            MessageBox("", "所有内容都必须按规定填写。");
            return;
        }

        strSQL = "Insert into Dance_Class (School,PX,ClassName,ClassTeacher,ClassTimeStart,ClassTimeEnd,ClassWeek,MaxMen,Flag) ";
        strSQL += " values (" + db_School + "," + Db_PX + ",'" + db_KCMC + "','" + db_RKLS + "','" + db_xksj + "','" + db_xksj + "','" + db_Week + "',10,0)";

        if (OP_Mode.SQLRUN(strSQL))
        {
            MessageBox("", "课程添加成功。", "/Dance/ManageClass.aspx");
            return;
        }
        else
        {
            MessageBox("", "课程添加失败。<br>错误：" + OP_Mode.strErrMsg);
            return;
        }

    }
}