using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_ReportAdd : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton_Next_Click(object sender, EventArgs e)
    {
        System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
        System.Text.StringBuilder strmsg = new System.Text.StringBuilder("");

        string strMSG = string.Empty;
        int ifile;
        for (ifile = 0; ifile < files.Count; ifile++)
        {
            //MessageBox("", files.Count.ToString());
            if (files[ifile].FileName.Length > 0)
            {
                //System.Web.HttpPostedFile postedfile = files[ifile];
                //if (postedfile.ContentLength / 1024 > 1024)//单个文件不能大于1024k
                //{
                //    strmsg.Append(Path.GetFileName(postedfile.FileName) + "---不能大于1024k<br>");
                //    break;
                //}
                //string fex = Path.GetExtension(postedfile.FileName);
                //if (fex != ".jpg" && fex != ".JPG" && fex != ".gif" && fex != ".GIF")
                //{
                //    strmsg.Append(Path.GetFileName(postedfile.FileName) + "---图片格式不对，只能是jpg或gif<br>");
                //    break;
                //}
                strMSG += files[ifile].FileName.ToString() + ",";
            }
        }
        MessageBox("", "[" + strMSG + "]");

    }
    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}