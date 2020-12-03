using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CWGL_Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDefaultData();
        }
    }

    /// <summary>
    /// 加载基础数据
    /// </summary>

    private void LoadDefaultData()
    {
        TextBoxSTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
        Label_CName.Text = UserNAME;
    }
    /// <summary>
    ///  
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "0")
        {
            LabelRadioText.InnerText = "施工编号：";
        }
        else if (RadioButtonList1.SelectedValue == "1")
        {
            LabelRadioText.InnerText = "事由：";
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            LabelRadioText.InnerText = "事由：";
        }
    }
    /// <summary>
    /// 添加图片显示
    /// </summary>
    private void AddImagesShow(String strURL)
    {
        UpdateImages.InnerHtml += "<img src=\"" + strURL + "\" style =\"height:40px;\" />";

        WellList.InnerHtml += "";
        WellList.InnerHtml += " <div class=\"well\">";
        WellList.InnerHtml += "   <h4 class=\"green smaller lighter\">交通费及补助</h4>";
        WellList.InnerHtml += "    2020-12-03 40 元 ";
        WellList.InnerHtml += " </div>";

    }


protected void LinkButton3_Click(object sender, EventArgs e)
    {///上传图片，并且显示出来
        String imageName = UploadTP(FileUpload1);
        string newpath = "/BxImages/" + imageName;
        AddImagesShow(newpath);
    }

    private string UploadTP(FileUpload fileName)
    {
        string name = fileName.PostedFile.FileName;//获取文件名称

        if (name.Length > 0)
        {
            if (fileName.HasFile)
            {
                int i = fileName.PostedFile.ContentLength;   //得到上传文件大小

                int index = name.LastIndexOf(".");

                string lastName = name.Substring(index, name.Length - index);//文件后缀

                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff") + lastName;//新文件名
                                                                                       //  string newname = "12345" + lastName;
                string path = Server.MapPath("~/BxImages/" + newname);

                string URLpath = Server.MapPath("\\BxImages\\" + newname);

                if (System.IO.File.Exists(URLpath))
                {
                    return string.Empty;
                }
                else
                {
                    try
                    {
                        if (i < 1048576)
                        {
                            fileName.PostedFile.SaveAs(path);//保存到服务器上	 小于1M的图片不进行压缩处理
                        }
                        else
                        { /// 大于1M的图片文件压缩后上传
                            ystp(fileName.PostedFile, "~/BxImages/" + newname);
                        }

                        //string imageName = "BX" + newname;
                        //string newpath = Server.MapPath(@"/BxImages/" + imageName);

                        return newname;
                    }
                    catch (Exception ex)
                    {
                        MessageBox("", "服务器正忙，请稍后再试！" + ex.ToString());
                        return string.Empty;
                    }

                }

            }
        }
        return string.Empty;
    }
    /// <summary>
    /// 压缩图片
    /// </summary>
    /// <param name="filePath">要压缩的图片的路径</param>
    /// <param name="filePath_ystp">压缩后的图片的路径</param>
    public void ystp(HttpPostedFile uploadFile, string newFileFullName)
    {
        //Bitmap
        Bitmap bmp = null;

        //ImageCoderInfo 
        ImageCodecInfo ici = null;

        //Encoder
        Encoder ecd = null;

        //EncoderParameter
        EncoderParameter ept = null;

        //EncoderParameters
        EncoderParameters eptS = null;

        try
        {
            bmp = new Bitmap(uploadFile.InputStream);

            ici = this.getImageCoderInfo("image/jpeg");

            ecd = Encoder.Quality;

            eptS = new EncoderParameters(1);

            ept = new EncoderParameter(ecd, 20L);

            eptS.Param[0] = ept;

            bmp.Save(@Server.MapPath(newFileFullName), ici, eptS);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            bmp.Dispose();

            ept.Dispose();

            eptS.Dispose();
        }
    }
    /// <summary>
    /// 获取图片编码类型信息
    /// </summary>
    /// <param name="coderType">编码类型</param>
    /// <returns>ImageCodecInfo</returns>
    private ImageCodecInfo getImageCoderInfo(string coderType)
    {
        ImageCodecInfo[] iciS = ImageCodecInfo.GetImageEncoders();

        ImageCodecInfo retIci = null;

        foreach (ImageCodecInfo ici in iciS)
        {
            if (ici.MimeType.Equals(coderType))
                retIci = ici;
        }

        return retIci;
    }
}