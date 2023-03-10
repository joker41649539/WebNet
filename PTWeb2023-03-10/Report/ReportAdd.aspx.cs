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
        if (!IsPostBack)
        {
            ChangShowDiv();
            if (Label_Flag.Text == "待提交")
            {
                Label_CName.Text = UserNAME;
            }
        }
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
                strMSG += strmsg[ifile].ToString() + ",";
            }
        }
        MessageBox("", "[" + strMSG + "]");

    }
    private void ChangShowDiv()
    {
        Div_AddXCKC.Visible = false;
        Div_FALZ.Visible = false;
        Div_ZJCYQK.Visible = false;
        Div_JFYS.Visible = false;
        Div_GAYS.Visible = false;
        Div_CJHY.Visible = false;
        Div_CJXX.Visible = false;
        Div_TBQK.Visible = false;
        Div_Other.Visible = false;
        if (DropDownList1.SelectedValue == "现场勘察")
        {
            Div_AddXCKC.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "方案论证")
        {
            Div_FALZ.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "质检查验")
        {
            Div_ZJCYQK.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "甲方验收")
        {
            Div_JFYS.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "公安验收")
        {
            Div_GAYS.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "参加会议")
        {
            Div_CJHY.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "参加学习")
        {
            Div_CJXX.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "投标情况")
        {
            Div_TBQK.Visible = true;
        }
        else if (DropDownList1.SelectedValue == "其他")
        {
            Div_Other.Visible = true;
        }
    }

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangShowDiv();
    }
}